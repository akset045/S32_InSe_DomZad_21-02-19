using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomZad_21_02_19
{
    public partial class Form1 : Form
    {
        CaesarCipher C1;
        public Form1()
        {
            InitializeComponent();
            C1 = new CaesarCipher();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            int secretKey1 = 29;
            int secretKey2 = 7;
            int secretKey3 = 14;

            string text1 = "Делу время - потехе час";
            string text2 = "С Новым годом";
            string text3 = "Первое сентября";

            var encryptedText1 = C1.Encrypt(text1, secretKey1);
            var encryptedText2 = C1.Encrypt(text2, secretKey1);
            var encryptedText3 = C1.Encrypt(text3, secretKey1);

            var encryptedText4 = C1.Encrypt(text1, secretKey2);
            var encryptedText5 = C1.Encrypt(text2, secretKey2);
            var encryptedText6 = C1.Encrypt(text3, secretKey2);

            var encryptedText7 = C1.Encrypt(text1, secretKey3);
            var encryptedText8 = C1.Encrypt(text2, secretKey3);
            var encryptedText9 = C1.Encrypt(text3, secretKey3);

            label1.Text = (encryptedText1);
            label2.Text = (encryptedText2);
            label3.Text = (encryptedText3);
            label4.Text = (encryptedText4);
            label5.Text = (encryptedText5);
            label6.Text = (encryptedText6);
            label7.Text = (encryptedText7);
            label8.Text = (encryptedText8);
            label9.Text = (encryptedText9);
        }
        public class CaesarCipher
        {
            const string ABC = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            private string CodeEncode(string text, int k)
            {
                var fullABC = ABC + ABC.ToLower();
                var letterQty = fullABC.Length;
                var retVal = "";
                for (int i = 0; i < text.Length; i++)
                {
                    var c = text[i];
                    var index = fullABC.IndexOf(c);
                    if (index < 0)
                    {
                        retVal += c.ToString();
                    }
                    else
                    {
                        var codeIndex = (letterQty + index + k) % letterQty;
                        retVal += fullABC[codeIndex];
                    }
                }
                return retVal;
            }
            public string Encrypt(string plainMessage, int key) => CodeEncode(plainMessage, key);
            public string Decrypt(string encryptedMessage, int key) => CodeEncode(encryptedMessage, -key);
        }
    }
}
