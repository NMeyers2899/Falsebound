using System;
using System.Collections.Generic;
using System.Text;

namespace Falsebound
{
    abstract class Collider
    {
        private Actor _owner;

        /// <summary>
        /// The actor that the collider is attached to.
        /// </summary>
        public Actor Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        /// <summary>
        /// The basic constructor for a collider that takes in an actor.
        /// </summary>
        /// <param name="owner"> The actor that will become this collider's owner. </param>
        public Collider(Actor owner)
        {
            _owner = owner;
        }

        public bool CheckForCollision(Actor other)
        {
            return CheckSphereCollision((SphereCollider)other.Collider);
        }

        public virtual bool CheckSphereCollision(SphereCollider other) { return false; }

        public virtual void Draw() { }
    }
}
