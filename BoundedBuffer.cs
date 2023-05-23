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
        int currentWriter;
        int completedWriters;
        private const int bufferSize = 20;
        private string[] textBuffer;
        private BufferStatus[] dataStatus;
        private int writerPos;
        private int readerPos;
        private int modiferPos;
        private object lockObj;
        private int readerCount = 0;
        ListBox listBox;
        RichTextBox textBox;

        public BoundedBuffer(ListBox listBox, RichTextBox textBox)
        {
            this.textBox = textBox;
            this.listBox = listBox;

            textBuffer = new string[bufferSize];
            
            dataStatus = new BufferStatus[bufferSize];
            currentWriter = 0;
            completedWriters = 0;
            writerPos = 0;
            readerPos = 0;
            modiferPos = 0;

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


                dataStatus[writerPos] = BufferStatus.New;
                writerPos = (writerPos + 1) % bufferSize;
                Monitor.PulseAll(lockObj);
            }
        }


        public string Read()
        {
            string data = string.Empty;


            lock (lockObj)  //same as Monitor Enter
            {
                while (dataStatus[readerPos] != BufferStatus.Checked)
                {
                    Monitor.Wait(lockObj);
                }

                //read data and mark the position
                data = textBuffer[readerPos];
                dataStatus[readerPos] = BufferStatus.Empty;
                readerPos = (readerPos + 3) % bufferSize;
                listBox.Invoke(new Action(() =>
                {
                    listBox.Items.Add("Reader has read " + data + ", position" + readerPos);
                }));

                Monitor.PulseAll(lockObj);
            return data;
            }
        }
        private bool lastReader = false;
        public bool IsLastReader { get => lastReader; }

        public int Modify(string find, string replace)
        {
            //data = string.
            lock (lockObj)
            {
                while (dataStatus[modiferPos] != BufferStatus.New)
                {
                    Monitor.Wait(lockObj);
                }
                textBuffer[modiferPos] = textBuffer[modiferPos].Replace(find, replace);

                dataStatus[modiferPos] = BufferStatus.Checked;
                modiferPos = (modiferPos + 1) % bufferSize;

                listBox.Invoke(new Action(() => { listBox.Items.Add("modifier  on buffer pos " + modiferPos); }));

                Monitor.PulseAll(lockObj);
                return modiferPos;
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

