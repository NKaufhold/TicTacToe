using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CL_TicTacToe;                     // Using for the Class Libary


//Böge, Kaufhold
namespace WPF_TicTacToe
{
    /// <summary>
    /// Logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Button[,] button = new Button[3, 3];                  // Array for Buttons

        TicTacToeGameplay gameplay = new TicTacToeGameplay();   // Create an object of the TicTacToeGameplay class



        public MainWindow()
        {
            InitializeComponent();
            createButtons();
            whichPlayer();

        }

        /// <summary>
        /// To create the Buttons field
        /// </summary>
        private void createButtons()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    button[x, y] = new Button();                         // dynamically creation of a Button
                    button[x, y].Height = button[x, y].Width = 100;      // constantly height and width -> Rectangle
                    button[x, y].FontSize = 40;                          // sets the font size 

                    button[x, y].Click += this.whichButton;              // merge the Click-Event to this specific button, every created button gets its own

                    this.WP_Feld.Children.Add(button[x, y]);             // adds the button to the panel
                }
            }
        }

        /// <summary>
        /// The label shows which player can turn
        /// </summary>
        private void whichPlayer()
        {
            textblockPlayer.Text = String.Format("Player {0}, it's your turn", gameplay.Player);                // textblock is better than a label in this case // String.Format is able to put the variable into the string
        }

        /// <summary>
        /// Find the sender
        /// </summary>
        /// <param name="sender">Button.Click event</param>
        /// <param name="e">Button.Click event -> see InitializeComponent()</param>
        private void whichButton(object sender, RoutedEventArgs e)
        {
            bool buttonclicked = false;
            
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (button[x, y] == sender)
                    {
                        if (gameplay.Gamefield[x, y] != symbol.empty || gameplay.Playerwon)     //don't recognise the click when the button is already filled or the game is over
                        {
                            buttonclicked = true;
                            break;
                        }

                        gameplay.SaveClick(x, y);

                        changeIcon(x, y);
                    }
                }
            }

            if (!buttonclicked)     //don't need to be checked, when no new icon was set
            {
                gameOver();
            }
                       
            if (!buttonclicked && !gameplay.Playerwon)  //only change the player, when the player put his icon and the game is still running
            {
                gameplay.Changeplayer();
                whichPlayer();
            }
        }

        /// <summary>
        /// Change the button to a textbox
        /// </summary>
        private void changeIcon(int x, int y)
        {
            TextBlock iconBlock = new TextBlock();

            iconBlock.Text = gameplay.Gamefield[x,y].ToString();            // The textbox knows, what symbol is in use and can show it

            button[x, y].Content = iconBlock.Text;
        }

        /// <summary>
        /// The game has ended, what is the result?
        /// </summary>
        private void gameOver()
        {
            if (gameplay.Playerwon == true)
            {
                MessageBox.Show($"Player {gameplay.Player} has won!");
                textblockPlayer.Text = String.Format("game over");
                textblockPlayer.Foreground = new SolidColorBrush(Colors.Red);
            }
            else if (gameplay.Fullfields == 9 && gameplay.Playerwon == false)
            {
                MessageBox.Show("The Game is over. Draw");
                textblockPlayer.Text = String.Format("game over");
                textblockPlayer.Foreground = new SolidColorBrush(Colors.Red);
                gameplay.Playerwon = true;
            }

        }

        /// <summary>
        /// reset the game, when reset-button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetbutton_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    button[x, y].Content = "";
                    gameplay.Gamefield[x, y] = symbol.empty;
                }

            }

            gameplay.Playersicon = symbol.x;
            gameplay.Player = 1;
            whichPlayer();
            gameplay.Playerwon = false;
            textblockPlayer.Foreground = new SolidColorBrush(Colors.Black);
            gameplay.Fullfields = 0;
        }
    }
}
