using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwOOPFirst
{
    class QuestionaryElement
    {
        List<string> _answersOptions;
        public Door Door { get; }
        public string Question { get; }
        public string[] AnswersOptions
        {
            get => _answersOptions.ToArray();
        }

        public QuestionaryElement(string question, List<string> answersOptions, Door door = null)
        {
            Question = question ?? String.Empty;
            _answersOptions = answersOptions ?? new List<string>();
            Door = door ?? new Door();
        }
        public void PutAnswer(string answer)
        {
            Door.Open();
        }
    }

    class Questionary : IEnumerable<QuestionaryElement>
    {
        private List<QuestionaryElement> _elements = new List<QuestionaryElement>();

        public void Add(QuestionaryElement element)
        {
            if (element == null)
                throw new ArgumentNullException();

            _elements.Add(element);
        }

        IEnumerator<QuestionaryElement> IEnumerable<QuestionaryElement>.GetEnumerator()
        {
            return ((IEnumerable<QuestionaryElement>)_elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<QuestionaryElement>)_elements).GetEnumerator();
        }
    }
}
