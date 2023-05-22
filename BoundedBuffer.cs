using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_CS_GUI
{
    internal class BoundedBuffer
    {
        private const int bufferSize = 20;
        private string[] textBuffer;
        private BufferStatus[] dataStatus;
        private int writerPos;
        private int readerPos;
        private int modifyPos;
        private object lockObj;
        private int readerCount = 0;


        public BoundedBuffer()
        {
            textBuffer = new string[bufferSize];
            dataStatus = new BufferStatus[bufferSize];

            writerPos = 0;
            readerPos = 0;
            modifyPos = 0;

            lockObj = new object();
        }

        public void Write(string data)
        {
            lock (lockObj)
            {
                while (dataStatus[writerPos] != BufferStatus.Empty)
                {
                    Monitor.Wait(lockObj);
                }
                textBuffer[writerPos] = data;
                dataStatus[writerPos] = BufferStatus.Empty;

                writerPos = (writerPos + 1) % textBuffer.Length;

                Monitor.PulseAll(lockObj);
            }
        }

        public string Read(out bool lastReader)
        {
            string data = string.Empty;
            lastReader = false;

            lock (lockObj)  //same as Monitor Enter
            {
                readerCount++;

                //Condition Sych - if the readerPos is not full (no data)
                //block (go to sleep inside the monitor)
                while (dataStatus[readerPos] != BufferStatus.New)
                    Monitor.Wait(lockObj);

                //read data and mark the position
                data = textBuffer[readerPos];

                readerCount--;

                Console.WriteLine($"{Thread.CurrentThread.Name:10} :{data}! at pos [{readerPos}]");

                if (readerCount == 0)
                {
                    dataStatus[readerPos] = BufferStatus.Empty;
                    readerPos = (readerPos + 1) % textBuffer.Length;
                    lastReader = true;
                }

                Monitor.PulseAll(lockObj);
            }
            return data;
        }
        private bool lastReader = false;
        public bool IsLastReader { get => lastReader; }

        public string ReadToModify()
        {
            string data = string.Empty;

            lock (lockObj)
            {
                while (dataStatus[modifyPos] != BufferStatus.Empty && !IsFinished)
                {
                    Monitor.Wait(lockObj);
                }

                if (dataStatus[modifyPos] == BufferStatus.New)
                {
                    data = textBuffer[modifyPos];
                    dataStatus[modifyPos] = BufferStatus.Checked;
                }
                else if (IsFinished)
                {
                    data = null; // No more strings to modify
                }

                modifyPos = (modifyPos + 1) % textBuffer.Length;

                Monitor.PulseAll(lockObj);
            }

            return data;
        }
        public void WriteModified(string modifiedData)
        {
            lock (lockObj)
            {
                while (dataStatus[writerPos] != BufferStatus.Empty)
                {
                    Monitor.Wait(lockObj);
                }

                textBuffer[writerPos] = modifiedData;
                dataStatus[writerPos] = BufferStatus.New;

                writerPos = (writerPos + 1) % textBuffer.Length;

                Monitor.PulseAll(lockObj);
            }
        }

        //the isFinished boolean variable is set to true from the
        //reader thread object when all data is read.
        bool isFinished = false;

        public bool IsFinished
        {
            get => isFinished;
            set => isFinished = value;
        }
    }


}

