using System;

namespace Vector
{

    public class Vector3D
    {
        public double X { get; private set; }

        public double Y { get; private set; }

        public double Z { get; private set; }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double Length
        {
            get { return Math.Sqrt(X * X + Y * Y + Z * Z); }
        }

        public double Angle(Vector3D v)
        {
            return (X * v.X + Y * v.Y + Z * v.Z) / (Length * v.Length);
        }

        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }


        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static double operator *(Vector3D v1, Vector3D v2)
        {
            return v1.Length * v2.Length * v1.Angle(v2);
        }

        public static bool operator ==(Vector3D v1, Vector3D v2)
        {
            return (v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z);
        }

        public static bool operator !=(Vector3D v1, Vector3D v2)
        {
            return !(v1 == v2);
        }
        public override string ToString()
        {
            return string.Format(" = {0}i + {1}j + {2}k", X, Y, Z);
        }
    }

}
