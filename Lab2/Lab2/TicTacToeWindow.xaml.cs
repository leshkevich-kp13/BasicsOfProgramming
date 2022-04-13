using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для TicTacToeWindow.xaml
    /// </summary>
    public partial class TicTacToeWindow : Window
    {
        Label Score_X_Label = new Label();
        Label Score_O_Label = new Label();
        Label CurrentTurnLabel = new Label();

        /* This variable controls current turn (true = X, False = O)*/
        bool currentTurn;

        int numOfXTurns;

        ExtendedButton[,] gameField = new ExtendedButton[5, 5];

        /* Arrays for coeficients of lines */
        public int[] rowsCoef;
        int[] columnsCoef;
        int[] diagonalsCoef;

        public TicTacToeWindow()
        {
            InitializeComponent();
            Width = 600;
            Height = 450;

            Grid mainGrid = new Grid();
            mainGrid.Background = new SolidColorBrush(Color.FromRgb(20, 200, 50));
            
            RowDefinition rowDef1 = new RowDefinition();
            rowDef1.Height = new GridLength(0.3, GridUnitType.Star);
            RowDefinition rowDef2 = new RowDefinition();
            rowDef2.Height = new GridLength(2.5, GridUnitType.Star);
            RowDefinition rowDef3 = new RowDefinition();
            rowDef3.Height = new GridLength(0.5, GridUnitType.Star);

            mainGrid.RowDefinitions.Add(rowDef1);
            mainGrid.RowDefinitions.Add(rowDef2);
            mainGrid.RowDefinitions.Add(rowDef3);

            Grid grid2 = new Grid();
            ColumnDefinition columnDef1 = new ColumnDefinition();
            columnDef1.Width = new GridLength(4, GridUnitType.Star);
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(columnDef1);
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetRow(grid2, 1);
            mainGrid.Children.Add(grid2);

            Grid grid2_1 = new Grid();
            RowDefinition rowDef4 = new RowDefinition();
            rowDef4.Height = new GridLength(0.5, GridUnitType.Star);
            RowDefinition rowDef5 = new RowDefinition();
            rowDef5.Height = new GridLength(0.5, GridUnitType.Star);
            grid2_1.RowDefinitions.Add(rowDef4);
            grid2_1.RowDefinitions.Add(new RowDefinition());
            grid2_1.RowDefinitions.Add(new RowDefinition());
            grid2_1.RowDefinitions.Add(rowDef5);
            Grid.SetColumn(grid2_1, 0);
            grid2.Children.Add(grid2_1);

            Grid grid2_2 = new Grid();
            grid2_2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2_2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2_2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2_2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2_2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2_2.RowDefinitions.Add(new RowDefinition());
            grid2_2.RowDefinitions.Add(new RowDefinition());
            grid2_2.RowDefinitions.Add(new RowDefinition());
            grid2_2.RowDefinitions.Add(new RowDefinition());
            grid2_2.RowDefinitions.Add(new RowDefinition());
            Grid.SetColumn(grid2_2, 1);
            grid2.Children.Add(grid2_2);


            Grid grid2_3 = new Grid();
            RowDefinition rowDef6 = new RowDefinition();
            rowDef6.Height = new GridLength(74, GridUnitType.Star);
            RowDefinition rowDef7 = new RowDefinition();
            rowDef7.Height = new GridLength(183, GridUnitType.Star);
            RowDefinition rowDef8 = new RowDefinition();
            rowDef8.Height = new GridLength(106, GridUnitType.Star);
            grid2_3.RowDefinitions.Add(rowDef6);
            grid2_3.RowDefinitions.Add(rowDef7);
            grid2_3.RowDefinitions.Add(rowDef8);
            Grid.SetColumn(grid2_3, 2);
            grid2.Children.Add(grid2_3);

            Grid grid3 = new Grid();
            ColumnDefinition columnDef2 = new ColumnDefinition();
            columnDef2.Width = new GridLength(0.7, GridUnitType.Star);
            ColumnDefinition columnDef3 = new ColumnDefinition();
            columnDef3.Width = new GridLength(5, GridUnitType.Star);
            ColumnDefinition columnDef4 = new ColumnDefinition();
            columnDef4.Width = new GridLength(5, GridUnitType.Star);
            ColumnDefinition columnDef5 = new ColumnDefinition();
            columnDef5.Width = new GridLength(5, GridUnitType.Star);
            ColumnDefinition columnDef6 = new ColumnDefinition();
            columnDef6.Width = new GridLength(0.7, GridUnitType.Star);
            grid3.ColumnDefinitions.Add(columnDef2);
            grid3.ColumnDefinitions.Add(columnDef3);
            grid3.ColumnDefinitions.Add(columnDef4);
            grid3.ColumnDefinitions.Add(columnDef5);
            grid3.ColumnDefinitions.Add(columnDef6);
            Grid.SetRow(grid3, 2);
            mainGrid.Children.Add(grid3);

            Label score_Label = new Label();
            score_Label.Content = "Score";
            score_Label.FontSize = 24;
            score_Label.FontFamily = new FontFamily("Segoe Print");
            score_Label.FontWeight = FontWeights.Bold;
            score_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            score_Label.Margin = new Thickness(10, 0, 0.2, 9.8);
            Grid.SetRow(score_Label, 0);
            grid2_1.Children.Add(score_Label);

            Label teamX_Label = new Label();
            teamX_Label.Content = "Team X";
            teamX_Label.FontSize = 20;
            teamX_Label.FontFamily = new FontFamily("Segoe Print");
            teamX_Label.FontWeight = FontWeights.Bold;
            teamX_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            teamX_Label.Margin = new Thickness(10, 9.6, 0.2, 42.8);
            Grid.SetRow(teamX_Label, 1);
            grid2_1.Children.Add(teamX_Label);

            Label teamO_Label = new Label();
            teamO_Label.Content = "Team O";
            teamO_Label.FontSize = 20;
            teamO_Label.FontFamily = new FontFamily("Segoe Print");
            teamO_Label.FontWeight = FontWeights.Bold;
            teamO_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            teamO_Label.Margin = new Thickness(10, 9.6, 0.2, 42.8);
            Grid.SetRow(teamO_Label, 2);
            grid2_1.Children.Add(teamO_Label);

            Label currentTurn_Label = new Label();
            currentTurn_Label.Content = "Current \n Turn";
            currentTurn_Label.FontSize = 20;
            currentTurn_Label.FontFamily = new FontFamily("Segoe Print");
            currentTurn_Label.FontWeight = FontWeights.Bold;
            currentTurn_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            currentTurn_Label.Margin = new Thickness(0, 0.4, 0.4, 0);
            Grid.SetRow(currentTurn_Label, 1);
            grid2_3.Children.Add(currentTurn_Label);
       
            CurrentTurnLabel.Content = "X";
            CurrentTurnLabel.FontSize = 65;
            CurrentTurnLabel.FontFamily = new FontFamily("Segoe Print");
            CurrentTurnLabel.FontWeight = FontWeights.Bold;
            CurrentTurnLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            CurrentTurnLabel.Margin = new Thickness(20, 42.6, 0.4, 0.6);
            Grid.SetRow(CurrentTurnLabel, 1);
            grid2_3.Children.Add(CurrentTurnLabel);

            Score_X_Label.Content = "0";
            Score_X_Label.FontSize = 20;
            Score_X_Label.FontFamily = new FontFamily("Segoe Print");
            Score_X_Label.FontWeight = FontWeights.Bold;
            Score_X_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Score_X_Label.Margin = new Thickness(36, 53, 36.2, 10.4);     
            Grid.SetRow(Score_X_Label, 1);
            grid2_1.Children.Add(Score_X_Label);

            Score_O_Label.Content = "0";
            Score_O_Label.FontSize = 20;
            Score_O_Label.FontFamily = new FontFamily("Segoe Print");
            Score_O_Label.FontWeight = FontWeights.Bold;
            Score_O_Label.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Score_O_Label.Margin = new Thickness(36, 53, 36.2, 10.4);
            Grid.SetRow(Score_O_Label, 2);
            grid2_1.Children.Add(Score_O_Label);

            Button MoveToMain_Btn = new Button();
            MoveToMain_Btn.Content = "Main Window";
            MoveToMain_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            MoveToMain_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            MoveToMain_Btn.Margin = new Thickness(10);
            MoveToMain_Btn.FontFamily = new FontFamily("Segoe Print");
            MoveToMain_Btn.FontSize = 22;
            MoveToMain_Btn.FontWeight = FontWeights.Bold;
            MoveToMain_Btn.Click += MoveToMainFromThird_Btn_Click;
            Grid.SetColumn(MoveToMain_Btn, 1);
            grid3.Children.Add(MoveToMain_Btn);

            Button StartTwoPlayers_Btn = new Button();
            StartTwoPlayers_Btn.Content = "Two Players";
            StartTwoPlayers_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            StartTwoPlayers_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            StartTwoPlayers_Btn.Margin = new Thickness(10);
            StartTwoPlayers_Btn.FontFamily = new FontFamily("Segoe Print");
            StartTwoPlayers_Btn.FontSize = 22;
            StartTwoPlayers_Btn.FontWeight = FontWeights.Bold;
            StartTwoPlayers_Btn.Click += StartTwoPlayersBtn_Click;
            Grid.SetColumn(StartTwoPlayers_Btn, 2);
            grid3.Children.Add(StartTwoPlayers_Btn);

            Button StartOnePlayer_Btn = new Button();
            StartOnePlayer_Btn.Content = "One Player";
            StartOnePlayer_Btn.Background = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            StartOnePlayer_Btn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            StartOnePlayer_Btn.Margin = new Thickness(10);
            StartOnePlayer_Btn.FontFamily = new FontFamily("Segoe Print");
            StartOnePlayer_Btn.FontSize = 22;
            StartOnePlayer_Btn.FontWeight = FontWeights.Bold;
            StartOnePlayer_Btn.Click += StartOnePlayerBtn_Click;
            Grid.SetColumn(StartOnePlayer_Btn, 3);
            grid3.Children.Add(StartOnePlayer_Btn);

            Content = mainGrid;

            currentTurn = true;
            numOfXTurns = 1;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
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
                    Grid.SetColumn(gameField[i, j], i);
                    Grid.SetRow(gameField[i, j], j);

                    grid2_2.Children.Add(gameField[i, j]);

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

            if (RowChecker(symbol, y) || ColumnChecker(symbol, x) || FirstDiagonalChecker(symbol) || SecondDiagonalChecker(symbol))
            {

                WinnerMessage winnerMessage = new WinnerMessage(symbol + " WINS");
                winnerMessage.ShowDialog();

                ChangeScore();
                currentTurn = !currentTurn;
                return true;
            }
            else if (numOfXTurns == 13)
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
            for (int i = 0; i < 5; i++)
            {
                if (gameField[i, y].Content != symbol)
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

            if (x == y)
            {
                AnalyseFirstDiagonal();
            }
            if ((x + y) == 4)
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

            for (int i = 0; i < 5; i++)
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

            if ((numOf_X + numOf_O) == 5)
            {
                rowsCoef[y] = 0;
                return;
            }
            if (numOf_X > 0 && numOf_O > 0)
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
            if (numOf_X > 0)
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
            else if (columnsMax > rowsMax)
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

            return (x, y);
        }
    }
    public class ExtendedButton : Button
    {

        public int x;
        public int y;
    }

}

