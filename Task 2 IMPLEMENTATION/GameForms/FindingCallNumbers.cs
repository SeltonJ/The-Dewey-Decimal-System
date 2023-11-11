using System.Collections.Generic;
using System;
using System.IO;
using System.Windows.Forms;
using Task_2_IMPLEMENTATION.Controls;
using Task_2_IMPLEMENTATION.BinarySearchTree;
using Newtonsoft.Json;
using System.Linq;

namespace Task_2_IMPLEMENTATION.GameForms
{
    public partial class FindingCallNumbers : Form
    {

        private BinarySearchTree<DeweyDecimalEntry> deweyTree;
        private List<DeweyDecimalEntry> entries;
        private DeweyDecimalEntry currentEntry;
        private List<DeweyDecimalEntry> allEntries;
        private Random rng = new Random();
        private int currentQuestionIndex = 0;
        private string correctAnswer;
        private int score = 300;

        /// <summary>
        /// Initializes the form, loads data, and prepares the first question.
        /// </summary>
        public FindingCallNumbers()
        {
            InitializeComponent();

            // Prevent resizing and disable maximize button.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Initialize the entries list
            entries = new List<DeweyDecimalEntry>();

            // Load the data from the file
            LoadData();

            // Display the first question
            DisplayNextQuestion();
        }

        /// <summary>
        /// Loads the Dewey Decimal data from a file into the binary search tree.
        /// </summary>
        private void LoadData()
        {
            string filePath = Path.Combine(Application.StartupPath, "src", "DeweyDecimalData.txt");
            deweyTree = new BinarySearchTree<DeweyDecimalEntry>();

            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"The file at {filePath} does not exist.");
                    return;
                }

