using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthTask
{
    abstract class DialogueComponent
    {
        public string Sentence { get; }

        public DialogueComponent(string question) =>
            Sentence = question ?? throw new ArgumentNullException();

        public abstract void Add(KeyValuePair<string, DialogueComponent> answer);
        public abstract void Remove(KeyValuePair<string, DialogueComponent> anwser);

        public override bool Equals(object obj)
        {
            return ((DialogueComponent)obj).Sentence == Sentence;
        }
        public override int GetHashCode()
        {
            return Sentence.GetHashCode();
        }
    }
    class DialogueComposit : DialogueComponent
    {
        public Dictionary<string, DialogueComponent> Answers { get; private set; }
        public string Answer { get; internal set; }

        public DialogueComposit(string question, Dictionary<string, DialogueComponent> answers)
            : base(question) =>
            Answers = answers ?? throw new ArgumentNullException();
       
        public override void Add(KeyValuePair<string, DialogueComponent> answer)
        {
            Answers.Add(answer.Key, answer.Value);
        }

        public override void Remove(KeyValuePair<string, DialogueComponent> answer)
        {
            Answers.Remove(answer.Key);
        }

        public override bool Equals(object obj)
        {
            return Answers.Equals(((DialogueComposit)obj).Answers) &&
                base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Answers.GetHashCode() ^
                base.GetHashCode();
        }
        internal DialogueComponent CheckAnswer()
        {
            if (Answers.TryGetValue(Answer, out DialogueComponent next))
                return next;
            else
                throw new Exception("Некоррекнтый ответ");
        }
    }
    class DialogueEnding : DialogueComponent
    {
        public DialogueEnding(string sentence) : base(sentence) { }
        public override void Add(KeyValuePair<string, DialogueComponent> answer)
        {
            throw new NotImplementedException();
        }

        public override void Remove(KeyValuePair<string, DialogueComponent> anwser)
        {
            throw new NotImplementedException();
        }
    }
    class Dialogue
    {
        private DialogueComponent _root;
        private DialogueComponent _current;

        public string Name { get; }
        public Dialogue(DialogueComponent root, string name)
        {
            _root = _current = root ?? throw new ArgumentNullException();
            Name = name ?? throw new ArgumentNullException();
        }
        
        public DialogueComponent PutAnswer(string answer)
        {
            ((DialogueComposit)_current).Answer = answer;
            return _current = ((DialogueComposit)_current).CheckAnswer();
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
