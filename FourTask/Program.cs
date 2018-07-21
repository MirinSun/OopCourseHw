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
            toDoList.AddGoalGroup("Личный");
            toDoList.AddGoalGroup("Рабочий");
            toDoList.AddGoalGroup("Семейный");

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

            ShowGoalsForGroups();

            Console.WriteLine("\nКуда вы хотите добавить цель?");
            string goalGroupName = Console.ReadLine().ToLower();
            Console.WriteLine("Что это за цель?");
            string goal = Console.ReadLine();

            try
            {
                _toDoList
                    .GetGoalGroup(goalGroupName)
                    .AddGoal(goal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void ShowGoalsForGroups()
        {
            int i = 0;
            foreach (var item in _toDoList.GoalGroups)
            {
                Console.Write(i++ == _toDoList.GoalGroups.Length - 1 ? $"{item.Name}\n" : $"{item.Name} |");               
            }

            int max = _toDoList.GetMaxLengthGoalGroup().Goals.Length;
            for (i = 0; i < max; i++)
            {
                for (int j = 0; j < _toDoList.GoalGroups.Length; j++)
                {
                    if (_toDoList.GoalGroups[j].Goals.Length > i)
                    {
                        Console.Write(_toDoList.GoalGroups[j].Goals[i] + " | ");
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
        private List<GoalGroup> _goalGroups = new List<GoalGroup>();

        public GoalGroup[] GoalGroups { get => _goalGroups.ToArray(); }

        public void AddGoalGroup(string name)
        {
            if (name == null)
                throw new ArgumentNullException();
            if (_goalGroups.Find(n => n.Name.ToLower() == name) != null)
                throw new Exception("Группа с таким именем уже существует");

            _goalGroups.Add(new GoalGroup(name));
        }

        public GoalGroup GetGoalGroup(string name)
        {
            if (name == null)
                throw new ArgumentNullException();

            GoalGroup findGroup = _goalGroups.Find(n=>n.Name.ToLower() == name);

            if (findGroup == null)
                throw new Exception("Группа с таким именем не найдена");

            return findGroup;
        }

        public GoalGroup GetMaxLengthGoalGroup()
        {
            if (_goalGroups.Count == 0)
                throw new Exception("Список групп пуст");

            double max = _goalGroups.Max(s => s.Goals.Length);

            return _goalGroups.Find(n => n.Goals.Length == max);
        }

    }
    class GoalGroup
    {
        public string Name { get; }
        public string[] Goals { get; private set; } = new string[0];

        public GoalGroup(string name) => Name = name;

        public void AddGoal(string goal)
        {
            string[] goalsNew = new string[Goals.Length + 1];

            for (int j = 0; j < Goals.Length; j++)
            {
                goalsNew[j] = Goals[j];
            }

            goalsNew[goalsNew.Length - 1] = goal ?? throw new ArgumentException();
            Goals = goalsNew;
        }
    }
}
