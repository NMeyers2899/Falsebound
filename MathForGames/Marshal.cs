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

        public Marshal(float x, float y, float z, string name = "Marshal",
            Shape shape = Shape.CUBE) : base(x, y, z, name, shape)
        {
            _destination = new Vector3(x, y, z);

            for (int i = 0; i < Team.Length; i++)
                Team[i] = new Monster();
        }

        public override void Update(float deltaTime)
        {
            // Sets the marshal's speed equal to the speed of their team's leader.
            _speed = _team[0].Speed;

            // Looks at the destination set by the player.
            LookAt(Destination);

            // If the marshal is outside of a certain distance from their destination...
            if(Destination.X - WorldPosition.X > 1 || Destination.X - WorldPosition.X < -1 || 
                Destination.Z - WorldPosition.Z > 1 || Destination.Z - WorldPosition.Z < -1)
            {
                // ...they move towards the destination.
                Vector3 moveDirection = Destination - LocalPosition;

                Velocity = moveDirection.Normalized * Speed * deltaTime;

                Translate(Velocity.X, Velocity.Y, Velocity.Z);
            }
            
            
            base.Update(deltaTime);
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void OnCollision(Actor actor)
        {
            // Gets the current scene.
            Scene currentScene = Engine.GetCurrentScene();

            // If they collide with a marshal and the current scene is not a battle scene...
            if (actor is Marshal && !(currentScene is BattleScene))
                // ...change the scene to a battle scene.
                Engine.MoveToBattleScene(Team, (actor as Marshal).Team);
                
        }

        /// <summary>
        /// Adds a team member to a specific index in the marshal's team.
        /// </summary>
        /// <param name="monster"> The monster being added to the team. </param>
        /// <param name="index"> The index in which the monster is being added. </param>
        public void AddTeamMemeber(Monster monster, int index)
        {
            _team[index] = monster;
        }

        /// <summary>
        /// Removes a team member from the marshal's team.
        /// </summary>
        /// <param name="index"> The index at which the monster will be removed. </param>
        /// <returns> If the monster could be removed or not. </returns>
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
