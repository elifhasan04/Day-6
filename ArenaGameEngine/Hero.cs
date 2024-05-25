using System;

namespace ArenaGameEngine
{
    public class Hero
    {
        public string Name { get; private set; }

        public int Health { get; private set; }

        public int Strength { get; private set; }

        public Hero(string name)
        {
            Name = name;
            Health = 500;
            Strength = 60;
        }

        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        public bool IsDead
        {
            get { return !IsAlive; }
        }

        public virtual int Attack()
        {
            int coef = Random.Shared.Next(80, 121);
            return (coef * Strength) / 100;
        }

        public virtual void TakeDamage(int incomingDamage)
        {
            Health = Math.Max(Health - incomingDamage, 0); 
        }
    }

    public class Mage : Hero
    {
        public int Mana { get; private set; }

        public Mage(string name) : base(name)
        {
            Health = 755;
            Strength = 40;
            Mana = 250;
        }

        public override int Attack()
        {
            if (Mana >= 20)
            {
                Mana -= 20;
                int coef = Random.Shared.Next(90, 131); 
                return (coef * Strength) / 100 + 50; 
            }
            else
            {
                return base.Attack(); 
            }
        }
    }

    public class Tank : Hero
    {
        public int Defense { get; private set; }

        public Tank(string name) : base(name)
        {
            Health = 900;
            Strength = 80;
            Defense = 100;
        }

        public override void TakeDamage(int incomingDamage)
        {
            base.TakeDamage(incomingDamage - (Defense / 2)); 
        }
    }
}
