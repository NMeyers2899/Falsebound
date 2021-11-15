using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Gets the length of the vector.
        /// </summary>
        public float Magnitude
        {
            get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W); }
        }

        /// <summary>
        /// Gets the normalized version of this vector without changing it.
        /// </summary>
        public Vector4 Normalized
        {
            get
            {
                Vector4 value = this;
                return value.Normalize();
            }
        }

        /// <summary>
        /// Changes this vector to have a magnitude that is equal to one.
        /// </summary>
        /// <returns> The result of the normalization. Returns an empty vector if magnitude is zero. </returns>
        public Vector4 Normalize()
        {
            if (Magnitude == 0)
                return new Vector4();

            return this /= Magnitude;
        }

        /// <summary>
        /// Finds the dot product between two vectors.
        /// </summary>
        /// <param name="lhs"> The Vector4 on the left hand side. </param>
        /// <param name="rhs"> The Vector4 on the right hand side. </param>
        /// <returns> The dot product of the two vectors. </returns>
        public static float DotProduct(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z);
        }

        /// <summary>
        /// Find the cross product between the two vectors.
        /// </summary>
        /// <param name="lhs"> The Vector4 on the left hand side. </param>
        /// <param name="rhs"> The Vector4 on the right hand side. </param>
        /// <returns> The cross product between the two vectors. </returns>
        public static Vector4 CrossProduct(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4((lhs.Y * rhs.Z) - (lhs.Z * rhs.Y), (lhs.Z * rhs.X) - (lhs.X * rhs.Z),
                (lhs.X * rhs.Y) - (lhs.Y * rhs.X), 0);
        }

        /// <summary>
        /// Finds the distance between two vectors.
        /// </summary>
        /// <param name="lhs"> The Vector4 on the left hand side. </param>
        /// <param name="rhs"> The Vector4 on the right hand side. </param>
        /// <returns> The distance between the two vectors. </returns>
        public static float Distance(Vector4 lhs, Vector4 rhs)
        {
            return (rhs - lhs).Magnitude;
        }

        /// <summary>
        /// Finds the sum of two vector4's
        /// </summary>
        /// <param name="lhs"> The Vector4 on the left hand side. </param>
        /// <param name="rhs"> The Vector4 on the right hand side. </param>
        /// <returns> The sum of the two vectors. </returns>
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4 { X = lhs.X + rhs.X, Y = lhs.Y + rhs.Y, Z = lhs.Z + rhs.Z, W = lhs.W + rhs.W };
        }

        /// <summary>
        /// Finds the difference between two vector4's.
        /// </summary>
        /// <param name="lhs"> The Vector4 on the left hand side. </param>
        /// <param name="rhs"> The Vector4 on the right hand side. </param>
        /// <returns> The difference between the two vectors. </returns>
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4 { X = lhs.X - rhs.X, Y = lhs.Y - rhs.Y, Z = lhs.Z - rhs.Z, W = lhs.W - rhs.W };
        }

        /// <summary>
        /// Finds the inverse of the vector.
        /// </summary>
        /// <param name="vector"> The vector that will be inversed. </param>
        /// <returns> The inverse of the vector. </returns>
        public static Vector4 operator -(Vector4 vector)
        {
            return new Vector4 { X = -vector.X, Y = -vector.Y, Z = -vector.Z, W = -vector.W };
        }

        /// <summary>
        ///  Multiplies the vector4 by the scalar.
        /// </summary>
        /// <param name="lhs"> The vector4 on the left hand side. </param>
        /// <param name="rhs"> The scalar on the right hand side. </param>
        /// <returns> The product of the vector and the scalar. </returns>
        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            return new Vector4 { X = lhs.X * rhs, Y = lhs.Y * rhs, Z = lhs.Z * rhs, W = lhs.W / rhs };
        }

        /// <summary>
        /// Divides the vector4 by the scalar.
        /// </summary>
        /// <param name="lhs"> The scalar on the left hand side. </param>
        /// <param name="rhs"> The vector4 on the right hand side. </param>
        /// <returns> The quotient of the vector and the scalar. </returns>
        public static Vector4 operator *(float lhs, Vector4 rhs)
        {
            return new Vector4 { X = lhs * rhs.X, Y = lhs * rhs.Y, Z = lhs * rhs.Z, W = lhs * rhs.W };
        }

        /// <summary>
        /// Divides the vector4 by the scalar.
        /// </summary>
        /// <param name="lhs"> The vector4 on the left hand side. </param>
        /// <param name="rhs"> The scalar on the right hand side. </param>
        /// <returns> The quotient of the vector and the scalar. </returns>
        public static Vector4 operator /(Vector4 lhs, float rhs)
        {
            return new Vector4 { X = lhs.X / rhs, Y = lhs.Y / rhs, Z = lhs.Z / rhs, W = lhs.W / rhs };
        }

        /// <summary>
        /// Checks to see if both vectors are equal.
        /// </summary>
        /// <param name="lhs"> The left hand vector4. </param>
        /// <param name="rhs"> The right hand vector4. </param>
        /// <returns> Whether or not the vectors are equal. </returns>
        public static bool operator ==(Vector4 lhs, Vector4 rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z && lhs.W == rhs.W;
        }

        /// <summary>
        /// Checks to see if both vectors are not equal.
        /// </summary>
        /// <param name="lhs"> The left hand vector4. </param>
        /// <param name="rhs"> The right hand vector4. </param>
        /// <returns> Whether or not the vectors are not equal. </returns>
        public static bool operator !=(Vector4 lhs, Vector4 rhs)
        {
            return !(lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z && lhs.W == rhs.W);
        }

        /// <summary>
        /// Checks to see if the lhs is greater than or equal to the rhs.
        /// </summary>
        /// <param name="lhs"> The left hand vector4. </param>
        /// <param name="rhs"> The right hand vector4. </param>
        /// <returns> Whether or not the lhs is greater than or equal to the rhs. </returns>
        public static bool operator >=(Vector4 lhs, Vector4 rhs)
        {
            return lhs.X >= rhs.X && lhs.Y >= rhs.Y && lhs.Z >= rhs.Z && lhs.W >= rhs.W;
        }

        /// <summary>
        /// Checks to see if the lhs is less than or equal to the rhs.
        /// </summary>
        /// <param name="lhs"> The left hand vector4. </param>
        /// <param name="rhs"> The right hand vector4. </param>
        /// <returns> Whether or not the lhs is less than or equal to the rhs. </returns>
        public static bool operator <=(Vector4 lhs, Vector4 rhs)
        {
            return lhs.X <= rhs.X && lhs.Y <= rhs.Y && lhs.Z <= rhs.Z && lhs.W <= rhs.W;
        }

        /// <summary>
        /// Checks to see if the lhs is les than the rhs.
        /// </summary>
        /// <param name="lhs"> The left hand vector4. </param>
        /// <param name="rhs"> The right hand vector4. </param>
        /// <returns> Whether or not the lhs is less than the rhs. </returns>
        public static bool operator <(Vector4 lhs, Vector4 rhs)
        {
            return lhs.X < rhs.X && lhs.Y < rhs.Y && lhs.Z < rhs.Z && lhs.W < rhs.W;
        }

        /// <summary>
        /// Checks to see if the lhs is greater than the rhs.
        /// </summary>
        /// <param name="lhs"> The left hand vector4. </param>
        /// <param name="rhs"> The right hand vector4. </param>
        /// <returns> Whether or not the lhs is greater than the rhs. </returns>
        public static bool operator >(Vector4 lhs, Vector4 rhs)
        {
            return lhs.X > rhs.X && lhs.Y > rhs.Y && lhs.Z > rhs.Z && lhs.W > rhs.W;
        }
    }
}
