using System.Globalization;
using System.Xml.Linq;

namespace dz6._2
{
    internal class Program
    {
        class USD
        {
            private double count = 0;
            public double Count
            {
                get { return count; }
                set
                {
                    if (value >= 0) { count = value; }
                    else { throw new Exception("Invalid value. Value shouldn't be negative"); }
                }
            }
            private double exchange = 1;
            public double Exchange
            {
                get { return exchange; }
                set
                {
                    if (value > 0) { exchange = value; }
                    else { throw new Exception("Invalid value. Value shouldn't be negative"); }
                }
            }

            public USD(double _count) { Count = _count; }
            public USD(double _count, double _exchange) { Count = _count; Exchange = _exchange; }

            public static explicit operator EUR(USD usd)
            {
                return new EUR(usd.Count * 0.92);
            }
            public override string ToString()
            {
                return $"{Count} | Exchange: {Exchange}";
            }
        }


        class EUR
        {
            private double count = 0;
            public double Count
            {
                get { return count; }
                set
                {
                    if (value >= 0) { count = value; }
                    else { throw new Exception("Invalid value. Value shouldn't be negative"); }
                }
            }
            private double exchange = 0.92;
            public double Exchange
            {
                get { return exchange; }
                set
                {
                    if (value > 0) { exchange = value; }
                    else { throw new Exception("Invalid value. Value shouldn't be negative"); }
                }
            }
            public EUR(double _count) { Count = _count; }
            public EUR(double _count, double _exchange) { Count = _count; Exchange = _exchange; }

            public static implicit operator USD(EUR eur)
            {
                return new USD(eur.Count / 0.92);
            }

            public override string ToString()
            {
                return $"{Count} | Exchange: {Exchange}";
            }
        }
        static void Main(string[] args)
        {
            USD usd = new USD(100);
            Console.WriteLine($"USD: {usd}");

            EUR eur = (EUR)usd;
            Console.WriteLine($"to EUR: {eur}");

            USD usd1 = eur;
            Console.WriteLine($"back to USD: {usd1}");
        }
    }
}
