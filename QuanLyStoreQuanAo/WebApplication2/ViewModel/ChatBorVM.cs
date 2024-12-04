using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModel
{
    public class ChatBorVM
    {
       public List<string> lstSuggestion {  get; set; }
        public List<LichSuChat> lstLichSuChat { get; set; }
    }
}