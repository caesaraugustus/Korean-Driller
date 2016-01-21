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
    public class word_list
    {
        [XmlElement("word")]
        public word[] words { get; set; }

        public int length()
        {
            return words.Length;
        }
        public word get_word(string word_category)
        {
            IEnumerable<word> temp = global.my_words.words.Where(word => word.category == word_category);
            return temp.ElementAt(global.r.Next(0, temp.Count()));
        }
    }
}
