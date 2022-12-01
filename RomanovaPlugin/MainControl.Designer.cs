namespace RomanovaPlugin
{
    partial class MainControl
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sevaTreeView = new ComponentsLibrary.BasharinVisualComponents.SevaTreeView();
            this.romanovaExcelDocument = new ComponentsLibrary.MyNotVisualComponents.RomanovaExcelDocument(this.components);
            this.diagramTopdf = new ComponentsLibrary.BasharinNotVisualComponents.DiagramToPDF(this.components);
            this.componentDocumentWithTableMultiHeaderWord = new ComponentsLibraryNet60.DocumentWithTable.ComponentDocumentWithTableMultiHeaderWord(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(801, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // sevaTreeView
            // 
            this.sevaTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sevaTreeView.Location = new System.Drawing.Point(0, 28);
            this.sevaTreeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sevaTreeView.Name = "sevaTreeView";
            this.sevaTreeView.SelectedNodeIndex = 0;
            this.sevaTreeView.Size = new System.Drawing.Size(801, 458);
            this.sevaTreeView.TabIndex = 1;
            this.sevaTreeView.Load += new System.EventHandler(this.treeViewControl_Load);
            // 
            // MainControl
            // 
            this.Controls.Add(this.sevaTreeView);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(801, 486);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem справочникToolStripMenuItem;
        private ComponentsLibrary.BasharinVisualComponents.SevaTreeView sevaTreeView;
        private ComponentsLibrary.MyNotVisualComponents.RomanovaExcelDocument romanovaExcelDocument;
        private ComponentsLibrary.BasharinNotVisualComponents.DiagramToPDF diagramTopdf;
        private ComponentsLibraryNet60.DocumentWithTable.ComponentDocumentWithTableMultiHeaderWord componentDocumentWithTableMultiHeaderWord;
    }
}
