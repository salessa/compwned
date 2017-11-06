using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Numerics;
using System.IO.MemoryMappedFiles;
using System.Collections;



namespace pwned_win
{
    public partial class Form1 : Form
    {

        const int NUM_HASHES = 10;
        const long BIT_ARRAY_SIZE = 4615205609;
        const string FILE_NAME = "hibp_4615205609_10.bin";

        private MemoryMappedFile mem_mapped = null;
        MemoryMappedViewAccessor accessor = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "https://haveibeenpwned.com/Passwords";

            linkLabel.Links.Add(link);


            this.AcceptButton = this.button1;
        }

        private void textPass_TextChanged(object sender, EventArgs e)
        {
            labelResult.Text = "";
            labelResult.BackColor = this.BackColor;
            linkLabel.Visible = true;
        }


        private byte[] convert_to_unsigned(byte[] hash_bytes)
        {
            if (hash_bytes[hash_bytes.Length - 1] != 0)
            {
                byte[] temp = new byte[hash_bytes.Length + 1];
                Array.Copy(hash_bytes, temp, hash_bytes.Length);
                temp[temp.Length - 1] = 0;
                return temp;
            }

            else
            {
                return hash_bytes;
            }
        }

        private string get_sha1_string(string str_value)
        {
            byte[] byte_arr = Encoding.Default.GetBytes(str_value);

            SHA1 sha = new SHA1CryptoServiceProvider();

            byte[] hash_val = sha.ComputeHash(byte_arr);


            string hash_str = BitConverter.ToString(hash_val).Replace("-", "");

            return hash_str.ToUpper();
            

        }


        private long get_bit_index(string str_value) {

            BigInteger table_size = new BigInteger(BIT_ARRAY_SIZE);
            BigInteger index;

            byte[] byte_arr = Encoding.Default.GetBytes(str_value);

            SHA1 sha = new SHA1CryptoServiceProvider();

           byte[] hash_val = sha.ComputeHash(byte_arr);
           Array.Reverse( hash_val );

            hash_val = convert_to_unsigned(hash_val);
            

            //System.Console.WriteLine(BitConverter.ToString(hash_val).Replace("-", ""));

            BigInteger int_hash = new BigInteger(hash_val);
            //System.Console.WriteLine("Int Hash:" + int_hash.ToString());


            BigInteger.DivRem(int_hash, table_size, out index);

            //System.Console.WriteLine("Index:" + ((long)index).ToString());
            return (long)index;

        }

        private bool is_bit_set(MemoryMappedViewAccessor accessor, long offset)
        {
            byte val =  accessor.ReadByte(offset/8);

            //System.Console.WriteLine("Byte Val:\t" + val.ToString());

            UInt16 bit_index = (UInt16)(7 - offset % 8);

            bool bit = ((val >> bit_index) & 1) == 1;

            //System.Console.WriteLine("Bit Val:\t" + bit.ToString());


            return bit;

        }
        


        private void search()
        {

            //get the password as a byte array
            string pass = textPass.Text;

            if (pass == "") return;


            //map bloom filter ...
            if (mem_mapped == null)
            {
                mem_mapped =
                MemoryMappedFile.CreateFromFile(FILE_NAME, System.IO.FileMode.Open, "BLOOM");
                accessor = mem_mapped.CreateViewAccessor();
            }

            
            

            bool found = true;

            long index = get_bit_index(pass);


            found = found & is_bit_set(accessor, index);

            string password_sha1 = get_sha1_string(pass);
            //System.Console.WriteLine(password_sha1);
            for (int i = 0; i< NUM_HASHES-1; i++)
            {

                index = get_bit_index(password_sha1 + i.ToString());
                found = found & is_bit_set(accessor, index);

            }

            linkLabel.Visible = false;

            if (found)
            {
                labelResult.Text = "Oh No! \n It is highly likely this password has previously appeared in a data breach. Change it immediately! !";
                labelResult.BackColor = Color.Maroon;
            }
            else
            {
                labelResult.Text = "Good news — not found in list of breached passwords!";
                labelResult.BackColor = Color.Green;
            }

            

            /*System.Console.WriteLine(BitConverter.ToString(hash_val).Replace("-",""));
            System.Console.WriteLine(table_size.ToString());
            System.Console.WriteLine(int_val.ToString());
            System.Console.WriteLine(index.ToString());*/


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData as string);
        }

        private void textPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
