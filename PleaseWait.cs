using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace JC_ICR
{
    public partial class PleaseWait : Form
    {
        Form1 Main;
        public PleaseWait(Form1 parent)
        {
            InitializeComponent();
            Main = parent;
            //Timer();
        }


         private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       /* Timer formCloser = new Timer();
        private void PleaseWait_Load(object sender, EventArgs e)
        {
            formCloser.Interval = 120000;
            formCloser.Enabled = true;
            formCloser.Tick += new EventHandler(formClose_Tick);
        }

        private void formClose_Tick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }*/

       

        
    }
}



        /*public PleaseWait()
        {
            InitializeComponent();
        }*/

        
       /* private void Timer()
        {
            this.timer1.Start();
        }*/

         /*private void button1_Click(object sender, EventArgs e)
         {
             int counter = 0;

             int rowMax = 175000;
             int colMax = 1000;

             decimal pcdDone;


             for (int r = 0; r < rowMax; r++)
             {
                 for (int c = 0; c < colMax; c++)
                 {
                     counter++;
                 }


                 pcdDone = (decimal)counter / (rowMax * colMax);

                 groupBox1.Text = ((int)(pcdDone * 100)).ToString() + "%";
                 groupBox1.Refresh();

                 label1.Width = Convert.ToInt32(pcdDone * (groupBox1.Width - 10));
             }

             this.Close();

         }

       /* private void PleaseWait_Load(object sender, EventArgs e)
        {
            
        }*/

    