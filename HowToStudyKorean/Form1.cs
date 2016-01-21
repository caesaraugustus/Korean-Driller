using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace HowToStudyKorean
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Menu strip item click functions change the current drill selection.
        // See definition of drill_selection in global.cs for valid values.
        // Begin menu strip item click functions.
        private void iAmAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global.drill_selection = 1;
        }

        private void iHaveAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global.drill_selection = 2;
        }

        private void iAmInatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global.drill_selection = 3;
        }

        private void objectLocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global.drill_selection = 4;
        }
        // End menu strip item click functions.

        // Generate the next sentence.
        // Will catch and print helpful text if no drill language was selected or
        // no drill sentence selection has been made.
        private void button1_Click(object sender, EventArgs e)
        {
            // Make sure a drill language has been selected by checking if all radio buttons are clear.
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                label1.Text = "Choose a language using the radio buttons above.";
                label2.Text = "Then select a drill sentence using the menu at the top.";
                label2.Visible = true;
                return;
            }

            // Setting global and local variables to start building the sentence.
            global.english_sentence = " ";
            global.korean_sentence = " ";
            word tmp = null;
            // Hide label2 since this is the translated answer value.
            label2.Visible = false;
            switch(global.drill_selection)
            {
                //No selection has been made (0 is default value)
                case 0:
                    label1.Text = "No drill selection made!";
                    break;

                //"I am a ____"
                case 1:
                    tmp = global.my_words.get_word("title");
                    global.english_sentence = "I am a " + tmp.english;
                    global.korean_sentence = "나는 " + tmp.korean + " 이다";
                    write_screen();
                    break;

                //"I have a ____"
                case 2:
                    tmp = global.my_words.get_word("object");
                    global.subject_picker("title", "have");
                    global.english_sentence += " a " + tmp.english;
                    global.korean_sentence += " " + tmp.korean + tmp.have_helper() + " 있다";
                    write_screen();
                    break;

                //"I am in/at ____"
                case 3:
                    tmp = global.my_words.get_word("location");
                    global.subject_picker("title", "be");
                    global.english_sentence += " at the " + tmp.english;
                    global.korean_sentence += " " + tmp.korean + "에 있다";
                    write_screen();
                    break;

                //Object Locations
                case 4:
                    tmp = global.my_words.get_word("object");
                    word tmp2 = global.my_words.get_word("object");
                    global.english_sentence = "The " + tmp.english + " is ";
                    global.korean_sentence = tmp.korean + tmp.be_helper() + " " + tmp2.korean + " ";
                    global.location_picker();
                    global.english_sentence += " the " + tmp2.english;
                    global.korean_sentence += " 있다";
                    write_screen();
                    break;
            }
        }

        // write_screen() function
        // Arguments:
        // none
        // Actions:
        // Prints the current sentences to the labels.
        // Should be called AFTER the sentences have been built.
        private void write_screen()
        {
            if (radioButton1.Checked)
            {
                label1.Text = global.english_sentence;
                label2.Text = global.korean_sentence;
            }
            else if (radioButton2.Checked)
            {
                label1.Text = global.korean_sentence;
                label2.Text = global.english_sentence;
            }
            else
                label1.Text = "Oops! I made a mistake.";
        }

        // Show the translated answer text.
        private void button2_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        // Select "Korean" sentence generation.
        // Clear the current sentence and hide the answer text.
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Visible = false;
        }

        // Select "English" sentence generation.
        // Clear the current sentence and hide the answer text.
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Visible = false;
        }
    }
}
