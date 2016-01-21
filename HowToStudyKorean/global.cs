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
    public class global
    {
        private static XmlSerializer my_deserializer = new XmlSerializer(typeof(word_list));
        private static TextReader my_reader = new StreamReader("words.xml");
        public static word_list my_words = (word_list)my_deserializer.Deserialize(my_reader);
        public static string korean_sentence = "";
        public static string english_sentence = "";
        public static int drill_selection = 0;
        public static Random r = new Random();

        public static void subject_picker(string subject, string verb)
        {
            int i = r.Next(0, 2);
            word sub = global.my_words.get_word(subject);
            switch (i)
            {
                case 0:
                    switch (verb)
                    {
                        case "be":
                            english_sentence += "I am";
                            break;
                        case "have":
                            english_sentence += "I have";
                            break;
                    }
                    korean_sentence += "나는";
                    break;
                case 1:
                    switch (verb)
                    {
                        case "be":
                            english_sentence += "This " + sub.english + " is ";
                            break;
                        case "have":
                            english_sentence += "This " + sub.english + " has ";
                            break;
                    }
                    korean_sentence += "이 " + sub.korean + " " + sub.be_helper();
                    break;
                case 2:
                    switch (verb)
                    {
                        case "be":
                            english_sentence += "That " + sub.english + " is ";
                            break;
                        case "have":
                            english_sentence += "That " + sub.english + " has ";
                            break;
                    }
                    korean_sentence += "그 " + sub.korean + " " + sub.be_helper();
                    break;
            }
        }

        public static string location_picker(string language)
        {
            int i = r.Next(0, 5);
            switch (i)
            {
                case 0:
                    if (language == "English")
                        return "inside";
                    else if (language == "Korean")
                        return "안에";
                    else
                        return "Oops";
                case 1:
                    if (language == "English")
                        return "on top of";
                    else if (language == "Korean")
                        return "위에";
                    else
                        return "Oops";
                case 2:
                    if (language == "English")
                        return "below";
                    else if (language == "Korean")
                        return "밑에";
                    else
                        return "Oops";
                case 3:
                    if (language == "English")
                        return "beside";
                    else if (language == "Korean")
                        return "옆에";
                    else
                        return "Oops";
                case 4:
                    if (language == "English")
                        return "behind";
                    else if (language == "Korean")
                        return "뒤에";
                    else
                        return "Oops";
                case 5:
                    if (language == "English")
                        return "in front of";
                    else if (language == "Korean")
                        return "앞에";
                    else
                        return "Oops";
            }
            return "Oops";
        }
    }
}
