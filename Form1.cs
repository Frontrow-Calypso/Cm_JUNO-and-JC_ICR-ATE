

using NationalInstruments;
using NationalInstruments.UI;
using NationalInstruments.DAQmx;

using NationalInstruments.NetworkVariable;
using NationalInstruments.NetworkVariable.WindowsForms;
using NationalInstruments.Analysis;
using NationalInstruments.Analysis.Conversion;
using NationalInstruments.Analysis.Dsp;
using NationalInstruments.Analysis.Dsp.Filters;
using NationalInstruments.Analysis.Math;
using NationalInstruments.Analysis.Monitoring;
using NationalInstruments.Analysis.SignalGeneration;
using NationalInstruments.Tdms;
using NationalInstruments.UI.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using Mitov.SignalLab;
using Mitov.AudioLab;
using mshtml;



namespace JC_ICR
{
    public partial class Form1 : Form
    {
        int instrumentstatus = 0;

        int datax;

        WebBrowser b;
        int TestNo;
        bool testCompleted = false;

        QR_Scan form2;

        Audio form3;

        Rotate form4;

        //PleaseWait form4;

        ProgressBar form5;

        Success form6;

        Fail form7;

             
        string TestString;

        string url1 = "http://192.168.1.110/button.cgi?Event=1.htm";
        string url2 = "http://192.168.1.110/button.cgi?Event=2.htm";
        string url_Test1 = "http://192.168.1.103/cfg/testctrl.htm";
        string url3 = "http://192.168.1.110/button.cgi?Event=3.htm";
        string url4 = "http://192.168.1.110/button.cgi?Event=4.htm";
        string url5 = "http://192.168.1.110/button.cgi?Event=5.htm";

        public bool Initialize_Components = true;
        public bool SerialNumber = true;
        public bool PowerOn = true;
        public bool Program_Load = true;
        public bool JC_ICR_Functional = true;
        public bool IR = true;
        public bool Audio_Result = true;
        public bool PowerOFF_R = true;
        //public bool Reset = false;
        string output;
        string output1;
        string output2;
        string output3;
        //string out

        double average0;

        double average1;

        double average2;

        double average4;

        public Form1()
        {
            InitializeComponent();

            Serial_Number();

            
            MessageBox.Show("Please select the board type" +
                     "\n 请选择板式");


            
        }

        private void Results()
        {

            /*if (SerialNumber & PowerOn & Initialize_Components & Program_Load & Audio_Result & IR & PowerOFF_R)
            {

                Test = new Success(this);

                form6.Show();
            }

            else
            {
                form7 = new Fail(this);

                form7.Show();
            }*/
            if(radioButton2.Checked == true)
            {

                if (led1.OffColor == Color.LimeGreen && led2.OffColor == Color.LimeGreen && led3.OffColor == Color.LimeGreen && led4.OffColor == Color.LimeGreen && led5.OffColor == Color.LimeGreen && led6.OffColor == Color.LimeGreen && led7.OffColor == Color.LimeGreen && led8.OffColor == Color.LimeGreen && led9.OffColor == Color.LimeGreen  && led27.OffColor == Color.LimeGreen)
                {
                form6 = new Success(this);

                form6.Show();

                 }
                 else
                 {

                form7 = new Fail(this);

                form7.Show();
              }

            }

            if (radioButton1.Checked == true)
            {
                if (led1.OffColor == Color.LimeGreen && led2.OffColor == Color.LimeGreen && led3.OffColor == Color.LimeGreen && led4.OffColor == Color.LimeGreen && led5.OffColor == Color.LimeGreen && led7.OffColor == Color.LimeGreen && led8.OffColor == Color.LimeGreen && led9.OffColor == Color.LimeGreen && led24.OffColor == Color.LimeGreen && led27.OffColor == Color.LimeGreen)
                {
                    form6 = new Success(this);

                    form6.Show();

                }
                else
                {

                    form7 = new Fail(this);

                    form7.Show();
                }

            }

        }


        
            


        private void Serial_Number()
        {
            form2 = new QR_Scan(this);

            form2.Show();

            while (form2.Visible == true)
            {
                Application.DoEvents();

            }

            label2.Enabled = true;
            led2.OffColor = Color.Yellow;
            this.Refresh();

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                //bool SerialNumber = true;

                /*int outputValue=0;
                bool isNumber=false;
                isNumber=int.TryParse(textBox1.Text, out outputValue); */
                //if (SerialNumber == true)
                //{
                    label2.Enabled = true;
                    led2.OffColor = Color.Red;
                    Thread.Sleep(1000);
                    this.Refresh();
                }

                else
                {
                    SerialNumber = false;
                    label2.Enabled = true;
                    led2.OffColor = Color.LimeGreen;
                    Thread.Sleep(1000);
                    this.Refresh();

                }
            }
        
    
    
            /*if (.Visible == true)
            {
                label2.Enabled = true;
                led2.OffColor = Color.Green;
                this.Refresh();
            }
            else
            {
                label2.Enabled = true;
                led2.OffColor = Color.Red;
                this.Refresh();
            }*/

            
        

        //PowerStage
          private void Power_Up()
          {
              label8.Enabled = true;
              led8.OffColor = Color.Black;
              this.Refresh();



              label3.Enabled = true;
              led3.OffColor = Color.Yellow;
              Thread.Sleep(1000);

              this.Refresh();

              b = new WebBrowser();

              b.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(b_DocumentCompleted);

              b.Navigate(url1);

              // ProcessStartInfo sInfo = new ProcessStartInfo("http://192.168.1.110/button.cgi?Event=1.htm");
              // Process.Start(sInfo);

              // if (url1.StartsWith("http://192.168.1.110/button.cgi?Event=1.htm"))
              //{
              // bool PowerON = true;
              AI();
              AI_1();
              AI_2();

              if (led10.OffColor == Color.LimeGreen && led11.OffColor == Color.LimeGreen )
              {
                                  
                      label3.Enabled = true;
                      led3.OffColor = Color.LimeGreen;
                      Thread.Sleep(1000);

                      this.Refresh();
                  }

                  else
                  {
                      label3.Enabled = true;
                      led3.OffColor = Color.Red;
                      Thread.Sleep(1000);

                      this.Refresh();
                  }
              
          }
        //}
            

            /*if (b_DocumentCompleted.)
            { 
                label3.Enabled = true;
                led2.OffColor = Color.LimeGreen;
                Thread.Sleep(1000);
                this.Refresh();
            }

            else
            {
                label3.Enabled = true;
                led2.OffColor = Color.Red;
                this.Refresh();
            }*/

          /*/ private void b_Document(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                label3.Enabled = true;
                led2.OffColor = Color.LimeGreen;
                Thread.Sleep(1000);
                this.Refresh();
    
                }*/


