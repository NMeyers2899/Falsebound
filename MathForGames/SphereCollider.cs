using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Falsebound
{
    class SphereCollider : Collider
    {
        private float _collisionRadius;

        public float CollisionRadius
        {
            get { return _collisionRadius; }
            set { _collisionRadius = value; }
        }

        public SphereCollider(float collisionRadius, Actor owner) : base(owner)
        {
            _collisionRadius = collisionRadius;
        }

        public override void Draw()
        {
            base.Draw();
            System.Numerics.Vector3 position = new System.Numerics.Vector3(Owner.WorldPosition.X,
                Owner.WorldPosition.Y, Owner.WorldPosition.Z);
            Raylib.DrawSphereWires(position, CollisionRadius, 15, 15, Color.YELLOW);
        }

        public override bool CheckSphereCollision(SphereCollider other)
        {
            // If the owners are the same...
            if (other.Owner == Owner)
                // ...return false. 
                return false;

            // Finds the distance between the two actors.
            float distance = Vector3.Distance(other.Owner.WorldPosition, Owner.WorldPosition);
            // Finds the length of radii of the two actors combined.
            float combinedRadii = other.CollisionRadius + CollisionRadius;

            // Return whether or not the distance is less than the combined radii.
            return distance <= combinedRadii;
        }
    }
}
