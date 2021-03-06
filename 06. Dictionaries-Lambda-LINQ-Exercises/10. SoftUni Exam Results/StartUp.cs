﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> namePoints = new Dictionary<string, int>();
            Dictionary<string, int> languageCount = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "exam finished")
                {
                    break;
                }

                string[] inputArgs = input.Split("-");
                string name = inputArgs[0];
                string language = inputArgs[1];

                if (inputArgs.Length == 2)
                {
                    namePoints.Remove(name);
                    continue;
                }

                int points = int.Parse(inputArgs[2]);

                if (namePoints.ContainsKey(name) == false)
                {
                    namePoints[name] = points;
                }
                else
                {
                    if (points > namePoints[name])
                    {
                        namePoints[name] = points;
                    }
                }

                if (languageCount.ContainsKey(language) == false)
                {
                    languageCount[language] = 1;
                }
                else
                {
                    languageCount[language]++;
                }
            }

            Console.WriteLine("Results:");
            Console.WriteLine(string.Join(Environment.NewLine, namePoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Select(a => $"{a.Key} | {a.Value}")));

            Console.WriteLine("Submissions:");
            Console.WriteLine(string.Join(Environment.NewLine, languageCount
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(a => $"{a.Key} - {a.Value}")));
        }
    }
}
