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
            string[] answers = { "Да", "Нет" };

            DialogueComponent firstEnding = new DialogueEnding("Вы победили!");
            DialogueComponent secondEnding = new DialogueEnding("Вы проиграли");

            DialogueComponent firstBranching = new DialogueComposit
                (
                    question: "А Ваша мама была орком?",
                    answers: new Dictionary<string, DialogueComponent>()
                );
            firstBranching.Add(new KeyValuePair<string, DialogueComponent>(answers[0], firstEnding));
            firstBranching.Add(new KeyValuePair<string, DialogueComponent>(answers[1], secondEnding));

            DialogueComponent root = new DialogueComposit
                (
                    question: "Вы орк?",
                    answers: new Dictionary<string, DialogueComponent>()
                );
            root.Add(new KeyValuePair<string, DialogueComponent>(answers[0], firstBranching));
            root.Add(new KeyValuePair<string, DialogueComponent>(answers[1], secondEnding));

            Dialogue dialogue = new Dialogue(root, "Тест");
            DialogueGUI gUI = new DialogueGUI(new Dialogue[] { dialogue });

            while(true)
            {
                gUI.Update();
            }
        }
    }
}
