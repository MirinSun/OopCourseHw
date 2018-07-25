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

            DialogueComponent firstEnding = new DialogueComponent("Вы победили!");
            DialogueComponent secondEnding = new DialogueComponent("Вы проиграли");

            DialogueComponent firstBranching = new DialogueComponent
                (
                    sentence: "А Ваша мама была орком?",
                    answers: new Dictionary<string, DialogueComponent>()
                );
            firstBranching.Add(new KeyValuePair<string, DialogueComponent>(answers[0], firstEnding));
            firstBranching.Add(new KeyValuePair<string, DialogueComponent>(answers[1], secondEnding));

            DialogueComponent root = new DialogueComponent
                (
                    sentence: "Вы орк?",
                    answers: new Dictionary<string, DialogueComponent>()
                );
            root.Add(new KeyValuePair<string, DialogueComponent>(answers[0], firstBranching));
            root.Add(new KeyValuePair<string, DialogueComponent>(answers[1], secondEnding));

            Dialogue dialogue = new Dialogue("Тест", root);
            DialogueGUI gUI = new DialogueGUI(new Dialogue[] { dialogue });

            while(true)
            {
                gUI.Update();
            }
        }
    }
}
