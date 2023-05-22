using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_CS_GUI
{
    internal class Writer
    {
        private List<string> sourceList; //text from a file 
        private BoundedBuffer buffer;
        public Writer(BoundedBuffer buffer, List<string>dataToWrite) 
        {
            this.buffer = buffer;
            this.sourceList = dataToWrite;
        }

        public void RunWrite()
        {
            foreach (string str in sourceList) 
            {
                buffer.Write(str);
                Thread.Sleep(50);
            }
        }
    }
}
