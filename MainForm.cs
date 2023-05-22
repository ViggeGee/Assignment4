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
            sourceStrings= new List <String> ();
            targetStrings= new List <String> ();
            CreateThreads();
            foreach (Thread thread in readers)
                thread.Start();
            foreach (Thread thread in writers)
                thread.Start();
            foreach (Thread thread in modifiers)
                thread.Start();

            InitializeComponent();
            InitializeGUI();
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
            BoundedBuffer buffer = new BoundedBuffer();
            writer = new Writer(buffer, sourceStrings);
            reader = new Reader(buffer, targetStrings, sourceStrings.Count);
            modifier = new Modifier(buffer);

            writers.Add(writerThread = new Thread(writer.RunWrite));
            writers.Add(writerThread = new Thread(writer.RunWrite));
            writers.Add(writerThread = new Thread(writer.RunWrite));

            readers.Add(readerThread = new Thread(reader.RunRead));

            modifiers.Add(modifierThread = new Thread(modifier.RunModify));
            modifiers.Add(modifierThread = new Thread(modifier.RunModify));
            modifiers.Add(modifierThread = new Thread(modifier.RunModify));
            modifiers.Add(modifierThread = new Thread(modifier.RunModify));

           
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
            

            string[] lines = rtxtSource.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string modifiedText = string.Join(Environment.NewLine, lines.Select(line => line.Replace(findWord, replaceWord)));
            rtxtDest.Text = modifiedText;
        }

        private void rtxtSource_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtxtDest_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