        //Programming the DUT using MPLAB and MCLOADER
        private void Programming()
        {
            button1.Enabled = false;

            button2.Enabled = false;

            if (radioButton2.Checked == true)
            {
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
                MessageBox.Show("Make sure PICKit3 is connected" +
                    "/n 确保PICKit3连接");
                var processInfo = new ProcessStartInfo(@"C:\\Users\\vaka\\Desktop\\JC_ICR.bat");

                processInfo.CreateNoWindow = true;

                processInfo.UseShellExecute = false;

                //processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;


                //MessageBox.Show("Programming Device. Please wait for 2 mins" +
                //         "\n 编程设备。请等待2分钟");

                var process = Process.Start(processInfo);
                //timer1_Tick(3000);

                MessageBox.Show("Programming Device" +
                            "\n 编程设备");

                MessageBox.Show("Please wait for 2 mins" +
                            "\n 请等待2分钟");

                form5 = new ProgressBar(this);

                form5.Show();

                while (form5.Visible == true)
                {
                  Application.DoEvents();

                //Form1.ShowDialog();

                 }

                //form4.Hide();


                //if (!process.WaitForExit(10000))
                //{
                // MessageBox.Show("No PICkit 3 Connected" +
                //   "\n 请连接PIC KIT 3");
                //}

                output = process.StandardOutput.ReadToEnd();
                form5.Dispose();
                process.WaitForExit();

                //MessageBox.Show(output);

                if (output.StartsWith("No PICkit 3 Connected"))
                {
                    MessageBox.Show("No PICkit 3 Connected" +
                         "\n 请连接PIC KIT 3");
                }


                if (output.Contains("PK3Err0045:"))
                {
                    MessageBox.Show("Please connect a Target Device" +
                            "\n 请连接目标设备");
                }




                label4.Enabled = true;
                led4.OffColor = Color.Yellow;
                Thread.Sleep(1000);
                this.Refresh();




                //process.WaitForExit();



                Thread.Sleep(500);

                if (output.Contains("Programming/Verify complete"))
                {

                    

                    MessageBox.Show("Programming/Verify complete" +
                            "\n 编程/验证完成");

                    //MessageBox.Show("编程/验证完成");
                    ProcessStartInfo psi = new ProcessStartInfo("java.exe", " -jar  \"C:\\Users\\vaka\\Desktop\\MCLoader_v1.0b4\\MCLoader_v1.0b4\\MCLoader.jar\" ");
                    psi.WorkingDirectory = "C:\\Users\\vaka\\Desktop\\MCLoader_v1.0b4\\MCLoader_v1.0b4\\"; // Do not miss this line. The app will show no icon and no images/labels

                    string a = "-v";
                    string args = string.Format("-jar MCLoader.jar {0}", a);
                    psi.Arguments = args;
                    psi.CreateNoWindow = true;
                    psi.UseShellExecute = false;
                    psi.RedirectStandardOutput = true;
                    Process p = new Process();
                    p.StartInfo = psi;
                    p.Start();

                    output1 = p.StandardOutput.ReadToEnd();
                                  
                    p.WaitForExit();

                   
                    //StreamReader stream = p.StandardOutput;
                    

                    //MessageBox.Show(output1);

                    if (output1.Contains("ddd6"))
                    {
                        Program_Load = true;
                        
                        
                            //bool Programming = true;
                            label4.Enabled = true;
                            led4.OffColor = Color.LimeGreen;
                            Thread.Sleep(1000);
                            this.Refresh();
                        }
                    else
                        {
                            MessageBox.Show("Programming Fail");
                            Program_Load = false;
                            label4.Enabled = true;
                            led4.OffColor = Color.Red;
                            Thread.Sleep(1000);
                            this.Refresh();


                            form7 = new Fail(this);

                            form7.Show();

                            Thread.Sleep(3000);
                            Power_OFF();
                        }
                    }

                    else
                    {

                        MessageBox.Show("Programming Fail");
                        Program_Load = false;

                        label4.Enabled = true;
                        led4.OffColor = Color.Red;
                        Thread.Sleep(3000);
                        this.Refresh();

                        form7 = new Fail(this);
                        form7.Show();

                        Power_OFF();

                    
            }
                }

            
                if (radioButton1.Checked == true)
                {

                    pictureBox2.Visible = false;
                    pictureBox1.Visible = true;
                    

                    MessageBox.Show("Make sure PICKit3 is connected" +
                    "/n 确保PICKit3连接");
                    var processInfo = new ProcessStartInfo(@"C:\\Users\\vaka\\Desktop\\PICKIT3.bat");

                    processInfo.CreateNoWindow = true;

                    processInfo.UseShellExecute = false;

                    //processInfo.RedirectStandardError = true;
                    processInfo.RedirectStandardOutput = true;


                    //MessageBox.Show("Programming Device. Please wait for 2 mins" +
                    //         "\n 编程设备。请等待2分钟");

                    var process = Process.Start(processInfo);
                    //timer1_Tick(3000);

                    MessageBox.Show("Programming Device" +
                                "\n 编程设备");
                    MessageBox.Show("Please wait for 2 mins" +
                                     "\n 请等待2分钟");
 
                    form5 = new ProgressBar(this);

                    form5.Show();

                    while (form5.Visible == true)
                    {
                      Application.DoEvents();

                    //Form1.ShowDialog();

                     }

                    

                    output2 = process.StandardOutput.ReadToEnd();
                    form5.Dispose();
                    process.WaitForExit();




                    if (output2.StartsWith("No PICkit 3 Connected"))
                    {
                        MessageBox.Show("No PICkit 3 Connected" +
                             "\n 请连接PIC KIT 3");
                    }


                    if (output2.Contains("PK3Err0045:"))
                    {
                        MessageBox.Show("Please connect a Target Device" +
                                "\n 请连接目标设备");
                    }




                    label4.Enabled = true;
                    led4.OffColor = Color.Yellow;
                    Thread.Sleep(1000);
                    this.Refresh();




                    //process.WaitForExit();



                    Thread.Sleep(500);

                    if (output2.Contains("Programming/Verify complete"))
                    {

                        form5.Close();

                        MessageBox.Show("Programming/Verify complete" +
                                "\n 编程/验证完成");

                        //MessageBox.Show("编程/验证完成");
                        ProcessStartInfo psi = new ProcessStartInfo("java.exe", " -jar \"C:\\Users\\vaka\\Desktop\\MCLoader_v1.0a20\\MCLoader.jar\"");
                        //psi.WorkingDirectory = "C:\\Users\\vaka\\Desktop\\MCLoader_v1.0a20\\"; // Do not miss this line. The app will show no icon and no images/labels
                        psi.CreateNoWindow = true;
                        psi.UseShellExecute = false;
                        psi.RedirectStandardOutput = true;
                        Process p = new Process();
                        p.StartInfo = psi;
                        p.Start();
                        output3 = p.StandardOutput.ReadToEnd();
                        
                        p.WaitForExit();

                        //StreamReader stream = p.StandardOutput;
                        

                        //MessageBox.Show(output3);

                        if (output3.Contains("f89d"))
                        {
                            Program_Load = true;
                            label4.Enabled = true;
                            led4.OffColor = Color.LimeGreen;
                            Thread.Sleep(1000);
                            this.Refresh();
                        }

                        else
                        {
                            MessageBox.Show("Programming Fail");
                            Program_Load = false;
                            label4.Enabled = true;
                            led4.OffColor = Color.Red;
                            Thread.Sleep(1000);
                            this.Refresh();
                            form7 = new Fail(this);
                            form7.Show();

                            Thread.Sleep(3000);
                            Power_OFF();
                        }
                    }


                    else
                    {
                        MessageBox.Show("Programming Fail");
                        //Program_Load = false;
                        label4.Enabled = true;
                        led4.OffColor = Color.Red;
                        Thread.Sleep(1000);
                        this.Refresh();
                        form7 = new Fail(this);
                        form7.Show();

                        Thread.Sleep(3000);
                        Power_OFF();
                    }
                }
            }

                
      private void Stream()
        {
            WebBrowser b = new WebBrowser();


            b.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(b_DocumentCompleted);

            b.Navigate(url3);
        
        }

        private void JC_ICR_Functional_Test()
        {
            label5.Enabled = true;
            led5.OffColor = Color.Yellow;
            Thread.Sleep(1000);
            this.Refresh();
            WebBrowser b = new WebBrowser();


            // unregister first webpage handler. Create a new one
            b.DocumentCompleted -= new WebBrowserDocumentCompletedEventHandler(b_DocumentCompleted);



          for (TestNo = 1; TestNo <= 10; TestNo++)
          {

              testCompleted = false;
               

                WebPageTest(1);



                while (!testCompleted)
                {
                    Application.DoEvents();


           }
            
        }
    }

