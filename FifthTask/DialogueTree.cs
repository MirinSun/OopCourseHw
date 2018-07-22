using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthTask
{
    class Dialogue : IEnumerable<DialogFragment>
    {
        private DialogueTree _tree = new DialogueTree();

        public Dialogue(DialogueTree tree)
        {
            _tree = tree;
        }

        public IEnumerator<DialogFragment> GetEnumerator()
        {
            return _tree;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _tree;
        }
    }

    class DialogueTree: IEnumerator<DialogFragment>
    {
        private DialogueTreeComponent _root;
        private DialogueTreeComponent _current;

        public DialogueTree()
        {
            _root = null;
            _current = null;
        }
        public DialogueTree(DialogueTreeComponent component) =>
            _root = _current = component ?? throw new ArgumentNullException();

        public DialogFragment Current { get => _current._fragment; }

        object IEnumerator.Current => throw new NotImplementedException();
    
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            int index = _current._fragment.CheckAnswer();
            _current = _current._components[index];
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
    class DialogueTreeComponent
    {
        public DialogFragment _fragment;
        public List<DialogueTreeComponent> _components = new List<DialogueTreeComponent>();

        public DialogueTreeComponent(DialogFragment fragment) =>
            _fragment = fragment ?? throw new ArgumentNullException();

        public void Add(DialogueTreeComponent component)
            => _components.Add(component ?? throw new ArgumentNullException());

    }
    class DialogFragment
    {
        public string Question { get; }
        public List<string> AnswersOptions { get; }

        internal string _answer;

        public DialogFragment(string question, List<string> answersOptions)
        {
            Question = question ?? String.Empty;
            AnswersOptions = answersOptions ?? new List<string>();
        }
        public void PutAnswer(string answer) =>
            _answer = answer ?? throw new ArgumentNullException();

        internal int CheckAnswer()
        {
            try
            {
                return AnswersOptions.FindIndex(n => n == _answer);
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
