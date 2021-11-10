using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Falsebound
{
    class Marshal : Actor
    {
        private float _speed;
        private Vector3 _velocity;
        private Vector3 _destination;

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

        public Marshal(float x, float y, float z, float speed, string name = "Marshal",
            Shape shape = Shape.CUBE) : base(x, y, z, name, shape)
        {
            _speed = speed;
            _destination = new Vector3(x, y, z);
        }

        public override void Update(float deltaTime, Scene currentScene)
        {
            Vector3 positionDistance = new Vector3(1, 0, 1);

            if (Destination - LocalPosition > 1 || Destination - LocalPosition < -1)
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
                Engine.MoveToNextScene();
        }
    }
}
