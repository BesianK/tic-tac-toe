using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace kodra_TicTacToe
{
    /// <summary>
    /// Besian Kodra || ITDEV 115
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
            MessageBox.Show("Welcome to Besian Kodra's Tic Tac Toe app. This app was made for Michael Hunsicker'a ITDEV 115 class. " +
                "This is a game where two players alternate turns trying to place three Xs or Os in a row, column, or diagonal first in order to win. " +
                "Press 'Ok' to close this message and start the game. Have fun!");
        }

        private Symbol[] mResults;
        private bool mPlayer1Turn;
        private bool mGameOver;
        private void NewGame()
        {
            mResults = new Symbol[9];

            for (int i = 0; i < mResults.Length; i++)
                mResults[i] = Symbol.Empty;

            mPlayer1Turn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.SteelBlue;
                button.Foreground = Brushes.Coral;
            });
            mGameOver = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameOver)
            {
                NewGame();
                return;
            }
            var button = (Button)sender;
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);

            int index = column + (row * 3);

            if (mResults[index] != Symbol.Empty)
                return;

            if (mPlayer1Turn)
                mResults[index] = Symbol.Cross;
            else
                mResults[index] = Symbol.Circle;

            if (mPlayer1Turn)
                button.Content = "X";
            else
                button.Content = "O";

            if (!mPlayer1Turn)
                button.Foreground = Brushes.LightSteelBlue;

            if (mPlayer1Turn)
                mPlayer1Turn = false;
            else
                mPlayer1Turn = true;

            CheckForWinner();
        }
        private void CheckForWinner()
        {   //horizontal
            if (mResults[0] != Symbol.Empty && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameOver = true;
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.MediumSeaGreen;
                Reset();
            }
            if (mResults[3] != Symbol.Empty && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameOver = true;
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.MediumSeaGreen;
                Reset();
            }
            if (mResults[6] != Symbol.Empty && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameOver = true;
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.MediumSeaGreen;
                Reset();
            }
            //vertical
            if (mResults[0] != Symbol.Empty && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameOver = true;
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.MediumSeaGreen;
                Reset();
            }
            if (mResults[1] != Symbol.Empty && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameOver = true;
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.MediumSeaGreen;
                Reset();
            }
            if (mResults[2] != Symbol.Empty && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameOver = true;
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.MediumSeaGreen;
                Reset();
            }
            //diagonal
            if (mResults[0] != Symbol.Empty && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameOver = true;
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.MediumSeaGreen;
                Reset();
            }
            if (mResults[2] != Symbol.Empty && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameOver = true;
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.MediumSeaGreen;
                Reset();
            }
            //full board
            if (!mResults.Any(f => f == Symbol.Empty) && !mGameOver)
            {
                mGameOver = true;
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
                MessageBox.Show("It's a tie! Click Ok to start a new game.");
                NewGame();
            }
        }
        public void Reset()
        {
            MessageBox.Show("Congratulations! You won! Click 'Ok' to start a new game.");
            NewGame();
        }
    }
}
