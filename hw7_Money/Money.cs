using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace hw7_Money
{
    internal class Money
    {
        public int Rub { get; set; }
        public int Kop { get; set; }

        public override string ToString()
        {
            return $"{Rub} руб. {Kop} коп.";
        }

        public static Money operator +(Money m, Money n)
        {
            Money sum = new Money
            {
                Rub = m.Rub + n.Rub,
                Kop = m.Kop + n.Kop
            };
            if (sum.Kop > 100)
            {
                sum.Rub++;
                sum.Kop -= 100;
            }
            return sum;
        }

        public static Money operator -(Money m, Money n)
        {
            Money dif = new Money
            {
                Kop = ((m.Rub * 100 + m.Kop) - (n.Rub * 100 + n.Kop)) % 100,
                Rub = ((m.Rub * 100 + m.Kop) - (n.Rub * 100 + n.Kop)) / 100
            };
            return dif;
        }

        public static Money operator /(Money m, int x)
        {
            Money rez = new Money
            {
                Kop = (m.Rub * 100 + m.Kop) / x % 100,
                Rub = (m.Rub * 100 + m.Kop) / x / 100

            };
            return rez;
        }



        public static Money operator *(Money m, int x)
        {
            Money rez = new Money
            {
                Kop = m.Kop * x,
                Rub = m.Rub * x
            };
            if (rez.Kop > 100)
            {
                rez.Rub += (rez.Kop - (rez.Kop % 100)) / 100;
                rez.Kop %= 100;
            }
            return rez;
        }
        public static Money operator ++(Money m)
        {
            m.Kop++;
            if (m.Kop > 99)
            {
                m.Rub++;
                m.Kop = 0;
            }
            return m;
        }

        public static Money operator --(Money m)
        {
            m.Kop--;
            if (m.Kop < 0)
            {
                m.Rub--;
                m.Kop = 99;
            }
            return m;
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Money m1, Money m2)
        {
            return m1.Equals(m2);
        }
        public static bool operator !=(Money m1, Money m2)
        {
            return !(m1 == m2);
        }
        public static bool operator <(Money m1, Money m2)
        {
            return m1.Rub * 100 + m1.Kop < m2.Rub * 100 + m2.Kop;
        }
        public static bool operator >(Money m1, Money m2)
        {
            return !(m1 < m2) && !(m1 == m2);
        }

        public Money iniz()
        {
            Money m = new Money();
            try
            {
                Write("рублей: ");
                m.Rub = int.Parse(ReadLine());
                Write("копеек: ");
                m.Kop = int.Parse(ReadLine());
                if (m.Kop > 99)
                {
                    throw new My_Exep2();
                }
            }
            catch (My_Exep2 e)
            {
                WriteLine(e.Message);
                Write("Введите заново\nкопеек: ");
                m.Kop = int.Parse(ReadLine());
            }
            return m;
        }
        public Money prov(Money m)
        {
            try
            {
                if (m.Rub < 0 || m.Kop < 0)
                {
                    throw new My_Exep3();
                }
            }
            catch (My_Exep3 e)
            {
                WriteLine(e.Message);
                Write("Введите сумму заново:\n ");
                m = new Money().iniz();
            }
            return m;
        }
    }

    public class My_Exep : ApplicationException
    {
        public My_Exep() : base("Банкрот")
        {

        }

    }

    public class My_Exep2 : ApplicationException
    {
        public My_Exep2() : base("Сумма задана некорректно: количество копеек > 99")
        {
        }

    }

    public class My_Exep3 : ApplicationException
    {
        public My_Exep3() : base("Сумма задана некорректно: введено отрицательное значение")
        {
        }

    }
}