        private void IR_Test()
        {
            //IR_Read();
            label6.Enabled = true;
            led6.OffColor = Color.Yellow;
            Thread.Sleep(1000);
            this.Refresh();

            IR_Read();


            /*label6.Enabled = true;
            led6.OffColor = Color.LimeGreen;
            Thread.Sleep(1000);
            this.Refresh();*/
            if (datax >= 1330 && datax <= 4600)
            {
                //IR = true;
                label6.Enabled = true;
                led6.OffColor = Color.LimeGreen;
                Thread.Sleep(1000);
                this.Refresh();

            }
            else
            {
                //IR = false;
                label6.Enabled = true;
                led6.OffColor = Color.LimeGreen;
                Thread.Sleep(1000);
                this.Refresh();
            }

            //double IR_Sample = Convert.ToDouble(iR_ReadComponent1);

            /*if (IR_Sample >= 1431 && IR_Sample <= 4510)
            {
                label6.Enabled = true;
                led6.OffColor = Color.LimeGreen;
                Thread.Sleep(1000);
                this.Refresh();

            }
            else
            {
               // bool IR_Test = true;
                label6.Enabled = true;
                led6.OffColor = Color.Red;
                Thread.Sleep(1000);
                this.Refresh();
            }*/

        }

        private void Audio_Test()
        {

            label7.Enabled = true;
            led7.OffColor = Color.Yellow;
            this.Refresh();
            Thread.Sleep(1000);

            WebBrowser b = new WebBrowser();


            b.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(b_DocumentCompleted);

            b.Navigate(url3);

            form3 = new Audio(this);

            form3.Show();

            Thread.Sleep(1000);
            

            GPIO();

            try
            {
                NationalInstruments.AnalogWaveform<double>[] acquiredData = aI_4Component1.Read();
                waveformGraph1.PlotWaveforms(acquiredData);


               int numberOfPoints = 100;
                AnalogWaveform<double> analogWaveform1 = new AnalogWaveform<double>(numberOfPoints);
                
                double[] data ;
                //string data1;
               data = acquiredData[0].GetRawData();

       
                                
                double total = 0;

                for (int index = 0; index < data.Count(); index++)
                {

                    total = total + (Math.Abs(data[index]));


                }

                double avg = total / data.Count();

                label13.Text = avg.ToString();

                double rms = Math.Sqrt(avg);

                 label14.Text = rms.ToString();
              


               if (rms >= 0.15 && rms <= 0.5)
               {
                   Audio_Result = true;
                   label7.Enabled = true;
                   led7.OffColor = Color.LimeGreen;
                   Thread.Sleep(1000);
                   this.Refresh();
               }
               else
               {
                   Audio_Result = false;
                   label7.Enabled = true;
                   led7.OffColor = Color.Red;
                   Thread.Sleep(1000);
                   this.Refresh();
               }
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




            form3.Close();

           // DUT_ADC();

            //CM800();

           /* if (url3.StartsWith("http://192.168.1.110/button.cgi?Event=3.htm"))
            {
                
                label7.Enabled = true;
                led7.OffColor = Color.LimeGreen;
                Thread.Sleep(1000);
                this.Refresh();
            }
            else
            {
                label7.Enabled = true;
                led7.OffColor = Color.Red;
                Thread.Sleep(1000);
                this.Refresh();
            }*/

        }

        private void Audio_OFF()
        {

            WebBrowser b = new WebBrowser();


            b.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(b_DocumentCompleted);

            b.Navigate(url4);

        }



        private void WebPageTest(int Test)
        {

           WebBrowser c= new WebBrowser();

           //TestNo = Test;


            c.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(CM_Juno_Response_Handler);

           c.Navigate(url_Test1);
            /*byte[] postData = Encoding.ASCII.GetBytes("RunTest=1");
            c.Navigate(url_Test1, null, postData, null);         
            byte[] postData = Encoding.ASCII.GetBytes("RunTest=1");
            WebRequest request = WebRequest.Create(url_Test1);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(postData, 0, postData.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            CM_Juno_Response_Handler(data, 1);
            response.Close();*/

        }

        private void SetLogic()
        {
            


            try
            {
                //button3.Enabled = false;
                uint[] generatedData = new uint[daqTask1Component2.NumberOfChannelsToWrite];

                // TODO: Populate data to write.
                // throw new System.NotImplementedException("You must populate the data to write before writing the data.");
                //generatedData[0] = 10000000;

                //Thread.Sleep(1000);
                
                generatedData[0] = 00001000;



                //generatedData[0] = 10000000;
                daqTask1Component2.WriteAsync(generatedData);


                double[] controlData = NationalInstruments.DataConverter.Convert<double[]>(generatedData);
                //numericEditArray1.SetValues(controlData);
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //button3.Enabled = true;
            }
        }

        private void daqTask1Component1_WriteCompleted(object sender, NationalInstruments.DAQmx.ComponentModel.WriteCompletedEventArgs e)
        {
            //button3.Enabled = true;
        }

        private void daqTask1Component1_Error(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            //MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            daqTask1Component2.StopTask();
            //button3.Enabled = true;
        }


        private void ADC()
        {
            label32.Enabled = true;
            led27.OffColor = Color.Yellow;
            this.Refresh();

            DUT_ADC();
            //CM800();

                
        }

               
        private int initNIUSB6001()
        {
            try
            {
                //button3.Enabled = false;
                NationalInstruments.AnalogWaveform<double>[] generatedData = new NationalInstruments.AnalogWaveform<double>[audioOut_0Component1.NumberOfChannelsToWrite];
                
                // TODO: Populate data to write.
                //throw new System.NotImplementedException("You must populate the data to write before writing the data.");

                int numberOfPoints = 100;
                AnalogWaveform<double> analogWaveform = new AnalogWaveform<double>(numberOfPoints);

                for (int i = 0; i < numberOfPoints; i++)
                {
                    analogWaveform.Samples[i].Value = 0;
                }

                generatedData[0] = analogWaveform;
                generatedData[1] = analogWaveform;
                audioOut_0Component1.WriteAsync(generatedData);
                //waveformGraph7.PlotWaveforms(generatedData);
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // button3.Enabled = true;
            }

            try
            {

                // button1.Enabled = false;
                uint[] generatedData = new uint[daqTask1Component2.NumberOfChannelsToWrite];

                // TODO: Populate data to write.
                // throw new System.NotImplementedException("You must populate the data to write before writing the data.");

                daqTask1Component2.WriteAsync(generatedData);
                generatedData[0] = 0x00;


                double[] controlData = NationalInstruments.DataConverter.Convert<double[]>(generatedData);
                // numericEditArray1.SetValues(controlData);


            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //button1.Enabled = true;
                Close();
                return 1;


            }

            
            Initialize_Components = true;
            label1.Enabled = true;
            led1.OffColor = Color.LimeGreen;
            this.Refresh();


            return 0;
        }




        private void Power_OFF()
        {
            button2.Enabled = true;
            WebBrowser b = new WebBrowser();


            b.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(b_DocumentCompleted);

            b.Navigate(url2);


            led10.OffColor = Color.Black;
            led11.OffColor = Color.Black;
            //led12.OffColor = Color.Black;

            if (led10.OffColor != Color.LimeGreen && led11.OffColor != Color.LimeGreen )
            {
                label8.Enabled = true;
                led8.OffColor = Color.LimeGreen;

                Thread.Sleep(1000);
                this.Refresh();
                //ProcessStartInfo sInfo = new ProcessStartInfo("http://192.168.1.110/button.cgi?Event=2.htm");
                //Process.Start(sInfo);
            }
            else
            {
                label8.Enabled = true;
                led8.OffColor = Color.Red;

                Thread.Sleep(1000);
                this.Refresh();
            }
        }

        private void b_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser b = sender as WebBrowser;

            string response = b.DocumentText;

            Console.WriteLine(response);

            //MessageBox.Show(response);
        }

