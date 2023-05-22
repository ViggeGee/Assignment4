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
        public Reader(BoundedBuffer buffer, List<string> targetList, int numOfStringsToRead) 
        {
            this.buffer = buffer;
            this.targetList = targetList;
            this.numOfStringsToRead = numOfStringsToRead;
        }

        public void RunRead()
        {
            for (int i = 0; i < numOfStringsToRead; i++)
            {
                bool lastReader = false;
                string str = buffer.Read(out lastReader);

                if (buffer.IsLastReader)
                    targetList.Add(str);

                if (buffer.IsLastReader && (targetList.Count == numOfStringsToRead))
                    buffer.IsFinished = true;
                Thread.Sleep(50); //Sleep affects the execution
            }
        }
    }
}
