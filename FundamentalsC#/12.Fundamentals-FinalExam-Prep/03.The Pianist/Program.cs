using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Fundamentals
{
    class Piece
    {
        public Piece(string name, string composer, string key)
        {
            this.Name = name;
            this.Composer = composer;
            this.Key = key;
        }
        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPieces = int.Parse(Console.ReadLine());

            List<Piece> noteBook = new List<Piece>();

            for (int i = 0; i < numberOfPieces; i++)
            {
                string newPiece = Console.ReadLine();
                string[] pieceArgs = newPiece.Split('|', StringSplitOptions.RemoveEmptyEntries);

                Piece piece = new Piece (pieceArgs[0], pieceArgs[1], pieceArgs[2]);

                noteBook.Add(piece);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] split = input.Split('|');
                string command = split[0];
                string pieceName = split[1];

                if (command == "Add")
                {
                    if (!IsPieceInCollection(noteBook, pieceName))
                    {
                        string composer = split[2];
                        string key = split[3];

                        Piece piece = new Piece(pieceName, composer, key);
                        noteBook.Add(piece);

                        Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    if (IsPieceInCollection(noteBook, pieceName))
                    {
                        foreach (Piece piece in noteBook)
                        {
                            if (piece.Name == pieceName)
                            {
                                noteBook.Remove(piece);
                                Console.WriteLine($"Successfully removed {pieceName}!");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
                else
                {
                    if (IsPieceInCollection(noteBook, pieceName))
                    {
                        string key = split[2];

                        foreach (Piece piece in noteBook)
                        {
                            if (piece.Name == pieceName)
                            {
                                piece.Key = key;
                                Console.WriteLine($"Changed the key of {pieceName} to {key}!");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
            }

            foreach (Piece piece in noteBook)
            {
                Console.WriteLine($"{piece.Name} -> Composer: {piece.Composer}, Key: {piece.Key}");
            }
        }
        static bool IsPieceInCollection (List<Piece> noteBook, string pieceName)
        {
            foreach (Piece piece in noteBook)
            {
                if (pieceName == piece.Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
