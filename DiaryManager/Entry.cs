using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryManager
{
    public class Entry
    {
        public string Date { get; }
        public string Content { get;}
        
        public Entry(string date,string content)
        {
            Date = date;
            Content = content;
        }
    }
}