        /*private void d_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser d = sender as WebBrowser;

            string response = d.DocumentText;

            Console.WriteLine(response);
        }*/

    /*    private void CM_Juno_Response_Handler(Stream data, int testNum)
        {
            bool desiredElement = false;
            //bool success = false;
            StreamReader reader = new StreamReader(data);
             HTMLDocument doc = new HTMLDocument();
            IHTMLDocument2 htmlDoc = (IHTMLDocument2)doc;
            htmlDoc.write(reader.ReadToEnd());
            reader.Close();

            IHTMLElementCollection collection = htmlDoc.all;
            foreach (IHTMLElement elem in collection)
            {
                if (elem.tagName == "img")
                {
                    if (desiredElement)
                    {
                        if (elem.all.Contains("go.png"))
                            //success = true;
                            led25.OffColor = Color.LimeGreen;

                        break;
                    }
                }
                else if (elem.tagName == "input")
                {
                    string altStr = elem.getAttribute("alt");
                    string classStr = elem.getAttribute("class");
                    string typeStr = elem.getAttribute("type");
                    string valueStr = elem.getAttribute("value");
                    string tabindexStr = elem.getAttribute("tabindex");
                    string onclickStr = elem.getAttribute("onclick");

                    string s = elem.all;

                    Console.WriteLine(" Type = {0}, ClassStr = {1} valueStr = {2} tabindex = {3} onclick = {4}", typeStr, classStr, valueStr, tabindexStr, s);

                    TestString = "nclick=runtest(" + testNum.ToString() + ")";

                    desiredElement = s.Contains(TestString);
                }
            }
        }*/

        private void CM_Juno_Response_Handler(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            WebBrowser c = sender as WebBrowser;

            //c.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(CM_Juno_Response_Handler);

            string response = c.DocumentText;

            Console.WriteLine(response);


            HtmlElementCollection elems = c.Document.GetElementsByTagName("input");

            foreach (HtmlElement elem in elems)
            {
                string altStr = elem.GetAttribute("alt");
                string classStr = elem.GetAttribute("class");
                string typeStr = elem.GetAttribute("type");
                string valueStr = elem.GetAttribute("value");
                string tabindexStr = elem.GetAttribute("tabindex");
                string onclickStr = elem.GetAttribute("onclick");



                //if ((altStr == "BusiBtn") && (classStr == "button") && (typeStr == "submit") && (valueStr == "Search") && (tabindexStr == "16"))

                string s = null;




                if (onclickStr == "System.__ComObject")
                {
                    int iStartPos = elem.OuterHtml.IndexOf("onclick=\"") + ("onclick=\"").Length;
                    int iEndPos = elem.OuterHtml.IndexOf(";", iStartPos);
                    //get our substring
                    s = elem.OuterHtml.Substring(iStartPos, iEndPos - iStartPos);


                }


                Console.WriteLine(" Type = {0}, ClassStr = {1} valueStr = {2} tabindex = {3} onclick = {4}", typeStr, classStr, valueStr, tabindexStr, s);


                if (typeStr == "button")
                {
                    //elem.InvokeMember("click");

                    Console.WriteLine("Button found");


                    //break;
                }



                 TestString = "nclick=runtest(" + TestNo.ToString() + ")";



                if (s == TestString)
                {

                    elem.InvokeMember("click");


                    if (TestNo == 1)
                    {
                        label20.Enabled = true;
                        led13.OffColor = Color.Yellow;
                        this.Refresh();
                        //if (response.Contains("(<tr><td class=num>1</td> <td>Test Audio and ADC</td>  <td><input type=button onclick=runtest(1);value=Run></td> <td class=center><div id=Status1><img src=/images/go.png></div></td></tr> <tr><td class=num>2</td> <td>Test Rotary Switch</td> <td><input type=button onclick=runtest(2); value=Run></td> <td class=center></td></tr> <tr><td class=num>3</td> <td>Test Reset Pin</td> <td><input type=button onclick=runtest(3); value=Run></td> <td class=center></td></tr> <tr><td class=num>4</td> <td>Test General Purpose Input</td> <td><input type=button onclick=runtest(4); value=Run></td> <td class=center></td></tr> <tr><td class=num>5</td> <td>Test System Signaling Outputs</td> <td><input type=button onclick=runtest(5); value=Run></td> <td class=center></td></tr> <tr><td class=num>6</td> <td>Test Tick Counter</td> <td><input type=button onclick=runtest(6); value=Run></td> <td class=center></td></tr><tr><td class=num>7</td> <td>Test External Memory</td> <td><input type=button onclick=runtest(7); value=Run></td><td class=center> </td></tr> <tr><td class=num>8</td> <td>Test Serial UART 1</td> <td><input type=button onclick=runtest(8); value=Run></td><td class=center></td></tr> <tr><td class=num>9</td> <td>Test Serial UART 3</td> <td><input type=button onclick=runtest(9); value=Run></td><td class=center></td></tr><tr><td class=num>10</td> <td>Test Electret Mic</td> <td><input type=button onclick=runtest(10); value=Run></td><td class=center></td></tr>"))
                            //led13.OffColor = Color.LimeGreen;
                        }
                    Error();

                    if (TestNo == 2)
                    {

                        label21.Enabled = true;
                        led14.OffColor = Color.Yellow;
                        this.Refresh();

                        if (led23.OffColor == Color.LimeGreen)
                        {
                            led13.OffColor = Color.LimeGreen;
                            this.Refresh();
                        }
                        else
                        {
                            led13.OffColor = Color.Red;
                            this.Refresh();
                        }

                        MessageBox.Show("Rotate the knob to the left, right and press the dial" +
                            "\n 旋钮旋转到左边，右边和按拨盘");
                        form4 = new Rotate(this);

                        form4.Show();

                        while (form4.Visible == true)
                        {
                            Application.DoEvents();

                        }
                        
                        Thread.Sleep(100);

                    }
                    Error();

                    if (TestNo == 3)
                    {
                        label22.Enabled = true;
                        led15.OffColor = Color.Yellow;
                        this.Refresh();
                        if (led23.OffColor == Color.LimeGreen)
                        {
                            led14.OffColor = Color.LimeGreen;
                            this.Refresh();
                        }


                        else
                        {
                            led14.OffColor = Color.Red;
                            this.Refresh();
                        }
                        toggle1();
                        //Reset();
                       Thread.Sleep(1000);
                        //toggle1();
                        //Thread.Sleep(1000);
                        //toggle1();
                        //Thread.Sleep(1000);
                        //toggle1();
                        //Thread.Sleep(1000);
                        //toggle1();

                   }
                    Error();

                    initNIUSB6001();
                    SetLogic();
                    

                    if (TestNo == 4)
                    {
                                                
                        
                        label23.Enabled = true;
                        led16.OffColor = Color.Yellow;
                        this.Refresh();
                        if (led23.OffColor == Color.LimeGreen)
                        {
                            led15.OffColor = Color.LimeGreen;
                            this.Refresh();
                        }

                        else
                        {
                            led15.OffColor = Color.LimeGreen;
                            this.Refresh();
                        }

                        //SetLogic();
                        toggle1();
                        Thread.Sleep(100);
                        //toggle();
                   

                    }
                    Error();

                    if (TestNo == 5)
                    {
                        label24.Enabled = true;
                        led17.OffColor = Color.Yellow;
                        this.Refresh();

                        if (led23.OffColor == Color.LimeGreen)
                        {
                            led16.OffColor = Color.LimeGreen;
                            this.Refresh();
                        }
                        else
                        {
                            led16.OffColor = Color.LimeGreen;
                            this.Refresh();
                        }
                       
                        Thread.Sleep(100);

                    }

                    Error();
                    if (TestNo == 6)
                    {
                        label25.Enabled = true;
                        led18.OffColor = Color.Yellow;
                        this.Refresh();
                        if (led23.OffColor == Color.LimeGreen)
                        {
                            led17.OffColor = Color.LimeGreen;
                            this.Refresh();
                        }

                        else
                        {
                            led17.OffColor = Color.Red;
                            this.Refresh();
                        }

                        
                        Thread.Sleep(100);


                    }
                    Error();
                    if (TestNo == 7)
                    {
                        label26.Enabled = true;
                        led19.OffColor = Color.Yellow;
                        this.Refresh();

                        if (led23.OffColor == Color.LimeGreen)
                        {
                            led18.OffColor = Color.LimeGreen;
                            this.Refresh();
                        }
                        else
                        {
                            led18.OffColor = Color.Red;
                            this.Refresh();
                        }
                        Thread.Sleep(100);


                    }
                    Error();
                    if (TestNo == 8)
                    {
                        label27.Enabled = true;
                        led20.OffColor = Color.Yellow;
                        this.Refresh();

                        if (led23.OffColor == Color.LimeGreen)
                        {
                            led19.OffColor = Color.LimeGreen;
                            this.Refresh();
                        }
                        else
                        {
                            led19.OffColor = Color.Red;
                            this.Refresh();
                        }
                        
                        Thread.Sleep(100);


                    }

                    Error();

                    if (TestNo == 9)
                    {
                        label28.Enabled = true;
                        led21.OffColor = Color.Yellow;
                        this.Refresh();

                        if (led23.OffColor == Color.LimeGreen)
                        {
                            led20.OffColor = Color.LimeGreen;
                            this.Refresh();
                        }
                        else
                        {
                            led20.OffColor = Color.Red;
                            this.Refresh();
                        }
                        Thread.Sleep(100);


                    }
                    Error();
                    if (TestNo == 10)
                    {
                        label29.Enabled = true;
                        led22.OffColor = Color.Yellow;
                        this.Refresh();

                        if (led23.OffColor == Color.LimeGreen)
                        {
                            led21.OffColor = Color.LimeGreen;
                            this.Refresh();
                        }
                        else
                        {
                            led21.OffColor = Color.Red;
                            this.Refresh();
                        }
                        if (radioButton2.Checked == true)
                        {

                            IR_Test();
                            
                        }

                        Error();


                        if (led23.OffColor == Color.LimeGreen)
                        {
                            led22.OffColor = Color.LimeGreen;
                            this.Refresh();
                        }
                        else
                        {
                            led22.OffColor = Color.Red;
                            this.Refresh();
                        }


                        if (led13.OffColor == Color.LimeGreen && led14.OffColor == Color.LimeGreen && led15.OffColor == Color.LimeGreen && led16.OffColor == Color.LimeGreen && led17.OffColor == Color.LimeGreen && led18.OffColor == Color.LimeGreen && led19.OffColor == Color.LimeGreen && led20.OffColor == Color.LimeGreen && led21.OffColor == Color.LimeGreen && led22.OffColor == Color.LimeGreen)
                        {
                            led5.OffColor = Color.LimeGreen;
                            label5.Visible = true;
                            this.Refresh();
                        }
                        else
                        {
                            led5.OffColor = Color.Red;
                            label5.Visible = true;
                            this.Refresh();

                        }

           
                        c.DocumentCompleted -= new WebBrowserDocumentCompletedEventHandler(CM_Juno_Response_Handler);
                        //c.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(c_CaptureWave);

                        
                    }

                        // break;

                        // might have to put a delay here

                        //Thread.Sleep(2000);
                        // automate the click of the button



                        // remove old event handler and create a new one.
                        c.DocumentCompleted -= new WebBrowserDocumentCompletedEventHandler(CM_Juno_Response_Handler);

                        c.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(c_DocumentCompleted2);



                    }

                //Console.ReadLine();

                


               }

            }




