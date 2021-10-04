using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    class ComplexNumber
    {
        private int real;
        private int imaginary;

        public ComplexNumber(int r, int i)
        {
            real = r;
            imaginary = i;
        }

        public ComplexNumber Add(ComplexNumber z1, ComplexNumber z2)
        {
            return new ComplexNumber(z1.real + z2.real, z1.imaginary + z2.imaginary);
        }

        public static ComplexNumber operator + (ComplexNumber z1, ComplexNumber z2)
        {
            return new ComplexNumber(z1.real + z2.real, z1.imaginary + z2.imaginary);
        }

        public static ComplexNumber operator +(ComplexNumber z1, int i)
        {
            return new ComplexNumber(z1.real + i, z1.imaginary);
        }

        public static ComplexNumber operator +( int i, ComplexNumber z1)
        {
            return z1+i;
        }

        public static ComplexNumber operator -(ComplexNumber z1, int i) => new ComplexNumber(z1.real - i, z1.imaginary);

        

        public static ComplexNumber operator -(int i, ComplexNumber z1)
        {
            return z1 + i;
        }




        public static ComplexNumber operator -(ComplexNumber z)
        {
            return new ComplexNumber(-z.real, -z.imaginary);
        }

        public static bool operator true(ComplexNumber z)
        {
            return z.real != 0 || z.imaginary != 0;
        }

        public static bool operator false(ComplexNumber z)
        {
            return z.real == 0 && z.imaginary == 0;
        }

        public double Modulo
        {
            get
            {
                return Math.Sqrt(Math.Pow(this.real, 2) + Math.Pow(this.imaginary, 2));
            }
        }

        public static bool operator <(ComplexNumber z1, ComplexNumber z2)
        {
            return z1.Modulo < z2.Modulo;
        }

        public static bool operator >(ComplexNumber z1, ComplexNumber z2)
        {
            return z2.Modulo < z1.Modulo;
        }

        public static explicit operator ComplexNumber (int d)
        {
            return new ComplexNumber(d, 0);
        }

        public static explicit operator int(ComplexNumber d)
        {
            return d.real;
        }


        public static implicit operator int[](ComplexNumber z)
        {
            return new int[]{z.real, z.imaginary};
        }

        public override string ToString()
        {
            if (imaginary > 0)
                return String.Format("{0}+{1}i", this.real, this.imaginary);
            else return String.Format("{0}-{1}i", this.real, -this.imaginary);
        }
    }


}
