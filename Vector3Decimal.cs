using UnityEngine;
using DecimalMath

[System.Serializable]
public struct Vector3Decimal
{
    public decimal x;
    public decimal y;
    public decimal z;

    public decimal magnitude;

    public Vector3Decimal(decimal x, decimal y, decimal z)
    {
        this.x = x;
        this.y = y;
        this.z = z;

        decimal a = (x * x + y * y + z * z);

        if ((float)a == 0f)
            magnitude = 0;
        else
            magnitude = DecimalEx.Sqrt(a);
    }

    public Vector3Decimal(Vector3 v3)
    {
        x = (decimal)v3.x;
        y = (decimal)v3.y;
        z = (decimal)v3.z;

        decimal a = (x * x + y * y + z * z);

        if ((float)a == 0f)
            magnitude = 0;
        else
            magnitude = DecimalEx.Sqrt(a);
    }

    public Vector3Decimal(float x, float y, float z)
    {
        this.x = (decimal)x;
        this.y = (decimal)y;
        this.z = (decimal)z;

        decimal a = (decimal)(x * x + y * y + z * z);

        if ((float)a == 0f)
            magnitude = 0;
        else
            magnitude = DecimalEx.Sqrt(a);
    }
    

    public static Vector3Decimal up = new Vector3Decimal(0f, 1f, 0f);
    public static Vector3Decimal forward = new Vector3Decimal(0f, 0f, 1f);
    public static Vector3Decimal right = new Vector3Decimal(1f, 0f, 0f);
    public static Vector3Decimal zero = new Vector3Decimal(0f, 0f, 0f);

    public Vector3 ToVector3f()
    {
        Vector3 newV3 = new Vector3((float)x, (float)y, (float)z);
        return newV3;
    }
    public static float Distance(Vector3Decimal a, Vector3Decimal b)
    {
        float dist;

        Vector3Decimal diff = a - b;
        dist = (float)diff.magnitude;

        return dist;

    }

    public static Vector3Decimal operator -(Vector3Decimal a)
    {
        Vector3Decimal negative = new Vector3Decimal(-a.x, -a.y, -a.z);
        return negative;
    }
    public static Vector3Decimal operator -(Vector3Decimal a, Vector3Decimal b)
    {
        Vector3Decimal diff = new Vector3Decimal(a.x - b.x, a.y - b.y, a.z - b.z);
        return diff;
    }
    public static Vector3Decimal operator -(Vector3Decimal a, Vector3 b)
    {
        Vector3Decimal diff = new Vector3Decimal(a.x - (decimal)b.x, a.y - (decimal)b.y, a.z - (decimal)b.z);
        return diff;
    }
    public static Vector3Decimal operator +(Vector3Decimal a, Vector3Decimal b)
    {
        Vector3Decimal sum = new Vector3Decimal(a.x + b.x, a.y + b.y, a.z + b.z);
        return sum;
    }
    public static Vector3Decimal operator +(Vector3Decimal a, Vector3 b)
    {
        Vector3Decimal sum = new Vector3Decimal(a.x + (decimal)b.x, a.y + (decimal)b.y, a.z + (decimal)b.z);
        return sum;
    }
    public static Vector3Decimal operator *(Vector3Decimal a, Vector3Decimal b)
    {
        Vector3Decimal prod = new Vector3Decimal(a.x * b.x, a.y * b.y, a.z * b.z);
        return prod;
    }

    public static Vector3Decimal operator *(Vector3Decimal a, decimal f)
    {
        Vector3Decimal prod = new Vector3Decimal(a.x * f, a.y * f, a.z * f);
        return prod;
    }

    public static Vector3Decimal operator /(Vector3Decimal a, Vector3Decimal b)
    {
        Vector3Decimal quotient = new Vector3Decimal(a.x / b.x, a.y / b.y, a.z / b.z);
        return quotient;
    }

    public static Vector3Decimal Sqrts(Vector3Decimal vec)
    {
        Vector3Decimal ret = new Vector3Decimal(DecimalEx.Sqrt(vec.x), DecimalEx.Sqrt(vec.y), DecimalEx.Sqrt(vec.z));
        return ret;
    }

    public static decimal Dot(Vector3Decimal vec1, Vector3Decimal vec2)
    {
        decimal ret = (vec1.x * vec2.x) + (vec1.y * vec2.y) + (vec1.z * vec2.z);
        return ret;
    }

    public static Vector3Decimal Cross(Vector3Decimal vec1, Vector3Decimal vec2)
    {
        decimal ax = (vec1.y * vec2.z) - (vec1.z * vec2.y);
        decimal ay = (vec1.z * vec2.x) - (vec1.x * vec2.z);
        decimal az = (vec1.x * vec2.y) - (vec1.y * vec2.x);
        Vector3Decimal a = new Vector3Decimal(ax, ay, az);
        return a;
    }
    public override string ToString()
    {
        return x.ToString() +" , "+ y.ToString() + " , " + z.ToString();
    }
}
