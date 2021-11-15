using System;
using System.Collections.Generic;
using System.Text;

namespace Falsebound
{
    abstract class Collider
    {
        private Actor _owner;

        public Actor Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

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
