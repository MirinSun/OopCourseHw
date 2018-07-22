using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            DialogueTreeComponent one = new DialogueTreeComponent
                (
                    new DialogFragment
                    (
                        question: "Кто вы такой?",
                        answersOptions: new List<string>()
                        {
                            "Человек","Эльф","Гном"
                        }
                     )
                );

            DialogueTreeComponent two = new DialogueTreeComponent
                            (
                                new DialogFragment
                                (
                                    question: "?",
                                    answersOptions: new List<string>()
                                    {
                                        "Человек","Эльф","Гном"
                                    }
                                 )
                            );
        }
    }
}