        private void c_DocumentCompleted2(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            WebBrowser c = sender as WebBrowser;

            string response = c.DocumentText;

            Console.WriteLine(response);
            testCompleted = true;
        }



        

        private void toggle1()
        {

             try
             {

                 // button1.Enabled = false;
                 uint[] generatedData = new uint[daqTask1Component2.NumberOfChannelsToWrite];

                 // TODO: Populate data to write.
                 // throw new System.NotImplementedException("You must populate the data to write before writing the data.");

                 daqTask1Component2.WriteAsync(generatedData);
                 generatedData[0] ^= 0x01;


                 double[] controlData = NationalInstruments.DataConverter.Convert<double[]>(generatedData);
                 // numericEditArray1.SetValues(controlData);


             }
             catch (NationalInstruments.DAQmx.DaqException ex)
             {
                 MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 //button1.Enabled = true;
                 Close();
                 //return 1;
             }


          
        }

            
        

        private void daqTask3Component1_WriteCompleted(object sender, NationalInstruments.DAQmx.ComponentModel.WriteCompletedEventArgs e)
        {
            //button3.Enabled = true;
        }

        private void daqTask3Component1_Error(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            daqTask3Component1.StopTask();
            //button3.Enabled = true;
        }

        
            private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        

        private void Form1_Load_1(object sender, EventArgs e)
        {
            /*Serial_Number();


            Thread.Sleep(1000);


            MessageBox.Show("Please select the board type" +
                     "\n 请选择板式");*/
            //waveformGraph1.YAxes[0].Mode = AxisMode.Fixed;
        }

        private void toggle()
        {

             try
             {

                 // button1.Enabled = false;
                 uint[] generatedData = new uint[daqTask1Component2.NumberOfChannelsToWrite];

                 // TODO: Populate data to write.
                 // throw new System.NotImplementedException("You must populate the data to write before writing the data.");

                 daqTask1Component2.WriteAsync(generatedData);
                 //generatedData[0] = 00000000;
                // generatedData[0] = 00000010;

                 //generatedData[0] = 00001010;
                 //generatedData[0] |= 00001000;


                 double[] controlData = NationalInstruments.DataConverter.Convert<double[]>(generatedData);
                 // numericEditArray1.SetValues(controlData);


             }
             catch (NationalInstruments.DAQmx.DaqException ex)
             {
                 MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 //button1.Enabled = true;
                 Close();
                 //return 1;
             }

          /*  try
            {
                //button4.Enabled = false;
                bool[] generatedData = new bool[daqTask2Component1.NumberOfChannelsToWrite];

                // TODO: Populate data to write.
                //throw new System.NotImplementedException("You must populate the data to write before writing the data.");

                generatedData[0] = false;
                daqTask2Component1.WriteAsync(generatedData);
                //ledArray1.SetValues(generatedData);
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //button4.Enabled = true;
            }*/
        }
        

        private void daqTask2Component1_WriteCompleted0(object sender, NationalInstruments.DAQmx.ComponentModel.WriteCompletedEventArgs e)
        {
            //button4.Enabled = true;
        }

        private void daqTask2Component1_Error0(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            daqTask2Component1.StopTask();
            //button4.Enabled = true;
        }

