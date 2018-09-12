using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeventhTask
{
    #region 1 способ
    class Person
    {
        public int Health { get; protected set; }

        public Person(int health)
        {
            Health = health;
        }

        protected void CheckDeath()
        {
            if (Health <= 0)
            {
                Console.WriteLine("Я умер");
            }
        }
    }
    class Human : Person
    {
        public int Agility { get; private set; }

        public Human(int health, int agility) : base(health)
        {
            Agility = agility;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage / Agility;
            CheckDeath();
        }
    }
    class Wombat : Person
    {
        public int Armor { get; private set; }
        public Wombat(int health, int armor) : base(health)
        {
            Armor = armor;
        }
        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
            CheckDeath();
        }
    }
    #endregion

    //#region 2 способ
    //abstract class Person
    //{
    //    public int Health { get; private set; }
    //    public Person(int health)
    //    {
    //        Health = health;
    //    }
    //    public void TakeDamage(int damage)
    //    {
    //        Health -= CalculateDamage(damage);

    //        CheckDeath();
    //    }       
    //    protected abstract int CalculateDamage(int damage);
    //    private void CheckDeath()
    //    {
    //        if (Health <= 0)
    //        {
    //            Console.WriteLine("Я умер");
    //        }
    //    }
    //}
    //class Wombat : Person
    //{
    //    public int Armor { get; private set; }
    //    public Wombat(int health, int armor) : base(health)
    //    {
    //        Armor = armor;
    //    }
    //    protected override int CalculateDamage(int damage)
    //    {
    //        return damage - Armor;
    //    }
    //}

    //class Human : Person
    //{
    //    public int Agility { get; private set; }
    //    public Human(int health, int agility) : base(health)
    //    {
    //        Agility = agility;
    //    }
    //    protected override int CalculateDamage(int damage)
    //    {
    //        return damage / Agility;
    //    }
    //}
    //#endregion
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

}
