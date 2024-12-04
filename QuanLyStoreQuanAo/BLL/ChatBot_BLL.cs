using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class ChatBot_BLL
    {
        ChatBot_DAL dal = new ChatBot_DAL();
        QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();
        public ChatBot_BLL() { 
        }
        public string getResponse(string userInput)
        {
            userInput = userInput.Trim();
            string response = dal.GetResponse(userInput);
            return response;
        }
        public List<LichSuChat> getALLHistoryChatByUserID(string userID)
        {
            return dal.getALLHistoryChatByUserID(userID);

        }
        public bool insertHistoryChat(LichSuChat x)
        {
            var lastID = context.LichSuChats
                     .OrderByDescending(n => n.MaChat)
                     .Select(n => n.MaChat)
                     .FirstOrDefault();

            var newID =lastID + 1;
            x.MaChat = newID;
            x.ThoiGianGui=DateTime.Now;
            return dal.insertHistoryChat(x);
        }
        public List<string> GetSuggestedQuestions(string userInput)
        {
            return dal.GetSuggestedQuestions(userInput);
        }


    }
}
