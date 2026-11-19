namespace dz6._1
{
    internal class Program
    {
        class Fraction
        {
            public int Num { get; set; } = 0;
            private int denom = 1;
            public int Denom
            {
                get { return denom; }
                set 
                { 
                    if (value != 0) { denom = value; }
                    else { throw new DivideByZeroException(); }
                }
            }
            public Fraction(int _numerator, int _denominator) { Num = _numerator; Denom = _denominator; }

            public void Reduce()
            {
                if (Num == 0) { Denom = 1; return; }
                if (Denom < 0)
                {
                    Num = -Num;
                    Denom = -Denom;
                }

                int a = Num;
                int b = Denom;
                if (Num < 0) { a *= -1; }
                while (b != 0) 
                {
                    int t = b;
                    b = a % b;
                    a = t;
                }
                Num /= a;
                Denom /= a;
            }

            public static Fraction operator +(Fraction a, Fraction b)
            {
                Fraction r = new Fraction(a.Num * b.Denom + b.Num * a.Denom, a.Denom * b.Denom);
                r.Reduce();
                return r;
            }

            public static Fraction operator -(Fraction a, Fraction b)
            {
                Fraction r = new Fraction(a.Num * b.Denom - b.Num * a.Denom, a.Denom * b.Denom);
                r.Reduce();
                return r;
            }
            public static Fraction operator *(Fraction a, Fraction b)
            {
                Fraction r = new Fraction(a.Num * b.Num, a.Denom * b.Denom);
                r.Reduce();
                return r;
            }
            public static Fraction operator /(Fraction a, Fraction b)
            {
                Fraction r = new Fraction(a.Num * b.Denom, a.Denom * b.Num);
                r.Reduce();
                return r;
            }

            public static bool operator ==(Fraction op1, Fraction op2)
            {
                return op1.Num == op2.Num && op1.Denom == op2.Denom;
            }

            public static bool operator !=(Fraction op1, Fraction op2)
            {
                return !(op1 == op2);
            }

            public override string ToString()
            {
                return $"({Num}/{Denom})";
            }
        }


        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(2, 4);
            Fraction f2 = new Fraction(3, 6);
            Fraction f3 = new Fraction(1, 3);

            Console.Write($"f1 = {f1}");
            f1.Reduce();
            Console.WriteLine($" | {f1}");
            Console.Write($"f2 = {f2}");
            f2.Reduce();
            Console.WriteLine($" | {f2}");
            Console.Write($"f3 = {f3}");
            f3.Reduce();
            Console.WriteLine($" | {f3}");

            Console.WriteLine($"f1 + f3 = {f1 + f3}");
            Console.WriteLine($"f1 - f3 = {f1 - f3}");
            Console.WriteLine($"f1 * f3 = {f1 * f3}");
            Console.WriteLine($"f1 / f3 = {f1 / f3}");

            Console.WriteLine($"f1 == f2: {f1 == f2}");
            Console.WriteLine($"f1 == f3: {f1 == f3}");
            Console.WriteLine($"f1 != f3: {f1 != f3}");
        }
    }
}
