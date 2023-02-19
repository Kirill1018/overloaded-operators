using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace cs
{
    internal class Features
    {
        class Money
        {
            public Money()
            {

            }
            public double Rubles { get; set; } = 3;//начальная инициализация рублей
            public double Kopecks { get; set; } = 6;//начальная инициализация копеек
            public Money(double roubles, double copecks)
            {
                Rubles = roubles;
                Kopecks = copecks / 100;
                double cash = Rubles + Kopecks;
                Write("итог=");
                Write(cash);
                WriteLine(" рублей");
                if (Rubles < 0 || Kopecks < 0) WriteLine("ошибка");
            }
            public void sum(double currency, double _currency)
            {
                double coin = currency + _currency;
                Write("стоимость=");
                WriteLine(coin);
            }
            public void tax(double currency, double _currency)
            {
                var rand = new Random();
                Write("налог на первый товар=");
                double taxation = rand.Next(65), charge = currency / 100 * taxation;
                WriteLine(charge);
                Write("налог на второй товар=");
                double _taxation = rand.Next(65), _charge = _currency / 100 * _taxation;
                WriteLine(_charge);
            }
            public static Money operator -(Money buck)
            {
                buck.Rubles = -buck.Rubles;
                return buck;
            }
            public static Money operator -(Money buck, Money dough)
            {
                double result = buck.Rubles * 100 - dough.Kopecks;
                return buck;
            }
            public static Money operator +(Money buck)
            {
                buck.Rubles += buck.Rubles;
                return buck;
            }
            public static Money operator +(Money buck, Money dough)
            {
                double result = buck.Rubles * 100 + dough.Kopecks;
                return buck;
            }
            public static Money operator /(Money buck, Money dough)
            {
                buck.Rubles = dough.Kopecks / 100;
                return buck;
            }
            public static Money operator *(Money buck, Money dough)
            {
                buck.Kopecks = dough.Rubles * 100;
                return buck;
            }
            public static Money operator %(Money buck, Money dough)
            {
                buck.Rubles = buck.Rubles * 100 % dough.Kopecks;
                return buck;
            }
            public static Money operator >(Money buck, Money dough)
            {
                bool result = buck.Kopecks > dough.Rubles;
                return buck;
            }
            public static Money operator <(Money buck, Money dough)
            {
                bool result = buck.Kopecks < dough.Rubles;
                return buck;
            }
            public static Money operator >=(Money buck, Money dough)
            {
                bool result = buck.Kopecks >= dough.Rubles;
                return buck;
            }
            public static Money operator <=(Money buck, Money dough)
            {
                bool result = buck.Kopecks <= dough.Rubles;
                return buck;
            }
            public static Money operator ==(Money buck, Money dough)
            {
                bool result = buck.Kopecks == dough.Rubles;
                return buck;
            }
            public static Money operator !=(Money buck, Money dough)
            {
                bool result = buck.Kopecks != dough.Rubles;
                return buck;
            }
            public void arithm_and_log_act(Money buck, Money dough)
            {
                WriteLine("арифметические и логические действия");
                buck.Rubles = -buck.Rubles;
                WriteLine(buck.Rubles);
                buck.Kopecks = buck.Kopecks - dough.Rubles;
                WriteLine(buck.Kopecks);
                buck.Rubles = +buck.Rubles;
                WriteLine(buck.Rubles);
                buck.Kopecks = buck.Kopecks + dough.Rubles;
                WriteLine(buck.Kopecks);
                buck.Kopecks = buck.Kopecks / dough.Rubles;
                WriteLine(buck.Kopecks);
                buck.Kopecks = buck.Kopecks * dough.Rubles;
                WriteLine(buck.Kopecks);
                buck.Kopecks = buck.Kopecks % dough.Rubles;
                WriteLine(buck.Kopecks);
                bool result = buck.Kopecks > dough.Rubles;
                WriteLine(result);
                result = buck.Kopecks < dough.Rubles;
                WriteLine(result);
                result = buck.Kopecks >= dough.Rubles;
                WriteLine(result);
                result = buck.Kopecks <= dough.Rubles;
                WriteLine(result);
                result = buck.Kopecks == dough.Rubles;
                WriteLine(result);
                result = buck.Kopecks != dough.Rubles;
                WriteLine(result);
            }
        }
        class Pocket
        {
            public double Rubles { get; set; }
            public static implicit operator Pocket(double rubbles)
            {
                return new Pocket
                {
                    Rubles = rubbles
                };
            }
            public static explicit operator double(Pocket silver)
            {
                return silver.Rubles;
            }
            public static explicit operator Pocket(Money pelf)
            {
                double kopeks = pelf.Kopecks;
                return new Pocket
                {
                    Rubles = kopeks / 100
                };
            }
            public static implicit operator Money(Pocket mammon)
            {
                double cent = mammon.Rubles * 100;
                return new Money
                {
                    Rubles = cent / 100
                };
            }
        }
        class _Money
        {
            public double Kopecks { get; set; }
            public static implicit operator _Money(double peanutses)
            {
                return new _Money
                {
                    Kopecks = peanutses
                };
            }
            public static explicit operator double(_Money _kopecks)
            {
                return _kopecks.Kopecks;
            }
        }
        static void Main(string[] args)
        {
            Money wherewithal = new Money();
            Write("цена первого товара=");
            double roubles = Convert.ToDouble(ReadLine());
            WriteLine("рублей");
            double copecks = Convert.ToDouble(ReadLine());
            WriteLine("копеек");
            Money monies = new Money(roubles, copecks);
            double currency = roubles + copecks / 100;
            Write("цена второго товара=");
            roubles = Convert.ToDouble(ReadLine());
            WriteLine("рублей");
            copecks = Convert.ToDouble(ReadLine());
            WriteLine("копеек");
            Money _monies = new Money(roubles, copecks);
            double _currency = roubles + copecks / 100;
            wherewithal.sum(currency, _currency);
            wherewithal.tax(currency, _currency);
            Money buck = new Money(), dough = new Money();
            wherewithal.arithm_and_log_act(buck, dough);
            WriteLine("перегрузка операторов преобразования");
            Pocket money = new Pocket()
            {
                Rubles = 10
            };
            double _money = (double)money;
            WriteLine(_money);
            Pocket pocket = _money;
            WriteLine(pocket.Rubles);
            _Money money_1 = new _Money()
            {
                Kopecks = 10
            };
            double money_2 = (double)money_1;
            WriteLine(money_2);
            _Money _pocket = money_2;
            WriteLine(_pocket.Kopecks);
            WriteLine(money.Rubles);
            WriteLine(wherewithal.Rubles);
        }
    }
}