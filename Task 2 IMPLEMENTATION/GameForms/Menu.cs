using System;
using System.Windows.Forms;
using Task_2_IMPLEMENTATION.Controls;
using Task_2_IMPLEMENTATION.GameForms;

namespace Task_2_IMPLEMENTATION
{
    /// <summary>
    /// Represents the main menu form of the game.
    /// </summary>
    public partial class Menu : Form
    {
        // Timer to introduce a delay before transitioning to the ReplaceBooksForm.
        private Timer delayTimer = new Timer();
        private Timer delayTimer2 = new Timer();
        private Timer delayTimer3 = new Timer();


        /// <summary>
        /// Initializes a new instance of the Menu class.
        /// </summary>
        public Menu()
        {
            InitializeComponent();
            
            // Prevent resizing and disable maximize button.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Set the timer interval to 1 second (1000 milliseconds).
            delayTimer.Interval = 1000;
            delayTimer2.Interval = 1000;
            delayTimer3.Interval = 1000;
            delayTimer.Tick += delayForm_Tick;
            delayTimer2.Tick += identifyingAreas_Tick;
            delayTimer3.Tick += findingCallNumbers_Tick;

        }

        /// <summary>
        /// Handles the Load event for the Menu form.
        /// Sets the background image for the form.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.bookcase_wallpaper;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        /// <summary>
        /// Handles the click event for the "Exit" button.
        /// Exits the application.
        /// </summary>
        private void btnExitApp_Click(object sender, EventArgs e)
        {
            SoundsControl.PlayButtonSoundEffect();
            Application.Exit();
        }

        /// <summary>
        /// Handles the click event for the "Replacing Books" button.
        /// Initiates the timer to delay the transition to the ReplaceBooksForm.
        /// </summary>
        private void btnReplacingBooks_Click(object sender, EventArgs e)
        {
            SoundsControl.PlayButtonSoundEffect();
            delayTimer.Start();
        }

        /// <summary>
        /// Handles the Tick event for the delayTimer.
        /// Stops the timer and transitions to the ReplaceBooksForm.
        /// </summary>
        private void delayForm_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();
            this.Close();
            ReplaceBooksForm replaceBooksForm = new ReplaceBooksForm();
            replaceBooksForm.Show();
        }

        /// <summary>
        /// Handles the Tick event for the delayTimer.
        /// Stops the timer and transitions to the IdentifyingAreasForm.
        /// </summary>
        private void btnIdentifyingA_Click(object sender, EventArgs e)
        {
            SoundsControl.PlayButtonSoundEffect();
            delayTimer2.Start();
        }

        private void identifyingAreas_Tick(object sender, EventArgs e)
        {
            delayTimer2.Stop();
            this.Close();
            IdentifyingAreasForm identifyingAreasForm = new IdentifyingAreasForm();
            identifyingAreasForm.Show();
        }


        /// <summary>
        /// Handles the Tick event for the delayTimer.
        /// Stops the timer and transitions to the FindingCallNumbers.
        /// </summary>
        private void btnFindingCallNumbers_Click(object sender, EventArgs e)
        {
            SoundsControl.PlayButtonSoundEffect();
            delayTimer3.Start();
        }

        private void findingCallNumbers_Tick(object sender, EventArgs e)
        {
            delayTimer3.Stop();
            this.Close();
            FindingCallNumbers findingCallNumbers = new FindingCallNumbers();
            findingCallNumbers.Show();
        }
    }
}
