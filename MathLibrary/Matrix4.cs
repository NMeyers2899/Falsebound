﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Matrix4
    {
        public float M00, M01, M02, M03, M10, M11, M12, M13, M20, M21, M22, M23, M30, M31, M32, M33;

        public Matrix4(float m00, float m01, float m02, float m03,
                       float m10, float m11, float m12, float m13,
                       float m20, float m21, float m22, float m23,
                       float m30, float m31, float m32, float m33)
        {
            M00 = m00; M01 = m01; M02 = m02; M03 = m03;
            M10 = m10; M11 = m11; M12 = m12; M13 = m13;
            M20 = m20; M21 = m21; M22 = m22; M23 = m23;
            M30 = m30; M31 = m31; M32 = m32; M33 = m33;
        }

        /// <summary>
        /// Gets a basic matrix4.
        /// </summary>
        public static Matrix4 Identity
        {
            get
            {
                return new Matrix4(1, 0, 0, 0,
                                   0, 1, 0, 0,
                                   0, 0, 1, 0,
                                   0, 0, 0, 1);
            }
        }

        /// <summary>
        /// Adds two matrix4's together.
        /// </summary>
        /// <param name="lhs"> The left hand matrix4. </param>
        /// <param name="rhs"> The right hand matrix4 </param>
        /// <returns> The sum of both matricies. </returns>
        public static Matrix4 operator +(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(lhs.M00 + rhs.M00, lhs.M01 + rhs.M01, lhs.M02 + rhs.M02, lhs.M03 + rhs.M03,
                               lhs.M10 + rhs.M10, lhs.M11 + rhs.M11, lhs.M12 + rhs.M12, lhs.M13 + rhs.M13,
                               lhs.M20 + rhs.M20, lhs.M21 + rhs.M21, lhs.M22 + rhs.M22, lhs.M23 + rhs.M23,
                               lhs.M30 + rhs.M30, lhs.M31 + rhs.M31, lhs.M32 + rhs.M32, lhs.M33 + rhs.M33);
        }

        /// <summary>
        /// Subtracts two matrix4's by each other.
        /// </summary>
        /// <param name="lhs"> The left hand matrix4. </param>
        /// <param name="rhs"> The right hand matrix4 </param>
        /// <returns> The difference between two matricies. </returns>
        public static Matrix4 operator -(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(lhs.M00 - rhs.M00, lhs.M01 - rhs.M01, lhs.M02 - rhs.M02, lhs.M03 - rhs.M03,
                               lhs.M10 - rhs.M10, lhs.M11 - rhs.M11, lhs.M12 - rhs.M12, lhs.M13 - rhs.M13,
                               lhs.M20 - rhs.M20, lhs.M21 - rhs.M21, lhs.M22 - rhs.M22, lhs.M23 - rhs.M23,
                               lhs.M30 - rhs.M30, lhs.M31 - rhs.M31, lhs.M32 - rhs.M32, lhs.M33 - rhs.M33);
        }

        /// <summary>
        ///  Multiplies two matrix4's together.
        /// </summary>
        /// <param name="lhs"> The left hand matrix4. </param>
        /// <param name="rhs"> The right hand matrix4. </param>
        /// <returns> The product of the two matricies. </returns>
        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            // Row 1, Column 1.
            return new Matrix4(((lhs.M00 * rhs.M00) + (lhs.M01 * rhs.M10) + (lhs.M02 * rhs.M20) + (lhs.M03 * rhs.M30)),
                               // Row 1, Column 2.
                               ((lhs.M00 * rhs.M01) + (lhs.M01 * rhs.M11) + (lhs.M02 * rhs.M21) + (lhs.M03 * rhs.M31)),
                               // Row 1, Column 3.
                               ((lhs.M00 * rhs.M02) + (lhs.M01 * rhs.M12) + (lhs.M02 * rhs.M22) + (lhs.M03 * rhs.M32)),
                               // Row 1, Column 4.
                               ((lhs.M00 * rhs.M03) + (lhs.M01 * rhs.M13) + (lhs.M02 * rhs.M23) + (lhs.M03 * rhs.M33)),

                               // Row 2, Column 1.
                               ((lhs.M10 * rhs.M00) + (lhs.M11 * rhs.M10) + (lhs.M12 * rhs.M20) + (lhs.M13 * rhs.M30)),
                               // Row 2, Column 2.
                               ((lhs.M10 * rhs.M01) + (lhs.M11 * rhs.M11) + (lhs.M12 * rhs.M21) + (lhs.M13 * rhs.M31)),
                               // Row 2, Column 3.
                               ((lhs.M10 * rhs.M02) + (lhs.M11 * rhs.M12) + (lhs.M12 * rhs.M22) + (lhs.M13 * rhs.M32)),
                               // Row 2, Column 4.
                               ((lhs.M10 * rhs.M03) + (lhs.M11 * rhs.M13) + (lhs.M12 * rhs.M23) + (lhs.M13 * rhs.M33)),

                               // Row 3, Column 1.
                               ((lhs.M20 * rhs.M00) + (lhs.M21 * rhs.M10) + (lhs.M22 * rhs.M20) + (lhs.M23 * rhs.M30)),
                               // Row 3, Column 2.
                               ((lhs.M20 * rhs.M01) + (lhs.M21 * rhs.M11) + (lhs.M22 * rhs.M21) + (lhs.M23 * rhs.M31)),
                               // Row 3, Column 3.
                               ((lhs.M20 * rhs.M02) + (lhs.M21 * rhs.M12) + (lhs.M22 * rhs.M22) + (lhs.M23 * rhs.M32)),
                               // Row 3, Column 4.
                               ((lhs.M20 * rhs.M03) + (lhs.M21 * rhs.M13) + (lhs.M22 * rhs.M23) + (lhs.M23 * rhs.M33)),

                               // Row 4, Column 1.
                               ((lhs.M30 * rhs.M00) + (lhs.M31 * rhs.M10) + (lhs.M32 * rhs.M20) + (lhs.M33 * rhs.M30)),
                               // Row 4, Column 2.
                               ((lhs.M30 * rhs.M01) + (lhs.M31 * rhs.M11) + (lhs.M32 * rhs.M21) + (lhs.M33 * rhs.M31)),
                               // Row 4, Column 3.
                               ((lhs.M30 * rhs.M02) + (lhs.M31 * rhs.M12) + (lhs.M32 * rhs.M22) + (lhs.M33 * rhs.M32)),
                               // Row 4, Column 4.
                               ((lhs.M30 * rhs.M03) + (lhs.M31 * rhs.M13) + (lhs.M32 * rhs.M23) + (lhs.M33 * rhs.M33)));
        }

        /// <summary>
        /// Multiplies a matrix3 by a vector4.
        /// </summary>
        /// <param name="lhs"> The left hand matrix4. </param>
        /// <param name="rhs"> The right hand vector4. </param>
        /// <returns> The product of a matrix3 and vector4. </returns>
        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4((lhs.M00 * rhs.X) + (lhs.M01 * rhs.Y) + (lhs.M02 * rhs.Z) + (lhs.M03 * rhs.W),
                               (lhs.M10 * rhs.X) + (lhs.M11 * rhs.Y) + (lhs.M12 * rhs.Z) + (lhs.M13 * rhs.W),
                               (lhs.M20 * rhs.X) + (lhs.M21 * rhs.Y) + (lhs.M22 * rhs.Z) + (lhs.M23 * rhs.W),
                               (lhs.M30 * rhs.X) + (lhs.M31 * rhs.Y) + (lhs.M32 * rhs.Z) + (lhs.M33 * rhs.W));
        }

        /// <summary>
        /// Rotates a matrix on the x-axis.
        /// </summary>
        /// <param name="radians"> The amount the matrix will be rotated by. </param>
        /// <returns> The rotated matrix. </returns>
        public static Matrix4 CreateRotationX(float radians)
        {
            return new Matrix4(1, 0, 0, 0,
                               0, (float)Math.Cos(radians), -(float)Math.Sin(radians), 0,
                               0, (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                               0, 0, 0, 1);
        }

        /// <summary>
        /// Rotates a matrix on the y-axis.
        /// </summary>
        /// <param name="radians"> The amount the matrix will be rotated by. </param>
        /// <returns> The rotated matrix. </returns>
        public static Matrix4 CreateRotationY(float radians)
        {
            return new Matrix4((float)Math.Cos(radians), 0, (float)Math.Sin(radians), 0,
                               0, 1, 0, 0,
                               -(float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                               0, 0, 0, 1);
        }

        /// <summary>
        /// Rotates a matrix on the z-axis.
        /// </summary>
        /// <param name="radians"> The amount the matrix will be rotated by. </param>
        /// <returns> The rotated matrix. </returns>
        public static Matrix4 CreateRotationZ(float radians)
        {
            return new Matrix4((float)Math.Cos(radians), -(float)Math.Sin(radians), 0, 0,
                               (float)Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                               0, 0, 1, 0,
                               0, 0, 0, 1);
        }

        /// <summary>
        /// Sets the translation of a matrix.
        /// </summary>
        /// <param name="x"> Where it moves on the x-axis. </param>
        /// <param name="y"> Where it moves on the y-axis. </param>
        /// <param name="z"> Where it moves on the z-axis. </param>
        /// <returns> The new position. </returns>
        public static Matrix4 CreateTranslation(float x, float y, float z)
        {
            return new Matrix4(1, 0, 0, x,
                               0, 1, 0, y,
                               0, 0, 1, z,
                               0, 0, 0, 1);
        }

        /// <summary>
        /// Sets the translation of a matrix.
        /// </summary>
        /// <param name="translation"> The location the matrix will be translated to. </param>
        /// <returns> The new position </returns>
        public static Matrix4 CreateTranslation(Vector3 translation)
        {
            return new Matrix4(1, 0, 0, translation.X,
                               0, 1, 0, translation.Y,
                               0, 0, 1, translation.Z,
                               0, 0, 0, 1);
        }

        /// <summary>
        /// Sets the scale of the matrix.
        /// </summary>
        /// <param name="x"> How much the matrix scales on the x-axis. </param>
        /// <param name="y"> How much the matrix scales on the y-axis. </param>
        /// <param name="z"> How much the matrix scales on the z-axis. </param>
        /// <returns> The new scale. </returns>
        public static Matrix4 CreateScale(float x, float y, float z)
        {
            return new Matrix4(x, 0, 0, 0,
                               0, y, 0, 0,
                               0, 0, z, 0,
                               0, 0, 0, 1);
        }

        /// <summary>
        /// Sets the scale of the matrix.
        /// </summary>
        /// <param name="scale"> How much the matrix will scale on each axis. </param>
        /// <returns> The new scale. </returns>
        public static Matrix4 CreateScale(Vector3 scale)
        {
            return new Matrix4(scale.X, 0, 0, 0,
                               0, scale.Y, 0, 0,
                               0, 0, scale.Z, 0,
                               0, 0, 0, 1);
        }
    }
}