                string json = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(json))
                {
                    MessageBox.Show("The file is empty or could not be read properly.");
                    return;
                }

                List<DeweyClass> deweyClasses = JsonConvert.DeserializeObject<List<DeweyClass>>(json);
                if (deweyClasses == null)
                {
                    MessageBox.Show("Deserialization of JSON data failed.");
                    return;
                }

                foreach (var deweyClass in deweyClasses)
                {
                    if (deweyClass.Entries != null)
                    {
                        foreach (var entry in deweyClass.Entries)
                        {
                            DeweyDecimalEntry deweyEntry = new DeweyDecimalEntry
                            {
                                Class = deweyClass.Class,
                                Subclass = "",
                                Description = entry.Description,
                                CallNumber = entry.CallNumber
                            };
                            deweyTree.Insert(deweyEntry);
                        }
                    }

                    if (deweyClass.Subclasses != null)
                    {
                        foreach (var subclass in deweyClass.Subclasses)
                        {
                            foreach (var entry in subclass.Entries)
                            {
                                DeweyDecimalEntry deweyEntry = new DeweyDecimalEntry
                                {
                                    Class = deweyClass.Class,
                                    Subclass = subclass.Code,
                                    Description = entry.Description,
                                    CallNumber = entry.CallNumber
                                };
                                deweyTree.Insert(deweyEntry);
                            }
                        }
                    }
                }

                allEntries = deweyTree.InOrderTraversal();
                // Populate the entries list with all entries
                entries = new List<DeweyDecimalEntry>(allEntries); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        /// <summary>
        /// Displays the next question in the quiz.
        /// </summary>
        private void DisplayNextQuestion()
        {
            if (entries == null || entries.Count == 0)
            {
                MessageBox.Show("No entries to display.");
                return;
            }

            // Randomly select a third-level entry
            currentEntry = GetRandomThirdLevelEntry();
            if (currentEntry != null)
            {
                lbl_description.Text = currentEntry.Description;

                var answers = GenerateRandomAnswers(currentEntry.CallNumber);
                if (answers.Count == 4)
                {
                    radioButton1.Text = answers[0];
                    radioButton2.Text = answers[1];
                    radioButton3.Text = answers[2];
                    radioButton4.Text = answers[3];
                }
                else
                {
                    MessageBox.Show("Not enough answers to display.");
                }

                correctAnswer = $"{currentEntry.CallNumber.Substring(0, 1)}00"; // The top-level correct answer
            }
            else
            {
                lbl_description.Text = "No more third-level entries available.";
                radioButton1.Enabled = radioButton2.Enabled = radioButton3.Enabled = radioButton4.Enabled = btn_check.Enabled = false;
            }
        }

        // This method retrieves the description for a top-level Dewey Decimal class.
        private string GetDescriptionForTopLevel(string topLevel)
        {
            // Assuming 'allEntries' contains all possible entries, including top-level ones.
            // We filter for top-level entries and find the one that matches the provided 'topLevel' parameter.
            var topLevelEntry = allEntries.FirstOrDefault(e => e.CallNumber.StartsWith(topLevel) && e.CallNumber.EndsWith("00"));
            return topLevelEntry != null ? topLevelEntry.Description : "Unknown Top-Level Class";
        }

        // This method selects a random third-level entry from the list of all entries.
        private DeweyDecimalEntry GetRandomThirdLevelEntry()
        {
            // Filter the list for third-level entries. This assumes that a third-level entry
            // has a call number with more than 3 digits (excluding zeros at the end).
            var thirdLevelEntries = allEntries.Where(e => e.CallNumber.Length > 3 && !e.CallNumber.EndsWith("00")).ToList();

            // If there are no third-level entries, return null.
            if (!thirdLevelEntries.Any())
            {
                return null;
            }

            // Select a random third-level entry from the list.
            int randomIndex = rng.Next(thirdLevelEntries.Count);
            return thirdLevelEntries[randomIndex];
        }

        /// <summary>
        /// Generates a list of random answers including the correct one.
        /// </summary>
        /// <param name="correctAnswer">The correct answer to include in the list.</param>
        /// <returns>A list of possible answers.</returns>
        private List<string> GenerateRandomAnswers(string correctAnswer)
        {
            // Create a list of incorrect answers
            HashSet<string> incorrectAnswers = new HashSet<string>();
            while (incorrectAnswers.Count < 3)
            {
                int randomIndex = rng.Next(allEntries.Count);
                // Ensure that the incorrect answer is a top-level class and not the correct one
                if (allEntries[randomIndex].CallNumber.Substring(0, 1) != correctAnswer.Substring(0, 1))
                {
                    string potentialAnswer = $"{allEntries[randomIndex].CallNumber.Substring(0, 1)}00 - {allEntries[randomIndex].Description}";
                    incorrectAnswers.Add(potentialAnswer);
                }
            }

            // Add the correct top-level answer to the list
            string correctTopLevelAnswer = $"{correctAnswer.Substring(0, 1)}00 - {GetDescriptionForTopLevel(correctAnswer.Substring(0, 1))}";
            List<string> answers = new List<string>(incorrectAnswers) { correctTopLevelAnswer };

            // Sort the answers by call number
            answers.Sort((a, b) => a.Split(' ')[0].CompareTo(b.Split(' ')[0]));
            return answers;
        }

        /// <summary>
        /// Shuffles the elements of a list in place.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to shuffle.</param>
        private void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Resets the quiz to the initial state and displays the first question.
        /// </summary>
        private void btn_resart_Click(object sender, EventArgs e)
        {
            // Reset the quiz
            score = 300;
            lbl_score.Text = "Score: " + score;
            lbl_feedback.Text = "Feedback:";
            currentQuestionIndex = 0;
            btn_check.Enabled = true;
            btn_hint.Enabled = true;
            entries = new List<DeweyDecimalEntry>(allEntries);
            currentQuestionIndex = 0;
            radioButton1.Enabled = radioButton2.Enabled = radioButton3.Enabled = radioButton4.Enabled = btn_check.Enabled = btn_hint.Enabled = true;
            DisplayNextQuestion();

        }

        /// <summary>
        ///  Event handler to go the Menu form.
        /// </summary> 
        private void btn_menu_Click(object sender, EventArgs e)
        {
            SoundsControl.PlayButtonSoundEffect();
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        /// <summary>
        /// Checks the selected answer and updates the score accordingly.
        /// </summary>
        private void btn_check_Click_1(object sender, EventArgs e)
        {
            // Determine which radio button is checked and get its associated text
            string selectedAnswer = "";
            if (radioButton1.Checked) selectedAnswer = radioButton1.Text;
            else if (radioButton2.Checked) selectedAnswer = radioButton2.Text;
            else if (radioButton3.Checked) selectedAnswer = radioButton3.Text;
            else if (radioButton4.Checked) selectedAnswer = radioButton4.Text;

            // Check if the selected answer is correct
            if (selectedAnswer == correctAnswer)
            {
                // Correct answer
                score += 50; //Increment score
                lbl_feedback.Text = "Correct! You've chosen the right class!";
            }
            else
            {
                // Incorrect answer
                score -= 25; //reduce score
                lbl_feedback.Text = "Incorrect. The right class was: " + correctAnswer;
            }

            // Check if the score has reached 0
            if (score <= 0)
            {
                // Game over
                MessageBox.Show("Your score has reached 0. Game over!", "Game Over");
                lbl_score.Text = "Score: " + 0;
                EndGame();
                return; // Exit the method to prevent further execution
            }

            lbl_score.Text = "Score: " + score;

            // Uncheck all radio buttons for the next question
            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;

            // Move to the next question
            DisplayNextQuestion();
        }

        /// <summary>
        /// Ends the game when the player's score reaches zero.
        /// </summary>
        private void EndGame()
        {
            // Disable all interactive elements or close the form
            radioButton1.Enabled = radioButton2.Enabled = radioButton3.Enabled = radioButton4.Enabled = btn_check.Enabled = btn_hint.Enabled = false;
            btn_check.Enabled = false;
            btn_hint.Enabled=false;
        }

        /// <summary>
        /// Handles the event when the hint button is clicked, provides a hint, and updates the score.
        /// </summary>
        private void btn_hint_Click(object sender, EventArgs e)
        {
            score -= 50; //reduce score
            lbl_score.Text = "Score: " + score; 
            // Generate a hint for the current question
            string hint = GenerateHint(currentEntry);
            MessageBox.Show(hint, "Hint");
        }

        /// <summary>
        /// Generates a hint based on the current Dewey Decimal entry.
        /// </summary>
        /// <param name="entry">The current Dewey Decimal entry for which to generate a hint.</param>
        /// <returns>A string containing the hint.</returns>
        private string GenerateHint(DeweyDecimalEntry entry)
        {
            return "The correct class starts with the number: " + entry.CallNumber.Substring(0, 2);
        }
    }
}