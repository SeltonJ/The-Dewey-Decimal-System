using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Task_2_IMPLEMENTATION.Controls
{
    /// <summary>
    /// Provides methods to control and play sound effects and background music.
    /// </summary>
    public class SoundsControl
    {
        /// <summary>
        /// Plays the button sound effect.
        /// </summary>
        public static void PlayButtonSoundEffect()
        {
            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.Minecraft_Menu_Button_Sound_Effect___Sounffex);
            soundPlayer.Play();
        }


        /// <summary>
        /// Plays the book grap and drop sound effect.
        /// </summary>
        public static void DropBookSoundEffect()
        {
            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.book_drop_sound);
            soundPlayer.Play();
        }

        /// <summary>
        /// Returns the path to the background song "Beginning 2".
        /// </summary>
        public static string PlayBackGroundSongBeginning2()
        {
            string backGroundSongBeginning2 = Path.Combine(Application.StartupPath,"src", "C418 - Beginning 2 (Minecraft Volume Beta).wav");
            return backGroundSongBeginning2;
        }
    }
}
