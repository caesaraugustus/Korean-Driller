using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace HowToStudyKorean
{
    public class word
    {
        public string english { get; set; }
        public string korean { get; set; }
        public string category { get; set; }
        public string korean_ending { get; set; }

        public string have_helper()
        {
            if (korean_ending == "1")
                return "가";
            else
                return "이";
        }

        public string be_helper()
        {
            if (korean_ending == "1")
                return "는";
            else
                return "은";
        }
    }
}
