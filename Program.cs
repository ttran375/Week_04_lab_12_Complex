﻿namespace Week_04_lab_012_Complex_W
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Complex c0 = new Complex(-2, 3);
            Complex c1 = new Complex(-2, 3);
            Complex c2 = new Complex(1, -2);

            Console.WriteLine($"{c0}");
            Console.WriteLine(c1);
            Console.WriteLine(c2);

            Console.WriteLine($"{c1} + {c2} = {c1 + c2}");
            Console.WriteLine($"{c1} - {c2} = {c1 - c2}");

            Complex c3 = c1 + c2;

            Console.WriteLine($"{c3} in polar form is {c3.Modulus:f2}cis({c3.Argument:f2})");

            Console.WriteLine($"{c0} {(c0 == c1 ? "=" : "!=")} {c1}");
            Console.WriteLine($"{c0} {(c0 == c2 ? "=" : "!=")} {c2}");

            Console.WriteLine($"{c1} * {c2} = {c1 * c2}");

            Complex c4 = -c1;
            Console.WriteLine($"- {c1} = {c4}");
        }
    }


    public class Complex
    {
        public int Real { get; }
        public int Imaginary { get; }
        public double Modulus => Math.Sqrt(Real * Real + Imaginary * Imaginary);
        public double Argument => Math.Atan2(Imaginary, Real);
        public static Complex Zero => new Complex(0, 0);

        public Complex(int real, int imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public override string ToString()
        {
            return $"({Real}, {Imaginary})";
        }

        public static Complex operator +(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.Real + rhs.Real, lhs.Imaginary + rhs.Imaginary);
        }

        public static Complex operator -(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.Real - rhs.Real, lhs.Imaginary - rhs.Imaginary);
        }

        public static Complex operator *(Complex lhs, Complex rhs)
        {
            int real = lhs.Real * rhs.Real - lhs.Imaginary * rhs.Imaginary;
            int imaginary = lhs.Real * rhs.Imaginary + lhs.Imaginary * rhs.Real;
            return new Complex(real, imaginary);
        }

        public static Complex operator -(Complex c)
        {
            return new Complex(-c.Real, -c.Imaginary);
        }

        public static bool operator ==(Complex lhs, Complex rhs)
        {
            return lhs.Real == rhs.Real && lhs.Imaginary == rhs.Imaginary;
        }

        public static bool operator !=(Complex lhs, Complex rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Complex other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Real, Imaginary).GetHashCode();
        }
    }
}
