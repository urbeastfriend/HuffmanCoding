using System;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
namespace HuffmanCoding
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();    

        }

        HuffmanTree huffmanTree = new HuffmanTree();
        BitArray encoded;

        private void btnEncode_Click(object sender, EventArgs e)
        {
            var EncodedTextJ = new List<byte>(txtBoxSource.TextLength);
            string input = txtBoxSource.Text;
            double countencoded;
            double countnotencoded;
            huffmanTree.Build(input);
            encoded = huffmanTree.Encode(input);

            foreach (bool bit in encoded)
            {
                txtBoxResult.Text = txtBoxResult.Text + (bit ? 1 : 0);
            }
            for (int i = 0; i < txtBoxSource.TextLength; i++)
            {
                EncodedTextJ.AddRange(BitConverter.GetBytes(txtBoxSource.Text[i]));
            }
            countencoded = txtBoxResult.TextLength / 8;
            countnotencoded = EncodedTextJ.ToArray().Length;
            MessageBox.Show("Коэффициент сжатия = " + ((double)countnotencoded / (double)countencoded));
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            string decoded = huffmanTree.Decode(encoded);
            txtBoxResult.Text = "Decoded: " + decoded;
        }
    }
}
