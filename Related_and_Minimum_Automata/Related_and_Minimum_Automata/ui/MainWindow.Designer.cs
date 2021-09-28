
namespace Related_and_Minimum_Automata.ui
{
    partial class FiniteStateMachine
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
            this.enterAutomata1 = new Related_and_Minimum_Automata.ui.EnterAutomata();
            this.machineTable1 = new Related_and_Minimum_Automata.ui.MachineTable();
            this.ReduceMachineButton = new System.Windows.Forms.Button();
            this.OpenTableButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enterAutomata1
            // 
            this.enterAutomata1.Location = new System.Drawing.Point(136, 12);
            this.enterAutomata1.Name = "enterAutomata1";
            this.enterAutomata1.Size = new System.Drawing.Size(370, 320);
            this.enterAutomata1.TabIndex = 0;
            // 
            // machineTable1
            // 
            this.machineTable1.Location = new System.Drawing.Point(51, 34);
            this.machineTable1.Name = "machineTable1";
            this.machineTable1.Size = new System.Drawing.Size(550, 263);
            this.machineTable1.TabIndex = 1;
            this.machineTable1.Visible = false;
            // 
            // ReduceMachineButton
            // 
            this.ReduceMachineButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.ReduceMachineButton.Location = new System.Drawing.Point(436, 338);
            this.ReduceMachineButton.Name = "ReduceMachineButton";
            this.ReduceMachineButton.Size = new System.Drawing.Size(165, 35);
            this.ReduceMachineButton.TabIndex = 2;
            this.ReduceMachineButton.Text = "Reduce Machine";
            this.ReduceMachineButton.UseVisualStyleBackColor = true;
            this.ReduceMachineButton.Visible = false;
            this.ReduceMachineButton.Click += new System.EventHandler(this.ReduceMachineButton_Click);
            // 
            // OpenTableButton
            // 
            this.OpenTableButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.OpenTableButton.Location = new System.Drawing.Point(239, 318);
            this.OpenTableButton.Name = "OpenTableButton";
            this.OpenTableButton.Size = new System.Drawing.Size(165, 35);
            this.OpenTableButton.TabIndex = 3;
            this.OpenTableButton.Text = "Open table";
            this.OpenTableButton.UseVisualStyleBackColor = true;
            this.OpenTableButton.Click += new System.EventHandler(this.OpenTableButton_Click);
            // 
            // FiniteStateMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 409);
            this.Controls.Add(this.OpenTableButton);
            this.Controls.Add(this.ReduceMachineButton);
            this.Controls.Add(this.machineTable1);
            this.Controls.Add(this.enterAutomata1);
            this.Name = "FiniteStateMachine";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private EnterAutomata enterAutomata1;
        private MachineTable machineTable1;
        private System.Windows.Forms.Button ReduceMachineButton;
        private System.Windows.Forms.Button OpenTableButton;
    }
}