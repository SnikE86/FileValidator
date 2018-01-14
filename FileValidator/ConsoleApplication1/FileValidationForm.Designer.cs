namespace FileValidator
{
    partial class FileValidationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileValidationForm));
            this.panelToValidate = new System.Windows.Forms.Panel();
            this.panelSuccess = new System.Windows.Forms.Panel();
            this.panelFailures = new System.Windows.Forms.Panel();
            this.buttonRunValidation = new System.Windows.Forms.Button();
            this.buttonViewConfig = new System.Windows.Forms.Button();
            this.dataGridViewToProcess = new System.Windows.Forms.DataGridView();
            this.dataGridViewSuccess = new System.Windows.Forms.DataGridView();
            this.dataGridViewFailures = new System.Windows.Forms.DataGridView();
            this.panelToValidate.SuspendLayout();
            this.panelSuccess.SuspendLayout();
            this.panelFailures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFailures)).BeginInit();
            this.SuspendLayout();
            // 
            // panelToValidate
            // 
            this.panelToValidate.Controls.Add(this.dataGridViewToProcess);
            this.panelToValidate.Location = new System.Drawing.Point(34, 29);
            this.panelToValidate.Name = "panelToValidate";
            this.panelToValidate.Size = new System.Drawing.Size(423, 431);
            this.panelToValidate.TabIndex = 0;
            // 
            // panelSuccess
            // 
            this.panelSuccess.Controls.Add(this.dataGridViewSuccess);
            this.panelSuccess.Location = new System.Drawing.Point(485, 29);
            this.panelSuccess.Name = "panelSuccess";
            this.panelSuccess.Size = new System.Drawing.Size(435, 212);
            this.panelSuccess.TabIndex = 1;
            // 
            // panelFailures
            // 
            this.panelFailures.Controls.Add(this.dataGridViewFailures);
            this.panelFailures.Location = new System.Drawing.Point(485, 248);
            this.panelFailures.Name = "panelFailures";
            this.panelFailures.Size = new System.Drawing.Size(435, 212);
            this.panelFailures.TabIndex = 2;
            // 
            // buttonRunValidation
            // 
            this.buttonRunValidation.Location = new System.Drawing.Point(748, 489);
            this.buttonRunValidation.Name = "buttonRunValidation";
            this.buttonRunValidation.Size = new System.Drawing.Size(75, 23);
            this.buttonRunValidation.TabIndex = 3;
            this.buttonRunValidation.Text = "Run";
            this.buttonRunValidation.UseVisualStyleBackColor = true;
            // 
            // buttonViewConfig
            // 
            this.buttonViewConfig.Location = new System.Drawing.Point(845, 489);
            this.buttonViewConfig.Name = "buttonViewConfig";
            this.buttonViewConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonViewConfig.TabIndex = 4;
            this.buttonViewConfig.Text = "View Config";
            this.buttonViewConfig.UseVisualStyleBackColor = true;
            // 
            // dataGridViewToProcess
            // 
            this.dataGridViewToProcess.AllowUserToAddRows = false;
            this.dataGridViewToProcess.AllowUserToDeleteRows = false;
            this.dataGridViewToProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewToProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewToProcess.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewToProcess.Name = "dataGridViewToProcess";
            this.dataGridViewToProcess.ReadOnly = true;
            this.dataGridViewToProcess.Size = new System.Drawing.Size(423, 431);
            this.dataGridViewToProcess.TabIndex = 0;
            // 
            // dataGridViewSuccess
            // 
            this.dataGridViewSuccess.AllowUserToAddRows = false;
            this.dataGridViewSuccess.AllowUserToDeleteRows = false;
            this.dataGridViewSuccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSuccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSuccess.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSuccess.Name = "dataGridViewSuccess";
            this.dataGridViewSuccess.ReadOnly = true;
            this.dataGridViewSuccess.Size = new System.Drawing.Size(435, 212);
            this.dataGridViewSuccess.TabIndex = 0;
            // 
            // dataGridViewFailures
            // 
            this.dataGridViewFailures.AllowUserToAddRows = false;
            this.dataGridViewFailures.AllowUserToDeleteRows = false;
            this.dataGridViewFailures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFailures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFailures.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFailures.Name = "dataGridViewFailures";
            this.dataGridViewFailures.ReadOnly = true;
            this.dataGridViewFailures.Size = new System.Drawing.Size(435, 212);
            this.dataGridViewFailures.TabIndex = 0;
            // 
            // FileValidationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 539);
            this.Controls.Add(this.buttonViewConfig);
            this.Controls.Add(this.buttonRunValidation);
            this.Controls.Add(this.panelFailures);
            this.Controls.Add(this.panelSuccess);
            this.Controls.Add(this.panelToValidate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileValidationForm";
            this.Text = "File Validator";
            this.panelToValidate.ResumeLayout(false);
            this.panelSuccess.ResumeLayout(false);
            this.panelFailures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFailures)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelToValidate;
        private System.Windows.Forms.Panel panelSuccess;
        private System.Windows.Forms.Panel panelFailures;
        private System.Windows.Forms.Button buttonRunValidation;
        private System.Windows.Forms.Button buttonViewConfig;
        private System.Windows.Forms.DataGridView dataGridViewToProcess;
        private System.Windows.Forms.DataGridView dataGridViewSuccess;
        private System.Windows.Forms.DataGridView dataGridViewFailures;
    }
}