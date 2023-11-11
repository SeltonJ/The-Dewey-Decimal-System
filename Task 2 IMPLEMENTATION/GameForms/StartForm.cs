using System;
using System.Windows.Forms;
using Task_2_IMPLEMENTATION.Controls;

namespace Task_2_IMPLEMENTATION.GameForms
{
    /// <summary>
    /// Represents the starting form of the game.
    /// </summary>
    public partial class StartForm : Form
    {
        // Timer to introduce a delay before transitioning to the Menu form.
        private Timer delayTimer = new Timer();

        /// <summary>
        /// Initializes a new instance of the StartForm class.
        /// </summary>
        public StartForm()
        {
            InitializeComponent();
            backgroungSound();

            // Set the timer interval to 1 second (1000 milliseconds).
            delayTimer.Interval = 1000;
            delayTimer.Tick += delayForm_Tick;
        }

        /// <summary>
        /// Handles the click event for the exit button.
        /// Exits the application.
        /// </summary>
        private void exit_Click(object sender, EventArgs e)
        {
            SoundsControl.PlayButtonSoundEffect();
            Application.Exit();
        }

        /// <summary>
        /// Handles the click event for the goToMenu button.
        /// Initiates the timer to delay the transition to the Menu form.
        /// </summary>
        private void goToMenu_Click(object sender, EventArgs e)
        {
            SoundsControl.PlayButtonSoundEffect();
            // Start the timer when the button is clicked.
            delayTimer.Start();
        }

        /// <summary>
        /// Handles the Tick event for the delayTimer.
        /// Stops the timer and transitions to the Menu form.
        /// </summary>
        private void delayForm_Tick(object sender, EventArgs e)
        {
            // Stop the timer.
            delayTimer.Stop();

            // Hide the current form and open the Menu form.
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        /// <summary>
        /// Plays the background sound for the menu.
        /// </summary>
        public void backgroungSound()
        {
            mxp.URL = SoundsControl.PlayBackGroundSongBeginning2();
            mxp.settings.playCount = 9999;
            mxp.Ctlcontrols.play();
            mxp.Visible = false;
        }
    }
}
