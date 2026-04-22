using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GameMemoriLogic;

namespace GameMemori
{
    public partial class GameMemori : Form
    {
        private MemoryGame game;
        private Button[,] cardButtons;
        private PictureBox[,] cardPictures;
        private int buttonSize = 100;
        private int spacing = 15;
        private string currentTheme;
        private List<Image> themeImages = new List<Image>();

        private Panel[] playerPanels;
        private Label[] playerScoreLabels;
        private Label[] playerTimeLabels;
        private Label[] playerNameLabels;
        private Label[] playerTurnLabels;

        private int cols = 0;
        private int rows = 0;

        public GameMemori(GameMode mode, BoardSize size, string theme)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Load += GameMemori_Load;
            currentTheme = theme;
            LoadThemeImages();
            game = new MemoryGame(mode, size);
            SetupPlayerPanels();
            CreateGameBoard();
            UpdateUI();
            gameTimer.Start();
        }

        private void GameMemori_Load(object sender, EventArgs e)
        {
            CreateGameBoard();
        }

        private void LoadThemeImages()
        {
            string basePath = Application.StartupPath;
            string themePath = Path.Combine(basePath, "Images", currentTheme);

            if (!Directory.Exists(themePath))
            {
                MessageBox.Show($"Папка с изображениями не найдена: {themePath}\nБудут использованы эмодзи",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UseEmojiFallback();
                return;
            }

            var imageFiles = Directory.GetFiles(themePath, "*.jpg")
                .Concat(Directory.GetFiles(themePath, "*.png"))
                .Concat(Directory.GetFiles(themePath, "*.jpeg"))
                .ToList();

            if (imageFiles.Count == 0)
            {
                UseEmojiFallback();
                return;
            }

            foreach (var file in imageFiles)
            {
                try
                {
                    var img = Image.FromFile(file);
                    var resizedImg = new Bitmap(img, new Size(100, 100));
                    img.Dispose();
                    themeImages.Add(resizedImg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка загрузки {Path.GetFileName(file)}: {ex.Message}");
                }
            }

            if (themeImages.Count == 0)
            {
                UseEmojiFallback();
            }
        }

        private void UseEmojiFallback()
        {
            string[] emojis;
            switch (currentTheme)
            {
                case "OnePiece":
                    emojis = new[] { "🏴‍☠️", "👒", "🍖", "🗡️", "⚡", "❄️", "🔥", "🌊", "🐉", "🦒", "🦩", "🐺", "🦌", "🐱", "🐦", "🐙", "🍩", "🍺", "🍊", "⚓" };
                    break;
                case "JoJo":
                    emojis = new[] { "💎", "👊", "⭐", "💀", "🕺", "🎩", "🐍", "🦅", "⚡", "🔥", "💧", "🌪️", "🕰️", "💉", "🎲", "♠️", "♥️", "♣️", "♦️", "🔮" };
                    break;
                default:
                    emojis = new[] { "🏴‍☠️", "💎", "🍥", "👒", "⭐", "⚡", "🔥", "🌊", "🐉", "🦊", "🗡️", "🎩", "🕺", "🍜", "🌸", "✨", "🎮", "🌟", "⭐", "💫" };
                    break;
            }

            for (int i = 0; i < emojis.Length; i++)
            {
                var bmp = new Bitmap(100, 100);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.FromArgb(52, 73, 94));
                    using (Font font = new Font("Segoe UI Emoji", 50))
                    {
                        var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        g.DrawString(emojis[i], font, Brushes.White, new RectangleF(0, 0, 100, 100), sf);
                    }
                }
                themeImages.Add(bmp);
            }
        }

