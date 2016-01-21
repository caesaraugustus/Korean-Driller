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
    // Class "word_list"
    // An array of words.
    public class word_list
    {
        [XmlElement("word")]
        public word[] words { get; set; }

        // Length function
        // Returns the length of the word list
        public int length()
        {
            return words.Length;
        }

        // get_word function
        // Arguments:
        // (string word_category) = Type of word to get. 
        // Should be a valid category for a word in "words.xml".
        // Actions:
        // Returns a word from the word list of the requested type.
        public word get_word(string word_category)
        {
            IEnumerable<word> temp = global.my_words.words.Where(word => word.category == word_category);
            return temp.ElementAt(global.r.Next(0, temp.Count()));
        }
    }
}
