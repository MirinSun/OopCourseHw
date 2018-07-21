using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMarkTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] goalsIndividual = new string[0], goalsWork = new string[0], goalsFamilly = new string[0];

            while (true)
            {
                Console.Clear();
                //поиск длинны самого длинного списка на данный момент
                int max = goalsIndividual.Length > goalsWork.Length ? goalsIndividual.Length : goalsWork.Length;
                max = max > goalsFamilly.Length ? max : goalsFamilly.Length;

                Console.WriteLine("Личный | Рабочий | Семейный");
                for (int i = 0; i < max; i++)
                {
                    if (goalsIndividual.Length > i)
                    {
                        Console.Write(goalsIndividual[i] + " | ");
                    }
                    else
                    {
                        Console.Write("Empty | ");
                    }

                    if (goalsWork.Length > i)
                    {
                        Console.Write(goalsWork[i] + " | ");
                    }
                    else
                    {
                        Console.Write("Empty | ");
                    }

                    if (goalsFamilly.Length > i)
                    {
                        Console.Write(goalsFamilly[i] + " | ");
                    }
                    else
                    {
                        Console.Write("Empty | ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Куда вы хотите добавить цель?");
                string listName = Console.ReadLine().ToLower(); //то что введёт пользователь переведённое в нижний регистр
                Console.WriteLine("Что это за цель?");
                string goal = Console.ReadLine();

                //Здесь нельзя использовать Array.Resize
                if (listName == "личный")
                {
                    string[] goalsIndividualNew = new string[goalsIndividual.Length + 1];
                    for (int j = 0; j < goalsIndividual.Length; j++)
                    {
                        goalsIndividualNew[j] = goalsIndividual[j];
                    }
                    goalsIndividualNew[goalsIndividualNew.Length - 1] = goal;
                    goalsIndividual = goalsIndividualNew;
                }
                else if (listName == "рабочий")
                {
                    string[] goalsWorkNew = new string[goalsWork.Length + 1];
                    for (int j = 0; j < goalsWork.Length; j++)
                    {
                        goalsWorkNew[j] = goalsWork[j];
                    }
                    goalsWorkNew[goalsWorkNew.Length - 1] = goal;
                    goalsWork = goalsWorkNew;
                }
                else if (listName == "семейный")
                {
                    string[] goalsFamillyNew = new string[goalsFamilly.Length + 1];
                    for (int j = 0; j < goalsFamilly.Length; j++)
                    {
                        goalsFamillyNew[j] = goalsFamilly[j];
                    }
                    goalsFamillyNew[goalsFamillyNew.Length - 1] = goal;
                    goalsFamilly = goalsFamillyNew;
                }

            }
        }
    }
}
