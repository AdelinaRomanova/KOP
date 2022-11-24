namespace test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clear = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.romanovaComboBox = new ComponentsLibrary.MyVisualComponents.RomanovaComboBox();
            this.romanovaTextBox = new ComponentsLibrary.MyVisualComponents.RomanovaTextBox();
            this.romanovaListBox1 = new ComponentsLibrary.MyVisualComponents.RomanovaListBox();
            this.update = new System.Windows.Forms.Button();
            this.addTemplate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.createExcel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.Color.RosyBrown;
            this.clear.FlatAppearance.BorderSize = 0;
            this.clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear.Location = new System.Drawing.Point(86, 130);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(94, 28);
            this.clear.TabIndex = 1;
            this.clear.Text = "Отчистить";
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.RosyBrown;
            this.save.FlatAppearance.BorderSize = 0;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Location = new System.Drawing.Point(283, 130);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(94, 28);
            this.save.TabIndex = 3;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // romanovaComboBox
            // 
            this.romanovaComboBox.Location = new System.Drawing.Point(25, 35);
            this.romanovaComboBox.Name = "romanovaComboBox";
            this.romanovaComboBox.SelectElement = "";
            this.romanovaComboBox.Size = new System.Drawing.Size(208, 79);
            this.romanovaComboBox.TabIndex = 4;
            // 
            // romanovaTextBox
            // 
            this.romanovaTextBox.ChekDate = "";
            this.romanovaTextBox.Location = new System.Drawing.Point(227, 44);
            this.romanovaTextBox.Name = "romanovaTextBox";
            this.romanovaTextBox.Size = new System.Drawing.Size(180, 79);
            this.romanovaTextBox.TabIndex = 5;
            this.romanovaTextBox.template = "";
            // 
            // romanovaListBox1
            // 
            this.romanovaListBox1.index = -1;
            this.romanovaListBox1.Location = new System.Drawing.Point(429, 165);
            this.romanovaListBox1.Name = "romanovaListBox1";
            this.romanovaListBox1.Size = new System.Drawing.Size(336, 141);
            this.romanovaListBox1.TabIndex = 6;
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.Color.RosyBrown;
            this.update.FlatAppearance.BorderSize = 0;
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.Location = new System.Drawing.Point(476, 312);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(94, 28);
            this.update.TabIndex = 7;
            this.update.Text = "Обновить";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.button1_Click);
            // 
            // addTemplate
            // 
            this.addTemplate.BackColor = System.Drawing.Color.RosyBrown;
            this.addTemplate.FlatAppearance.BorderSize = 0;
            this.addTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTemplate.Location = new System.Drawing.Point(497, 130);
            this.addTemplate.Name = "addTemplate";
            this.addTemplate.Size = new System.Drawing.Size(186, 28);
            this.addTemplate.TabIndex = 8;
            this.addTemplate.Text = "Добавить шаблон";
            this.addTemplate.UseVisualStyleBackColor = false;
            this.addTemplate.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(429, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 27);
            this.textBox1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "ComboBox";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "TextBox";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(562, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "ListBox";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(603, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 13;
            this.button1.Text = "Проверка";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // createExcel
            // 
            this.createExcel.BackColor = System.Drawing.Color.RosyBrown;
            this.createExcel.FlatAppearance.BorderSize = 0;
            this.createExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createExcel.Location = new System.Drawing.Point(61, 206);
            this.createExcel.Name = "createExcel";
            this.createExcel.Size = new System.Drawing.Size(188, 29);
            this.createExcel.TabIndex = 14;
            this.createExcel.Text = "Создать документ";
            this.createExcel.UseVisualStyleBackColor = false;
            this.createExcel.Click += new System.EventHandler(this.createExcel_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RosyBrown;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(61, 251);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 29);
            this.button2.TabIndex = 15;
            this.button2.Text = "Создать таблицу";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.RosyBrown;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(62, 297);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 29);
            this.button3.TabIndex = 16;
            this.button3.Text = "Создать диаграмму";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(792, 379);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.createExcel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.addTemplate);
            this.Controls.Add(this.update);
            this.Controls.Add(this.romanovaListBox1);
            this.Controls.Add(this.romanovaTextBox);
            this.Controls.Add(this.romanovaComboBox);
            this.Controls.Add(this.save);
            this.Controls.Add(this.clear);
            this.Name = "Form1";
            this.Text = "Тест";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button clear;
        private Button save;
        private ComponentsLibrary.MyVisualComponents.RomanovaComboBox romanovaComboBox;
        private ComponentsLibrary.MyVisualComponents.RomanovaTextBox romanovaTextBox;
        private ComponentsLibrary.MyVisualComponents.RomanovaListBox romanovaListBox1;
        private Button update;
        private Button addTemplate;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button createExcel;
        private Button button2;
        private Button button3;
    }
}