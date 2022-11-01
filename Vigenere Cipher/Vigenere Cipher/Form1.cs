using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vigenere_Cipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //lakaty Encryption supporty space nakat chunka ema charekterakanman ba char nasandua
        //Yakam jar function bo encryption drustakayn 
        public void vigenereEncrypt(ref StringBuilder s,string key)
        {
            for(int i = 0; i < s.Length; i++) s[i]= char.ToUpper(s[i]);
            key= key.ToUpper();
            int j = 0;
            for(int i=0;i<s.Length; i++)
            {
                if (char.IsLetter(s[i]))////indecates whether the s[i] is catagorized as a unicode letter
                {
                    s[i] = (char)(s[i] + key[j] - 'A');
                    if (s[i] > 'Z') s[i] = (char)(s[i] - 'Z' + 'A' - 1);
                }
                j=j+1==key.Length ? 0 : j+1;
            }
            
        }
        //function bo Decryption drust akayn
        public void vigenereDecrypt(ref StringBuilder s, string key)
        {
            for (int i = 0; i < s.Length; i++) s[i] = char.ToUpper(s[i]);
            key=key.ToUpper();
            int j = 0;
            for(int i=0; i<s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    s[i] = s[i] >= key[j] ?
                              (char)(s[i] - key[j] + 'A'):
                              (char)('A' + ('Z' - key[j] + s[i] - 'A') + 1);
                }
                j=j+1==key.Length? 0 : j+1;
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder(textBox1.Text);
            string key = textBox2.Text;
            vigenereEncrypt(ref s, key);
            textBox3.Text = Convert.ToString(s);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder(textBox4.Text);
            string key = textBox5.Text;
            vigenereDecrypt(ref s, key);
            textBox6.Text = Convert.ToString(s);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
