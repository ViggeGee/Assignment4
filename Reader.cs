using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_CS_GUI
{
    internal class Reader
    {
        private List<string> targetList; //text to a new file

        private BoundedBuffer buffer;
        private int numOfStringsToRead;
        RichTextBox textBox;
        public Reader(BoundedBuffer buffer, List<string> targetList, int numOfStringsToRead, RichTextBox textBox) 
        {
            this.textBox = textBox;
            this.buffer = buffer;
            this.targetList = targetList;
            this.numOfStringsToRead = numOfStringsToRead;
        }

        public void RunRead()
        {
            bool runRead = true;
            while (runRead)
            {
                for (int i = 0; i < numOfStringsToRead; i++)
                {
                    string str = buffer.Read();

                    textBox.Invoke(new Action(() =>
                    {
                        textBox.Text += " "+str;
                    }));

                    Thread.Sleep(50);
                }
            }
        }
    }
}
