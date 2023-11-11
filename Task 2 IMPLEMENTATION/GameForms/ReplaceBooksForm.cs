using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Task_2_IMPLEMENTATION.Controls;

namespace Task_2_IMPLEMENTATION.GameForms
{
    public partial class ReplaceBooksForm : Form
    {
        // Constants for achievements.
        private string[] ACHIEVEMENTS = new string[3]
        {
            "LEVEL: Sorting Novice!",
            "LEVEL: Sorting Pro!",
            "LEVEL: Sorting Master!",
        };

        //User lavel count to zero. 
        private int successfulSorts = 0;

        // List to store the call numbers.
        private List<string> callNumbers = new List<string>();

        // Create a sorted list from the initial list of labels.
        private List<string> sortedOrder = new List<string>();

        // String to store the current achievement.
        private string currentAchievement = "";

        // Timer for the game countdown.
        private Timer gameTimer = new Timer();

        // set game timer to 1 minute.
        private int timeLeft = 60;

        /// <summary>
        /// Initializes a new instance of the ReplaceBooksForm class.
        /// </summary>
        public ReplaceBooksForm()
        {
            InitializeComponent();

            InitializeComponents();
        }

        /// <summary>
        /// Initialize all the components. 
        /// </summary>
        private void InitializeComponents()
        {
            // Create a sorted version of the call numbers for comparison
            this.sortedOrder = new List<string>(this.callNumbers);
            this.sortedOrder.Sort();

            // Prevent resizing and disable maximize button
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Initialize the timer
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += timer1_Tick;

            // Initial UI setup
            lbl_achievement.Text = "USER SORTING LEVEL.";
            lblTimer.Text = "CLICK START TO BEGIN.";
            bookShelf.AllowDrop = false;
            btnCheckOrder.Enabled = false;

            UpdateProgressBar();
        }

        /// <summary>
        /// Handles the Load event for the ReplaceBooksForm.
        /// Sets the background image for the form.
        /// </summary>
        private void ReplaceBooksForm_Load(object sender, EventArgs e)
        {
            // Call the method to generate call numbers
            CreateCallNumbers();

            for (var i = 0; i < 10; i++)
            {
                var label = new Label();
                label.Text = callNumbers[i];
                // Set the font size and color
                label.Font = new Font(label.Font.FontFamily, 8, FontStyle.Bold);

                // Check if the index is within the bounds of the bookSizes array
                if (i < bookSizes.Length)
                {
                    // Set the size based on the array
                    label.Width = bookSizes[i].Width;
                    label.Height = bookSizes[i].Height;
                }

                // Specify a bright background color
                Color[] brightColors = new Color[10]
                {
                        Color.FromArgb(204, 204, 0),     
                        Color.FromArgb(204, 0, 204),     
                        Color.FromArgb(0, 204, 204),    
                        Color.FromArgb(204, 0, 0),       
                        Color.FromArgb(0, 204, 0),      
                        Color.FromArgb(0, 0, 204),     
                        Color.FromArgb(204, 204, 204),  
                        Color.FromArgb(204, 102, 0),  
                        Color.FromArgb(102, 0, 204),    
                        Color.FromArgb(0, 102, 102)  
                };

                // Stretch the background image to fit the label's dimensions
                label.BackgroundImageLayout = ImageLayout.Stretch;
                label.BackColor = brightColors[i];
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Margin = new Padding(0);
                label.MouseDown += Label_MouseDown;
                bookShelf.Controls.Add(label);
            }

            bookShelf.DragEnter += bookShelf_DragEnter;
            bookShelf.DragDrop += bookShelf_DragDrop;
        }

        /// <summary>
        /// Generates random call numbers for the game.
        /// </summary>
        private void CreateCallNumbers()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var number = random.Next(100, 999);
                var letter = (char)random.Next(65, 90); // ASCII values for A-Z
                var callNumber = $"{number}.{random.Next(10, 99)} {letter}{letter}{letter}";

