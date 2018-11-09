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
    /// Defines a DAQ component that performs finite input data acquisition
    /// operations.
    /// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    [ToolboxItem(false)]
    [TemplateData("Read1DBool", MxbFile="Digital_In.mxb")]
    partial class Digital_InComponent : FiniteInputDaqComponent<DigitalMultiChannelReader, bool[]>
    {
        private static readonly object EventReadCompleted = new object();

        /// <summary>
        /// Initializes a new instance of the component.
        /// </summary>
        public Digital_InComponent()
        {
            Initialize();
        }
        
        /// <summary>
        /// Initializes a new instance of the component with the specified container.
        /// </summary>
        public Digital_InComponent(IContainer container)
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
            return new Digital_In();
        }

        /// <summary>
        /// Creates the underlying DAQ reader of the component.
        /// </summary><returns>
        /// The DAQ reader that performs the input data acquisition operations.
        /// </returns>
        protected override DigitalMultiChannelReader CreateReader()
        {
            return new DigitalMultiChannelReader(Task.Stream);
        }

        /// <summary>
        /// Performs a synchronous read operation.
        /// </summary><returns>
        /// A value that contains the result of the synchronous read operation.
        /// </returns>
        protected override bool[] ReadFinite()
        {
            return Reader.ReadSingleSampleSingleLine();
        }
        
        /// <summary>
        /// Begins an asynchronous read operation.
        /// </summary><param name="callback">
        /// An asynchronous callback that is called when the read is completed.
        /// </param><param name="state">
        /// An object that distinguishes this asynchronous read request from other
        /// requests.
        /// </param>
        protected override void BeginReadFinite(AsyncCallback callback, object state)
        {
            Reader.BeginReadSingleSampleSingleLine(callback, state);
        }

        /// <summary>
        /// Ends an asynchronous read operation.
        /// </summary><param name="result">
        /// An IAsyncResult that represents an asynchronous call started by
        /// BeginReadFinite.
        /// </param>
        protected override void EndReadFinite(IAsyncResult result)
        {
            try
            {
                bool[] data = Reader.EndReadSingleSampleSingleLine(result);

                Digital_InComponentReadCompletedEventArgs args = new Digital_InComponentReadCompletedEventArgs(data);
                RaiseGenericEventAsync(result, OnReadCompleted, args);
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

        /// <summary>
        /// Raises the ReadCompleted event.
        /// </summary><param name="e">
        /// The event arguments of the ReadCompleted event.
        /// </param>
        protected virtual void OnReadCompleted(Digital_InComponentReadCompletedEventArgs e)
        {
            RaiseGenericEventDirect(EventReadCompleted, e);
        }

        /// <summary>
        /// Occurs when the asynchronous read operation that was initiated by
        /// ReadAsync has completed.
        /// </summary>
        [Category("Action")]
        [Description("Occurs when the asynchronous read operation that was initiated by ReadAsync has completed.")]
        public event EventHandler<Digital_InComponentReadCompletedEventArgs> ReadCompleted
        {
            add
            {
                AddEventHandler(EventReadCompleted, value);
            }

            remove
            {
                RemoveEventHandler(EventReadCompleted, value);
            }
        }
    }

    /// <summary>
    /// Provides data for the ReadCompleted event.
    /// </summary>
    public class Digital_InComponentReadCompletedEventArgs : ReadCompletedEventArgs<bool[]>
    {
        /// <summary>
        /// Initializes a new instance of the ReadCompleted event arguments.
        /// </summary><param name="data">
        /// The data that was acquired from an asynchronous finite input data acquisition.
        /// </param>
        public Digital_InComponentReadCompletedEventArgs(bool[] data)
            : base(data)
        {
        }
    }

    #region Timing Compatibility
    partial class Digital_InComponent
    {
        /// <summary>
        /// This member supports compatibility with code that is generated with a
        /// different timing mode and is not intended to be used directly from your code.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This member supports compatibility with code that is generated with a different timing mode and is not intended to be used directly from your code.")]
        public event EventHandler<Digital_InComponentDataReadyEventArgs> DataReady
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
    public class Digital_InComponentDataReadyEventArgs : DataReadyEventArgs<object>
    {
        /// <summary>
        /// This member supports compatibility with code that is generated with a
        /// different timing mode and is not intended to be used directly from your code.
        /// </summary>
        public Digital_InComponentDataReadyEventArgs(object data)
            : base(data)
        {
            throw new NotSupportedException("This member supports compatibility with code that is generated with a different timing mode and is not intended to be used directly from your code.");
        }
    }
    #endregion




      
    public class Digital_In : Task
    {
        public Digital_In()
        {
            Configure();
        }
        
        public virtual void Configure()
        {
            // This code was generated by Measurement Studio.  Changes to this 
            // file may cause incorrect behavior and will be lost if the code 
            // is regenerated.
            
                DIChannel ch = DIChannels.CreateChannel("Dev1/port1/line3", "DigitalIn", ChannelLineGrouping.OneChannelForEachLine);
                

        }
    }


}
