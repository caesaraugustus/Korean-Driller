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
        //Read in the word list from the file "words.xml".
        private static XmlSerializer my_deserializer = new XmlSerializer(typeof(word_list));
        private static TextReader my_reader = new StreamReader("words.xml");
        // List of all vocabulary words stored in "words.xml". 
        // word_list type is an array of type <word>.
        public static word_list my_words = (word_list)my_deserializer.Deserialize(my_reader);
        // The sentence currently being built in Korean.
        public static string korean_sentence = "";
        // The sentence currently being built in English.
        public static string english_sentence = "";
        // The current drill selection.
        // 0 = No selection
        // 1 = "I am a ____"
        // 2 = "I have a ____"
        // 3 = "I am in/at ____"
        // 4 = Objects location drill (The ____ is [on top|in front|beside...] the ____)"
        public static int drill_selection = 0;
        // Random number generator
        public static Random r = new Random();

        // Subject helper function.
        // Arguments:
        // (string subject) = subject type. This should be a valid word category to be queried from the global word_list.
        // (string verb) = helper verb. Current valid values are "be" and "have".
        // (int min) = minimum for the random number generator. Default is 0. 
        // (int max) = maximum for the random number generator. Default is 2.
        // Actions:
        // This function will generate a subject for a sentence and append it to the sentence currently being built.
        // It will act on all languages and should only be called once.
        public static void subject_picker(string subject, string verb, int min = 0, int max = 2)
        {
            int i = r.Next(min, max);
            word sub = global.my_words.get_word(subject);
            switch (i)
            {
                // Case 0: First person "I"
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
                // Case 1: Third person "This"
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
                // Case 2: Third person "That"
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


        // Location helper function.
        // Arguments:
        // none
        // Actions:
        // This function will pick a location from [on top|in front|beside...] and
        // append it to the sentence currently being built in all languages.
        public static void location_picker()
        {
            int i = r.Next(0, 5);
            switch (i)
            {
                // Case 0: "inside"
                case 0:
                    english_sentence += "inside";
                    korean_sentence += "안에";
                    break;
                // Case 1: "on top of"
                case 1:
                    english_sentence += "on top of";
                    korean_sentence += "위에";
                    break;
                // Case 2: "below"
                case 2:
                    english_sentence += "below";
                    korean_sentence += "밑에";
                    break;
                // Case 3: "beside"
                case 3:
                    english_sentence += "beside";
                    korean_sentence += "옆에";
                    break;
                // Case 4: "behind"
                case 4:
                    english_sentence += "behind";
                    korean_sentence += "뒤에";
                    break;
                // Case 5: "in front of"
                case 5:
                    english_sentence += "in front of";
                    korean_sentence += "앞에";
                    break;
            }
        }
    }
}