                callNumbers.Add(callNumber);
            }
        }

        /// <summary>
        ///  Method to fomat time. 
        /// </summary> 
        private string FormatTime(int totalSeconds)
        {
            var minutes = totalSeconds / 60;
            var seconds = totalSeconds % 60;
            return $"{minutes:00}:{seconds:00}";
        }

        /// <summary>
        /// Checks and updates achievements based on successful sorts.
        /// </summary>
        private void CheckAchievements()
        {
            switch (successfulSorts)
            {
                case 1:
                    currentAchievement = ACHIEVEMENTS[0];
                    break;
                case 5:
                    currentAchievement = ACHIEVEMENTS[1];
                    break;
                case 10:
                    currentAchievement = ACHIEVEMENTS[2];
                    break;
            }
            lbl_achievement.Text = currentAchievement;
        }

        /// <summary>
        /// Updates the progress bar based on the number of items in the correct order.
        /// </summary>
        private void UpdateProgressBar()
        {
            var correctOrderCount = 0;

            // Create a list to store the current order of labels in the bookShelf control
            List<string> currentOrder = new List<string>();
            foreach (Label label in bookShelf.Controls)
            {
                currentOrder.Add(label.Text);
            }

            // Compare the current order with the sorted order to determine the correct order count
            for (var i = 0; i < sortedOrder.Count; i++)
            {
                if (sortedOrder[i] == currentOrder[i])
                {
                    correctOrderCount++;
                }
            }

            // Calculate progress as a percentage
            var progress = (int)(((double)correctOrderCount / sortedOrder.Count) * 100);

            // Ensure the progress value is between 0 and 100
            progress = Math.Max(0, Math.Min(100, progress));

            progressBar.Value = progress;
        }

        /// <summary>
        ///  Event handler to check order of the ListBox
        /// </summary> 
        private void btnCheckOrder_Click(object sender, EventArgs e)
        {
            bool isCorrectOrder = true;

            // Compare the sorted list with the user's list
            for (int i = 0; i < sortedOrder.Count; i++)
            {
                if (sortedOrder[i] != bookShelf.Controls[i].Text)
                {
                    isCorrectOrder = false;
                    break;
                }
            }

            // Check if the order is correct and update achievements
            if (isCorrectOrder)
            {
                bookShelf.AllowDrop = false;

                // Restart the game timer
                gameTimer.Stop();
                lblTimer.ForeColor = Color.Green;
                btnStart.Enabled = true;

                successfulSorts++;
                CheckAchievements();
                MessageBox.Show("Correct order! " + currentAchievement);

                // Restart the game
                progressBar.Value = 0;

                btnCheckOrder.Enabled = false;
            }
            else
            {
                MessageBox.Show("Incorrect order. Try again!");
            }
        }

        /// <summary>
        ///  Event handler to set timer 
        /// </summary> 
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblTimer.Text = FormatTime(timeLeft);

            // if time it 0 the user loses the game
            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                lblTimer.ForeColor = Color.Red;
                lblTimer.Text="Time's up! You lost.";
                btnCheckOrder.Enabled = false;
                bookShelf.AllowDrop = false;
                btnStart.Enabled = true;
            }
        }

        /// <summary>
        ///  Event handler to Start the game
        /// </summary> 
        private void btnStart_Click(object sender, EventArgs e)
        {
            SoundsControl.PlayButtonSoundEffect();
            // Reset the timer

            timeLeft = 60;
            lblTimer.Text = FormatTime(timeLeft);
            gameTimer.Start();
            lblTimer.ForeColor = Color.White;

            // Clear the current call numbers and regenerate them
            callNumbers.Clear();
            CreateCallNumbers();

            for (int i = 0; i < bookShelf.Controls.Count; i++)
            {
                bookShelf.Controls[i].Text = callNumbers[i];
            }

            // Create a sorted version of the call numbers for comparison
            sortedOrder = new List<string>(callNumbers);
            sortedOrder.Sort();

            // Reset the progress bar
            progressBar.Value = 0;

            // Reset achievements
            successfulSorts = 0;
            lbl_achievement.Text = "USER ACHIEVEMENT";

            // Enable/Disable necessary controls
            bookShelf.AllowDrop = true;
            btnCheckOrder.Enabled = true;
            btnStart.Enabled = false;
        }

        /// <summary>
        ///  Event handler to go the Menu form.
        /// </summary> 
        private void btnMenu_Click(object sender, EventArgs e)
        {
            SoundsControl.PlayButtonSoundEffect();
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        /// <summary>
        /// Event handler handle book movement.
        /// </summary>
        private void bookShelf_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Label)) != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        /// <summary>
        /// Event handler to handle drag and drop.
        /// </summary>
        private void bookShelf_DragDrop(object sender, DragEventArgs e)
        {
            var label = e.Data.GetData(typeof(Label)) as Label;
            Point droppedBookLocation = bookShelf.PointToClient(new Point(e.X, e.Y));
            var bookUnderCursor = bookShelf.GetChildAtPoint(droppedBookLocation);

            if (label != null && bookUnderCursor != null)
            {
                int indexOfBookUnderCursor = bookShelf.Controls.GetChildIndex(bookUnderCursor);
                bookShelf.Controls.SetChildIndex(label, indexOfBookUnderCursor);
            }

            UpdateProgressBar();
        }

        /// <summary>
        /// Event handler to handle drag and drop.
        /// </summary>
        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                DoDragDrop(label, DragDropEffects.Move);
                SoundsControl.DropBookSoundEffect();
            }
        }

        /// <summary>
        /// Event handler to define an array or list to store book sizes.
        /// </summary>
        private Size[] bookSizes = new Size[10]
        {
            new Size(49, 140),  
            new Size(49, 130),
            new Size(49, 155),
            new Size(49, 135),
            new Size(49, 120),
            new Size(49, 110),
            new Size(49, 160),
            new Size(49, 145),
            new Size(49, 125),
            new Size(49, 150),
        };

        /// <summary>
        /// Event handler to define the the game exit button.
        /// </summary>
        private void btnExitApplication_Click(object sender, EventArgs e)
        {
            SoundsControl.PlayButtonSoundEffect();
            Application.Exit();
        }
    }
}