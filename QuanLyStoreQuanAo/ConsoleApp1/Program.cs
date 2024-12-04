using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;

using DTO;
class Chatbot
{
    QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();
    // Kịch bản mẫu
    static List<string> scriptQuestions = context.DonHangs.Select(x => x.ToString()).ToList();

    static List<string> scriptAnswers = new List<string>
    {
        "Bạn có thể chọn sản phẩm tại đây: [link sản phẩm]",
        "Bạn có thể liên hệ bộ phận hỗ trợ tại: support@example.com",
        "Cửa hàng mở cửa từ 8h sáng đến 8h tối."
    };

    static void Main(string[] args)
    {

        Console.WriteLine("Chatbot: Xin chào! Bạn cần giúp đỡ gì?");

        while (true)
        {
            Console.Write("Bạn: ");
            string userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput)) break;

            string response = GetResponse(userInput);
            Console.WriteLine($"Chatbot: {response}");
        }
    }

    // Hàm trả lời
    static string GetResponse(string userInput)
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

    // Tính TF-IDF vector cho một câu
    static MathNet.Numerics.LinearAlgebra.Vector<double> ComputeTFIDFVector(string sentence, List<string> corpus)
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
}
