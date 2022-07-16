using System;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace TaskPane
{
    public partial class CustomPane : UserControl
    {
        private TextBox textBox;
        public string filename { get; set; }
        public CustomPane()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            //string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            Word.Document doc = Globals.ThisAddIn.Application.ActiveDocument;

            string fileName = doc.Name;
            string FilePath = doc.Path;
            string sFullpath_pdf = FilePath + "\\" + fileName + ".pdf";
            doc.ExportAsFixedFormat(sFullpath_pdf, Word.WdExportFormat.wdExportFormatPDF, OpenAfterExport: true);
        }

        private void CustomPane_Load(object sender, EventArgs e)
        {

            Word.Document doc = Globals.ThisAddIn.Application.ActiveDocument;
            Word.Application wordApp = new Word.Application();

            //textBox = new TextBox();
            //textBox.Text = doc.Name;

            filename = doc.Name.ToString();
            //textBox1.Text = filename;
            DocumentTitle.Text = doc.Name;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Word.Application wordApp = new Word.Application();

            object missing = System.Reflection.Missing.Value;
            object fileName = DocumentTitle.Text;
            object isReadOnly = false;
            object isVisible = true;

            Word.Document doc = wordApp.Documents.Add(ref missing, ref missing, ref missing, ref isVisible);

            doc.SaveAs2(ref fileName, ref missing, ref missing, ref missing, ref missing, ref missing, ref isReadOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            wordApp.Visible = true;

            //Word.Document doc = Globals.ThisAddIn.Application.ActiveDocument;

            //string FilePath = doc.Path;
            //var newDocumentTitle = textBox1.Text;
            //var oldDocumentTitle = doc.Name;

            //string oldFullpath = FilePath + "\\" + oldDocumentTitle + ".docx";

            //string newFullPath = FilePath + "\\" + newDocumentTitle + ".docx";
            ////doc.form
            ////File.Move(oldFullpath, newFullPath);

            ////string sourceFile = doc.Path;
            //// Create a FileInfo  
            //FileInfo fi = new FileInfo(oldFullpath);
            //// Check if file is there  
            //if (fi.Exists)
            //{
            //    // Move file with a new name. Hence renamed.  
            //    fi.MoveTo($"{FilePath} +{newDocumentTitle} + .docx");
            //    //Console.WriteLine("File Renamed.");

            //}
        }


        private void DocumentTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
