using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Falsebound
{
    class Camera : Actor
    {
        private Camera3D _camera = new Camera3D();
        private float _speed;
        private Vector3 _velocity;

        public Camera3D PlayerCamera
        {
            get { return _camera; }
        }

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

        public Camera(float x, float y, float z, float speed, string name = "Camera", 
            Shape shape = Shape.CUBE, Actor parent = null) : base(x, y, z, name, shape, parent)
        {
            _speed = speed;
        }

        public override void Start()
        {
            base.Start();

            // Camera position.
            _camera.position = new System.Numerics.Vector3(0, 10, 10);
            // Point the camera is focused on.
            _camera.target = new System.Numerics.Vector3(0, 0, 0);
            // Camera up vector(rotation towards target).
            _camera.up = new System.Numerics.Vector3(0, 1, 0);
            // Camera's field of view Y.
            _camera.fovy = 60;
            // Camera mode type.
            _camera.projection = CameraProjection.CAMERA_PERSPECTIVE;
        }

        public override void Update(float deltaTime, Scene currentScene)
        {
            _camera.position = new System.Numerics.Vector3(Parent.WorldPosition.X,
                Parent.WorldPosition.Y + 10, Parent.WorldPosition.Z + 15);
            _camera.target = new System.Numerics.Vector3(Parent.WorldPosition.X,
                0, Parent.WorldPosition.Z);

            base.Update(deltaTime, currentScene);
        }
    }
}
