using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthTask
{
    class DialogueGUI
    {
        private Dialogue[] _dialogues;

        public DialogueGUI(Dialogue[] dialogue) => 
            _dialogues = dialogue ?? throw new ArgumentNullException();

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("Доступные команды: \nShowAll - показать все диалоги\nStart n - запустить n диалог");

            string ch = Console.ReadLine();

            switch (ch)
            {
                case "ShowAll":
                    foreach (var item in _dialogues)
                    {
                        Console.WriteLine($"{item.Name}\n");
                    }
                    break;
                case "Start 1":
                    StartDialogue(0);
                    break;
                default:
                    Console.WriteLine("Вы ввели неверную команду");
                    break;
            }
            Console.ReadKey();
        }
        private void StartDialogue(int n)
        {
            Console.Clear();
            DialogueComponent component = _dialogues[n].GetStartComponent();

            while(!component.IsEnding)
            {
                try
                {
                    Console.WriteLine($"\n{component.Sentence}\n");
                    foreach (var item in component.Answers.Keys)
                    {
                        Console.WriteLine($"{item}\n");
                    }

                    Console.Write("Введите ответ: ");
                    component = _dialogues[n].PutAnswer(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex.Message}\n");
                }              
            }
          
            Console.WriteLine($"\n{component.Sentence}\n");
            _dialogues[n].Reset();
        }
    }
}
