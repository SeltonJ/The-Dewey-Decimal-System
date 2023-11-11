using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Task_2_IMPLEMENTATION.Controls;

/// <summary>
/// I useed the sourcers to do this project.
/// Warren, L. (2022, 12 20). Match the columns using a data dictionary in C# winForm. Retrieved from StackOverflow
/// ChatGPT4 to help me the the following methods:
/// checkIdentifiedAreas_Click()
/// ShuffleAndDisplay()
/// </summary>

namespace Task_2_IMPLEMENTATION.GameForms
{
    public partial class IdentifyingAreasForm : Form
    {
        private Dictionary<string, string> categories;
        private Dictionary<string, string> shuffledCategories;
        private Timer gameTimer;
        private Random random = new Random();
        private int remainingTime = 300;
        private bool isMatchingDescriptionToCallNumber = true;
        private int score = 0;

        /// <summary>
        /// Initialize all the components. 
        /// </summary>
        public IdentifyingAreasForm()
        {
            InitializeComponent();
            InitializeCategories();
            //ShuffleAndDisplay();
            InitializeTimer();
            DisableAllComboBoxes();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            DisableButtons();
            ToggleQuestionType();
            SetComboBoxesToDropDownList();
        }

        /// <summary>
        /// Method making all the combo boxes not no editable by the user.
        /// </summary>
        private void SetComboBoxesToDropDownList()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        /// <summary>
        /// Toggles the question type between matching description to call number and vice versa.
        /// After toggling, it reshuffles and displays the categories accordingly.
        /// </summary>
        private void ToggleQuestionType()
        {
            isMatchingDescriptionToCallNumber = !isMatchingDescriptionToCallNumber;
            ShuffleAndDisplay();
        }

        /// <summary>
        /// Enables the game-related buttons: Hint, Check Identified Areas, and Finish.
        /// </summary>
        private void EnableButtons()
        {
            btnHint.Enabled = true;
            checkIdentifiedAreas.Enabled = true;
            btn_Finish.Enabled = true;
        }

        /// <summary>
        /// Disables the game-related buttons: Hint, Check Identified Areas, and Finish.
        /// </summary>
        private void DisableButtons()
        {
            btnHint.Enabled = false;
            checkIdentifiedAreas.Enabled = false;
            btn_Finish.Enabled = false;
        }

        /// <summary>
        /// Initializes the game timer with a one-second interval and sets the initial display time.
        /// </summary>
        private void InitializeTimer()
        {
            gameTimer = new Timer();
            gameTimer.Interval = 1000;  // One second interval
            gameTimer.Tick += timer_Tick;

            timeLabel.Text = $"{remainingTime / 60}m {remainingTime % 60}s";
        }

        /// <summary>
        /// Initializes the dictionary of categories with their respective call numbers and descriptions.
        /// </summary>
        private void InitializeCategories()
        {
            categories = new Dictionary<string, string>
            {
                { "000-099", "Computer Science, and Information" },
                { "100-199", "Philosophy and Psychology" },
                { "200-299", "Religion" },
                { "300-399", "Social Sciences" },
                { "400-499", "Language" },
                { "500-599", "Natural Sciences and Mathematics" },
                { "600-699", "Technology" },
                { "700-799", "Generalities" }
            };
        }

        /// <summary>
        /// Shuffles the given dictionary of categories.
        /// </summary>
        /// <param name="categories">The dictionary of categories to shuffle.</param>
        /// <returns>A shuffled dictionary of categories.</returns>
        private Dictionary<string, string> ShuffleCategories(Dictionary<string, string> categories)
        {
            var random = new Random();
            return categories.OrderBy(x => random.Next()).ToDictionary(item => item.Key, item => item.Value);
        }

