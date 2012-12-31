namespace ExceptionReflector
{
    partial class MainForm
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.itemTreeView = new System.Windows.Forms.TreeView();
            this.loadAssemblyLinkLabel = new System.Windows.Forms.LinkLabel();
            this.labelAvailableExceptions = new System.Windows.Forms.Label();
            this.exceptionList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.itemTreeView);
            this.splitContainer.Panel1.Controls.Add(this.loadAssemblyLinkLabel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.labelAvailableExceptions);
            this.splitContainer.Panel2.Controls.Add(this.exceptionList);
            this.splitContainer.Size = new System.Drawing.Size(983, 461);
            this.splitContainer.SplitterDistance = 492;
            this.splitContainer.TabIndex = 0;
            // 
            // itemTreeView
            // 
            this.itemTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemTreeView.Location = new System.Drawing.Point(15, 32);
            this.itemTreeView.Name = "itemTreeView";
            this.itemTreeView.Size = new System.Drawing.Size(463, 420);
            this.itemTreeView.TabIndex = 1;
            this.itemTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.itemTreeView_AfterSelect);
            // 
            // loadAssemblyLinkLabel
            // 
            this.loadAssemblyLinkLabel.AutoSize = true;
            this.loadAssemblyLinkLabel.Location = new System.Drawing.Point(12, 9);
            this.loadAssemblyLinkLabel.Name = "loadAssemblyLinkLabel";
            this.loadAssemblyLinkLabel.Size = new System.Drawing.Size(150, 13);
            this.loadAssemblyLinkLabel.TabIndex = 0;
            this.loadAssemblyLinkLabel.TabStop = true;
            this.loadAssemblyLinkLabel.Text = "Click here to load an assembly";
            this.loadAssemblyLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.loadAssemblyLinkLabel_LinkClicked);
            // 
            // labelAvailableExceptions
            // 
            this.labelAvailableExceptions.AutoSize = true;
            this.labelAvailableExceptions.Location = new System.Drawing.Point(16, 9);
            this.labelAvailableExceptions.Name = "labelAvailableExceptions";
            this.labelAvailableExceptions.Size = new System.Drawing.Size(98, 13);
            this.labelAvailableExceptions.TabIndex = 1;
            this.labelAvailableExceptions.Text = "Thrown Exceptions";
            // 
            // exceptionList
            // 
            this.exceptionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exceptionList.FormattingEnabled = true;
            this.exceptionList.Location = new System.Drawing.Point(19, 32);
            this.exceptionList.Name = "exceptionList";
            this.exceptionList.Size = new System.Drawing.Size(456, 420);
            this.exceptionList.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 461);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.Text = "Exception Reflector";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView itemTreeView;
        private System.Windows.Forms.LinkLabel loadAssemblyLinkLabel;
        private System.Windows.Forms.Label labelAvailableExceptions;
        private System.Windows.Forms.ListBox exceptionList;
    }
}

