
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
            this.TypeAutomataComboBox = new System.Windows.Forms.ComboBox();
            this.StatesTextBox = new System.Windows.Forms.TextBox();
            this.InputsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(94, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter an automata";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(35, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(35, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of states:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(35, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Number of inputs:";
            // 
            // TypeAutomataComboBox
            // 
            this.TypeAutomataComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.TypeAutomataComboBox.FormattingEnabled = true;
            this.TypeAutomataComboBox.Items.AddRange(new object[] {
            "Moore",
            "Mealy"});
            this.TypeAutomataComboBox.Location = new System.Drawing.Point(211, 100);
            this.TypeAutomataComboBox.Name = "TypeAutomataComboBox";
            this.TypeAutomataComboBox.Size = new System.Drawing.Size(121, 28);
            this.TypeAutomataComboBox.TabIndex = 7;
            this.TypeAutomataComboBox.Text = "Moore";
            // 
            // StatesTextBox
            // 
            this.StatesTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.StatesTextBox.Location = new System.Drawing.Point(211, 167);
            this.StatesTextBox.Name = "StatesTextBox";
            this.StatesTextBox.Size = new System.Drawing.Size(101, 27);
            this.StatesTextBox.TabIndex = 8;
            // 
            // InputsTextBox
            // 
            this.InputsTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.InputsTextBox.Location = new System.Drawing.Point(211, 242);
            this.InputsTextBox.Name = "InputsTextBox";
            this.InputsTextBox.Size = new System.Drawing.Size(101, 27);
            this.InputsTextBox.TabIndex = 9;
            // 
            // EnterAutomata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InputsTextBox);
            this.Controls.Add(this.StatesTextBox);
            this.Controls.Add(this.TypeAutomataComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EnterAutomata";
            this.Size = new System.Drawing.Size(370, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox TypeAutomataComboBox;
        private System.Windows.Forms.TextBox StatesTextBox;
        private System.Windows.Forms.TextBox InputsTextBox;
    }
}
