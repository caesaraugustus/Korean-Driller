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
    // Class "word"
    // A word for use generating sentences.
    public class word
    {
        // The word in English
        public string english { get; set; }
        // The word in Korean
        public string korean { get; set; }
        // The word's category
        // Valid values:
        // "title"
        // "object"
        // "location"
        // "blank"
        public string category { get; set; }
        // Indicates if the Korean word ends in a vowel or a consonant.
        // For use in Korean sentence conjugation.
        // "1" = vowel
        // "0" = consonant
        public string korean_ending { get; set; }

        // Returns Korean word based on the value of korean_ending.
        // For use when the verb being conjugated is "have"
        public string have_helper()
        {
            if (korean_ending == "1")
                return "가";
            else
                return "이";
        }

        // Returns Korean word based on the value of korean_ending.
        // For use when the verb being conjugated is "be"
        public string be_helper()
        {
            if (korean_ending == "1")
                return "는";
            else
                return "은";
        }
    }
}
