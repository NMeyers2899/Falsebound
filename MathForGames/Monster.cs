using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Falsebound
{
    class Monster : Actor
    {
        private int _health;
        private int _maxHealth;
        private int _attackPower;
        private int _defense;
        private float _speed;

        /// <summary>
        /// How many points of damage the monster can take before it is considered incapacitated.
        /// </summary>
        public int Health
        {
            get { return _health; }
            set 
            {
                if (_health > _maxHealth)
                    _health = _maxHealth;
                else
                    _health = value;
            }
        }

        /// <summary>
        /// The max amount of health a monster can have.
        /// </summary>
        public int MaxHealth
        {
            get { return _maxHealth; }
        }

        /// <summary>
        /// The amount of power a monster has when it attacks.
        /// </summary>
        public int AttackPower
        {
            get { return _attackPower; }
        }

        /// <summary>
        /// How much damage can be removed from a hit when this monster is attacked.
        /// </summary>
        public int Defense
        {
            get { return _defense; }
        }

        /// <summary>
        /// How quick the marshal this monster is on the team of will be able to move.
        /// </summary>
        public float Speed
        {
            get { return _speed; }
        }

        /// <summary>
        /// The basic constructor for a monster.
        /// </summary>
        /// <param name="speed"> The speed that corresponds to the monster. </param>
        /// <param name="maxHealth"> The max health of the monster. </param>
        /// <param name="attackPower"> The attack power of the monster. </param>
        /// <param name="defense"> The defense of the monster. </param>
        /// <param name="name"> The name of the monster. </param>
        /// <param name="shape"> The shape that will be drawn to the screen. </param>
        public Monster(float speed, int maxHealth, int attackPower, int defense, string name = "Monster", 
            Shape shape = Shape.CUBE) : base(0, 0, 0, name, shape, null)
        {
            _maxHealth = maxHealth;
            _health = _maxHealth;
            _attackPower = attackPower;
            _defense = defense;
            _speed = speed;
        }

        /// <summary>
        /// Sets up a basic monster with 0 in all stats.
        /// </summary>
        public Monster() : base(0, 0, 0, "", Shape.CUBE, null)
        {
            _health = 0;
            _maxHealth = 0;
            _attackPower = 0;
            _defense = 0;
            _speed = 0;
        }

        /// <summary>
        /// Takes in two monsters and sets the lhs equal to the rhs.
        /// </summary>
        /// <param name="lhs"> The left hand monster. </param>
        /// <param name="rhs"> The right hand monster. </param>
        /// <returns> The copied monster. </returns>
        public static Monster CopyMonster(Monster lhs, Monster rhs)
        {
            lhs = new Monster();
            lhs.Name = rhs.Name;
            lhs._maxHealth = rhs.MaxHealth;
            lhs.Health = lhs.MaxHealth;
            lhs._attackPower = rhs.AttackPower;
            lhs._defense = rhs.Defense;
            lhs._speed = rhs.Speed;
            lhs.ShapeColor = rhs.ShapeColor;
            lhs.Size = rhs.Size;

            return lhs;
        }
    }
}
