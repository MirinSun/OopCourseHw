using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoList toDoList = new ToDoList();
            toDoList.AddGoulGroup("Личный");
            toDoList.AddGoulGroup("Рабочий");
            toDoList.AddGoulGroup("Семейный");

            ToDoListGUI toDoListGUI = new ToDoListGUI(toDoList);

            while (true)
            {
                toDoListGUI.Update();
            }
        }
    }
    class ToDoListGUI
    {
        private ToDoList _toDoList;

        public ToDoListGUI(ToDoList toDoList) => _toDoList = toDoList;

        public void Update()
        {
            Console.Clear();

            ShowGoulsForGroups();

            Console.WriteLine("\nКуда вы хотите добавить цель?");
            string goulGroupName = Console.ReadLine().ToLower();
            Console.WriteLine("Что это за цель?");
            string goul = Console.ReadLine();

            try
            {
                _toDoList
                    .GetGoulGroup(goulGroupName)
                    .AddGoul(goul);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void ShowGoulsForGroups()
        {
            int i = 0;
            foreach (var item in _toDoList.GoulGroups)
            {
                Console.Write(i++ == _toDoList.GoulGroups.Length - 1 ? $"{item.Name}\n" : $"{item.Name} |");               
            }

            int max = _toDoList.GetMaxLengthGoulGroup().Gouls.Length;
            for (i = 0; i < max; i++)
            {
                for (int j = 0; j < _toDoList.GoulGroups.Length; j++)
                {
                    if (_toDoList.GoulGroups[j].Gouls.Length > i)
                    {
                        Console.Write(_toDoList.GoulGroups[j].Gouls[i] + " | ");
                    }
                    else
                    {
                        Console.Write("Empty | ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
    class ToDoList
    {
        private List<GoulGroup> _goulGroups = new List<GoulGroup>();

        public GoulGroup[] GoulGroups { get => _goulGroups.ToArray(); }

        public void AddGoulGroup(string name)
        {
            if (name == null)
                throw new ArgumentNullException();
            if (_goulGroups.Find(n => n.Name.ToLower() == name) != null)
                throw new Exception("Группа с таким именем уже существует");

            _goulGroups.Add(new GoulGroup(name));
        }

        public GoulGroup GetGoulGroup(string name)
        {
            if (name == null)
                throw new ArgumentNullException();

            GoulGroup findGroup = _goulGroups.Find(n=>n.Name.ToLower() == name);

            if (findGroup == null)
                throw new Exception("Группа с таким именем не найдена");

            return findGroup;
        }

        public GoulGroup GetMaxLengthGoulGroup()
        {
            if (_goulGroups.Count == 0)
                throw new Exception("Список групп пуст");

            double max = _goulGroups.Max(s => s.Gouls.Length);

            return _goulGroups.Find(n => n.Gouls.Length == max);
        }

    }
    class GoulGroup
    {
        public string Name { get; }
        public string[] Gouls { get; private set; } = new string[0];

        public GoulGroup(string name) => Name = name;

        public void AddGoul(string goul)
        {
            string[] goulsNew = new string[Gouls.Length + 1];

            for (int j = 0; j < Gouls.Length; j++)
            {
                goulsNew[j] = Gouls[j];
            }

            goulsNew[goulsNew.Length - 1] = goul ?? throw new ArgumentException();
            Gouls = goulsNew;
        }
    }
}
