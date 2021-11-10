using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Falsebound
{
    class Marshal : Actor
    {
        private Monster[] _team = new Monster[3];
        private float _speed;
        private Vector3 _velocity;
        private Vector3 _destination;
        private int _score;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector3 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Vector3 Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        public Monster[] Team
        {
            get { return _team; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public Marshal(float x, float y, float z, string name = "Marshal",
            Shape shape = Shape.CUBE) : base(x, y, z, name, shape)
        {
            _destination = new Vector3(x, y, z);
        }

        public override void Update(float deltaTime, Scene currentScene)
        {
            _speed = _team[0].Speed;

            LookAt(Destination);

            if(Destination.X - WorldPosition.X > 1 || Destination.X - WorldPosition.X < -1 || 
                Destination.Z - WorldPosition.Z > 1 || Destination.Z - WorldPosition.Z < -1)
            {
                Vector3 moveDirection = Destination - LocalPosition;

                Velocity = moveDirection.Normalized * Speed * deltaTime;

                Translate(Velocity.X, Velocity.Y, Velocity.Z);
            }
            
            
            base.Update(deltaTime, currentScene);
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void OnCollision(Actor actor, Scene currentScene)
        {
            if (actor is Marshal)
                Engine.MoveToBattleScene();
        }

        public void AddTeamMemeber(Monster monster, int index)
        {
            _team[index] = monster;
        }

        public bool RemoveTeamMember(int index)
        {
            bool removedMonster = false;

            _team[index] = new Monster();

            if (_team[index].Name == "")
                removedMonster = true;

            return removedMonster;
        }
    }
}
