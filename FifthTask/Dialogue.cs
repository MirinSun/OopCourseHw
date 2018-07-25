using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthTask
{
    public class DialogueComponent
    {
        public string Sentence { get; private set; }

        public Dictionary<string, DialogueComponent> Answers { get; private set; }

        public bool IsEnding { get => Answers.Count == 0; }

        public DialogueComponent(string sentence, Dictionary<string, DialogueComponent> answers = null)
        {
            Sentence = sentence ?? throw new ArgumentNullException();
            Answers = answers ?? new Dictionary<string, DialogueComponent>();
        }
       
        public void Add(KeyValuePair<string, DialogueComponent> answer)
        {
            Answers.Add(answer.Key, answer.Value);
        }

        public void Remove(string answer)
        {
            Answers.Remove(answer);
        }

        internal DialogueComponent CheckAnswer(string answer)
        {
            if (Answers.TryGetValue(answer, out DialogueComponent nextComponent))
                return nextComponent;
            else
                throw new Exception("Некоррекнтый ответ");
        }
    }
    class Dialogue
    {     
        private DialogueComponent _root;
        private DialogueComponent _current;

        public string Name { get; set; }
        public Dialogue(string name, DialogueComponent root)
        {
            Name = name ?? throw new ArgumentNullException();
            _root = _current = root ?? throw new ArgumentNullException();
        }

        public DialogueComponent PutAnswer(string answer)
        {
            if (_current.IsEnding)
                throw new Exception("Конец диалога достигнут");

            return _current = _current.CheckAnswer(answer);
        }

        public void Reset()
        {
            _current = _root;
        }

        public DialogueComponent GetStartComponent()
        {
            return _root;
        }
    }
}
