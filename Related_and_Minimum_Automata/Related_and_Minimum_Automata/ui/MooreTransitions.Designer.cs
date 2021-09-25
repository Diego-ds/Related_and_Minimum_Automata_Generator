
namespace Related_and_Minimum_Automata.ui
{
    partial class MooreTransitions
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
            this.AddMooreTransButton = new System.Windows.Forms.Button();
            this.InitStateMooreComboBox = new System.Windows.Forms.ComboBox();
            this.FinalStateMooreComboBox = new System.Windows.Forms.ComboBox();
            this.InputMooreComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(156, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Moore transitions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(25, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Initial state";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(131, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Final state";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(249, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Input";
            // 
            // AddMooreTransButton
            // 
            this.AddMooreTransButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.AddMooreTransButton.Location = new System.Drawing.Point(341, 83);
            this.AddMooreTransButton.Name = "AddMooreTransButton";
            this.AddMooreTransButton.Size = new System.Drawing.Size(75, 23);
            this.AddMooreTransButton.TabIndex = 7;
            this.AddMooreTransButton.Text = "Add";
            this.AddMooreTransButton.UseVisualStyleBackColor = true;
            // 
            // InitStateMooreComboBox
            // 
            this.InitStateMooreComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.InitStateMooreComboBox.FormattingEnabled = true;
            this.InitStateMooreComboBox.Location = new System.Drawing.Point(21, 102);
            this.InitStateMooreComboBox.Name = "InitStateMooreComboBox";
            this.InitStateMooreComboBox.Size = new System.Drawing.Size(69, 23);
            this.InitStateMooreComboBox.TabIndex = 8;
            // 
            // FinalStateMooreComboBox
            // 
            this.FinalStateMooreComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.FinalStateMooreComboBox.FormattingEnabled = true;
            this.FinalStateMooreComboBox.Location = new System.Drawing.Point(122, 102);
            this.FinalStateMooreComboBox.Name = "FinalStateMooreComboBox";
            this.FinalStateMooreComboBox.Size = new System.Drawing.Size(69, 23);
            this.FinalStateMooreComboBox.TabIndex = 9;
            // 
            // InputMooreComboBox
            // 
            this.InputMooreComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.InputMooreComboBox.FormattingEnabled = true;
            this.InputMooreComboBox.Location = new System.Drawing.Point(239, 102);
            this.InputMooreComboBox.Name = "InputMooreComboBox";
            this.InputMooreComboBox.Size = new System.Drawing.Size(69, 23);
            this.InputMooreComboBox.TabIndex = 10;
            // 
            // MooreTransitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InputMooreComboBox);
            this.Controls.Add(this.FinalStateMooreComboBox);
            this.Controls.Add(this.InitStateMooreComboBox);
            this.Controls.Add(this.AddMooreTransButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MooreTransitions";
            this.Size = new System.Drawing.Size(444, 171);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddMooreTransButton;
        private System.Windows.Forms.ComboBox InitStateMooreComboBox;
        private System.Windows.Forms.ComboBox FinalStateMooreComboBox;
        private System.Windows.Forms.ComboBox InputMooreComboBox;
    }
}
