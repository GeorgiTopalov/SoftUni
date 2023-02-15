using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());


            int rows = input;
            int cols = input;

            char[,] chessBoard = new char[rows, cols];

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                string rowArgs = Console.ReadLine();

                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = rowArgs[col];
                }
            }

            int knightsToRemove = 0;

            while (true)
            {
                int maxAttacks = 0;
                int knightToRemoveRow = 0;
                int knightToRemoveCol = 0;

                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        if (chessBoard[row, col] == '0')
                        {
                            continue;
                        }

                        int attacks = 0;


                        if (IsIndexValid(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
                        {
                            attacks++;
                        }
                        if (IsIndexValid(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
                        {
                            attacks++;

                        }
                        if (IsIndexValid(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
                        {
                            attacks++;

                        }
                        if (IsIndexValid(chessBoard, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
                        {
                            attacks++;

                        }
                        if (IsIndexValid(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
                        {
                            attacks++;

                        }
                        if (IsIndexValid(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
                        {
                            attacks++;

                        }
                        if (IsIndexValid(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
                        {
                            attacks++;

                        }
                        if (IsIndexValid(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
                        {
                            attacks++;

                        }
                        if (attacks > maxAttacks)
                        {
                            maxAttacks = attacks;
                            knightToRemoveRow = row;
                            knightToRemoveCol = col;
                        }

                    }
                }
                if (maxAttacks > 0)
                {
                    chessBoard[knightToRemoveRow, knightToRemoveCol] = '0';
                    knightsToRemove++;
                }
                else
                {
                    Console.WriteLine(knightsToRemove);
                    break;
                }
            }
        }
        private static bool IsIndexValid(char[,] chessBoard, int row, int col)
        {
            return row >= 0 && row < chessBoard.GetLength(0) &&
                col >= 0 && col < chessBoard.GetLength(1);
        }
    }
}