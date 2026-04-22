namespace GameMemori
{
    partial class SelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpMode;
        private System.Windows.Forms.RadioButton rbSolo;
        private System.Windows.Forms.RadioButton rbOneVsOne;
        private System.Windows.Forms.RadioButton rbFourPlayers;
        private System.Windows.Forms.GroupBox grpSize;
        private System.Windows.Forms.RadioButton rb2x2;
        private System.Windows.Forms.RadioButton rb2x4;
        private System.Windows.Forms.RadioButton rb4x4;
        private System.Windows.Forms.RadioButton rb4x8;
        private System.Windows.Forms.RadioButton rb8x8;
        private System.Windows.Forms.GroupBox grpTheme;
        private System.Windows.Forms.RadioButton rbOnePiece;
        private System.Windows.Forms.RadioButton rbJoJo;
        private System.Windows.Forms.RadioButton rbMix;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlBackground = new Panel();
            btnExit = new Button();
            btnStart = new Button();
            grpTheme = new GroupBox();
            rbMix = new RadioButton();
            rbJoJo = new RadioButton();
            rbOnePiece = new RadioButton();
            grpSize = new GroupBox();
            rb8x8 = new RadioButton();
            rb4x8 = new RadioButton();
            rb4x4 = new RadioButton();
            rb2x4 = new RadioButton();
            rb2x2 = new RadioButton();
            grpMode = new GroupBox();
            rbFourPlayers = new RadioButton();
            rbOneVsOne = new RadioButton();
            rbSolo = new RadioButton();
            lblTitle = new Label();
            pnlBackground.SuspendLayout();
            grpTheme.SuspendLayout();
            grpSize.SuspendLayout();
            grpMode.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBackground
            // 
            pnlBackground.BackColor = Color.FromArgb(44, 62, 80);
            pnlBackground.Controls.Add(btnExit);
            pnlBackground.Controls.Add(btnStart);
            pnlBackground.Controls.Add(grpTheme);
            pnlBackground.Controls.Add(grpSize);
            pnlBackground.Controls.Add(grpMode);
            pnlBackground.Controls.Add(lblTitle);
            pnlBackground.Dock = DockStyle.Fill;
            pnlBackground.Location = new Point(0, 0);
            pnlBackground.Name = "pnlBackground";
            pnlBackground.Size = new Size(950, 550);
            pnlBackground.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(231, 76, 60);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(500, 470);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(150, 50);
            btnExit.TabIndex = 5;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += BtnExit_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(46, 204, 113);
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(320, 470);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(150, 50);
            btnStart.TabIndex = 4;
            btnStart.Text = "Начать игру";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStart_Click;
            // 
            // grpTheme
            // 
            grpTheme.BackColor = Color.FromArgb(52, 73, 94);
            grpTheme.Controls.Add(rbMix);
            grpTheme.Controls.Add(rbJoJo);
            grpTheme.Controls.Add(rbOnePiece);
            grpTheme.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpTheme.ForeColor = Color.White;
            grpTheme.Location = new Point(650, 110);
            grpTheme.Name = "grpTheme";
            grpTheme.Size = new Size(260, 200);
            grpTheme.TabIndex = 3;
            grpTheme.TabStop = false;
            grpTheme.Text = "Выберите вселенную";
            // 
            // rbMix
            // 
            rbMix.AutoSize = true;
            rbMix.Font = new Font("Segoe UI", 9F);
            rbMix.Location = new Point(20, 130);
            rbMix.Name = "rbMix";
            rbMix.Size = new Size(54, 24);
            rbMix.TabIndex = 2;
            rbMix.Text = "Mix";
            rbMix.UseVisualStyleBackColor = true;
            // 
            // rbJoJo
            // 
            rbJoJo.AutoSize = true;
            rbJoJo.Font = new Font("Segoe UI", 9F);
            rbJoJo.Location = new Point(20, 90);
            rbJoJo.Name = "rbJoJo";
            rbJoJo.Size = new Size(117, 24);
            rbJoJo.TabIndex = 1;
            rbJoJo.Text = "JoJo's Bizarre";
            rbJoJo.UseVisualStyleBackColor = true;
            // 
            // rbOnePiece
            // 
            rbOnePiece.AutoSize = true;
            rbOnePiece.Checked = true;
            rbOnePiece.Font = new Font("Segoe UI", 9F);
            rbOnePiece.Location = new Point(20, 50);
            rbOnePiece.Name = "rbOnePiece";
            rbOnePiece.Size = new Size(96, 24);
            rbOnePiece.TabIndex = 0;
            rbOnePiece.TabStop = true;
            rbOnePiece.Text = "One Piece";
            rbOnePiece.UseVisualStyleBackColor = true;
            // 
            // grpSize
            // 
            grpSize.BackColor = Color.FromArgb(52, 73, 94);
            grpSize.Controls.Add(rb8x8);
            grpSize.Controls.Add(rb4x8);
            grpSize.Controls.Add(rb4x4);
            grpSize.Controls.Add(rb2x4);
            grpSize.Controls.Add(rb2x2);
            grpSize.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpSize.ForeColor = Color.White;
            grpSize.Location = new Point(340, 110);
            grpSize.Name = "grpSize";
            grpSize.Size = new Size(280, 200);
            grpSize.TabIndex = 2;
            grpSize.TabStop = false;
            grpSize.Text = "Размер поля";
            // 
            // rb8x8
            // 
            rb8x8.AutoSize = true;
            rb8x8.Font = new Font("Segoe UI", 9F);
            rb8x8.Location = new Point(20, 170);
            rb8x8.Name = "rb8x8";
            rb8x8.Size = new Size(128, 24);
            rb8x8.TabIndex = 4;
            rb8x8.Text = "8x8 (64 карты)";
            rb8x8.UseVisualStyleBackColor = true;
            // 
            // rb4x8
            // 
            rb4x8.AutoSize = true;
            rb4x8.Font = new Font("Segoe UI", 9F);
            rb4x8.Location = new Point(20, 130);
            rb4x8.Name = "rb4x8";
            rb4x8.Size = new Size(128, 24);
            rb4x8.TabIndex = 3;
            rb4x8.Text = "4x8 (32 карты)";
            rb4x8.UseVisualStyleBackColor = true;
            // 
            // rb4x4
            // 
            rb4x4.AutoSize = true;
            rb4x4.Checked = true;
            rb4x4.Font = new Font("Segoe UI", 9F);
            rb4x4.Location = new Point(20, 90);
            rb4x4.Name = "rb4x4";
            rb4x4.Size = new Size(117, 24);
            rb4x4.TabIndex = 2;
            rb4x4.TabStop = true;
            rb4x4.Text = "4x4 (16 карт)";
            rb4x4.UseVisualStyleBackColor = true;
            // 
            // rb2x4
            // 
            rb2x4.AutoSize = true;
            rb2x4.Font = new Font("Segoe UI", 9F);
            rb2x4.Location = new Point(20, 59);
            rb2x4.Name = "rb2x4";
            rb2x4.Size = new Size(109, 24);
            rb2x4.TabIndex = 1;
            rb2x4.Text = "2x4 (8 карт)";
            rb2x4.UseVisualStyleBackColor = true;
            rb2x4.CheckedChanged += rb2x4_CheckedChanged;
            // 
            // rb2x2
            // 
            rb2x2.AutoSize = true;
            rb2x2.Font = new Font("Segoe UI", 9F);
            rb2x2.Location = new Point(20, 29);
            rb2x2.Name = "rb2x2";
            rb2x2.Size = new Size(120, 24);
            rb2x2.TabIndex = 0;
            rb2x2.Text = "2x2 (4 карты)";
            rb2x2.UseVisualStyleBackColor = true;
            // 
            // grpMode
            // 
            grpMode.BackColor = Color.FromArgb(52, 73, 94);
            grpMode.Controls.Add(rbFourPlayers);
            grpMode.Controls.Add(rbOneVsOne);
            grpMode.Controls.Add(rbSolo);
            grpMode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpMode.ForeColor = Color.White;
            grpMode.Location = new Point(30, 110);
            grpMode.Name = "grpMode";
            grpMode.Size = new Size(280, 200);
            grpMode.TabIndex = 1;
            grpMode.TabStop = false;
            grpMode.Text = "Режим игры";
            // 
            // rbFourPlayers
            // 
            rbFourPlayers.AutoSize = true;
            rbFourPlayers.Font = new Font("Segoe UI", 9F);
            rbFourPlayers.Location = new Point(20, 140);
            rbFourPlayers.Name = "rbFourPlayers";
            rbFourPlayers.Size = new Size(125, 24);
            rbFourPlayers.TabIndex = 2;
            rbFourPlayers.Text = "1 vs 1 vs 1 vs 1";
            rbFourPlayers.UseVisualStyleBackColor = true;
            // 
            // rbOneVsOne
            // 
            rbOneVsOne.AutoSize = true;
            rbOneVsOne.Font = new Font("Segoe UI", 9F);
            rbOneVsOne.Location = new Point(20, 90);
            rbOneVsOne.Name = "rbOneVsOne";
            rbOneVsOne.Size = new Size(67, 24);
            rbOneVsOne.TabIndex = 1;
            rbOneVsOne.Text = "1 vs 1";
            rbOneVsOne.UseVisualStyleBackColor = true;
            // 
            // rbSolo
            // 
            rbSolo.AutoSize = true;
            rbSolo.Checked = true;
            rbSolo.Font = new Font("Segoe UI", 9F);
            rbSolo.Location = new Point(20, 50);
            rbSolo.Name = "rbSolo";
            rbSolo.Size = new Size(65, 24);
            rbSolo.TabIndex = 0;
            rbSolo.TabStop = true;
            rbSolo.Text = "Соло";
            rbSolo.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(241, 196, 15);
            lblTitle.Location = new Point(250, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(509, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Anime Memory Game";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SelectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 550);
            Controls.Add(pnlBackground);
            Name = "SelectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anime Memory Game - Выбор режима";
            pnlBackground.ResumeLayout(false);
            pnlBackground.PerformLayout();
            grpTheme.ResumeLayout(false);
            grpTheme.PerformLayout();
            grpSize.ResumeLayout(false);
            grpSize.PerformLayout();
            grpMode.ResumeLayout(false);
            grpMode.PerformLayout();
            ResumeLayout(false);
        }
    }
}