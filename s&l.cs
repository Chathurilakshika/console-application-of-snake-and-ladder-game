using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int[] board = new int[101];

        static void Main(string[] args)
        {
            // Initialize the board
            InitializeBoard();

            // Get player names
            Console.WriteLine("Welcome to Snake and Ladder Game!");
            Console.Write("Enter name of Player 1: ");
            string player1 = Console.ReadLine();
            Console.Write("Enter name of Player 2: ");
            string player2 = Console.ReadLine();

            int player1Position = 0;
            int player2Position = 0;
            Random rand = new Random();

            bool gameWon = false;
            while (!gameWon)
            {
                // Player 1's turn
                Console.WriteLine($"{player1}, Please roll the dice.");
                if (Console.ReadKey().KeyChar == 'r')
                {
                    int diceRoll = rand.Next(1, 7);
                    player1Position = MovePlayer(player1, player1Position, diceRoll);
                    gameWon = CheckWin(player1, player1Position);
                }

                if (gameWon) break;

                // Player 2's turn
                Console.WriteLine($"{player2}, Please roll the dice.");
                if (Console.ReadKey().KeyChar == 'r')
                {
                    int diceRoll = rand.Next(1, 7);
                    player2Position = MovePlayer(player2, player2Position, diceRoll);
                    gameWon = CheckWin(player2, player2Position);
                }
            }
        }

        static void InitializeBoard()
        {
            // Ladders
            board[2] = 23;
            board[8] = 34;
            board[20] = 77;
            board[32] = 68;
            board[41] = 79;
            board[74] = 88;
            board[82] = 100;
            board[85] = 95;

            // Snakes
            board[29] = 9;
            board[38] = 15;
            board[47] = 5;
            board[53] = 33;
            board[62] = 37;
            board[86] = 54;
            board[92] = 70;
            board[97] = 25;
        }

        static int MovePlayer(string player, int position, int diceRoll)
        {
            position += diceRoll;
            Console.WriteLine($"{player} rolled a {diceRoll} and moved to {position}");

            if (position > 100)
            {
                position -= diceRoll;
                Console.WriteLine($"{player} rolled too high and stays at {position}");
            }
            else if (board[position] != 0)
            {
                if (position < board[position])
                {
                    Console.WriteLine($"{player} found a ladder at {position}! Climbs up to {board[position]}");
                }
                else
                {
                    Console.WriteLine($"{player} got bitten by a snake at {position}! Slides down to {board[position]}");
                }
                position = board[position];
            }

            Console.WriteLine($"{player} is now at position {position}");
            return position;
        }

        static bool CheckWin(string player, int position)
        {
            if (position == 100)
            {
                Console.WriteLine($"{player} has won the game!");
                return true;
            }
            return false;
        }
    }
}