using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Queens_Puzzle
{
    class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedColumns = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonal = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonal = new HashSet<int>();

        static void Main(string[] args)
        {
            var board = new bool[8, 8];

            PutQueens(board, 0);


        }
        public static void PutQueens(bool[,] board, int row)
        {

            if (row == board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int column = 0; column < board.GetLength(1); column++)
            {
                if (!IsAttacked(row, column))
                {
                    board[row, column] = true;
                    attackedRows.Add(row);
                    attackedColumns.Add(column);
                    attackedLeftDiagonal.Add(row - column);
                    attackedRightDiagonal.Add(row + column);

                    PutQueens(board, row + 1);

                    board[row, column] = false;
                    attackedRows.Remove(row);
                    attackedColumns.Remove(column);
                    attackedLeftDiagonal.Remove(row - column);
                    attackedRightDiagonal.Remove(row + column);
                }
            }
        }
        public static bool IsAttacked(int row, int column)
        {
            return attackedRows.Contains(row) || attackedColumns.Contains(column) || attackedLeftDiagonal.Contains(row - column) || attackedRightDiagonal.Contains(row + column);
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    if (board[r, c])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    }

