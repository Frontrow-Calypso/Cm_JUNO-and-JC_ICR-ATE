//------------------------------------------------------------------------------
// <autogenerated>
//    This code was generated by Measurement Studio.
//    Runtime Version: 15.0.0.49153
//
//    Changes to this file may cause incorrect behavior and will be lost if
//    the code is regenerated.
// <autogenerated>
//------------------------------------------------------------------------------

using NationalInstruments;
using NationalInstruments.DAQmx;
using NationalInstruments.DAQmx.ComponentModel;
using System;
using System.ComponentModel;
using System.Threading;


namespace JC_ICR
{
    /// <summary>
    /// Defines a DAQ component that performs finite output data acquisition
    /// operations.
    /// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    [ToolboxItem(false)]
    [TemplateData("WriteWfmStartWaitStop", MxbFile="AudioOut_0.mxb")]
    partial class AudioOut_0Component : FiniteOutputDaqComponent<AnalogMultiChannelWriter, AnalogWaveform<double>[]>
    {
        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromMilliseconds(10000);
        
        /// <summary>
        /// Initializes a new instance of the component.
        /// </summary>
        public AudioOut_0Component()
        {
            Initialize();
        }
        
        /// <summary>
        /// Initializes a new instance of the component with the specified container.
        /// </summary>
        public AudioOut_0Component(IContainer container)
            : this()
        {
            if (container != null)
                container.Add(this);
        }
        
        /// <summary>
        /// Creates the underlying DAQ task of the component.
        /// </summary><returns>
        /// A DAQ task that represents the DAQ task of the component.
        /// </returns>
        protected override Task CreateTask()
        {
            AudioOut_0 newTask = new AudioOut_0();
            newTask.Stream.Timeout = Convert.ToInt32(DefaultTimeout.TotalMilliseconds);
            return newTask;
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long NumberOfChannelsToWrite
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Creates the underlying DAQ writer of the component.
        /// </summary><returns>
        /// The DAQ writer that performs the output data acquisition operations.
        /// </returns>
        protected override AnalogMultiChannelWriter CreateWriter()
        {
            return new AnalogMultiChannelWriter(Task.Stream);
        }

        /// <summary>
        /// Gets the number of samples to write in the output data acquisition.
        /// </summary><value>
        /// A value that indicates the number of samples to write in the write
        /// operation.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NumberOfSamplesToWrite
        {
            get
            {
                return 100;
            }
        }

        /// <summary>
        /// Performs a synchronous write operation.
        /// </summary><param name="data">
        /// The data to write to the DAQ task.
        /// </param>
        protected override void WriteFinite(AnalogWaveform<double>[] data)
        {
            Writer.WriteWaveform(false, data);
        }

        /// <summary>
        /// Begins an asynchronous write operation.
        /// </summary><param name="data">
        /// The data to write to the DAQ task.
        /// </param><param name="callback">
        /// An asynchronous callback that is called when the write is completed.
        /// </param><param name="state">
        /// An object that distinguishes this asynchronous write request from other
        /// requests.
        /// </param>
        protected override void BeginWriteFinite(AnalogWaveform<double>[] data, AsyncCallback callback, object state)
        {
            Writer.BeginWriteWaveform(false, data, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous write operation.
        /// </summary><param name="result">
        /// An IAsyncResult that represents an asynchronous call started by
        /// BeginWriteFinite.
        /// </param>
        protected override void EndWriteFinite(IAsyncResult result)
        {
            try
            {
                Writer.EndWrite(result);
            }

            #region Debugger Exception Warnings
            catch (DaqException ex)
            {
                // If you Dispose the component while an asynchronous DAQ operation
                // is still running, the component may already be disposed or may be in the
                // process of disposing when this method is called.  Depending on timing, this situation
                // will result in one of the three errors below.  This is expected behavior.
                //
                // DaqExceptions are processed by the caller of this method in the
                // NationalInstruments.DAQmx.ComponentModel class library.  However, by default,
                // the Visual Studio debugger intercepts these exceptions and breaks
                // the debugger when they occur.
                //
                // Because these exceptions do not represent errors, they are caught and safely discarded
                // here.
                if (ex.Error != -200088 && ex.Error != -88709 && ex.Error != -88710)
                    throw;
            }
            #endregion

        }
    }

    #region Timing Compatibility
    partial class AudioOut_0Component
    {
        /// <summary>
        /// This member supports compatibility with code that is generated with a
        /// different timing mode and is not intended to be used directly from your code.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This member supports compatibility with code that is generated with a different timing mode and is not intended to be used directly from your code.")]
        public event EventHandler<AudioOut_0ComponentGenerateDataEventArgs> GenerateData
        {
            add
            {
                throw new NotSupportedException("This member supports compatibility with code that is generated with a different timing mode and is not intended to be used directly from your code.");
            }

            remove
            {
                throw new NotSupportedException("This member supports compatibility with code that is generated with a different timing mode and is not intended to be used directly from your code.");
            }
        }
    }
    
    /// <summary>
    /// This type supports compatibility with code that is generated with a
    /// different timing mode and is not intended to be used directly from your code.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AudioOut_0ComponentGenerateDataEventArgs : GenerateDataEventArgs<object>
    {
        /// <summary>
        /// This member supports compatibility with code that is generated with a
        /// different timing mode and is not intended to be used directly from your code.
        /// </summary>
        public AudioOut_0ComponentGenerateDataEventArgs(long numberOfChannelsToWrite)
            : base(numberOfChannelsToWrite)
        {
            throw new NotSupportedException("This member supports compatibility with code that is generated with a different timing mode and is not intended to be used directly from your code.");
        }
    }
    #endregion




      
    public class AudioOut_0 : Task
    {
        public AudioOut_0()
        {
            Configure();
        }
        
        public virtual void Configure()
        {
            // This code was generated by Measurement Studio.  Changes to this 
            // file may cause incorrect behavior and will be lost if the code 
            // is regenerated.
            
                AOChannels.CreateVoltageChannel("Dev1/ao0", "VoltageOut", -10, 10, AOVoltageUnits.Volts);
                AOChannels["VoltageOut"].TerminalConfiguration = AOTerminalConfiguration.Rse;
                AOChannels.CreateVoltageChannel("Dev1/ao1", "VoltageOut_0", -10, 10, AOVoltageUnits.Volts);
                AOChannels["VoltageOut_0"].TerminalConfiguration = AOTerminalConfiguration.Rse;
                Timing.ConfigureSampleClock("", 1000, SampleClockActiveEdge.Rising, SampleQuantityMode.FiniteSamples, 100);
                Stream.WriteRegenerationMode = WriteRegenerationMode.AllowRegeneration;

        }
    }


}