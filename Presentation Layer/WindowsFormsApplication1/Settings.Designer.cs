namespace MazeNavigatorUI
{
    partial class Settings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpAnimationSpeed = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAnimationSpeed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioRecursiveBacktracking = new System.Windows.Forms.RadioButton();
            this.radioPrimsAlgorithm = new System.Windows.Forms.RadioButton();
            this.radioCustom = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.grpAnimationSpeed.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtColumns);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRows);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maze Size";
            // 
            // txtColumns
            // 
            this.txtColumns.Location = new System.Drawing.Point(74, 58);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(43, 20);
            this.txtColumns.TabIndex = 3;
            this.txtColumns.TextChanged += new System.EventHandler(this.txtColumns_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Columns";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(74, 22);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(43, 20);
            this.txtRows.TabIndex = 1;
            this.txtRows.TextChanged += new System.EventHandler(this.txtRows_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rows";
            // 
            // grpAnimationSpeed
            // 
            this.grpAnimationSpeed.Controls.Add(this.label4);
            this.grpAnimationSpeed.Controls.Add(this.txtAnimationSpeed);
            this.grpAnimationSpeed.Controls.Add(this.label3);
            this.grpAnimationSpeed.Location = new System.Drawing.Point(181, 13);
            this.grpAnimationSpeed.Name = "grpAnimationSpeed";
            this.grpAnimationSpeed.Size = new System.Drawing.Size(143, 102);
            this.grpAnimationSpeed.TabIndex = 1;
            this.grpAnimationSpeed.TabStop = false;
            this.grpAnimationSpeed.Text = "Arrow Animation Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "seconds.";
            // 
            // txtAnimationSpeed
            // 
            this.txtAnimationSpeed.Location = new System.Drawing.Point(26, 29);
            this.txtAnimationSpeed.Name = "txtAnimationSpeed";
            this.txtAnimationSpeed.Size = new System.Drawing.Size(42, 20);
            this.txtAnimationSpeed.TabIndex = 1;
            this.txtAnimationSpeed.TextChanged += new System.EventHandler(this.txtAnimationSpeed_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(83, 291);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(174, 291);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioCustom);
            this.groupBox2.Controls.Add(this.radioRecursiveBacktracking);
            this.groupBox2.Controls.Add(this.radioPrimsAlgorithm);
            this.groupBox2.Location = new System.Drawing.Point(13, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 130);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Maze creation algorithm";
            // 
            // radioRecursiveBacktracking
            // 
            this.radioRecursiveBacktracking.AutoSize = true;
            this.radioRecursiveBacktracking.Location = new System.Drawing.Point(9, 62);
            this.radioRecursiveBacktracking.Name = "radioRecursiveBacktracking";
            this.radioRecursiveBacktracking.Size = new System.Drawing.Size(139, 17);
            this.radioRecursiveBacktracking.TabIndex = 1;
            this.radioRecursiveBacktracking.TabStop = true;
            this.radioRecursiveBacktracking.Text = "Recursive Backtracking";
            this.radioRecursiveBacktracking.UseVisualStyleBackColor = true;
            this.radioRecursiveBacktracking.Click += new System.EventHandler(this.radioRecursiveBacktracking_Click);
            // 
            // radioPrimsAlgorithm
            // 
            this.radioPrimsAlgorithm.AutoSize = true;
            this.radioPrimsAlgorithm.Location = new System.Drawing.Point(9, 29);
            this.radioPrimsAlgorithm.Name = "radioPrimsAlgorithm";
            this.radioPrimsAlgorithm.Size = new System.Drawing.Size(98, 17);
            this.radioPrimsAlgorithm.TabIndex = 0;
            this.radioPrimsAlgorithm.TabStop = true;
            this.radioPrimsAlgorithm.Text = "Prim\'s Algorithm";
            this.radioPrimsAlgorithm.UseVisualStyleBackColor = true;
            this.radioPrimsAlgorithm.Click += new System.EventHandler(this.radioPrimsAlgorithm_Click);
            // 
            // radioCustom
            // 
            this.radioCustom.AutoSize = true;
            this.radioCustom.Location = new System.Drawing.Point(9, 97);
            this.radioCustom.Name = "radioCustom";
            this.radioCustom.Size = new System.Drawing.Size(60, 17);
            this.radioCustom.TabIndex = 2;
            this.radioCustom.TabStop = true;
            this.radioCustom.Text = "Custom";
            this.radioCustom.UseVisualStyleBackColor = true;
            this.radioCustom.Click += new System.EventHandler(this.radioCustom_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 326);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpAnimationSpeed);
            this.Controls.Add(this.groupBox1);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpAnimationSpeed.ResumeLayout(false);
            this.grpAnimationSpeed.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpAnimationSpeed;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAnimationSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioRecursiveBacktracking;
        private System.Windows.Forms.RadioButton radioPrimsAlgorithm;
        private System.Windows.Forms.RadioButton radioCustom;

    }
}