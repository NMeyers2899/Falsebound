using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Falsebound
{
    class Player : Actor
    {
        private float _speed;
        private Vector3 _velocity;
        private Marshal _selectedMarshal = null;

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

        public Marshal SelectedMarshal
        {
            get { return _selectedMarshal; }
        }

        public Player(float x, float y, float z, float speed, string name = "Player",
            Shape shape = Shape.SPHERE) : base(x, y, z, name, shape)
        {
            _speed = speed;
        }

        public override void Update(float deltaTime)
        {
            // Get the player input direction.
            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));
            int zDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            // Create a vector that stores the move input.
            Vector3 moveDirection = new Vector3(xDirection, 0, zDirection);

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            LookAt(LocalPosition + moveDirection);

            Translate(Velocity.X, Velocity.Y, Velocity.Z);

            // If there is a marshal selected, and the player hits F...
            if (_selectedMarshal != null && Raylib.IsKeyPressed(KeyboardKey.KEY_F))
            {
                // ...set the marshal's destination to the current position of the player.
                Vector3 positionToMove = WorldPosition;
                _selectedMarshal.Destination = positionToMove;
                _selectedMarshal = null;
            }

            // If the player presses E...
            if (Raylib.IsKeyDown(KeyboardKey.KEY_E))
                // ...scale the player up.
                SetScale(2, 2, 2);

            // If the player presses R...
            if(Raylib.IsKeyDown(KeyboardKey.KEY_R))
                // ...reset the player's scale.
                SetScale(1, 0.5f, 1);

            base.Update(deltaTime);
        }
        
        public override void Draw()
        {
            base.Draw();

            // If there is a marshal selected...
            if (_selectedMarshal != null)
            {
                // ...draw a line from the marshal to the player.
                System.Numerics.Vector3 startPos = new System.Numerics.Vector3(_selectedMarshal.WorldPosition.X,
                _selectedMarshal.WorldPosition.Y, _selectedMarshal.WorldPosition.Z);
                System.Numerics.Vector3 endPos = new System.Numerics.Vector3(WorldPosition.X,
                    WorldPosition.Y, WorldPosition.Z);

                Raylib.DrawLine3D(startPos, endPos, Color.GREEN);
            }
        }

        public override void OnCollision(Actor actor)
        {
            // If the actor is a marshal, and the player presses F...
            if(actor is Marshal && Raylib.IsKeyPressed(KeyboardKey.KEY_F))
                // ...set the selected marshal to that marshal.
                _selectedMarshal = actor as Marshal;
        }
    }
}
