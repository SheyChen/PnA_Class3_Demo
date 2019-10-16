using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinate3D
{
    //建立三維點座標類別
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
        //計算兩個三維點之間的距離向量
        public static Vector3D Distance(Point3D pt1, Point3D pt2)
        {
            Vector3D ans = new Vector3D();
            ans.X = pt2.X - pt1.X;
            ans.Y = pt2.Y - pt1.Y;
            ans.Z = pt2.Z - pt1.Z;
            return ans;
        }
    }
    //建立三維向量類別
    public class Vector3D : Point3D
    {
        public Vector3D() : base(0, 0, 0) { }
        public Vector3D(double X, double Y, double Z) : base(X, Y, Z) { }

        //計算兩三維向量內積
        public static double Dot(Vector3D vect1, Vector3D vect2)
        {
            double ans;
            ans = vect1.X*vect2.X + vect1.Y*vect2.Y + vect1.Z*vect2.Z ;
            return ans;
        }
        //計算兩三維向量外積
        public static Vector3D Cross(Vector3D vect1, Vector3D vect2)
        {
            Vector3D ans = new Vector3D();
            ans.X = vect1.Y * vect2.Z - vect1.Z * vect2.Y;
            ans.Y = vect1.Z * vect2.X - vect1.X * vect2.Z;
            ans.Z = vect1.X * vect2.Y - vect1.Y * vect2.X;
            return ans;
        }
        //判斷兩三維向量是否垂直
        public static bool IsVertical(Vector3D vect1, Vector3D vect2)
        {
            return (Dot(vect1, vect2) == 0) ? true:false;
        }
        //判斷兩三維向量是否平行
        public static bool IsParallel(Vector3D vect1, Vector3D vect2)
        {
            return ( (vect1.X/vect2.X) == (vect1.Y / vect2.Y)
                && (vect1.Z / vect2.Z) == (vect1.Y / vect2.Y)
                && (vect1.Z / vect2.Z) == (vect1.X / vect2.X)) ? true : false;
        }
    }
    //建立三維4*4方陣類別
    public class Matrix3D
    {
        public double[][] Value = new double[3][];
        public int Length()
        {
            return Value.Length;
        }

        //計算3*3方陣相乘
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

        public static Matrix3D InvMatrux(Matrix3D matrix)
        {
            Matrix3D result = new Matrix3D();
            int p = matrix.Value[1].Length;
            for (int i = 0; i < result.Length(); i++)
            {
                result.Value[i] = new double[p];
            }
            double detAdd = matrix.Value[0][0] * matrix.Value[1][1] * matrix.Value[2][2] + matrix.Value[0][1] * matrix.Value[1][2] * matrix.Value[2][0] + matrix.Value[0][2] * matrix.Value[1][0] * matrix.Value[2][1];
            double detDec = matrix.Value[2][0] * matrix.Value[1][1] * matrix.Value[0][2] + matrix.Value[2][1] * matrix.Value[1][2] * matrix.Value[0][0] + matrix.Value[2][2] * matrix.Value[1][0] * matrix.Value[0][1];
            double det = 1/(detAdd - detDec);
            result.Value[0][0] = (det) * (matrix.Value[1][1] * matrix.Value[2][2] - matrix.Value[2][1] * matrix.Value[1][2]);
            result.Value[0][1] = (-det) * (matrix.Value[0][1] * matrix.Value[2][2] - matrix.Value[2][1] * matrix.Value[0][2]);
            result.Value[0][2] = (det) * (matrix.Value[0][1] * matrix.Value[1][2] - matrix.Value[1][1] * matrix.Value[0][2]);
            result.Value[1][0] = (-det) * (matrix.Value[1][0] * matrix.Value[2][2] - matrix.Value[2][0] * matrix.Value[1][2]);
            result.Value[1][1] = (det) * (matrix.Value[0][0] * matrix.Value[2][2] - matrix.Value[2][0] * matrix.Value[0][2]);
            result.Value[1][2] = (-det) * (matrix.Value[0][0] * matrix.Value[1][2] - matrix.Value[1][0] * matrix.Value[0][2]);
            result.Value[2][0] = (det) * (matrix.Value[1][0] * matrix.Value[2][1] - matrix.Value[2][0] * matrix.Value[1][1]);
            result.Value[2][1] = (-det) * (matrix.Value[0][0] * matrix.Value[2][1] - matrix.Value[2][0] * matrix.Value[0][1]);
            result.Value[2][2] = (det) * (matrix.Value[0][0] * matrix.Value[1][1] - matrix.Value[1][0] * matrix.Value[0][1]);
            
            return result;
        }
        public static Matrix3D Matrux_Flip_Symmetric(Matrix3D original_matrix)
        {
            Matrix3D ansMatrix = new Matrix3D();
            ansMatrix = original_matrix;
            for(int i = 0 ; i < 3 ; i ++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ansMatrix.Value[i][j] = original_matrix.Value[j][i];
                }
            }
            return ansMatrix;
        }
    }

}
