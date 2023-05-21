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
        public Semaphore maxCap = new Semaphore(20, 20);
        public enum BufferStatus
        {
            Empty,
            Checked,
            New
        }
        public BufferStatus bufferStatus;
        public BoundedBuffer() 
        { 
           
        }
    }
}
