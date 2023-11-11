namespace Task_2_IMPLEMENTATION.GameForms
{
    partial class ReplaceBooksForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_achievement = new System.Windows.Forms.Label();
            this.btnCheckOrder = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.bookShelf = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExitApplication = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(156, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(488, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Replacing Book Game";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_achievement
            // 
            this.lbl_achievement.AutoSize = true;
            this.lbl_achievement.BackColor = System.Drawing.Color.Transparent;
            this.lbl_achievement.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_achievement.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_achievement.Location = new System.Drawing.Point(84, 171);
            this.lbl_achievement.Name = "lbl_achievement";
            this.lbl_achievement.Size = new System.Drawing.Size(107, 37);
            this.lbl_achievement.TabIndex = 1;
            this.lbl_achievement.Text = "Level";
            // 
            // btnCheckOrder
            // 
            this.btnCheckOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOrder.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOrder.Location = new System.Drawing.Point(253, 220);
            this.btnCheckOrder.Name = "btnCheckOrder";
            this.btnCheckOrder.Size = new System.Drawing.Size(167, 49);
            this.btnCheckOrder.TabIndex = 3;
            this.btnCheckOrder.Text = "Check Order";
            this.btnCheckOrder.UseVisualStyleBackColor = true;
            this.btnCheckOrder.Click += new System.EventHandler(this.btnCheckOrder_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Showcard Gothic", 10.8F);
            this.btnMenu.Location = new System.Drawing.Point(426, 220);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(141, 49);
            this.btnMenu.TabIndex = 4;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(27, 71);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(742, 24);
            this.progressBar.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(92, 220);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(155, 49);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Font = new System.Drawing.Font("Showcard Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTimer.Location = new System.Drawing.Point(84, 116);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(126, 42);
            this.lblTimer.TabIndex = 7;
            this.lblTimer.Text = "Timer";
            // 
            // bookShelf
            // 
            this.bookShelf.AllowDrop = true;
            this.bookShelf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(12)))));
            this.bookShelf.BackgroundImage = global::Task_2_IMPLEMENTATION.Properties.Resources.BookShelfBackGround;
            this.bookShelf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bookShelf.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.bookShelf.Location = new System.Drawing.Point(73, 339);
            this.bookShelf.Name = "bookShelf";
            this.bookShelf.Size = new System.Drawing.Size(649, 236);
            this.bookShelf.TabIndex = 8;
            this.bookShelf.DragDrop += new System.Windows.Forms.DragEventHandler(this.bookShelf_DragDrop);
            this.bookShelf.DragEnter += new System.Windows.Forms.DragEventHandler(this.bookShelf_DragEnter);
            // 
            // btnExitApplication
            // 
            this.btnExitApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitApplication.Font = new System.Drawing.Font("Showcard Gothic", 10.8F);
            this.btnExitApplication.Location = new System.Drawing.Point(573, 220);
            this.btnExitApplication.Name = "btnExitApplication";
            this.btnExitApplication.Size = new System.Drawing.Size(141, 49);
            this.btnExitApplication.TabIndex = 9;
            this.btnExitApplication.Text = "Exit App";
            this.btnExitApplication.UseVisualStyleBackColor = true;
            this.btnExitApplication.Click += new System.EventHandler(this.btnExitApplication_Click);
            // 
            // ReplaceBooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Task_2_IMPLEMENTATION.Properties.Resources.bookcase_wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(794, 604);
            this.ControlBox = false;
            this.Controls.Add(this.btnExitApplication);
            this.Controls.Add(this.bookShelf);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnCheckOrder);
            this.Controls.Add(this.lbl_achievement);
            this.Controls.Add(this.label1);
            this.Name = "ReplaceBooksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replace Books Form";
            this.Load += new System.EventHandler(this.ReplaceBooksForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_achievement;
        private System.Windows.Forms.Button btnCheckOrder;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.FlowLayoutPanel bookShelf;
        private System.Windows.Forms.Button btnExitApplication;
    }
}