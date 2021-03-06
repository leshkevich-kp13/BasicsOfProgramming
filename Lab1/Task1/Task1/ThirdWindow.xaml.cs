using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Task1
{

    public partial class ThirdWindow : Window
    {
        /* This variable controls current turn (true = X, False = O)*/
        public bool currentTurn;

        public int numOfXTurns;

        ExtendedButton[,] gameField = new ExtendedButton[5, 5];

        /* Arrays for coeficients of lines */
        public int[] rowsCoef;
        int[] columnsCoef;
        int[] diagonalsCoef;

        public ThirdWindow()
        {
            InitializeComponent();
            currentTurn = true;
            numOfXTurns = 1;


            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {            
                    gameField[i, j] = new ExtendedButton();                  
                    gameField[i, j].FontSize = 40;
                    gameField[i, j].Content = "";
                    gameField[i, j].FontFamily = new FontFamily("Segoe Script");
                    gameField[i, j].Foreground = new SolidColorBrush(Colors.White);
                    gameField[i, j].Background = new SolidColorBrush(Colors.Green);

                    gameField[i, j].Click += TwoPlayersCell_Btn_Click;
                    gameField[i, j].Click += OnePlayerCell_Btn_Click;

                    gameField[i, j].x = i;
                    gameField[i, j].y = j;

                    grid.Children.Add(gameField[i, j]);
                 
                }
            }
        }
        /// <summary>
        /// Return to Main Window.
        /// </summary>
        private void MoveToMainFromThird_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        /// <summary>
        /// Switch game mode to "Player VS Bot".
        /// </summary>
        private void StartOnePlayerBtn_Click(object sender, RoutedEventArgs e)
        {
            StartOnePlayerMode();
        }

        /// <summary>
        /// Switch game mode to "Player VS Player".
        /// </summary>
        private void StartTwoPlayersBtn_Click(object sender, RoutedEventArgs e)
        {
            StartTwoPlayersMode();
        }

        /// <summary>
        /// Start the game in "Player VS Bot" mode.
        /// </summary>
        private void StartOnePlayerMode()
        {
            currentTurn = true;
            numOfXTurns = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    gameField[i, j].Content = "";
                    gameField[i, j].Click -= TwoPlayersCell_Btn_Click;
                    gameField[i, j].Click -= OnePlayerCell_Btn_Click;
                    gameField[i, j].Click += OnePlayerCell_Btn_Click;
                }
            }

            rowsCoef = new int[5] { 2, 2, 2, 2, 2 };
            columnsCoef = new int[5] { 2, 2, 2, 2, 2 };
            diagonalsCoef = new int[2] { 2, 2 };

        }

        /// <summary>
        /// Start the game in "Player VS Player" mode.
        /// </summary>
        private void StartTwoPlayersMode()
        {
            currentTurn = true;
            numOfXTurns = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    gameField[i, j].Content = "";
                    gameField[i, j].Click -= TwoPlayersCell_Btn_Click;
                    gameField[i, j].Click -= OnePlayerCell_Btn_Click;
                    gameField[i, j].Click += TwoPlayersCell_Btn_Click;
                }
            }
        }

        /// <summary>
        /// Puts a player's mark in the cell.
        /// After players turn next turn passes to bot.
        /// </summary>
        private void OnePlayerCell_Btn_Click(object sender, RoutedEventArgs e)
        {
            ExtendedButton button = (ExtendedButton)sender;
            if (button.Content == "" && currentTurn == true)
            {
                button.Content = "X";
                numOfXTurns++;
                if (WinnerChecker(button.x, button.y) == false)
                {             
                    ChangeTurn();
                    BotTurn(button.x, button.y);
                }     
            }
        }

        /// <summary>
        /// Puts a player's mark in the cell.
        /// After player's turn next turn passes to next player. 
        /// </summary>
        private void TwoPlayersCell_Btn_Click(object sender, RoutedEventArgs e)
        {
            ExtendedButton button = (ExtendedButton)sender;
            if (button.Content == "")
            {
                button.Content = currentTurn == true ? "X" : "O";
                numOfXTurns = currentTurn == true ? numOfXTurns + 1 : numOfXTurns;
                WinnerChecker(button.x, button.y);
                ChangeTurn();
            }
        }

        /// <summary>
        /// Сhecks if a row, column or diagonal consists of only one element.
        /// </summary>
        private bool WinnerChecker(int x, int y)
        {
            string symbol = currentTurn == true ? "X" : "O";

            if(RowChecker(symbol, y) || ColumnChecker(symbol, x) || FirstDiagonalChecker(symbol) || SecondDiagonalChecker(symbol))
            {

                WinnerMessage winnerMessage = new WinnerMessage(symbol+" WINS");
                winnerMessage.ShowDialog();

                ChangeScore();
                currentTurn = !currentTurn;
                return true;
            }
            else if(numOfXTurns == 13)
            {
                WinnerMessage winnerMessage = new WinnerMessage("DRAW");
                winnerMessage.ShowDialog();
                currentTurn = !currentTurn;
                return true;
            }
            return false;           
        }

        /// <summary>
        /// Сhecks if a row consists of only one element.
        /// </summary>
        private bool RowChecker(string symbol, int y)
        {
           for(int i = 0; i < 5; i++)
           {
                if(gameField[i, y].Content != symbol)
                {
                    return false;
                }
           }
            return true;
        }

        /// <summary>
        /// Сhecks if a column consists of only one element.
        /// </summary>
        private bool ColumnChecker(string symbol, int x)
        {
            for (int j = 0; j < 5; j++)
            {
                if (gameField[x, j].Content != symbol)
                {
                    return false;
                }              
            }
            return true;
        }

        /// <summary>
        /// Сhecks if a first diagonaln consists of only one element.
        /// </summary>
        private bool FirstDiagonalChecker(string symbol)
        {
            for (int i = 0; i < 5; i++)
            {           
                if (gameField[i, i].Content != symbol)
                {
                    return false;
                }
            }
            return true;
   
        }

        /// <summary>
        /// Сhecks if a second diagonaln consists of only one element.
        /// </summary>
        private bool SecondDiagonalChecker(string symbol)
        {
            for (int i = 0; i < 5; i++)
            {
                if (gameField[i, (4 - i)].Content != symbol)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Changes score labels 
        /// </summary>
        private void ChangeScore()
        {
            if (currentTurn == true)
            {
                Score_X_Label.Content = (Convert.ToInt32(Score_X_Label.Content) + 1);
            }
            else
            {
                Score_O_Label.Content = (Convert.ToInt32(Score_O_Label.Content) + 1);
            }
        }

        /// <summary>
        /// Switch current turn
        /// </summary>
        private void ChangeTurn()
        {
            currentTurn = !currentTurn;
            CurrentTurnLabel.Content = currentTurn == true ? "X" : "O";
        }

        /// <summary>
        /// Makes bot's turn.
        /// At first, bot analyses the previous move and corrects the coefficients of each line.
        /// After that, he chooses the best possible move based on the coefficients of the lines.
        /// </summary>
        private void BotTurn(int x, int y)
        {
            AnalyseField(x, y);
            int choosed_x; 
            int choosed_y;
            (choosed_x, choosed_y) = ChooseTheCell();
            gameField[choosed_x, choosed_y].Content = "O";
            AnalyseField(choosed_x, choosed_y);
            WinnerChecker(choosed_x, choosed_y);
            ChangeTurn();
        }

        /// <summary>
        /// The bot analyzes the row, column and diagonals that the player changed on the previous move. 
        /// </summary>
        private void AnalyseField(int x, int y)
        {
            AnalyseRow(y);
            AnalyseColumn(x);

            if(x == y)
            {
                AnalyseFirstDiagonal();
            }
            if((x + y) == 4)
            {
                AnalyseSecondDiagonal();
            }
        }

        /// <summary>
        /// The bot analyzes the row that the player changed on the previous move. 
        /// </summary>
        private void AnalyseRow(int y)
        {
            int numOf_O = 0;
            int numOf_X = 0;

            for(int i = 0; i < 5; i++)
            {
                switch (gameField[i, y].Content)
                {
                    case "X":
                        numOf_X++;
                            break;

                    case "O":
                        numOf_O++;
                        break;
                }
            }

            if((numOf_X + numOf_O) == 5)
            {
                rowsCoef[y] = 0;
                return;
            }
            if(numOf_X > 0 && numOf_O > 0)
            {
                rowsCoef[y] = 1;
                return;
            }
            if (numOf_O == 4)
            {
                rowsCoef[y] = 7;
                return;
            }
            if (numOf_X == 4)
            {
                rowsCoef[y] = 6;
                return;
            }
            if (numOf_O > 0)
            {
                rowsCoef[y] = 2 + numOf_O;
                return;
            }
            if (numOf_X > 0)
            {
                rowsCoef[y] = 1 + numOf_X;
                return;
            }
        }

        /// <summary>
        /// The bot analyzes the column that the player changed on the previous move. 
        /// </summary>
        private void AnalyseColumn(int x)
        {
            int numOf_O = 0;
            int numOf_X = 0;

            for (int j = 0; j < 5; j++)
            {
                switch (gameField[x, j].Content)
                {
                    case "X":
                        numOf_X++;
                        break;

                    case "O":
                        numOf_O++;
                        break;
                }
            }

            if ((numOf_X + numOf_O) == 5)
            {
                columnsCoef[x] = 0;
                return;
            }
            if (numOf_X > 0 && numOf_O > 0)
            {
                columnsCoef[x] = 1;
                return;
            }
            if (numOf_O == 4)
            {
                columnsCoef[x] = 7;
                return;
            }
            if (numOf_X == 4)
            {
                columnsCoef[x] = 6;
                return;
            }
            if (numOf_O > 0)
            {
                columnsCoef[x] = 2 + numOf_O;
                return;
            }
            if(numOf_X > 0)
            {
                columnsCoef[x] = 1 + numOf_X;
                return;
            }
        }

        /// <summary>
        /// The bot analyzes the first diagonal that the player changed on the previous move. 
        /// </summary>
        private void AnalyseSecondDiagonal()
        {
            int numOf_O = 0;
            int numOf_X = 0;

            for (int i = 0; i < 5; i++)
            {
                switch (gameField[4 - i, i].Content)
                {
                    case "X":
                        numOf_X++;
                        break;

                    case "O":
                        numOf_O++;
                        break;
                }
            }
            
            if ((numOf_X + numOf_O) == 5)
            {
                diagonalsCoef[1] = 0;
                return;
            }
            if (numOf_X > 0 && numOf_O > 0)
            {
                diagonalsCoef[1] = 1;
                return;
            }

            if (numOf_O == 4)
            {
                diagonalsCoef[1] = 7;
                return;
            }
            if (numOf_X == 4)
            {
                diagonalsCoef[1] = 6;
                return;
            }

            if (numOf_O > 0)
            {
                diagonalsCoef[1] = 2 + numOf_O;
                return;
            }
            if (numOf_X > 0)
            {
                diagonalsCoef[1] = 1 + numOf_X;
                return;
            }
        }

        /// <summary>
        /// The bot analyzes the second diagonal that the player changed on the previous move. 
        /// </summary>
        private void AnalyseFirstDiagonal()
        {
            int numOf_O = 0;
            int numOf_X = 0;

            for (int i = 0; i < 5; i++)
            {
                switch (gameField[i, i].Content)
                {
                    case "X":
                        numOf_X++;
                        break;

                    case "O":
                        numOf_O++;
                        break;
                }
            }

            if ((numOf_X + numOf_O) == 5)
            {
                diagonalsCoef[0] = 0;
                return;
            }
            if (numOf_X > 0 && numOf_O > 0)
            {
                diagonalsCoef[0] = 1;
                return;
            }
            if (numOf_O == 4)
            {
                diagonalsCoef[0] = 7;
                return;
            }
            if (numOf_X == 4)
            {
                diagonalsCoef[0] = 6;
                return;
            }
            if (numOf_O > 0)
            {
                diagonalsCoef[0] = 2 + numOf_O;
                return;
            }
            if (numOf_X > 0)
            {
                diagonalsCoef[0] = 1 + numOf_X;
                return;
            }
        }

        /// <summary>
        /// The bot selects the best cell based on the coefficient of each line. 
        /// </summary>
        private (int, int) ChooseTheCell()
        {
            /* Coordinates of cell, which bot will choose*/
            int x;          
            int y;

            /* Max coefficients of rows and columns */
            int rowsMax = rowsCoef.Max();
            int columnsMax = columnsCoef.Max();

            

            int rowsMaxIndex = Array.IndexOf(rowsCoef, rowsMax);
            int columnsMaxIndex = Array.IndexOf(columnsCoef, columnsMax);

            List<int> possibleCoordinates = new List<int>();

            /*Choose the line with the largest coefficient*/
            if (diagonalsCoef[0] >= rowsMax && diagonalsCoef[0] >= columnsMax)
            {

                /* Find the free cells on the first diagonal */
                for (int i = 0; i < 5; i++)
                {
                    if (gameField[i, i].Content == "")
                    {
                        possibleCoordinates.Add(i);
                    }
                }

                /* Find the cell with the highest coefficient on the first diagonal */
                x = possibleCoordinates[0];
                for (int i = 1; i < possibleCoordinates.Count; i++)
                {              
                    if ((columnsCoef[i] >= columnsCoef[i - 1] && columnsCoef[i] >= rowsCoef[i - 1]) || (rowsCoef[i] >= rowsCoef[i - 1] && rowsCoef[i] >= rowsCoef[i - 1]))
                    {
                        x = possibleCoordinates[i];
                    }                    
                }
                y = x;
            }
            else if (diagonalsCoef[1] >= rowsMax && diagonalsCoef[1] >= columnsMax)
            {

                /* Find the free cells on the second diagonal */
                for (int i = 0; i < 5; i++)
                {
                    if (gameField[i, 4 - i].Content == "")
                    {
                        possibleCoordinates.Add(i);
                    }
                }

                /* Find the cell with the highest coefficient on the second diagonal */
                x = possibleCoordinates[0];
                for (int i = 1; i < possibleCoordinates.Count; i++)
                {

                    if ((columnsCoef[i] >= columnsCoef[i - 1] && columnsCoef[i] >= rowsCoef[5 - i]) ||
                        (rowsCoef[4 - i] >= columnsCoef[i - 1] && rowsCoef[4 - i] >= rowsCoef[5 - i]))
                    {
                        x = possibleCoordinates[i];
                    }
                    
                }
                y = 4 - x;
            }
            else if(columnsMax > rowsMax)
            {
                x = columnsMaxIndex;

                /* Find the free cells on the [x] column */
                for (int i = 0; i < 5; i++)
                {
                    if (gameField[columnsMaxIndex, i].Content == "")
                    {
                        possibleCoordinates.Add(i);
                    }
                }

                /* Find the cell with the highest coefficient on the [x] column */
                y = possibleCoordinates[0];
                for (int i = 1; i < possibleCoordinates.Count; i++)
                {
                    
                    if (rowsCoef[i] >= rowsCoef[i - 1])
                    {
                        y = possibleCoordinates[i];
                    }
                    
                }
            }
            else
            {
                y = rowsMaxIndex;

                /* Find the free cells on the [y] row */
                for (int i = 0; i < 5; i++)
                {
                    if (gameField[i, rowsMaxIndex].Content == "")
                    {
                        possibleCoordinates.Add(i);
                    }
                }

                /* Find the cell with the highest coefficient on the [y] row  */
                x = possibleCoordinates[0];
                for (int i = 1; i < possibleCoordinates.Count; i++)
                {
                    
                    if (columnsCoef[i] >= columnsCoef[i - 1])
                    {
                        x = possibleCoordinates[i];
                    }
                    
                }
            }

            return(x, y);
        }      
    }
    class ExtendedButton : Button
    {

        public int x;
        public int y;
    }

}
