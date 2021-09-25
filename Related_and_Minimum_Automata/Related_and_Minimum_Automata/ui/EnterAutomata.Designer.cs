
namespace Related_and_Minimum_Automata.ui
{
    partial class EnterAutomata
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BuildAutomataButton = new System.Windows.Forms.Button();
            this.TypeAutomataComboBox = new System.Windows.Forms.ComboBox();
            this.StatesTextBox = new System.Windows.Forms.TextBox();
            this.InputsTextBox = new System.Windows.Forms.TextBox();
            this.OutputsTextBox = new System.Windows.Forms.TextBox();
            this.InitialStateComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter an automata";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(35, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(35, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of states:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(35, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Inputs:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(35, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Outputs:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(35, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Initial state:";
            // 
            // BuildAutomataButton
            // 
            this.BuildAutomataButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.BuildAutomataButton.Location = new System.Drawing.Point(134, 303);
            this.BuildAutomataButton.Name = "BuildAutomataButton";
            this.BuildAutomataButton.Size = new System.Drawing.Size(109, 23);
            this.BuildAutomataButton.TabIndex = 6;
            this.BuildAutomataButton.Text = "Build automata";
            this.BuildAutomataButton.UseVisualStyleBackColor = true;
            this.BuildAutomataButton.Click += new System.EventHandler(this.BuildAutomataButton_Click);
            // 
            // TypeAutomataComboBox
            // 
            this.TypeAutomataComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.TypeAutomataComboBox.FormattingEnabled = true;
            this.TypeAutomataComboBox.Items.AddRange(new object[] {
            "Moore",
            "Mealy"});
            this.TypeAutomataComboBox.Location = new System.Drawing.Point(122, 53);
            this.TypeAutomataComboBox.Name = "TypeAutomataComboBox";
            this.TypeAutomataComboBox.Size = new System.Drawing.Size(121, 23);
            this.TypeAutomataComboBox.TabIndex = 7;
            // 
            // StatesTextBox
            // 
            this.StatesTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.StatesTextBox.Location = new System.Drawing.Point(142, 94);
            this.StatesTextBox.Name = "StatesTextBox";
            this.StatesTextBox.Size = new System.Drawing.Size(157, 23);
            this.StatesTextBox.TabIndex = 8;
            // 
            // InputsTextBox
            // 
            this.InputsTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.InputsTextBox.Location = new System.Drawing.Point(122, 144);
            this.InputsTextBox.Name = "InputsTextBox";
            this.InputsTextBox.Size = new System.Drawing.Size(157, 23);
            this.InputsTextBox.TabIndex = 9;
            // 
            // OutputsTextBox
            // 
            this.OutputsTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.OutputsTextBox.Location = new System.Drawing.Point(122, 192);
            this.OutputsTextBox.Name = "OutputsTextBox";
            this.OutputsTextBox.Size = new System.Drawing.Size(157, 23);
            this.OutputsTextBox.TabIndex = 10;
            // 
            // InitialStateComboBox
            // 
            this.InitialStateComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.InitialStateComboBox.FormattingEnabled = true;
            this.InitialStateComboBox.Location = new System.Drawing.Point(122, 243);
            this.InitialStateComboBox.Name = "InitialStateComboBox";
            this.InitialStateComboBox.Size = new System.Drawing.Size(121, 23);
            this.InitialStateComboBox.TabIndex = 11;
            // 
            // EnterAutomata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InitialStateComboBox);
            this.Controls.Add(this.OutputsTextBox);
            this.Controls.Add(this.InputsTextBox);
            this.Controls.Add(this.StatesTextBox);
            this.Controls.Add(this.TypeAutomataComboBox);
            this.Controls.Add(this.BuildAutomataButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EnterAutomata";
            this.Size = new System.Drawing.Size(367, 380);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BuildAutomataButton;
        private System.Windows.Forms.ComboBox TypeAutomataComboBox;
        private System.Windows.Forms.TextBox StatesTextBox;
        private System.Windows.Forms.TextBox InputsTextBox;
        private System.Windows.Forms.TextBox OutputsTextBox;
        private System.Windows.Forms.ComboBox InitialStateComboBox;
    }
}