        private void Reset()
        {
           /* try
            {
                //bool Reset = true;
                bool[] acquiredData = digital_InComponent1.Read();
                ledArray1.SetValues(acquiredData);

                if (acquiredData[0] == true)
                {
                    label9.Enabled = true;
                    led23.OffColor = Color.LimeGreen;

                }
                else
                {
                    label9.Enabled = true;
                    led23.OffColor = Color.Red;
                }
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private void digital_InComponent1_Error(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            digital_InComponent1.StopTask();
        }

       

        private void aI_4Component1_Error(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            aI_4Component1.StopTask();
        }

        private void IR_Read()
        {

           // label6.Enabled = true;
            //led6.OffColor = Color.Yellow;
            //Thread.Sleep(1000);
            //this.Refresh();

            try
            {

                iR_ReadComponent1.StartRead();

               /* if (datax >= 1330 && datax <= 4600)
                {
                    IR = true;
                    label6.Enabled = true;
                    led6.OffColor = Color.LimeGreen;
                    Thread.Sleep(1000);
                    this.Refresh();
                   // iR_ReadComponent1.StopRead();
                }*/
            }

            catch (NationalInstruments.DAQmx.DaqException ex)
            {


               /* IR = false;
                label6.Enabled = true;
                led6.OffColor = Color.Red;
                Thread.Sleep(1000);
                this.Refresh();*/

                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //switch1.Value = false;
            }


           

           // IR_Read();

