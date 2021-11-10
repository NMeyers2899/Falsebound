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

        public void Attack(Monster target)
        {
            target.TakeDamage(_attackPower);
        }

        public void TakeDamage(int damage)
        {
            if (damage - _defense > _health)
                _health = 0;
            else
                _health -= damage - _defense;
        }
    }
}
