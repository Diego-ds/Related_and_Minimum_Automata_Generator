
namespace Related_and_Minimum_Automata.ui
{
    partial class MealyTransitions
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AddMealyTransitionButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.InputMealyComboBox = new System.Windows.Forms.ComboBox();
            this.OutputMealyComboBox = new System.Windows.Forms.ComboBox();
            this.FinalStateMealyComboBox = new System.Windows.Forms.ComboBox();
            this.InitStateMealyComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(168, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mealy transitions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(121, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Final state";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(220, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "input";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(300, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "output";
            // 
            // AddMealyTransitionButton
            // 
            this.AddMealyTransitionButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.AddMealyTransitionButton.Location = new System.Drawing.Point(376, 84);
            this.AddMealyTransitionButton.Name = "AddMealyTransitionButton";
            this.AddMealyTransitionButton.Size = new System.Drawing.Size(75, 23);
            this.AddMealyTransitionButton.TabIndex = 9;
            this.AddMealyTransitionButton.Text = "Add";
            this.AddMealyTransitionButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(24, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Initial state";
            // 
            // InputMealyComboBox
            // 
            this.InputMealyComboBox.FormattingEnabled = true;
            this.InputMealyComboBox.Location = new System.Drawing.Point(203, 101);
            this.InputMealyComboBox.Name = "InputMealyComboBox";
            this.InputMealyComboBox.Size = new System.Drawing.Size(68, 21);
            this.InputMealyComboBox.TabIndex = 11;
            // 
            // OutputMealyComboBox
            // 
            this.OutputMealyComboBox.FormattingEnabled = true;
            this.OutputMealyComboBox.Location = new System.Drawing.Point(292, 101);
            this.OutputMealyComboBox.Name = "OutputMealyComboBox";
            this.OutputMealyComboBox.Size = new System.Drawing.Size(65, 21);
            this.OutputMealyComboBox.TabIndex = 12;
            // 
            // FinalStateMealyComboBox
            // 
            this.FinalStateMealyComboBox.FormattingEnabled = true;
            this.FinalStateMealyComboBox.Location = new System.Drawing.Point(113, 101);
            this.FinalStateMealyComboBox.Name = "FinalStateMealyComboBox";
            this.FinalStateMealyComboBox.Size = new System.Drawing.Size(68, 21);
            this.FinalStateMealyComboBox.TabIndex = 13;
            // 
            // InitStateMealyComboBox
            // 
            this.InitStateMealyComboBox.FormattingEnabled = true;
            this.InitStateMealyComboBox.Location = new System.Drawing.Point(21, 101);
            this.InitStateMealyComboBox.Name = "InitStateMealyComboBox";
            this.InitStateMealyComboBox.Size = new System.Drawing.Size(68, 21);
            this.InitStateMealyComboBox.TabIndex = 14;
            // 
            // MealyTransitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InitStateMealyComboBox);
            this.Controls.Add(this.FinalStateMealyComboBox);
            this.Controls.Add(this.OutputMealyComboBox);
            this.Controls.Add(this.InputMealyComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddMealyTransitionButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "MealyTransitions";
            this.Size = new System.Drawing.Size(475, 171);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddMealyTransitionButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox InputMealyComboBox;
        private System.Windows.Forms.ComboBox OutputMealyComboBox;
        private System.Windows.Forms.ComboBox FinalStateMealyComboBox;
        private System.Windows.Forms.ComboBox InitStateMealyComboBox;
    }
}
