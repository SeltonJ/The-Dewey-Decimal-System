namespace Task_2_IMPLEMENTATION
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            this.btnReplacingBooks = new System.Windows.Forms.Button();
            this.btnIdentifyingA = new System.Windows.Forms.Button();
            this.btnFindingCallNumbers = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExitApp = new System.Windows.Forms.Button();
            this.delayForm = new System.Windows.Forms.Timer(this.components);
            this.identifyingAreas = new System.Windows.Forms.Timer(this.components);
            this.findingCallNumbers = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnReplacingBooks
            // 
            this.btnReplacingBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplacingBooks.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplacingBooks.Location = new System.Drawing.Point(307, 129);
            this.btnReplacingBooks.Name = "btnReplacingBooks";
            this.btnReplacingBooks.Size = new System.Drawing.Size(266, 49);
            this.btnReplacingBooks.TabIndex = 0;
            this.btnReplacingBooks.Text = "Replacing Books Game";
            this.btnReplacingBooks.UseVisualStyleBackColor = true;
            this.btnReplacingBooks.Click += new System.EventHandler(this.btnReplacingBooks_Click);
            // 
            // btnIdentifyingA
            // 
            this.btnIdentifyingA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdentifyingA.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.btnIdentifyingA.Location = new System.Drawing.Point(307, 184);
            this.btnIdentifyingA.Name = "btnIdentifyingA";
            this.btnIdentifyingA.Size = new System.Drawing.Size(266, 49);
            this.btnIdentifyingA.TabIndex = 1;
            this.btnIdentifyingA.Text = "Identifying Areas";
            this.btnIdentifyingA.UseVisualStyleBackColor = true;
            this.btnIdentifyingA.Click += new System.EventHandler(this.btnIdentifyingA_Click);
            // 
            // btnFindingCallNumbers
            // 
            this.btnFindingCallNumbers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindingCallNumbers.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.btnFindingCallNumbers.Location = new System.Drawing.Point(307, 239);
            this.btnFindingCallNumbers.Name = "btnFindingCallNumbers";
            this.btnFindingCallNumbers.Size = new System.Drawing.Size(266, 49);
            this.btnFindingCallNumbers.TabIndex = 2;
            this.btnFindingCallNumbers.Text = "Finding Call Numbers";
            this.btnFindingCallNumbers.UseVisualStyleBackColor = true;
            this.btnFindingCallNumbers.Click += new System.EventHandler(this.btnFindingCallNumbers_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(77, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(677, 74);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pick a Library Game";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnExitApp
            // 
            this.btnExitApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitApp.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.btnExitApp.Location = new System.Drawing.Point(307, 294);
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(266, 49);
            this.btnExitApp.TabIndex = 4;
            this.btnExitApp.Text = "Exit ";
            this.btnExitApp.UseVisualStyleBackColor = true;
            this.btnExitApp.Click += new System.EventHandler(this.btnExitApp_Click);
            // 
            // delayForm
            // 
            this.delayForm.Tick += new System.EventHandler(this.delayForm_Tick);
            // 
            // identifyingAreas
            // 
            this.identifyingAreas.Tick += new System.EventHandler(this.identifyingAreas_Tick);
            // 
            // findingCallNumbers
            // 
            this.findingCallNumbers.Tick += new System.EventHandler(this.findingCallNumbers_Tick);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Task_2_IMPLEMENTATION.Properties.Resources.bookcase_wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnExitApp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFindingCallNumbers);
            this.Controls.Add(this.btnIdentifyingA);
            this.Controls.Add(this.btnReplacingBooks);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReplacingBooks;
        private System.Windows.Forms.Button btnIdentifyingA;
        private System.Windows.Forms.Button btnFindingCallNumbers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExitApp;
        private System.Windows.Forms.Timer delayForm;
        private System.Windows.Forms.Timer identifyingAreas;
        private System.Windows.Forms.Timer findingCallNumbers;
    }
}

