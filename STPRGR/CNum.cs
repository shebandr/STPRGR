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

		static public CNum Pwr(CNum a, CNum b) // возведение самого себя в степень
        {
			double modulus = a.Mdl();
			double argument = a.Rad();

			double newModulus = Math.Pow(modulus, b.GetReal()) * Math.Exp(-b.GetIm() * argument);
            double newArgument = b.GetReal() * argument + b.GetIm() * Math.Log(modulus);

            double real = newModulus * Math.Cos(newArgument);
			double im = newModulus * Math.Sin(newArgument);
			return new CNum(real, im);
		}

        static public CNum Root(CNum a, CNum b) // извлечение корня из самого себя
        {
            double modulus = a.Mdl();
            double argument = a.Rad();

            double newModulus = Math.Pow(modulus, 1.0 / b.GetReal());
            double newArgument = (argument + 2 * Math.PI * b.GetIm()) / b.GetReal();

            double real = newModulus * Math.Cos(newArgument);
			double im = newModulus * Math.Sin(newArgument);
            return new CNum(real, im);
        }

        public double Mdl() // вычисление модуля самого себя
        {

            return Math.Sqrt(real * real + im * im);
        }

        public double Deg() // вычисление аргумента комплексного числа в градусах
        {
            return Rad() * (180 / Math.PI);
        }

        public double Rad() // вычисление аргумента комплексного в радианах
        {
            return Math.Atan2(im, real);
        }

        static public CNum Sum(CNum a, CNum b)
        {
            return new CNum(a.GetReal() + b.GetReal(), a.GetIm() + b.GetIm());
        }

		static public CNum Mult(CNum a, CNum b)
        {
            double newReal = a.GetReal() * b.GetReal() - a.GetIm() * b.GetIm();
            double newIm = a.GetReal() * b.GetIm() + a.GetIm() * b.GetReal();
            return new CNum(newReal, newIm);
        }

		static public CNum Sub(CNum a, CNum b)
        {
            return new CNum(a.GetReal() - b.GetReal(), a.GetIm() - b.GetIm());
        }

		static public CNum Div(CNum a, CNum b)
        {
            double denominator = b.GetReal() * b.GetReal() + b.GetIm() * b.GetIm();
            double newReal = (a.GetReal() * b.GetReal() + a.GetIm() * b.GetIm()) / denominator;
            double newIm = (a.GetIm() * b.GetReal() - a.GetReal() * b.GetIm()) / denominator;
            return new CNum(newReal, newIm);
        }
    }
}