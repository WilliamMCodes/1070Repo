using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class TicTacToe
    {
        private Regex checkInput = new Regex("[A-Ca-c][1-3]");
        private int[,] gameBoard;
        readonly bool firstGoesFirst;
        private int turnNumber;
        player2 opponent = new();
        gameStatus status = new();
        enum gameStatus
        {
            PLAYER_1Wins,
            PLAYER_2Wins,
            Draw,
            Continue
        }
        enum player2
        {
            COMPUTER,
            PLAYER_2
        }
        TicTacToe(int numberOfPlayers, bool firstGoesFirst) 
        {
            gameBoard = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            if(numberOfPlayers > 1)
            {
                opponent = player2.PLAYER_2;
            }
            else
            {
                opponent = player2.COMPUTER;
            }
            this.firstGoesFirst = firstGoesFirst;
            status = gameStatus.Continue;
            while (status == gameStatus.Continue)
            {
                DisplayBoard();

            }
        }

        public void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine($"\nfirstGoesFirst && turnNumber % 2 == 0 || !firstGoesFirst && turnNumber % 2 != 0 ? \n   | PLAYER_1 | {opponent}\n\n : \n     PLAYER_1 | {opponent} |\n");
            Console.WriteLine($"" +
                $"          1   2   3\n" +
                $"      A   {gameBoard[0,0]} | {gameBoard[0,1]} | {gameBoard[0,2]}   \n" +
                $"        -------------\n" +
                $"      B   {gameBoard[1,0]} | {gameBoard[1,1]} | {gameBoard[1,2]}   \n" +
                $"        -------------\n" +
                $"      C   {gameBoard[2,0]} | {gameBoard[2,1]} | {gameBoard[2,2]}   \n");
            Console.Write($"\nfirstGoesFirst && turnNumber % 2 == 0 || !firstGoesFirst && turnNumber % 2 != 0 ? Please enter PLAYER_1's move: : \nPlease enter {opponent}'s move: \n");
        }

        public void SetTicsAndTacs(string playerInput)
        {
            try
            {
                if (checkInput.IsMatch(playerInput))
                {
                    int player;
                    if(firstGoesFirst && turnNumber % 2 == 0 || !firstGoesFirst && turnNumber % 2 != 0)
                    {
                        player = 1;
                    }
                    else
                    {
                        player = 2;
                    }
                    int x = int.Parse(playerInput[1].ToString()) - 1;
                    switch (Char.ToUpper(playerInput[0]))
                    {
                        case 'A':
                            if(IsEmptySpace(0, x))
                            {
                                gameBoard[0, x] = player;
                                ++turnNumber;
                                break;
                            }
                            else
                            {
                                throw new Exception("Please enter only empty locations contained on the screen.\n\nPress any key to continue.");
                            }
                        case 'B':
                            if (IsEmptySpace(1, x))
                            {
                                gameBoard[1, x] = player;
                                ++turnNumber;
                                break;
                            }
                            else
                            {
                                throw new Exception("Please enter only empty locations contained on the screen.\n\nPress any key to continue.");
                            }
                        case 'C':
                            if (IsEmptySpace(2, x))
                            {
                                gameBoard[2, x] = player;
                                ++turnNumber;
                                break;
                            }
                            else
                            {
                                throw new Exception("Please enter only empty locations contained on the screen.\n\nPress any key to continue.");
                            }
                        default:
                            throw new Exception("Please enter only accepted values.\n\nPress any key to continue.");


                    }
                }
                else
                {
                    throw new Exception( "Please enter only empty locations contained on the screen.\n\nPress any key to continue.");
                }
            }
            catch(Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        private bool IsEmptySpace(int y, int x)
        {
            if(gameBoard[y, x] == 0)
            {
                return true;
            }
            return false;
        }
        private string DecideBlockOrWin()
        {
            //check for winning move
            char letter;
            for (int y = 0; y < 3; y++)
            {
                //check rows for a winning move
                if (gameBoard[y, 0] == 2 && (gameBoard[y, 1] == 2 || gameBoard[y, 2] == 2) && (gameBoard[y, 1] == 0 || gameBoard[y, 2] == 0) ||
                    gameBoard[y, 1] == 2 && (gameBoard[y, 0] == 2 || gameBoard[y, 2] == 2) && (gameBoard[y, 0] == 0 || gameBoard[y, 2] == 0) ||
                    gameBoard[y, 2] == 2 && (gameBoard[y, 1] == 2 || gameBoard[y, 0] == 2) && (gameBoard[y, 1] == 0 || gameBoard[y, 0] == 0))
                {
                    switch (y)
                    {
                        case 0:
                            letter = 'A';
                            break;
                        case 1:
                            letter = 'B';
                            break;
                        case 2:
                            letter = 'C';
                            break;
                        default:
                            letter = 'D';
                            break;
                    }
                    for (int x = 0; x < 3; x++)
                    {
                        if (gameBoard[y, x] == 0)
                        {
                            return $"{letter}{x}";
                        }
                    }
                }
                //check diagnol top left to bottom right
                if (y == 0)
                {
                    if (gameBoard[y, 0] == 2 && (gameBoard[y + 1, 1] == 2 || gameBoard[y + 2, 2] == 2) && (gameBoard[y + 1, 1] == 0 || gameBoard[y + 2, 2] == 0) ||
                    gameBoard[y + 1, 1] == 2 && (gameBoard[y, 0] == 2 || gameBoard[y + 2, 2] == 2) && (gameBoard[y, 0] == 0 || gameBoard[y + 2, 2] == 0) ||
                    gameBoard[y + 2, 2] == 2 && (gameBoard[y + 1, 1] == 2 || gameBoard[y + 2, 0] == 2) && (gameBoard[y + 1, 1] == 0 || gameBoard[y, 0] == 0))
                    {
                        for (y = 0; y < 3; y++)
                        {
                            int x = y;
                            switch (y)
                            {
                                case 0:
                                    letter = 'A';
                                    break;
                                case 1:
                                    letter = 'B';
                                    break;
                                case 2:
                                    letter = 'C';
                                    break;
                                default:
                                    letter = 'D';
                                    break;
                            }
                            if (gameBoard[y, x] == 0)
                            {
                                return $"{letter}{x}";
                            }
                        }
                    }
                }
                //check bottom left to top right
                else if (y == 2)
                {
                    if (gameBoard[y, 0] == 2 && (gameBoard[y - 1, 1] == 2 || gameBoard[y - 2, 2] == 2) && (gameBoard[y - 1, 1] == 0 || gameBoard[y - 2, 2] == 0) ||
                    gameBoard[y - 1, 1] == 2 && (gameBoard[y, 0] == 2 || gameBoard[y - 2, 2] == 2) && (gameBoard[y, 0] == 0 || gameBoard[y - 2, 2] == 0) ||
                    gameBoard[y - 2, 2] == 2 && (gameBoard[y - 1, 1] == 2 || gameBoard[y - 2, 0] == 2) && (gameBoard[y - 1, 1] == 0 || gameBoard[y, 0] == 0))
                    {
                        int x = 0;
                        for (y = 2; y >= 0; y--)
                        {
                            switch (y)
                            {
                                case 0:
                                    letter = 'A';
                                    break;
                                case 1:
                                    letter = 'B';
                                    break;
                                case 2:
                                    letter = 'C';
                                    break;
                                default:
                                    letter = 'D';
                                    break;
                            }
                            if (gameBoard[y, x] == 0)
                            {
                                return $"{letter}{x}";
                            }
                            x++;
                        }
                    }
                }
            }
            //check columns for win
            for (int x = 0; x < 3; x++)
            {
                //check rows for a winning move
                if (gameBoard[0, x] == 2 && (gameBoard[1, x] == 2 || gameBoard[2, x] == 2) && (gameBoard[1, x] == 0 || gameBoard[2, x] == 0) ||
                    gameBoard[1, x] == 2 && (gameBoard[0, x] == 2 || gameBoard[2, x] == 2) && (gameBoard[0, x] == 0 || gameBoard[2, x] == 0) ||
                    gameBoard[2, x] == 2 && (gameBoard[1, x] == 2 || gameBoard[0, x] == 2) && (gameBoard[1, x] == 0 || gameBoard[0, x] == 0))
                {
                    for (int y = 0; y < 3; y++)
                    {
                        switch (y)
                        {
                            case 0:
                                letter = 'A';
                                break;
                            case 1:
                                letter = 'B';
                                break;
                            case 2:
                                letter = 'C';
                                break;
                            default:
                                letter = 'D';
                                break;
                        }
                        if (gameBoard[y, x] == 0)
                        {
                            return $"{letter}{x}";
                        }
                    }
                }
            }

            //check all the previous for blocking moves
            for (int y = 0; y < 3; y++)
            {
                //check rows for a player_1 winning move
                if (gameBoard[y, 0] == 1 && (gameBoard[y, 1] == 1 || gameBoard[y, 2] == 1) && (gameBoard[y, 1] == 0 || gameBoard[y, 2] == 0) ||
                    gameBoard[y, 1] == 1 && (gameBoard[y, 0] == 1 || gameBoard[y, 2] == 1) && (gameBoard[y, 0] == 0 || gameBoard[y, 2] == 0) ||
                    gameBoard[y, 2] == 1 && (gameBoard[y, 1] == 1 || gameBoard[y, 0] == 1) && (gameBoard[y, 1] == 0 || gameBoard[y, 0] == 0))
                {
                    switch (y)
                    {
                        case 0:
                            letter = 'A';
                            break;
                        case 1:
                            letter = 'B';
                            break;
                        case 2:
                            letter = 'C';
                            break;
                        default:
                            letter = 'D';
                            break;
                    }
                    for (int x = 0; x < 3; x++)
                    {
                        if (gameBoard[y, x] == 0)
                        {
                            return $"{letter}{x}";
                        }
                    }
                }
                //check diagnol top left to bottom right
                if (y == 0)
                {
                    if (gameBoard[y, 0] == 1 && (gameBoard[y + 1, 1] == 1 || gameBoard[y + 2, 2] == 1) && (gameBoard[y + 1, 1] == 0 || gameBoard[y + 2, 2] == 0) ||
                    gameBoard[y + 1, 1] == 1 && (gameBoard[y, 0] == 1 || gameBoard[y + 2, 2] == 1) && (gameBoard[y, 0] == 0 || gameBoard[y + 2, 2] == 0) ||
                    gameBoard[y + 2, 2] == 1 && (gameBoard[y + 1, 1] == 1 || gameBoard[y + 2, 0] == 1) && (gameBoard[y + 1, 1] == 0 || gameBoard[y, 0] == 0))
                    {
                        for (y = 0; y < 3; y++)
                        {
                            int x = y;
                            switch (y)
                            {
                                case 0:
                                    letter = 'A';
                                    break;
                                case 1:
                                    letter = 'B';
                                    break;
                                case 2:
                                    letter = 'C';
                                    break;
                                default:
                                    letter = 'D';
                                    break;
                            }
                            if (gameBoard[y, x] == 0)
                            {
                                return $"{letter}{x}";
                            }
                        }
                    }
                }
                //check bottom left to top right
                else if (y == 2)
                {
                    if (gameBoard[y, 0] == 1 && (gameBoard[y - 1, 1] == 1 || gameBoard[y - 2, 2] == 1) && (gameBoard[y - 1, 1] == 0 || gameBoard[y - 2, 2] == 0) ||
                    gameBoard[y - 1, 1] == 1 && (gameBoard[y, 0] == 1 || gameBoard[y - 2, 2] == 1) && (gameBoard[y, 0] == 0 || gameBoard[y - 2, 2] == 0) ||
                    gameBoard[y - 2, 2] == 1 && (gameBoard[y - 1, 1] == 1 || gameBoard[y - 2, 0] == 1) && (gameBoard[y - 1, 1] == 0 || gameBoard[y, 0] == 0))
                    {
                        int x = 0;
                        for (y = 2; y >= 0; y--)
                        {
                            switch (y)
                            {
                                case 0:
                                    letter = 'A';
                                    break;
                                case 1:
                                    letter = 'B';
                                    break;
                                case 2:
                                    letter = 'C';
                                    break;
                                default:
                                    letter = 'D';
                                    break;
                            }
                            if (gameBoard[y, x] == 0)
                            {
                                return $"{letter}{x}";
                            }
                            x++;
                        }
                    }
                }
            }
            //check columns for player_1 win
            for (int x = 0; x < 3; x++)
            {
                if (gameBoard[0, x] == 1 && (gameBoard[1, x] == 1 || gameBoard[2, x] == 1) && (gameBoard[1, x] == 0 || gameBoard[2, x] == 0) ||
                    gameBoard[1, x] == 1 && (gameBoard[0, x] == 1 || gameBoard[2, x] == 1) && (gameBoard[0, x] == 0 || gameBoard[2, x] == 0) ||
                    gameBoard[2, x] == 1 && (gameBoard[1, x] == 1 || gameBoard[0, x] == 1) && (gameBoard[1, x] == 0 || gameBoard[0, x] == 0))
                {
                    for (int y = 0; y < 3; y++)
                    {
                        switch (y)
                        {
                            case 0:
                                letter = 'A';
                                break;
                            case 1:
                                letter = 'B';
                                break;
                            case 2:
                                letter = 'C';
                                break;
                            default:
                                letter = 'D';
                                break;
                        }
                        if (gameBoard[y, x] == 0)
                        {
                            return $"{letter}{x}";
                        }
                    }
                }
            }
            //early moves when there may not be a "block or win" option

        }
    }
}