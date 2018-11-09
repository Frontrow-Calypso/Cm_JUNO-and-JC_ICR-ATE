using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace JC_ICR
{
    public partial class QR_Scanner : Form
    {
        Form1 Main;
        public QR_Scanner(Form1 parent)
        {
            InitializeComponent();
            Main = parent;

            textBox1.Select();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // check for value 
            if (textBox1.Text == " ")
            {
                // show dialog for bad value
                MessageBox.Show("You must enter a serial number to continue." +
                        "\n您必须输入一个序列号，以继续",
                         "Serial Number",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation,
                         MessageBoxDefaultButton.Button1);


                // set focus on textbox
                textBox1.Select();

            }
            else
            {
                // populate mainform box and hide
                textBox1.Text = textBox1.Text;
                Hide();
            }

        }


      
        


    }

}

   
    

