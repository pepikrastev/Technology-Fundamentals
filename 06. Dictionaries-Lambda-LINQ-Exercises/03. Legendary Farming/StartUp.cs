﻿namespace _03._Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();

            keyMaterials.Add("motes", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("shards", 0);

            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                bool hasToBreak = false;

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (material == "motes" || material == "fragments" || material == "shards")
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] -= 250;

                            if (material == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (material == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            else if (material == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }
                            hasToBreak = true;
                            break;
                        }
                    }

                    else
                    {
                        if (!junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] = 0;
                        }

                        junkMaterials[material] += quantity;
                    }
                }

                if (hasToBreak)
                {
                    break;
                }
            }

            foreach (var kvp in keyMaterials.OrderByDescending(k => k.Value).ThenBy(kvp => kvp.Key))
            {
                string material = kvp.Key;
                int quantity = kvp.Value;

                Console.WriteLine($"{material}: {quantity}");
            }

            foreach (var kvp in junkMaterials.OrderBy(k => k.Key))
            {
                string material = kvp.Key;
                int quantity = kvp.Value;

                Console.WriteLine($"{material}: {quantity}");
            }
        }
    }
}
