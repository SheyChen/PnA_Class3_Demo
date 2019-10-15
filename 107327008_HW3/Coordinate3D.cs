﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinate3D
{
    public class Point3D
    {
        public double X;
        public double Y;
        public double Z;
        public Point3D()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }
        public Point3D(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public static Vector3D Distance(Point3D pt1, Point3D pt2)
        {
            Vector3D ans = new Vector3D();
            ans.X = pt2.X - pt1.X;
            ans.Y = pt2.Y - pt1.Y;
            ans.Z = pt2.Z - pt1.Z;
            return ans;
        }
    }
    public class Vector3D : Point3D
    {
        public Vector3D() : base(0, 0, 0) { }
        public Vector3D(double X, double Y, double Z) : base(X, Y, Z) { }
    }
    public class Matrix3D
    {
        public double[][] Value;
        public int Length()
        {
            return Value.Length;
        }
        public static Matrix3D MatrixMult(Matrix3D matrix1, Matrix3D matrix2)
        {
            int m = matrix1.Length(), n = matrix2.Length(), p = matrix2.Value[2].Length;
            Matrix3D result = new Matrix3D();
            for (int i = 0; i < result.Length(); i++)
            {
                result.Value[i] = new double[p];
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        result.Value[i][j] += (matrix1.Value[i][k] * matrix2.Value[k][j]);
                    }
                }
            }
            return result;
        }
    }

}