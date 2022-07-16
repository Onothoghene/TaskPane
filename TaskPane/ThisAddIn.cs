using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.Windows.Forms;

namespace TaskPane
{
    public partial class ThisAddIn
    {
        private CustomPane taskPane;
        public readonly TextBox textBox;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            taskPane = new CustomPane();
            CustomTaskPane = CustomTaskPanes.Add(taskPane, "UserWay");
            CustomTaskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionFloating;
            CustomTaskPane.Height = 500;
            CustomTaskPane.Width = 500;

            CustomTaskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
            CustomTaskPane.Width = 400;
            CustomTaskPane.VisibleChanged += new EventHandler(taskPaneValue_VisibleChanged);

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void taskPaneValue_VisibleChanged(object sender, System.EventArgs e)
        {
            Globals.Ribbons.Ribbon1.toggleButton1.Checked =
                CustomTaskPane.Visible;
        }

        public Microsoft.Office.Tools.CustomTaskPane CustomTaskPane { get; private set; }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
