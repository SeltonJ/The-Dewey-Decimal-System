namespace Task_2_IMPLEMENTATION.GameForms
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.label1 = new System.Windows.Forms.Label();
            this.goToMenu = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.mxp = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.mxp)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(96, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(632, 74);
            this.label1.TabIndex = 0;
            this.label1.Text = "The Library Games";
            // 
            // goToMenu
            // 
            this.goToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goToMenu.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.goToMenu.Location = new System.Drawing.Point(266, 166);
            this.goToMenu.Name = "goToMenu";
            this.goToMenu.Size = new System.Drawing.Size(266, 49);
            this.goToMenu.TabIndex = 1;
            this.goToMenu.Text = "Games";
            this.goToMenu.UseVisualStyleBackColor = true;
            this.goToMenu.Click += new System.EventHandler(this.goToMenu_Click);
            // 
            // exit
            // 
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.exit.Location = new System.Drawing.Point(266, 221);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(266, 49);
            this.exit.TabIndex = 2;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // mxp
            // 
            this.mxp.Enabled = true;
            this.mxp.Location = new System.Drawing.Point(662, 212);
            this.mxp.Name = "mxp";
            this.mxp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mxp.OcxState")));
            this.mxp.Size = new System.Drawing.Size(10, 15);
            this.mxp.TabIndex = 8;
            this.mxp.Visible = false;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Task_2_IMPLEMENTATION.Properties.Resources.bookcase_wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.mxp);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.goToMenu);
            this.Controls.Add(this.label1);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome page. ";
            ((System.ComponentModel.ISupportInitialize)(this.mxp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button goToMenu;
        private System.Windows.Forms.Button exit;
        private AxWMPLib.AxWindowsMediaPlayer mxp;
    }
}