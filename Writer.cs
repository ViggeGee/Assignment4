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
        RichTextBox textBox;
        public Writer(BoundedBuffer buffer, List<string>sourceList) 
        {
            
            this.buffer = buffer;
            this.sourceList = sourceList;
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
