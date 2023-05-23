using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

namespace Assignment4_CS_GUI
{
    public partial class MainForm : Form
    {
        string findWord;
        string replaceWord;

        Thread writerThread;
        Thread readerThread;
        Thread modifierThread;
        List <Thread> writers = new List <Thread> ();
        List <Thread> readers = new List <Thread> ();
        List <Thread> modifiers = new List <Thread> ();
        List<String> sourceStrings;
        List<String> targetStrings;
        Modifier modifier;
        Writer writer;
        Reader reader;

        private FileManager fileMngr = new FileManager();

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();

            sourceStrings= new List <String> ();
            targetStrings= new List <String> ();
            

            

        }

        private void InitializeGUI()
        {
            toolTip1.SetToolTip(txtFind, "Select a text from the source and copy here!");
            toolTip1.SetToolTip(txtReplace, "Select a text to replace the above with!");
            toolTip1.SetToolTip(rtxtSource, "You can also write or change the text here manually!");
        }
       
        List<string> lines;
        private void readDataFromTextFile(string fileName)
        {
            rtxtSource.Clear();
            lstStatus.Items.Clear();
            string errorMsg = string.Empty;
            lines = fileMngr.ReadFromTextFile(fileName, out errorMsg);
            //lblSource.Text = fileName;
            if (lines != null)
            {
                foreach (string line in lines)
                {
                    rtxtSource.AppendText(line + "\n");
                }
                lstStatus.Items.Add("Lines read from the file: " + lines.Count);
                 
            }
            else
                MessageBox.Show(errorMsg);

            BoundedBuffer buffer = new BoundedBuffer(lstStatus, rtxtDest);
            writer = new Writer(buffer, lines);
            reader = new Reader(buffer, targetStrings, lines.Count, rtxtDest);
            modifier = new Modifier(buffer, lines.Count, lstStatus);
            
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Load a textfile, select the find and replacement texts and then click me!");
        }

        private void btnLoadFile_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open file for reading as txt!";

            openFileDialog1.Filter = "Text files |*.txt| All files |*.*";
            openFileDialog1.FilterIndex = 0;

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;  //important
                readDataFromTextFile(fileName);
            }

            
        }

        public void CreateThreads()
        {
            

            writers.Add(new Thread(writer.RunWrite));
            writers.Add(new Thread(writer.RunWrite));
            writers.Add(new Thread(writer.RunWrite));

            readers.Add(new Thread(reader.RunRead));

            modifier.find = findWord;
            modifier.replace = replaceWord; 

            modifiers.Add(new Thread(modifier.Modify));
            modifiers.Add(new Thread(modifier.Modify));
            modifiers.Add(new Thread(modifier.Modify));
            modifiers.Add(new Thread(modifier.Modify));

            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
             findWord = txtFind.Text;
        }

        private void txtReplace_TextChanged(object sender, EventArgs e)
        {
             replaceWord = txtReplace.Text; 
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            CreateThreads();
            
            foreach (Thread thread in writers)
            {
                thread.Name = "Writer";
                thread.Start();
            }
            foreach (Thread thread in readers)
            {
                thread.Name = "Reader";
                thread.Start();
            }
            foreach (Thread thread in modifiers)
            {
                thread.Name = "modifier";
                thread.Start();
            }
        }

        private void rtxtSource_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtxtDest_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void lstStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }

}
