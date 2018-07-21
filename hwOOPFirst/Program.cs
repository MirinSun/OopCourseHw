using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Linq;
using System.Collections;

namespace hwOOPFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Questionary questionary = new Questionary()
            {
                new QuestionaryElement
                {
                    Question = "Кто вы?",
                    AnswersOptions = new String[]
                    {
                        "Человек", "Брандлмуха", "Кхаджит"
                    }             
                },
                new QuestionaryElement
                {
                    Question = "Что вы хотите?",
                    AnswersOptions = new String[]
                    {
                        "Победить Аразота", "Стать богатым", "Найти боевых товарищей"
                    }
                },
                new QuestionaryElement
                {
                    Question = "Чем вы можете помочь ордену?",
                    AnswersOptions = new String[]
                    {
                        "Я отлчиный воин", "Я добротный маг", "Я могу работать в кузнице"
                    }
                }
            };

            Console.WriteLine("Совершенно очевидно, что мы не берём в наш орден кого попало. По этому заполни вот эту анкету, " +
                              "и мы примем решение, брать тебя или нет");

            foreach (var qestionaryElement in questionary)
            {
                Console.WriteLine(qestionaryElement.Question);

                for (int i = 0; i < qestionaryElement.AnswersOptions.Length; i++)
                {
                    Console.WriteLine("[{0}]>{1}", i, qestionaryElement.AnswersOptions[i]);
                }
                
                qestionaryElement.PutAnswer(Console.ReadLine());
            }
        }
    }

}

