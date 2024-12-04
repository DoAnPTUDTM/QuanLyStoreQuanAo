using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace DAL
{
   public class ChatBot_DAL
    {
         List<string> scriptQuestions = new List<string>();
         List<string> scriptAnswers=new List<string>();
        QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();
        public ChatBot_DAL() {
           
            // Kịch bản mẫu
           scriptQuestions = context.FAQs.Select(x => x.Question).ToList();

           scriptAnswers = context.FAQs.Select(x => x.Answer).ToList();
        }
        public List<LichSuChat> getALLHistoryChatByUserID(string userID)
        {
            var chatHis= context.LichSuChats.Where(n=>n.MaKhachHang==userID).OrderBy(n=>n.ThoiGianGui).ToList();
            return chatHis; 
        }
        public bool insertHistoryChat(LichSuChat x)
        {
            var r = context.LichSuChats.Where(n => n.MaChat == x.MaChat).FirstOrDefault();
            if(r!=null)
            {
                return false;
            }
            else
            {
                try
                {
                    context.LichSuChats.InsertOnSubmit(x);
                    context.SubmitChanges();
                    return false;
                }
                catch
                {
                    return false;
                }
            }

        }
        public string GetResponse(string userInput)
        {
            // Biểu diễn TF-IDF
            var tfidfVectors = scriptQuestions.Select(q => ComputeTFIDFVector(q, scriptQuestions)).ToList();
            var userVector = ComputeTFIDFVector(userInput, scriptQuestions);

            // Tính toán độ tương đồng Cosine
            double maxSimilarity = 0;
            int bestMatchIndex = -1;

            for (int i = 0; i < tfidfVectors.Count; i++)
            {
                double similarity = CosineSimilarity(tfidfVectors[i], userVector);
                if (similarity > maxSimilarity)
                {
                    maxSimilarity = similarity;
                    bestMatchIndex = i;
                }
            }

            // Trả về câu trả lời phù hợp hoặc thông báo không hiểu
            return maxSimilarity > 0.5 ? scriptAnswers[bestMatchIndex] : "Xin lỗi, tôi chưa hiểu ý bạn. Vui lòng thử lại.";
        }
         MathNet.Numerics.LinearAlgebra.Vector<double> ComputeTFIDFVector(string sentence, List<string> corpus)
        {
            var words = sentence.ToLower().Split(' ');
            var uniqueWords = corpus.SelectMany(s => s.ToLower().Split(' ')).Distinct().ToList();

            var tfidf = uniqueWords.Select(word =>
            {
                double tf = words.Count(w => w == word) / (double)words.Length;
                double idf = Math.Log(corpus.Count / (1.0 + corpus.Count(s => s.ToLower().Contains(word))));
                return tf * idf;
            });

            return MathNet.Numerics.LinearAlgebra.Vector<double>.Build.DenseOfEnumerable(tfidf);
        }

        // Tính độ tương đồng Cosine
        static double CosineSimilarity(MathNet.Numerics.LinearAlgebra.Vector<double> vectorA, MathNet.Numerics.LinearAlgebra.Vector<double> vectorB)
        {
            return vectorA.DotProduct(vectorB) / (vectorA.L2Norm() * vectorB.L2Norm() + 1e-10); // Tránh chia cho 0
        }
        public List<string> GetSuggestedQuestions(string userInput)
        {
            var tfidfVectors = scriptQuestions.Select(q => ComputeTFIDFVector(q, scriptQuestions)).ToList();
            var userVector = ComputeTFIDFVector(userInput, scriptQuestions);

            var similarities = new List<(int index, double similarity)>();
            for (int i = 0; i < tfidfVectors.Count; i++)
            {
                double similarity = CosineSimilarity(tfidfVectors[i], userVector);
                similarities.Add((i, similarity));
            }

            // Sắp xếp các câu hỏi theo độ tương đồng giảm dần
            var sortedSimilarities = similarities.OrderByDescending(s => s.similarity).ToList();

            // Chọn ra các câu hỏi có độ tương đồng cao
            var suggestedQuestions = sortedSimilarities
                .Where(s => s.similarity > 0.3 &&s.similarity<0.9)
                //.OrderByDescending(s=>s.similarity)// Ngưỡng tương đồng
                .Take(2)  // Giới hạn số lượng câu hỏi gợi ý
                .Select(s => scriptQuestions[s.index])
                .ToList();

            return suggestedQuestions;
        }

    }
}
