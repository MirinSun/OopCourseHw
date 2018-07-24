using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthTask
{
    class DialogueGUI
    {
        private Dialogue[] _dialoge;

        public DialogueGUI(Dialogue[] dialogue) => 
            _dialoge = dialogue ?? throw new ArgumentNullException();

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("Доступные команды: \nShowAll - показать все диалоги\nStart n - запустить n диалог");

            string ch = Console.ReadLine();

            switch (ch)
            {
                case "ShowAll":
                    foreach (var item in _dialoge)
                    {
                        Console.WriteLine($"{item.Name}\n");
                    }
                    break;
                case "Start 1":
                    StartDialog(0);
                    break;
                default:
                    Console.WriteLine("Вы ввели неверную команду");
                    break;
            }
            Console.ReadKey();
        }
        private void StartDialog(int n)
        {
            DialogueComponent component = _dialoge[n].GetStartComponent();

            do
            {      
                try
                {
                    Console.WriteLine($"{component.Sentence}\n");

                    if (component is DialogueComposit)
                    {
                        foreach (var item in ((DialogueComposit)component).Answers.Keys)
                        {
                            Console.WriteLine($"{item}\n");
                        }

                        component = _dialoge[n].PutAnwser(Console.ReadLine());
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex.Message}\n");
                }
                

            } while (component is DialogueComposit);

            Console.WriteLine($"{component.Sentence}\n");
            _dialoge[n].Reset();
        }
    }
}
