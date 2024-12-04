using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
  
    public class ChatBotController : Controller
    {
       
        string makh = "KH001";
        ChatBot_BLL bll = new ChatBot_BLL();
        // GET: ChatBot
        public ActionResult Index()
        {
            List<LichSuChat> list = bll.getALLHistoryChatByUserID(makh);
            List<string> listSugesttion = bll.GetSuggestedQuestions("Xin chào");
            ChatBorVM viewModel = new ChatBorVM
            {
                lstLichSuChat = list,
                lstSuggestion = listSugesttion
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Index(string userInput)
        {
            
            if (userInput == null)
            {
                userInput = "Xin chào";
            }
            
            string response =bll.getResponse(userInput);
            LichSuChat chat = new LichSuChat();
            chat.MaKhachHang = makh;
            chat.TinNhan = userInput;
            chat.PhanHoi=response;
            bool rs =bll.insertHistoryChat(chat);
            ViewBag.Message = response;
            List<LichSuChat> list = bll.getALLHistoryChatByUserID(makh);
            if (userInput == "Xin chào")
            {
                userInput = "Sản phẩm ";
            }
            List<string>listSugesttion= bll.GetSuggestedQuestions(userInput);
            ChatBorVM viewModel = new ChatBorVM
            {
                lstLichSuChat = list,
                lstSuggestion= listSugesttion
            };
          
            return View(viewModel);
        }
    }
}