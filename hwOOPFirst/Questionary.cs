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
        public string Question { get; set; }
        public string[] AnswersOptions { get; set; }   
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
