using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_CS_GUI
{
    internal class Modifier
    {
        private BoundedBuffer buffer;

        public Modifier(BoundedBuffer buffer)
        {
            this.buffer = buffer;
        }

        public void RunModify()
        {
            while (true)
            {
                string str = buffer.ReadToModify();
                if (str == null) // No more strings to modify
                    break;

                // Perform the modifications on the string
                string modifiedString = ModifyString(str);

                // Write the modified string back to the buffer
                buffer.WriteModified(modifiedString);
            }
        }

        private string ModifyString(string str)
        {
            // Perform the necessary modifications on the string
            // For example, you can use string.Replace() to replace words

            // Replace "oldWord" with "newWord"
            string modifiedString = str.Replace("oldWord", "newWord");

            return modifiedString;
        }
    }
}
