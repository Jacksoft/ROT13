/* ROT13 Cipher/Decipher by Jacksoft (c) 2019
 * This is my C# version of ROT13 Cipher/Decipher
 * Done just for fun.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROT13 {
    public partial class ROTForm : Form {
        public ROTForm() {
            InitializeComponent();
        }

        //Array of alphabet in both upper and lower case.
        string alphabetl = "abcdefghijklmnopqrstuvwxyz";
        string alphabetu = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int shiftnum = 13; //ROT value
        int alphabetlen = 26; //Number of alphabeth chars

        public string shifter(string inputtxt) {
            string outputtext = "";
            int inputtxtlength = inputtxt.Length;
            if (inputtxtlength > 0) {
                //Cycle for the entire string that select a single char at time
                for (int i = 0; i < inputtxtlength; i++) {
                    char x = inputtxt[i];
                    if (alphabetl.Contains(x) || alphabetu.Contains(x)) {
                    //Cycles that detect char number and shift it by 13.
                        for (int c = 0; c < alphabetlen; c++) {
                            //Lowercase chars
                            if (x == alphabetl[c]) {
                                int cshift = c + shiftnum;
                                //If shift becames bigger than alphabet it substract alphabet lenght, otherwise it crash.
                                if (cshift >= alphabetlen) {
                                    cshift -= alphabetlen;
                                }
                                outputtext += alphabetl[cshift];
                                break;
                            }
                            //Uppercase chars
                            if (x == alphabetu[c]) {
                                int cshift = c + shiftnum;
                                if (cshift >= alphabetlen) {
                                    cshift -= alphabetlen;
                                }
                                outputtext += alphabetu[cshift];
                                break;
                            }
                        }
                    }
                    //For ANY other character
                    else {
                        outputtext += x;
                    }
                }
            }
            return outputtext;
        }

        private void rottext() {
            textBox_output.Text = shifter(textBox_input.Text);
        }
        private void textBox_input_TextChanged(object sender, EventArgs e) {
            rottext();
        }

    }
}