        /// <summary>
        /// Shuffles the categories and displays the first four in the UI.
        /// Populates the ComboBoxes with 4 correct and 3 incorrect answers.
        /// </summary>
        private void ShuffleAndDisplay()
        {
            if (categories == null || !categories.Any())
            {
                MessageBox.Show("No categories available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Shuffle the categories
            shuffledCategories = ShuffleCategories(categories);

            // Take the first four categories as your items
            var selectedCategories = shuffledCategories.Take(4).ToList();

            // Populate the ComboBoxes
            for (int i = 0; i < 4; i++)
            {
                var label = (Label)this.Controls["label" + (i + 1)];
                label.Text = selectedCategories[i].Key;  // Display the call number

                var comboBox = (ComboBox)this.Controls["comboBox" + (i + 1)];
                comboBox.Items.Clear();

                // Add the correct answer
                comboBox.Items.Add(selectedCategories[i].Value);

                // Add the other three correct answers
                var otherCorrectAnswers = shuffledCategories.Where(c => c.Key != selectedCategories[i].Key).Select(c => c.Value).Take(3).ToList();
                foreach (var answer in otherCorrectAnswers)
                {
                    comboBox.Items.Add(answer);
                }

                // Add three random incorrect answers
                var incorrectAnswers = categories.Where(c => !selectedCategories.Contains(c)).Select(c => c.Value).Take(3).ToList();
                foreach (var answer in incorrectAnswers)
                {
                    comboBox.Items.Add(answer);
                }

                // Shuffle the ComboBox items
                var items = comboBox.Items.Cast<string>().OrderBy(x => random.Next()).ToList();
                comboBox.Items.Clear();
                foreach (var item in items)
                {
                    comboBox.Items.Add(item);
                }
            }
        }


        /// <summary>
        /// Determines the rank of the user based on the number of correct answers.
        /// </summary>
        /// <param name="correctAnswers">The number of correct answers provided by the user.</param>
        /// <returns>A string representing the user's rank.</returns>
        private string GetRank(int correctAnswers)
        {
            switch (correctAnswers)
            {
                case 9:
                case 10:
                    return "Excellent";
                case 7:
                case 8:
                    return "Very Good";
                case 5:
                case 6:
                    return "Good";
                case 3:
                case 4:
                    return "Average";
                case 1:
                case 2:
                    return "Poor";
                default:
                    return "Very Poor";
            }
        }

        /// <summary>
        /// Event handler for the "checkIdentifiedAreas" button click.
        /// Validates the user's answers, provides feedback, and updates the game state.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void checkIdentifiedAreas_Click(object sender, EventArgs e)
        {
            try
            {
                SoundsControl.PlayButtonSoundEffect();

                int correct = 0;

                ComboBox[] comboBoxes = new ComboBox[] { comboBox1, comboBox2, comboBox3, comboBox4 };

                // Check if any ComboBox has no selected item
                foreach (var comboBox in comboBoxes)
                {
                    if (comboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Please make sure all dropdowns have a selection.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Exit the method early
                    }
                }

                // Ensure shuffledCategories is not null and has at least 4 entries
                if (shuffledCategories == null || shuffledCategories.Count < 4)
                {
                    MessageBox.Show("An error occurred: Insufficient categories.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selectedCategories = shuffledCategories.Take(4).ToList();

                for (int i = 0; i < 4; i++)
                {
                    // Check if the selected item is one of the correct answers
                    var correctAnswers = categories.Where(c => c.Key != selectedCategories[i].Key).Select(c => c.Value).Take(3).ToList();
                    correctAnswers.Add(selectedCategories[i].Value); // Add the main correct answer

                    if (correctAnswers.Contains(comboBoxes[i].SelectedItem.ToString()))
                    {
                        correct++;
                    }
                }

                if (correct == 4)
                {
                    //give the user more 40 seconds if they win.
                    remainingTime += 40;
                    string rank = GetRank(correct);
                    resultLabel.Text = $"Congratulations! You won! Rank: {rank}.";
                    ShuffleAndDisplay(); // Move to the next question
                }
                else
                {
                    MessageBox.Show($"You got {correct} out of 4 right!", "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions and display a message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        /// Event handler to define the the game exit button.
        /// </summary>
        private void btnExitApplication_Click(object sender, EventArgs e)
        {
            SoundsControl.PlayButtonSoundEffect();
            Application.Exit();
        }

        /// <summary>
        /// Resets the game state to its initial configuration, allowing the user to start a new game.
        /// </summary>
        private void RestartGame()
        {
            remainingTime = 300; // reset the time to 5 minutes
            timeLabel.Text = $"{remainingTime / 60}m {remainingTime % 60}s";
            timeLabel.ForeColor = Color.White; // reset label color

            btnStart.Enabled = true;

            ShuffleAndDisplay();
            DisableAllComboBoxes();
            resultLabel.Text = "Results"; // reset result label
            resultLabel.ForeColor = Color.White;

            gameTimer.Stop(); // make sure the timer is stopped before a new game starts
        }

        /// <summary>
        /// Disables all the ComboBox controls in the game interface.
        /// </summary>
        private void DisableAllComboBoxes()
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
        }

        /// <summary>
        /// Enables all the ComboBox controls in the game interface.
        /// </summary>
        private void EnableAllComboBoxes()
        {
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true; 
        }

        /// <summary>
        /// Handles the click event for the hint button. Provides hints to the user based on the shuffled categories.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void hint_Click(object sender, EventArgs e)
        {
            try
            {
                SoundsControl.PlayButtonSoundEffect();

                // Assuming shuffledCategories is a Dictionary or similar key-value pair collection
                if (shuffledCategories == null || !shuffledCategories.Any())
                {
                    MessageBox.Show("No categories available for hints.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StringBuilder hints = new StringBuilder();

                // Provide hints for all four correct answers
                int hintCount = 0;
                foreach (var entry in shuffledCategories.Take(4))
                {
                    string creativeHint = GetCreativeHint(entry.Key, entry.Value, hintCount);
                    hints.AppendLine(creativeHint);
                    hintCount++;
                }

                if (hintCount == 0)
                {
                    hints.AppendLine("No hints available.");
                }

                MessageBox.Show(hints.ToString(), "Hints", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Penalty for using the hint
                // Deducts 60 seconds
                remainingTime -= 60;

                // Ensure the remaining time doesn't go negative
                if (remainingTime < 0) remainingTime = 0;
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions and display a message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Generates a creative hint based on the provided key, value, and hint index.
        /// </summary>
        /// <param name="key">The key representing the category.</param>
        /// <param name="value">The value or description of the category.</param>
        /// <param name="hintIndex">The index of the hint being generated.</param>
        /// <returns>A creative hint string.</returns>
        private string GetCreativeHint(string key, string value, int hintIndex)
        {
            // This is a basic example. You can expand this with more creative hints based on your data.
            if (isMatchingDescriptionToCallNumber)
            {
                switch (hintIndex)
                {
                    case 0:
                        return $"Hint 1: Think of a place where {key} might be the key, but not in a tree!";
                    case 1:
                        return $"Hint 2: If {key} was a song, it'd be a melody!";
                    case 2:
                        return $"Hint 3: {key} is not just a word, it's a world!";
                    case 3:
                        return $"Hint 4: {key} might sound foreign, but it's closer than you think!";
                    default:
                        return "";
                }
            }
            else
            {
                string firstLetter = value.Substring(0, 1);
                switch (hintIndex)
                {
                    case 0:
                        return $"Hint 1: It starts with a '{firstLetter}', and it's not as easy as ABC!";
                    case 1:
                        return $"Hint 2: Dive deep and you might find '{value}' in the sea!";
                    case 2:
                        return $"Hint 3: If '{value}' was a color, it'd be as bright as can be!";
                    case 3:
                        return $"Hint 4: '{value}' is a mystery, but the answer is in plain sight!";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// Generates a creative hint based on the provided key, value, and hint index.
        /// </summary>
        /// <param name="key">The key representing the category.</param>
        /// <param name="value">The value or description of the category.</param>
        /// <param name="hintIndex">The index of the hint being generated.</param>
        /// <returns>A creative hint string.</returns>
        private void timer_Tick(object sender, EventArgs e)
        {
            remainingTime--;

            // Update the displayed time
            timeLabel.Text = $"{remainingTime / 60}m {remainingTime % 60}s";

            if (remainingTime <= 0)
            {
                gameTimer.Stop();
                DisableAllComboBoxes();
                DisableButtons();
                timeLabel.Text = "Game Over";
                timeLabel.ForeColor = Color.Red;  // Changing label color to red
                checkIdentifiedAreas_Click(null, null);  // Automatically check answers when time runs out

                if (MessageBox.Show("Would you like to play again?", "Restart Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    EnableButtons();
                    RestartGame();
                }
            }

        }

        /// <summary>
        /// Handles the click event for the start button. Initiates the game by starting the timer, enabling all ComboBoxes, 
        /// and disabling the start button while enabling other game-related buttons.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            gameTimer.Start();
            EnableAllComboBoxes();
            btnStart.Enabled = false;
            EnableButtons();
        }

        /// <summary>
        /// Handles the click event for the start button. Initiates the game by starting the timer, enabling all ComboBoxes, 
        /// and disabling the start button while enabling other game-related buttons.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btn_Finish_Click(object sender, EventArgs e)
        {
            SoundsControl.PlayButtonSoundEffect();  // Assuming you want to play a sound effect
            btn_Finish.Enabled = false;
            gameTimer.Stop();  // Stop the game timer
            DisableAllComboBoxes();  // Disable all ComboBoxes
            DisableButtons();  // Disable other game-related buttons

            // Display a message to the user
            MessageBox.Show("You have finished the game. Thank you for playing!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}