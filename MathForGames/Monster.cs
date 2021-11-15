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
        /// <summary>
        /// The amount of times during a battle a monster can act.
        /// </summary>
        private int _actions;
        private float _speed;

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

        public int MaxHealth
        {
            get { return _maxHealth; }
        }

        public int AttackPower
        {
            get { return _attackPower; }
        }

        public int Defense
        {
            get { return _defense; }
        }

        public int Actions
        {
            get { return _actions; }
        }

        public float Speed
        {
            get { return _speed; }
        }

        public Monster(float x, float y, float z, float speed, int maxHealth, int attackPower,
            int defense, int actions, string name = "Monster", Shape shape = Shape.CUBE,
            Actor parent = null) : base(x, y, z, name, shape, parent)
        {
            _maxHealth = maxHealth;
            _health = _maxHealth;
            _attackPower = attackPower;
            _defense = defense;
            _actions = actions;
            _speed = speed;
        }

        public Monster() : base(0, 0, 0, "", Shape.CUBE, null)
        {
            _health = 0;
            _maxHealth = 0;
            _attackPower = 0;
            _defense = 0;
            _actions = 0;
            _speed = 0;
        }

        /// <summary>
        /// This monster goes to deal its damage to the target.
        /// </summary>
        /// <param name="target"> The monster being attacked. </param>
        public void Attack(Monster target)
        {
            target.TakeDamage(_attackPower);
            _actions--;
        }

        /// <summary>
        /// This monster reduces its health based on the amount of damage being dealt.
        /// </summary>
        /// <param name="damage"> The damage about to be taken that will be reduced. </param>
        public void TakeDamage(int damage)
        {
            if (damage - _defense > _health)
                _health = 0;
            else
                _health -= damage - _defense;
        }

        /// <summary>
        /// Changes a monster's opacity to 0 making it invisible.
        /// </summary>
        public void Die()
        {
            SetColor(new Vector4(0, 0, 0, 0));
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
            lhs._actions = rhs.Actions;
            lhs._speed = rhs.Speed;
            lhs.ShapeColor = rhs.ShapeColor;
            lhs.Size = rhs.Size;

            return lhs;
        }
    }
}
