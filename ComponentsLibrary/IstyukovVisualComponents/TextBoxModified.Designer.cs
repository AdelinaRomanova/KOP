namespace ComponentsLibrary.IstyukovVisualComponents
{
    partial class TextBoxModified
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.checkBoxNull = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(11, 18);
            this.textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(90, 27);
            this.textBox.TabIndex = 0;
            this.textBox.TextChanged += new System.EventHandler(this.TextBox_SelectedChanged);
            // 
            // checkBoxNull
            // 
            this.checkBoxNull.AutoSize = true;
            this.checkBoxNull.Location = new System.Drawing.Point(11, 63);
            this.checkBoxNull.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBoxNull.Name = "checkBoxNull";
            this.checkBoxNull.Size = new System.Drawing.Size(125, 24);
            this.checkBoxNull.TabIndex = 1;
            this.checkBoxNull.Text = "null значение";
            this.checkBoxNull.UseVisualStyleBackColor = true;
            this.checkBoxNull.CheckedChanged += new System.EventHandler(this.checkBoxNull_CheckedChanged);
            // 
            // TextBoxModified
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxNull);
            this.Controls.Add(this.textBox);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "TextBoxModified";
            this.Size = new System.Drawing.Size(134, 100);
            this.Load += new System.EventHandler(this.TextBoxModified_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.CheckBox checkBoxNull;
    }
}
