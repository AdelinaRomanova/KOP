namespace LibraryView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sevaTreeView = new ComponentsLibrary.BasharinVisualComponents.SevaTreeView();
            this.romanovaExcelDocument = new ComponentsLibrary.MyNotVisualComponents.RomanovaExcelDocument(this.components);
            this.diagramTopdf1 = new ComponentsLibrary.BasharinNotVisualComponents.DiagramToPDF(this.components);
            this.componentDocumentWithTableMultiHeaderWord = new ComponentsLibraryNet60.DocumentWithTable.ComponentDocumentWithTableMultiHeaderWord(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(694, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // sevaTreeView
            // 
            this.sevaTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sevaTreeView.Location = new System.Drawing.Point(0, 28);
            this.sevaTreeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sevaTreeView.Name = "sevaTreeView";
            this.sevaTreeView.SelectedNodeIndex = 0;
            this.sevaTreeView.Size = new System.Drawing.Size(694, 354);
            this.sevaTreeView.TabIndex = 1;
            this.sevaTreeView.Load += new System.EventHandler(this.treeViewControl_Load);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 382);
            this.Controls.Add(this.sevaTreeView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Главная форма";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem справочникиToolStripMenuItem;
        private ComponentsLibrary.BasharinVisualComponents.SevaTreeView sevaTreeView;
        private ComponentsLibrary.MyNotVisualComponents.RomanovaExcelDocument romanovaExcelDocument;
        private ComponentsLibrary.BasharinNotVisualComponents.DiagramToPDF diagramTopdf1;
        private ComponentsLibraryNet60.DocumentWithTable.ComponentDocumentWithTableMultiHeaderWord componentDocumentWithTableMultiHeaderWord;
    }
}