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
                (
                    question: "Кто вы?",
                    answersOptions: new List<string>()
                    {
                        "Человек", "Брандлмуха", "Кхаджит"
                    }
                ),
                new QuestionaryElement
                (
                    question: "Что вы хотите?",
                    answersOptions: new List<string>()
                    {
                        "Победить Аразота", "Стать богатым", "Найти боевых товарищей"
                    }
                ),
                new QuestionaryElement
                (
                    question: "Чем вы можете помочь ордену?",
                    answersOptions: new List<string>()
                    {
                        "Я отлчиный воин", "Я добротный маг", "Я могу работать в кузнице"
                    }
                )
            };

            Console.WriteLine("Совершенно очевидно, что мы не берём в наш орден кого попало. По этому заполни вот эту анкету, " +
                              "и мы примем решение, брать тебя или нет");

            foreach (var qestionaryElement in questionary)
            {
                Console.WriteLine(qestionaryElement.Question);

                int i = 0;
                foreach (var answers in qestionaryElement.AnswersOptions)
                {
                    Console.WriteLine("[{0}]>{1}", i++, answers);
                }
       
                qestionaryElement.PutAnswer(Console.ReadLine());
            }
        }
    }

}

