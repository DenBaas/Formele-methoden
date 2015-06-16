namespace Eindopdracht
{
    partial class MainGUI
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
            this.ConvertButton = new System.Windows.Forms.Button();
            this.ToNDFA = new System.Windows.Forms.RadioButton();
            this.ToDFA = new System.Windows.Forms.RadioButton();
            this.ToReguliereGrammatica = new System.Windows.Forms.RadioButton();
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.InputBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(226, 12);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(75, 23);
            this.ConvertButton.TabIndex = 0;
            this.ConvertButton.Text = "------>";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // ToNDFA
            // 
            this.ToNDFA.AutoSize = true;
            this.ToNDFA.Checked = true;
            this.ToNDFA.Location = new System.Drawing.Point(12, 262);
            this.ToNDFA.Name = "ToNDFA";
            this.ToNDFA.Size = new System.Drawing.Size(54, 17);
            this.ToNDFA.TabIndex = 2;
            this.ToNDFA.TabStop = true;
            this.ToNDFA.Text = "NDFA";
            this.ToNDFA.UseVisualStyleBackColor = true;
            // 
            // ToDFA
            // 
            this.ToDFA.AutoSize = true;
            this.ToDFA.Location = new System.Drawing.Point(12, 285);
            this.ToDFA.Name = "ToDFA";
            this.ToDFA.Size = new System.Drawing.Size(46, 17);
            this.ToDFA.TabIndex = 3;
            this.ToDFA.Text = "DFA";
            this.ToDFA.UseVisualStyleBackColor = true;
            this.ToDFA.CheckedChanged += new System.EventHandler(this.ToDFA_CheckedChanged);
            this.ToDFA.EnabledChanged += new System.EventHandler(this.ToDFA_EnabledChanged);
            // 
            // ToReguliereGrammatica
            // 
            this.ToReguliereGrammatica.AutoSize = true;
            this.ToReguliereGrammatica.Location = new System.Drawing.Point(12, 308);
            this.ToReguliereGrammatica.Name = "ToReguliereGrammatica";
            this.ToReguliereGrammatica.Size = new System.Drawing.Size(127, 17);
            this.ToReguliereGrammatica.TabIndex = 4;
            this.ToReguliereGrammatica.Text = "Reguliere grammatica";
            this.ToReguliereGrammatica.UseVisualStyleBackColor = true;
            // 
            // OutputBox
            // 
            this.OutputBox.BackColor = System.Drawing.Color.Black;
            this.OutputBox.ForeColor = System.Drawing.Color.Lime;
            this.OutputBox.Location = new System.Drawing.Point(307, 9);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(315, 316);
            this.OutputBox.TabIndex = 5;
            this.OutputBox.Text = "";
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(12, 9);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(208, 75);
            this.InputBox.TabIndex = 6;
            this.InputBox.Text = "(ab)*";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Minimaliseer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mede mogelijk gemaakt door:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Igor van der Bom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Bas van Loon";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(226, 61);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(634, 337);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.ToReguliereGrammatica);
            this.Controls.Add(this.ToDFA);
            this.Controls.Add(this.ToNDFA);
            this.Controls.Add(this.ConvertButton);
            this.Name = "MainGUI";
            this.Text = "MainGUI";
            this.Load += new System.EventHandler(this.MainGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.RadioButton ToNDFA;
        private System.Windows.Forms.RadioButton ToDFA;
        private System.Windows.Forms.RadioButton ToReguliereGrammatica;
        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.RichTextBox InputBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button clearButton;
    }
}