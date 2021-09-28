
namespace Related_and_Minimum_Automata.ui
{
    partial class MachineTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TableMachine = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.TableMachine)).BeginInit();
            this.SuspendLayout();
            // 
            // TableMachine
            // 
            this.TableMachine.AllowUserToAddRows = false;
            this.TableMachine.AllowUserToDeleteRows = false;
            this.TableMachine.AllowUserToResizeColumns = false;
            this.TableMachine.AllowUserToResizeRows = false;
            this.TableMachine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TableMachine.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TableMachine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableMachine.Location = new System.Drawing.Point(3, 3);
            this.TableMachine.MultiSelect = false;
            this.TableMachine.Name = "TableMachine";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableMachine.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TableMachine.RowHeadersVisible = false;
            this.TableMachine.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.TableMachine.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.TableMachine.ShowEditingIcon = false;
            this.TableMachine.Size = new System.Drawing.Size(544, 196);
            this.TableMachine.TabIndex = 0;
            // 
            // MachineTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableMachine);
            this.Name = "MachineTable";
            this.Size = new System.Drawing.Size(550, 202);
            ((System.ComponentModel.ISupportInitialize)(this.TableMachine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TableMachine;
    }
}
