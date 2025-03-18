using System;

namespace STPRGR
{
    public class CNum
    {
        private double real;
        private double im;

        public CNum(double r, double i)
        {
            real = r;
            im = i;
        }

        public double GetReal() { return real; }
        public double GetIm() { return im; }
        public void SetReal(double r) { real = r; }
        public void SetIm(double i) { im = i; }

        public void Pwr(int n, int i) // возведение самого себя в степень
        {
            double modulus = Mdl();
            double argument = Cnrad();

            double newModulus = Math.Pow(modulus, n) * Math.Exp(-i * argument);
            double newArgument = n * argument + i * Math.Log(modulus);

            real = newModulus * Math.Cos(newArgument);
            im = newModulus * Math.Sin(newArgument);
        }

        public void Root(int n, int i) // извлечение корня из самого себя
        {
            double modulus = Mdl();
            double argument = Cnrad();

            double newModulus = Math.Pow(modulus, 1.0 / n);
            double newArgument = (argument + 2 * Math.PI * i) / n;

            real = newModulus * Math.Cos(newArgument);
            im = newModulus * Math.Sin(newArgument);
        }

        public double Mdl() // вычисление модуля самого себя
        {
            return Math.Sqrt(real * real + im * im);
        }

        public double Cnr() // вычисление аргумента комплексного числа в градусах
        {
            return Cnrad() * (180 / Math.PI);
        }

        public double Cnrad() // вычисление аргумента комплексного в радианах
        {
            return Math.Atan2(im, real);
        }

        public CNum Sum(CNum a, CNum b)
        {
            return new CNum(a.GetReal() + b.GetReal(), a.GetIm() + b.GetIm());
        }

        public CNum Mult(CNum a, CNum b)
        {
            double newReal = a.GetReal() * b.GetReal() - a.GetIm() * b.GetIm();
            double newIm = a.GetReal() * b.GetIm() + a.GetIm() * b.GetReal();
            return new CNum(newReal, newIm);
        }

        public CNum Sub(CNum a, CNum b)
        {
            return new CNum(a.GetReal() - b.GetReal(), a.GetIm() - b.GetIm());
        }

        public CNum Div(CNum a, CNum b)
        {
            double denominator = b.GetReal() * b.GetReal() + b.GetIm() * b.GetIm();
            double newReal = (a.GetReal() * b.GetReal() + a.GetIm() * b.GetIm()) / denominator;
            double newIm = (a.GetIm() * b.GetReal() - a.GetReal() * b.GetIm()) / denominator;
            return new CNum(newReal, newIm);
        }
    }
}