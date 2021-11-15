using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Matrix3
    {
        public float M00, M01, M02, M10, M11, M12, M20, M21, M22;

        public Matrix3(float m00, float m01, float m02,
                       float m10, float m11, float m12,
                       float m20, float m21, float m22)
        {
            M00 = m00; M01 = m01; M02 = m02;
            M10 = m10; M11 = m11; M12 = m12;
            M20 = m20; M21 = m21; M22 = m22;
        }

        /// <summary>
        /// Gets a basic matrix3.
        /// </summary>
        public static Matrix3 Identity
        {
            get
            {
                return new Matrix3(1, 0, 0,
                                   0, 1, 0,
                                   0, 0, 1);
            }
        }

        /// <summary>
        /// Adds two matrix3's together.
        /// </summary>
        /// <param name="lhs"> The left hand matrix3. </param>
        /// <param name="rhs"> The right hand matrix3 </param>
        /// <returns> The sum of both matricies. </returns>
        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(lhs.M00 + rhs.M00, lhs.M01 + rhs.M01, lhs.M02 + rhs.M02,
                               lhs.M10 + rhs.M10, lhs.M11 + rhs.M11, lhs.M12 + rhs.M12,
                               lhs.M20 + rhs.M20, lhs.M21 + rhs.M21, lhs.M22 + rhs.M22);
        }

        /// <summary>
        /// Subtracts two matrix3's by each other.
        /// </summary>
        /// <param name="lhs"> The left hand matrix3. </param>
        /// <param name="rhs"> The right hand matrix3 </param>
        /// <returns> The difference between two matricies. </returns>
        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(lhs.M00 - rhs.M00, lhs.M01 - rhs.M01, lhs.M02 - rhs.M02,
                               lhs.M10 - rhs.M10, lhs.M11 - rhs.M11, lhs.M12 - rhs.M12,
                               lhs.M20 - rhs.M20, lhs.M21 - rhs.M21, lhs.M22 - rhs.M22);
        }

        /// <summary>
        ///  Multiplies two matrix3's together.
        /// </summary>
        /// <param name="lhs"> The left hand matrix3. </param>
        /// <param name="rhs"> The right hand matrix3. </param>
        /// <returns> The product of the two matricies. </returns>
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            // Row 1, Column 1.
            return new Matrix3(((lhs.M00 * rhs.M00) + (lhs.M01 * rhs.M10) + (lhs.M02 * rhs.M20)),
                               // Row 1, Column 2.
                               ((lhs.M00 * rhs.M01) + (lhs.M01 * rhs.M11) + (lhs.M02 * rhs.M21)),
                               // Row 1, Column 3.
                               ((lhs.M00 * rhs.M02) + (lhs.M01 * rhs.M12) + (lhs.M02 * rhs.M22)),

                               // Row 2, Column 1.
                               ((lhs.M10 * rhs.M00) + (lhs.M11 * rhs.M10) + (lhs.M12 * rhs.M20)),
                               // Row 2, Column 2.
                               ((lhs.M10 * rhs.M01) + (lhs.M11 * rhs.M11) + (lhs.M12 * rhs.M21)),
                               // Row 2, Column 3.
                               ((lhs.M10 * rhs.M02) + (lhs.M11 * rhs.M12) + (lhs.M12 * rhs.M22)),

                               // Row 3, Column 1.
                               ((lhs.M20 * rhs.M00) + (lhs.M21 * rhs.M10) + (lhs.M22 * rhs.M20)),
                               // Row 3, Column 2.
                               ((lhs.M20 * rhs.M01) + (lhs.M21 * rhs.M11) + (lhs.M22 * rhs.M21)),
                               // Row 3, Column 3.
                               ((lhs.M20 * rhs.M02) + (lhs.M21 * rhs.M12) + (lhs.M22 * rhs.M22)));
        }

        /// <summary>
        /// Multiplies a matrix3 by a vector3.
        /// </summary>
        /// <param name="lhs"> The left hand matrix3. </param>
        /// <param name="rhs"> The right hand vector3. </param>
        /// <returns> The product of a matrix3 and vector3. </returns>
        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3((lhs.M00 * rhs.X) + (lhs.M01 * rhs.Y) + (lhs.M02 * rhs.Z),
                               (lhs.M10 * rhs.X) + (lhs.M11 * rhs.Y) + (lhs.M12 * rhs.Z),
                               (lhs.M20 * rhs.X) + (lhs.M21 * rhs.Y) + (lhs.M22 * rhs.Z));
        }

        /// <summary>
        /// Rotates a matrix.
        /// </summary>
        /// <param name="radians"> The amount the matrix will be rotated by. </param>
        /// <returns> The rotated matrix. </returns>
        public static Matrix3 CreateRotation(float radians)
        {
            return new Matrix3((float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                              -(float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                               0, 0, 1);
        }

        /// <summary>
        /// Sets the translation of the matrix.
        /// </summary>
        /// <param name="x"> The position the matrix will be translated to on the x-axis. </param>
        /// <param name="y"> The position the matrix will be translated to on the y-axis. </param>
        /// <returns> The new translation. </returns>
        public static Matrix3 CreateTranslation(float x, float y)
        {
            return new Matrix3(1, 0, x,
                               0, 1, y,
                               0, 0, 1);
        }

        /// <summary>
        /// Sets the translation of the matrix.
        /// </summary>
        /// <param name="points"> The position the matrix will be translated to on all axies. </param>
        /// <returns> The new translation. </returns>
        public static Matrix3 CreateTranslation(Vector2 points)
        {
            return new Matrix3(1, 0, points.X,
                               0, 1, points.Y,
                               0, 0, 1);
        }

        /// <summary>
        /// Sets the scale of the matrix.
        /// </summary>
        /// <param name="x"> How much the matrix scales on the x-axis. </param>
        /// <param name="y"> How much the matrix scales on the y-axis. </param>
        /// <returns> The new scale. </returns>
        public static Matrix3 CreateScale(float x, float y)
        {
            return new Matrix3(x, 0, 0,
                               0, y, 0,
                               0, 0, 1);
        }
    }
}
