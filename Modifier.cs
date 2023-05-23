using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_CS_GUI
{
    internal class Modifier
    {
        private BoundedBuffer buffer;
        private string wordToReplace;
        private string newWord;
        public string find, replace;
        bool runReader;
        int numOfStringsToRead;
        ListBox textBox;
        public Modifier(BoundedBuffer buffer, int numOfStringsToRead, ListBox textBox)
        {
            
            this.buffer = buffer;
            this.numOfStringsToRead= numOfStringsToRead;
        }

        public void Modify()
        {
            runReader = true;
            while (runReader)
            {
                for (int i = 0; i < numOfStringsToRead; i++)
                {
                    int pos = buffer.Modify(find, replace);
                    //textBox.Invoke(new Action(() => { textBox.Items.Add("modifier  on buffer pos " + pos); }));

                }
            }

        }
    }
}