        private void SetupPlayerPanels()
        {
            flpPlayers.Controls.Clear();

            int playerCount = game.Players.Count;

            // Для режима Соло скрываем панели игроков
            if (game.CurrentGameMode == GameMode.Solo)
            {
                flpPlayers.Visible = false;
                return;
            }

            flpPlayers.Visible = true;

            playerPanels = new Panel[playerCount];
            playerScoreLabels = new Label[playerCount];
            playerTimeLabels = new Label[playerCount];
            playerNameLabels = new Label[playerCount];
            playerTurnLabels = new Label[playerCount];

            flpPlayers.FlowDirection = FlowDirection.LeftToRight;
            flpPlayers.WrapContents = false;
            flpPlayers.AutoScroll = true;
            flpPlayers.Dock = DockStyle.Fill;

            int panelWidth = 220;
            int panelHeight = 110;

            for (int i = 0; i < playerCount; i++)
            {
                var panel = new Panel
                {
                    Size = new Size(panelWidth, panelHeight),
                    BackColor = Color.FromArgb(44, 62, 80),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5)
                };

                playerTurnLabels[i] = new Label
                {
                    Text = "",
                    Location = new Point(5, 5),
                    Size = new Size(30, 30),
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Visible = false
                };

                playerNameLabels[i] = new Label
                {
                    Text = game.Players[i].Name,
                    Location = new Point(40, 5),
                    Size = new Size(170, 30),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                playerScoreLabels[i] = new Label
                {
                    Text = $"🏆 Очки: {game.Players[i].Score}",
                    Location = new Point(5, 40),
                    Size = new Size(205, 30),
                    ForeColor = Color.Yellow,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                playerTimeLabels[i] = new Label
                {
                    Text = $"⏱️ Время: {game.Players[i].TimeLeft}",
                    Location = new Point(5, 70),
                    Size = new Size(205, 30),
                    ForeColor = Color.LightGreen,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                panel.Controls.AddRange(new Control[] {
                    playerTurnLabels[i],
                    playerNameLabels[i],
                    playerScoreLabels[i],
                    playerTimeLabels[i]
                });

                playerPanels[i] = panel;
                flpPlayers.Controls.Add(panel);
            }
        }

        private void CreateGameBoard()
        {
            pnlGame.Controls.Clear();
            pnlGame.AutoScroll = false;
            pnlGame.Dock = DockStyle.Fill;

            switch (game.CurrentBoardSize)
            {
                case BoardSize.Small2x2: cols = 2; rows = 2; break;
                case BoardSize.Small2x4: cols = 4; rows = 2; break;
                case BoardSize.Medium4x4: cols = 4; rows = 4; break;
                case BoardSize.Large4x8: cols = 8; rows = 4; break;
                case BoardSize.ExtraLarge8x8: cols = 8; rows = 8; break;
            }

            int availableWidth = pnlGame.ClientSize.Width - 60;
            int availableHeight = pnlGame.ClientSize.Height - 60;

            int sizeByWidth = (availableWidth - spacing * (cols - 1)) / cols;
            int sizeByHeight = (availableHeight - spacing * (rows - 1)) / rows;

            buttonSize = Math.Min(sizeByWidth, sizeByHeight);
            buttonSize = Math.Max(buttonSize, 60);
            buttonSize = Math.Min(buttonSize, 120);

            cardButtons = new Button[rows, cols];
            cardPictures = new PictureBox[rows, cols];

            int totalWidth = cols * buttonSize + (cols - 1) * spacing;
            int totalHeight = rows * buttonSize + (rows - 1) * spacing;
            int startX = (pnlGame.ClientSize.Width - totalWidth) / 2;
            int startY = (pnlGame.ClientSize.Height - totalHeight) / 2;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int cardIndex = i * cols + j;

                    var panel = new Panel
                    {
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(startX + j * (buttonSize + spacing),
                                            startY + i * (buttonSize + spacing)),
                        BackColor = Color.FromArgb(52, 73, 94),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    var btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.FromArgb(52, 73, 94),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", buttonSize / 3, FontStyle.Bold),
                        Text = "?",
                        Tag = cardIndex
                    };
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += CardButton_Click;

                    var pic = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Visible = false,
                        BackColor = Color.FromArgb(241, 196, 15)
                    };

                    panel.Controls.Add(pic);
                    panel.Controls.Add(btn);
                    btn.BringToFront();

                    cardButtons[i, j] = btn;
                    cardPictures[i, j] = pic;
                    pnlGame.Controls.Add(panel);
                }
            }
        }

        private void CardButton_Click(object sender, EventArgs e)
        {
            if (game.IsGameFinished) return;
            if (game.IsWaitingForMatch) return;

            var btn = (Button)sender;
            int cardIndex = (int)btn.Tag;

            if (game.Cards[cardIndex].IsMatched) return;
            if (game.Cards[cardIndex].IsFlipped) return;

            game.SelectCard(cardIndex);
            UpdateBoard();

            if (game.IsWaitingForMatch && game.FirstSelectedCard != null && game.SecondSelectedCard != null)
            {
                if (game.FirstSelectedCard.PairId == game.SecondSelectedCard.PairId)
                {
                    UpdateBoard();
                    UpdateUI();

                    if (game.CheckGameFinished())
                    {
                        EndGame();
                    }
                }
                else
                {
                    var timer = new System.Windows.Forms.Timer();
                    timer.Interval = 800;
                    timer.Tick += (s, args) =>
                    {
                        game.ResetAfterMismatch();
                        UpdateBoard();
                        UpdateUI();
                        timer.Stop();
                    };
                    timer.Start();
                }
            }

            UpdateUI();

            if (game.CheckGameFinished())
            {
                EndGame();
            }
        }

        private void UpdateBoard()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int cardIndex = i * cols + j;
                    if (cardIndex >= game.Cards.Count) continue;

                    var card = game.Cards[cardIndex];
                    var btn = cardButtons[i, j];
                    var pic = cardPictures[i, j];

                    if (card.IsMatched)
                    {
                        btn.Visible = false;
                        pic.Visible = true;
                        if (themeImages.Count > 0)
                            pic.Image = themeImages[card.PairId % themeImages.Count];
                        pic.BackColor = Color.FromArgb(46, 204, 113);
                        btn.Enabled = false;
                    }
                    else if (card.IsFlipped)
                    {
                        btn.Visible = false;
                        pic.Visible = true;
                        if (themeImages.Count > 0)
                            pic.Image = themeImages[card.PairId % themeImages.Count];
                        pic.BackColor = Color.FromArgb(241, 196, 15);
                    }
                    else
                    {
                        btn.Visible = true;
                        pic.Visible = false;
                        btn.Text = "?";
                    }
                }
            }
        }

        private void UpdateUI()
        {
            if (game == null) return;

            // Режим СОЛО - показываем только время
            if (game.CurrentGameMode == GameMode.Solo)
            {
                // Скрываем все элементы, связанные с игроками и очками
                lblPlayerTitle.Visible = false;
                lblCurrentPlayer.Visible = false;
                lblScoresTitle.Visible = false;
                lblScores.Visible = false;
                flpPlayers.Visible = false;

                // Показываем только время
                lblTimerTitle.Text = "⏱️ Время прохождения:";
                var elapsed = game.GetElapsedTime();
                lblTimer.Text = $"{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
                lblTimer.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                lblTimer.ForeColor = Color.FromArgb(46, 204, 113);

                // Обновляем статус
                if (!game.IsGameFinished)
                {
                    lblStatus.Text = "🎮 Игра в процессе... Найди все пары!";
                }
            }
            else
            {
                // Режим с несколькими игроками - показываем всё
                lblPlayerTitle.Visible = true;
                lblCurrentPlayer.Visible = true;
                lblScoresTitle.Visible = true;
                lblScores.Visible = true;
                lblTimerTitle.Text = "⏱️ Времени осталось:";
                lblTimer.Font = new Font("Segoe UI", 16, FontStyle.Bold);

                if (!game.IsGameFinished)
                {
                    string currentPlayerName = game.Players[game.CurrentPlayerIndex].Name;
                    int currentPlayerTime = game.Players[game.CurrentPlayerIndex].TimeLeft;
                    lblCurrentPlayer.Text = currentPlayerName;
                    lblTimer.Text = $"{currentPlayerTime} сек";

                    lblCurrentPlayer.ForeColor = Color.FromArgb(46, 204, 113);

                    if (currentPlayerTime <= 5 && currentPlayerTime > 0)
                    {
                        lblTimer.ForeColor = Color.FromArgb(231, 76, 60);
                        lblTimer.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                    }
                    else
                    {
                        lblTimer.ForeColor = Color.FromArgb(241, 196, 15);
                        lblTimer.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                    }
                }

                // Обновляем информацию о всех игроках
                for (int i = 0; i < game.Players.Count; i++)
                {
                    if (i < playerPanels.Length && playerPanels[i] != null)
                    {
                        playerScoreLabels[i].Text = $"🏆 Очки: {game.Players[i].Score}";
                        playerTimeLabels[i].Text = $"⏱️ Время: {game.Players[i].TimeLeft}";

                        if (game.CurrentPlayerIndex == i && !game.IsGameFinished)
                        {
                            playerPanels[i].BackColor = Color.FromArgb(46, 204, 113);
                            playerTurnLabels[i].Text = "▶";
                            playerTurnLabels[i].Visible = true;
                            playerTurnLabels[i].ForeColor = Color.White;
                            playerNameLabels[i].ForeColor = Color.FromArgb(44, 62, 80);
                        }
                        else
                        {
                            playerPanels[i].BackColor = Color.FromArgb(44, 62, 80);
                            playerTurnLabels[i].Visible = false;
                            playerNameLabels[i].ForeColor = Color.White;
                        }

                        if (game.Players[i].TimeLeft <= 5 && game.Players[i].TimeLeft > 0)
                        {
                            playerTimeLabels[i].ForeColor = Color.FromArgb(231, 76, 60);
                        }
                        else
                        {
                            playerTimeLabels[i].ForeColor = Color.LightGreen;
                        }
                    }
                }

                lblScores.Text = game.Players[game.CurrentPlayerIndex].Score.ToString();
            }

            // Сообщение об окончании игры
            if (game.IsGameFinished && game.Winner != null)
            {
                gameTimer.Stop();
                string themeName = currentTheme == "OnePiece" ? "One Piece 🏴‍☠️" :
                                  (currentTheme == "JoJo" ? "JoJo 💎" : "Mix 🌟");

                if (game.CurrentGameMode == GameMode.Solo)
                {
                    var elapsed = game.GetElapsedTime();
                    lblStatus.Text = $"🎉 {themeName} | Поздравляем! Время: {elapsed.Minutes:D2}:{elapsed.Seconds:D2} 🎉";
                    lblTimer.Text = $"{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
                }
                else
                {
                    lblStatus.Text = $"🏆 {themeName} | ПОБЕДИТЕЛЬ: {game.Winner.Name} | Очки: {game.Winner.Score} 🏆";
                }
                lblStatus.ForeColor = Color.FromArgb(241, 196, 15);
                lblStatus.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (game == null || game.IsGameFinished) return;

            game.UpdateTimer();
            UpdateUI();

            if (game.CurrentGameMode != GameMode.Solo)
            {
                if (game.Players[game.CurrentPlayerIndex].TimeLeft <= 0 && !game.IsWaitingForMatch)
                {
                    game.ResetAfterMismatch();
                    UpdateBoard();
                    UpdateUI();

                    lblStatus.Text = $"⏰ Время вышло! Ход переходит к {game.Players[game.CurrentPlayerIndex].Name}";
                    lblStatus.ForeColor = Color.FromArgb(231, 76, 60);
                    var timer = new System.Windows.Forms.Timer();
                    timer.Interval = 2000;
                    timer.Tick += (s, args) =>
                    {
                        if (game.CurrentGameMode == GameMode.Solo)
                            lblStatus.Text = "🎮 Игра в процессе... Найди все пары!";
                        else
                            lblStatus.Text = "Игра продолжается!";
                        lblStatus.ForeColor = Color.FromArgb(52, 152, 219);
                        timer.Stop();
                    };
                    timer.Start();
                }
            }

            if (game.CurrentGameMode == GameMode.Solo)
            {
                UpdateUI();
            }
        }

        private void EndGame()
        {
            gameTimer.Stop();
            UpdateUI();

            string message;
            if (game.CurrentGameMode == GameMode.Solo)
            {
                var elapsed = game.GetElapsedTime();
                message = $"🎉 ПОЗДРАВЛЯЕМ! 🎉\n\nВы прошли игру за {elapsed.Minutes:D2}:{elapsed.Seconds:D2}\n\nХотите сыграть еще?";
            }
            else
            {
                message = $"🏆 ИГРА ОКОНЧЕНА! 🏆\n\nПобедитель: {game.Winner.Name}\nОчки победителя: {game.Winner.Score}\n\nХотите сыграть еще?";
            }

            DialogResult result = MessageBox.Show(message, "Игра окончена",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var selectionForm = new SelectionForm();
                if (selectionForm.ShowDialog() == DialogResult.OK)
                {
                    currentTheme = selectionForm.SelectedTheme;
                    themeImages.Clear();
                    LoadThemeImages();
                    game = new MemoryGame(selectionForm.SelectedMode, selectionForm.SelectedSize);
                    SetupPlayerPanels();
                    CreateGameBoard();
                    UpdateUI();
                    gameTimer.Start();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();
            DialogResult result = MessageBox.Show("Начать новую игру?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var selectionForm = new SelectionForm();
                if (selectionForm.ShowDialog() == DialogResult.OK)
                {
                    currentTheme = selectionForm.SelectedTheme;
                    themeImages.Clear();
                    LoadThemeImages();
                    game = new MemoryGame(selectionForm.SelectedMode, selectionForm.SelectedSize);
                    SetupPlayerPanels();
                    CreateGameBoard();
                    UpdateUI();
                    gameTimer.Start();
                }
            }
            else
            {
                gameTimer.Start();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (game != null && cardButtons != null)
            {
                CreateGameBoard();
                UpdateBoard();
            }
        }
    }
}