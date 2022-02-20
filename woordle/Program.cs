﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developpez.Dotnet;
namespace woordle
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCount = 5;
            int count = 0;
            char[] alpha = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z".ToLower().ToArray();
            string wordfound = string.Empty;
            var listLetters = new List<string>();
            int nbLetters = 5;
            bool stop = false;
            while (!stop)
            {
                bool found = false;
                var word = StringExtensions.RemoveDiacritics(Moordle.CreateRandomWord(nbLetters).ToLower());
                Console.WriteLine(" ");
                Console.WriteLine(word.Substring(0, 1) + new string('?', nbLetters - 1));
                listLetters.Add(word.Substring(0, 1));
                Console.WriteLine(" ");
                while (count < maxCount)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine($"[{count}] Nombre de lettres disponibles:");
                    Console.WriteLine(alpha);
                    Console.WriteLine(" ");

                    Console.WriteLine(wordfound);
                    wordfound = word;
                    var test = Console.ReadLine().ToLower();
                    if (word == test)
                    {
                        found = true;
                        break;
                    }
                    else
                    {
                        if (test.Length == word.Length)
                        {
                            for (int a = 0; a < word.Length; a += 1)
                            {
                                if (word[a] == test[a])
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(test[a]);
                                    listLetters.Add(test[a].ToString());
                                }
                                else if (word.ToList().Contains(test[a]))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write(test[a]);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(test[a]);
                                }
                                alpha = alpha.Where(val => val != test[a]).ToArray();
                            }

                        }
                        else
                        {
                            Console.WriteLine("taille incorrecte");
                        }
                        listLetters = listLetters.Distinct().ToList();
                        foreach (var element in word)
                        {
                            if (!listLetters.Contains(element.ToString()))
                            {
                                wordfound = wordfound.Replace(element, '?');
                            }
                        }
                    }
                    count += 1;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (found)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("BINGO !");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Perdu: le mot était: {word}");
                }
                Console.WriteLine("restart ? o/n");
                var res = Console.ReadLine().ToLower();
                if (res == "o")
                {
                    Console.Clear();
                    maxCount = 5;
                    count = 0;
                    alpha = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z".ToLower().ToArray();
                    wordfound = string.Empty;
                    listLetters = new List<string>();
                    nbLetters = 5;
                }
                else
                {
                    stop = true;
                }
            }
        }

    }
}
