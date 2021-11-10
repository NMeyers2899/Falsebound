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

        public Marshal(float x, float y, float z, float speed, string name = "Marshal",
            Shape shape = Shape.CUBE) : base(x, y, z, name, shape)
        {
            _speed = speed;
        }

        public override void Update(float deltaTime, Scene currentScene)
        {
            base.Update(deltaTime, currentScene);
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void OnCollision(Actor actor, Scene currentScene)
        {
            if(actor is Marshal)
            {

            }
        }
    }
}
