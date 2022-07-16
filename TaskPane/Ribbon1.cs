using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Tools;
using Microsoft.Office.Tools.Ribbon;
using Word = Microsoft.Office.Interop.Word;

namespace TaskPane
{
    public partial class Ribbon1
    {
        private CustomPane customPane =  new CustomPane();
        public readonly TextBox textBox;
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void toggleButton1_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.CustomTaskPane.Visible = ((RibbonToggleButton)sender).Checked;
            Word.Document doc = Globals.ThisAddIn.Application.ActiveDocument;
            Word.Application wordApp = new Word.Application();
            customPane.DocumentTitle = new TextBox();
            //customPane.DocumentTitle.Text = "this is me";
            customPane.DocumentTitle.Text = wordApp.Name ;
        }

    }
}