            /*if ( datax >= 1330 && datax <= 4600)
            {
                //IR = true;
                label6.Enabled = true;
                led6.OffColor = Color.LimeGreen;
                Thread.Sleep(1000);
                this.Refresh();

            }
            else
            {
                //IR = false;
                label6.Enabled = true;
                led6.OffColor = Color.Red;
                Thread.Sleep(1000);
                this.Refresh();
            }*/
        }

        private void iR_ReadComponent1_DataReady(object sender, IR_ReadComponentDataReadyEventArgs e)
        {
            System.Threading.Monitor.Enter(iR_ReadComponent1);
            uint[] acquiredData = e.GetData();

            datax = Convert.ToInt32(acquiredData[0]);

            label19.Text = datax.ToString();

            double[] controlData = NationalInstruments.DataConverter.Convert<double[]>(acquiredData);

            //label19.Text = controlData.ToString();

             numericEditArray1.SetValues(controlData);
            System.Threading.Monitor.Exit(iR_ReadComponent1);
            //iR_ReadComponent1.StopRead();

            /*if (datax >= 1500 && datax <= 4593)
            {
                label6.Enabled = true;
                led6.OffColor = Color.LimeGreen;
                Thread.Sleep(1000);
                this.Refresh();

            }
            else
            {

                label6.Enabled = true;
                led6.OffColor = Color.Red;
                Thread.Sleep(1000);
                this.Refresh();
            }*/

            iR_ReadComponent1.StopRead();

            

                }

        private void iR_ReadComponent1_Error(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //switch1.Value = false;
        }

        private void DUT_ADC()
        {

            /*label32.Enabled = true;
            led27.OffColor = Color.Yellow;
            Thread.Sleep(1000);*/

            this.Refresh();

            b = new WebBrowser();

            b.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(b_DocumentCompleted);

            b.Navigate(url5);

            try
            {
                //button3.Enabled = false;
                NationalInstruments.AnalogWaveform<double>[] generatedData = new NationalInstruments.AnalogWaveform<double>[audioOut_0Component1.NumberOfChannelsToWrite];

                // TODO: Populate data to write.
                //throw new System.NotImplementedException("You must populate the data to write before writing the data.");
                int numberOfPoints = 100;
                AnalogWaveform<double> analogWaveform = new AnalogWaveform<double>(numberOfPoints);

                for (int i = 0; i < numberOfPoints; i++)
                {
                    analogWaveform.Samples[i].Value = 1.41;
                }

                generatedData[0] = analogWaveform;

                int numberOfPoints1 = 100;
                AnalogWaveform<double> analogWaveform1 = new AnalogWaveform<double>(numberOfPoints1);

                for (int i = 0; i < numberOfPoints; i++)
                {
                    analogWaveform1.Samples[i].Value = 0;
                }

                generatedData[1] = analogWaveform;

                //generatedData[1] = analogWaveform;
                audioOut_0Component1.WriteAsync(generatedData);
                //waveformGraph7.PlotWaveforms(generatedData);
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //button3.Enabled = true;
            }

            try
            {
                NationalInstruments.AnalogWaveform<double>[] acquiredData = cM800Component1.Read();
                waveformGraph3.PlotWaveforms(acquiredData);

                double[] datay = acquiredData[0].GetRawData();

                double averagey = datay.Average();

                double rms1 = Math.Sqrt(averagey);


                label33.Text = rms1.ToString();

                if (rms1 >= 0.35 && rms1 <= 0.56)
                {
                    led27.OffColor = Color.LimeGreen;
                    this.Refresh();

                }

                else
                {
                    led27.OffColor = Color.Red;
                    this.Refresh();

                }

            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




            
        }

           /* try
            {
                //button3.Enabled = false;
                NationalInstruments.AnalogWaveform<double>[] generatedData = new NationalInstruments.AnalogWaveform<double>[int_AOComponent1.NumberOfChannelsToWrite];

                // TODO: Populate data to write.
                //throw new System.NotImplementedException("You must populate the data to write before writing the data.");
                int numberOfPoints = 100;
                AnalogWaveform<double> analogWaveform = new AnalogWaveform<double>(numberOfPoints);

                for (int i = 0; i < numberOfPoints; i++)
                {
                    analogWaveform.Samples[i].Value = 1.41;
                }

                generatedData[0] = analogWaveform;
                //generatedData[1] = analogWaveform;

                int_AOComponent1.WriteAsync(generatedData);
                //waveformGraph1.PlotWaveforms(generatedData);
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //label11.Enabled = true;
                //led9.OffColor = Color.Red;
                //this.Refresh();

                //Close();
                //return;
                //button3.Enabled = true;
            }

            //bool Initialize_Components = true;
            //label11.Enabled = true;
            //led9.OffColor = Color.LimeGreen;
            //this.Refresh();

            //return;

        }*/


       /* private void CM800()
        {
            try
            {
                NationalInstruments.AnalogWaveform<double>[] acquiredData = cM800Component1.Read();
                waveformGraph3.PlotWaveforms(acquiredData);
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }*/

        private void cM800Component1_Error(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cM800Component1.StopTask();
        }




        private void GPIO()
        {
            try
            {
                bool[] acquiredData = dI_O1Component1.Read();
                ledArray2.SetValues(acquiredData);
                //ledArray2.Visible = false;
                label11.Enabled = true;
                led9.OffColor = Color.LimeGreen;
                this.Refresh();
                                
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label11.Enabled = true;
                led9.OffColor = Color.Red;
                this.Refresh();
            }

            
        }

        private void dI_O1Component1_Error(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dI_O1Component1.StopTask();
        }

        private void AI()
        {
            try
            {
                NationalInstruments.AnalogWaveform<double>[] acquiredData = aiComponent1.Read();
                waveformGraph4.PlotWaveforms(acquiredData);

                double[] data0 = acquiredData[0].GetRawData();
                
                
                 average0 = data0.Average();
                

                label16.Text = average0.ToString();

                  
               
               
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                average0 = 0;

                //led10.OffColor = Color.Red;
            }

            if (average0 >= 2.9 && average0 <= 3.4)
            {
                led10.OffColor = Color.LimeGreen;
                this.Refresh();
            }
            else
            {
                led10.OffColor = Color.Red;
                this.Refresh();
            }
                     
        }

        private void aiComponent1_Error(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            aiComponent1.StopTask();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            pictureBox2.Visible = false;
            pictureBox1.Visible = true;

            label6.Visible = false;
            led6.Visible = false;

            /*label9.Visible = false;
            led23.Visible = false;
            ledArray1.Visible = false;
            numericEditArray1.Visible = false;*/

            

        }




        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;

            label6.Visible = true;
            led6.Visible = true;

            /*label9.Visible = true;
            led23.Visible = true;
            ledArray1.Visible = true;
            numericEditArray1.Visible = true;*/

            label34.Visible = false;
            led24.Visible = false;
            this.Refresh();

        }

        private void AI_1()
        {
            try
            {
                NationalInstruments.AnalogWaveform<double>[] acquiredData = aI_1Component1.Read();
                waveformGraph5.PlotWaveforms(acquiredData);
                double[] data1 = acquiredData[0].GetRawData();

                 average1 = data1.Average();

                label17.Text = average1.ToString();

                

            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                average1 = 0;
                led11.OffColor = Color.Red;
            }


            if (average1 >= 4.8 && average1 <= 5.2)
            {
                led11.OffColor = Color.LimeGreen;
                this.Refresh();
            }

            else
            {
                led11.OffColor = Color.Red;
                this.Refresh();
            }
        }

        private void aI_1Component1_Error(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            aI_1Component1.StopTask();
        }

        private void AI_2()
        {
            try
            {
                NationalInstruments.AnalogWaveform<double>[] acquiredData = aI_2Component1.Read();
                waveformGraph6.PlotWaveforms(acquiredData);

                double[] data2 = acquiredData[0].GetRawData();

                average2 = data2.Average();

                //double rms2 = 

                label18.Text = average2.ToString();

                
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                average2 = 0;

                led12.OffColor = Color.Red;
            }


            if (average2 >= 1.8 && average2 <= 2.5)
            {
                led12.OffColor = Color.LimeGreen;
                this.Refresh();
            }
            else
            {
                led12.OffColor = Color.Red;
                this.Refresh();
            }
        }

        private void aI_2Component1_Error(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            aI_2Component1.StopTask();
        }

      
         
      

 //Test Data Storage based on each serial number of the DUT 

        public void TestData()
        {
            
            string filename = "c:\\JC_ICR ATE Data\\Test Data" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

        if (!File.Exists(filename))
           {
                using (StreamWriter sw = File.AppendText(filename))
                {


                    sw.WriteLine("Serial Number " +","+ "Power On 3.3V" + "," + " Power On 5V" + "," + " Current drawn in terms of Voltage" + ","
                                  +"Program_Load"  + "," + "MCLOADER"+ "," + "Functional Test" + "," + " Main Reset" + ","
                                    + "IR Value" + "," +
                                    "Audio Average" + "," + "Audio RMS" + "," + "Audio Test"
                                                                    
                                  
                                   );
                }

            }


                using (StreamWriter sw = File.AppendText(filename))
                {

                    sw.WriteLine(textBox1.Text+"," + label16.Text+ "," + label17.Text + "," +label18.Text + ","
                                             + Program_Load    + "," + "," +

                                                datax +"," +
                                                 Convert.ToString(numericEditArray1) + "," +
                                                 label13.Text + "," + label14.Text + "," + label33.Text
                                                  
                                                  
                                                  );



                }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            /*try
            {
                button3.Enabled = false;
                NationalInstruments.AnalogWaveform<double>[] generatedData = new NationalInstruments.AnalogWaveform<double>[audioOut_0Component1.NumberOfChannelsToWrite];

                // TODO: Populate data to write.
                throw new System.NotImplementedException("You must populate the data to write before writing the data.");

                audioOut_0Component1.WriteAsync(generatedData);
                waveformGraph7.PlotWaveforms(generatedData);
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button3.Enabled = true;
            }*/
        }

        private void audioOut_0Component1_WriteCompleted(object sender, NationalInstruments.DAQmx.ComponentModel.WriteCompletedEventArgs e)
        {
           // button3.Enabled = true;
        }

        private void audioOut_0Component1_Error(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            audioOut_0Component1.StopTask();
            //button3.Enabled = true;
        }

       

        private void button3_Click_2(object sender, EventArgs e)
        {
            Power_OFF();
            this.Close();

        }


        private void Set_MIC()
        {
            try
            {
                //button6.Enabled = false;
                NationalInstruments.AnalogWaveform<double>[] generatedData = new NationalInstruments.AnalogWaveform<double>[audioOut_0Component1.NumberOfChannelsToWrite];

                // TODO: Populate data to write.
                //throw new System.NotImplementedException("You must populate the data to write before writing the data.");
                int numberOfPoints = 100;
                AnalogWaveform<double> analogWaveform = new AnalogWaveform<double>(numberOfPoints);

                for (int i = 0; i < numberOfPoints; i++)
                {
                    analogWaveform.Samples[i].Value = 0;
                }

                // generatedData[0] = analogWaveform;
                generatedData[1] = analogWaveform;

                int numberOfPoints1 = 100;
                AnalogWaveform<double> analogWaveform1 = new AnalogWaveform<double>(numberOfPoints1);

                for (int i = 0; i < numberOfPoints; i++)
                {
                    analogWaveform1.Samples[i].Value = 0;
                }

                // generatedData[0] = analogWaveform;
                generatedData[0] = analogWaveform;


                // audioOut_0Component1.WriteAsync(generatedData);
                audioOut_0Component1.WriteAsync(generatedData);
                //waveformGraph8.PlotWaveforms(generatedData);
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //button6.Enabled = true;
            }

        }

        private void MIC()
        {
            label34.Enabled = true;
            led24.OffColor = Color.Yellow;
            this.Refresh();

            b = new WebBrowser();

            b.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(b_DocumentCompleted);

            b.Navigate(url5);

            try
            {
                //button6.Enabled = false;
                NationalInstruments.AnalogWaveform<double>[] generatedData = new NationalInstruments.AnalogWaveform<double>[audioOut_0Component1.NumberOfChannelsToWrite];

                // TODO: Populate data to write.
                //throw new System.NotImplementedException("You must populate the data to write before writing the data.");
                int numberOfPoints = 100;
                AnalogWaveform<double> analogWaveform = new AnalogWaveform<double>(numberOfPoints);

                for (int i = 0; i < numberOfPoints; i++)
                {
                    analogWaveform.Samples[i].Value = 0.042;
                }

                // generatedData[0] = analogWaveform;
                generatedData[1] = analogWaveform;

                int numberOfPoints1 = 100;
                AnalogWaveform<double> analogWaveform1 = new AnalogWaveform<double>(numberOfPoints1);

                for (int i = 0; i < numberOfPoints; i++)
                {
                    analogWaveform1.Samples[i].Value = 0;
                }

                // generatedData[0] = analogWaveform;
                generatedData[0] = analogWaveform;


               // audioOut_0Component1.WriteAsync(generatedData);
                audioOut_0Component1.WriteAsync(generatedData);
                //waveformGraph8.PlotWaveforms(generatedData);
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //button6.Enabled = true;
            }

            try
            {
                NationalInstruments.AnalogWaveform<double>[] acquiredData = cM800Component1.Read();
                waveformGraph3.PlotWaveforms(acquiredData);

                double[] datay = acquiredData[0].GetRawData();

                double averagey = datay.Average();

                double rms1 = Math.Sqrt(averagey);


                label35.Text = rms1.ToString();

                if (rms1 >= 0.15 && rms1 <= 0.56)
                {
                    led24.OffColor = Color.LimeGreen;
                    this.Refresh();

                }
                else
                {
                    led24.OffColor = Color.Red;
                    this.Refresh();

                }
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*try
            {
                button6.Enabled = false;
                NationalInstruments.AnalogWaveform<double>[] generatedData = new NationalInstruments.AnalogWaveform<double>[audioOut_0Component1.NumberOfChannelsToWrite];

                // TODO: Populate data to write.
               //throw new System.NotImplementedException("You must populate the data to write before writing the data.");
                int numberOfPoints = 100;
                AnalogWaveform<double> analogWaveform = new AnalogWaveform<double>(numberOfPoints);

                for (int i = 0; i < numberOfPoints; i++)
                {
                    analogWaveform.Samples[i].Value = 0.042;
                }

               // generatedData[0] = analogWaveform;
                generatedData[1] = analogWaveform;
                audioOut_0Component1.WriteAsync(generatedData);
                audioOut_0Component1.WriteAsync(generatedData);
                waveformGraph8.PlotWaveforms(generatedData);
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button6.Enabled = true;
            }*/
        }

        private void audioOut_0Component1_WriteCompleted0(object sender, NationalInstruments.DAQmx.ComponentModel.WriteCompletedEventArgs e)
        {
            //button6.Enabled = true;
        }

        private void audioOut_0Component1_Error0(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            audioOut_0Component1.StopTask();
           // button6.Enabled = true;
        }


        private void Error()
        {
            try
            {
                NationalInstruments.AnalogWaveform<double>[] acquiredData = daqTask6Component1.Read();
                waveformGraph9.PlotWaveforms(acquiredData);
                double[] data4 = acquiredData[0].GetRawData();

                average4 = data4.Average();

                label9.Text = average1.ToString();
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (average4 >=2.8 && average4 <=3.82 )
            {
                led23.OffColor = Color.LimeGreen;
                this.Refresh();
            }

            else
            {
                led23.OffColor = Color.Red;
                this.Refresh();
            }


        }
        private void button7_Click(object sender, EventArgs e)
        {
          /*  try
            {
                NationalInstruments.AnalogWaveform<double>[] acquiredData = daqTask6Component1.Read();
                waveformGraph9.PlotWaveforms(acquiredData);
            }
            catch (NationalInstruments.DAQmx.DaqException ex)
            {
                MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private void daqTask6Component1_Error(object sender, NationalInstruments.DAQmx.ComponentModel.ErrorEventArgs e)
        {
            // TODO: Handle DAQ errors.
            string message = e.Exception.Message;
            MessageBox.Show(message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            daqTask6Component1.StopTask();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Enabled = true;
            led1.OffColor = Color.Yellow;
            this.Refresh();


            instrumentstatus = initNIUSB6001();

            Thread.Sleep(1000);

           /* if (instrumentstatus == 0)
            Serial_Number();*/

           Thread.Sleep(5000);

            if (instrumentstatus == 0)
                SetLogic();

            Thread.Sleep(1000);
            if (instrumentstatus == 0)
                Power_Up();

            Thread.Sleep(3000);

            if (instrumentstatus == 0)
                Programming();

             Thread.Sleep(3000);

            if (instrumentstatus == 0)
                Stream();
            Thread.Sleep(1000);

            if (instrumentstatus == 0)
                Audio_OFF();
            Thread.Sleep(1000);

            if (instrumentstatus == 0)
                JC_ICR_Functional_Test();

            Thread.Sleep(1000);
                         
            if (instrumentstatus == 0)
                Audio_Test();
            Thread.Sleep(1000);
            // Audio_Test();


            if (instrumentstatus == 0)
                Audio_OFF();
            Thread.Sleep(1000);

            if (instrumentstatus == 0)
                GPIO();
            //ledArray2.

            Thread.Sleep(1000);

            if (instrumentstatus == 0)
                ADC();
            Thread.Sleep(3000);

            if (instrumentstatus == 0)
               Audio_OFF();
            Thread.Sleep(1000);

            if (instrumentstatus == 0)
                Set_MIC();
            Thread.Sleep(3000);

            if (instrumentstatus == 0)
                MIC();
            Thread.Sleep(1000);

            if (instrumentstatus == 0)
                Audio_OFF();
            Thread.Sleep(1000);

            if (instrumentstatus == 0)
                Power_OFF();
            Thread.Sleep(1000);

            if (instrumentstatus == 0)
                Results();
            Thread.Sleep(1000);

            if (instrumentstatus == 0)
                TestData();
            Thread.Sleep(1000);

            if (instrumentstatus == 0)
               this.SuspendLayout();
            Thread.Sleep(100);
        }


        private void suspendLayout()
        {
            if (form6.Visible == true)
            {
                this.SuspendLayout();

                button1.Enabled = false;

                button2.Enabled = true;

                button3.Enabled = true;
            }

            else if (form7.Visible == true)
            {
                this.SuspendLayout();

                button1.Enabled = false;

                button2.Enabled = true;

                button3.Enabled = true;

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please select the board type" +
                          "\n 请选择板式");

            label1.Enabled = false;
            led1.OffColor = Color.Black;
            this.Refresh();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            label1.Enabled = false;
            led1.OffColor = Color.Black;
            //this.Refresh();

            label2.Enabled = false;
            led2.OffColor = Color.Black;
            //this.Refresh();

            label3.Enabled = false;
            led3.OffColor = Color.Black;
            // this.Refresh();

            label4.Enabled = false;
            led4.OffColor = Color.Black;
            //this.Refresh();

            label5.Enabled = false;
            led5.OffColor = Color.Black;
            //this.Refresh();

            label6.Enabled = false;
            led6.OffColor = Color.Black;
            // this.Refresh();

            label7.Enabled = false;
            led7.OffColor = Color.Black;
            //this.Refresh();

            label8.Enabled = false;
            led8.OffColor = Color.Black;
            //this.Refresh();


            label11.Enabled = false;
            led9.OffColor = Color.Black;
            // this.Refresh();

            label34.Enabled = false;
            led24.OffColor = Color.Black;
            // this.Refresh();

            label20.Enabled = false;
            led13.OffColor = Color.Black;
            // this.Refresh();

            label21.Enabled = false;
            led14.OffColor = Color.Black;
            //this.Refresh();

            label22.Enabled = false;
            led15.OffColor = Color.Black;
            //this.Refresh();

            label23.Enabled = false;
            led16.OffColor = Color.Black;
            // this.Refresh();


            label24.Enabled = false;
            led17.OffColor = Color.Black;
            // this.Refresh();

            label25.Enabled = false;
            led18.OffColor = Color.Black;
            // this.Refresh();

            label26.Enabled = false;
            led19.OffColor = Color.Black;
            //this.Refresh();

            label27.Enabled = false;
            led20.OffColor = Color.Black;
            //this.Refresh();

            label28.Enabled = false;
            led21.OffColor = Color.Black;
            //this.Refresh();

            label29.Enabled = false;
            led22.OffColor = Color.Black;
            //this.Refresh();


            label32.Enabled = false;
            led27.OffColor = Color.Black;

            this.Refresh();


            average0 = 0;

            average1 = 0;

            average2 = 0;

            //toggle1();
            // toggle();

            //initNIUSB6001();

            Power_OFF();

            Serial_Number();

           
            Thread.Sleep(1000);

            //    Thread.Sleep(1000);


            MessageBox.Show("Please select the board type" +
                     "\n 请选择板式");

            label8.Enabled = false;
            led8.OffColor = Color.Black;
            this.Refresh();
        }

        

      




        
       

        
      
       

       

       

        

        

       

        
    }

}


