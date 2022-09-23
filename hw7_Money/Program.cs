using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace hw7_Money
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Меню:\n" +
                    "1. Сложение двух денежных сумм;\n" +
                    "2. Вычитание одной денежной суммы из другой;\n" +
                    "3. Деление денежной суммы на коэффициент" +
                    "4. Умножение денежной суммы на коэффициент;\n" +
                    "5. Увиличение суммы на одну копейку заданное количество раз\n" +
                    "6. Уменьшение суммы на одну копейку заданное количество раз\n" +
                    "7. Сравнение 2х сумм (<,>, =, !=)\n" +
                    "8. Выйти из программы.\n\n");
            while (true)
            {
                WriteLine("Какое действие хотите произвести:\n");
                int pos = int.Parse(ReadLine());
                switch (pos)
                {
                    case 1:
                        {
                            WriteLine("Сложение двух денежных сумм:\n");
                            Write("Введите первую сумму:\n");
                            Money m = new Money().iniz();
                            m = m.prov(m);

                            Write("Введите вторую сумму:\n ");
                            Money n = new Money().iniz();
                            n = n.prov(n);
                            WriteLine($"{m} + {n} = {m + n}");
                        }
                        break;

                    case 2:
                        {
                            WriteLine("Вычитание одной денежной суммы из другой:\n");

                            Write("Введите первую сумму:\n");
                            Money m = new Money().iniz();
                            m = m.prov(m);

                            Write("Введите вторую сумму:\n");
                            Money n = new Money().iniz();
                            n = n.prov(n);
                            try
                            {
                                if (m - n < new Money { Kop = 0, Rub = 0 })
                                {
                                    throw new My_Exep();
                                }
                                WriteLine($"{m} - {n} = {m - n}");
                            }
                            catch (My_Exep e)
                            {
                                WriteLine(e.Message);
                            }
                            WriteLine();
                        }
                        break;

                    case 3:
                        {
                            WriteLine("Деление денежной суммы на коэффициент:\n");
                            Write("Введите сумму:\n");
                            Money m = new Money().iniz();
                            m = m.prov(m);

                            Write("Введите коэффициент: ");
                            int n = int.Parse(ReadLine());

                            try
                            {
                                if (n == 0)
                                {
                                    throw new DivideByZeroException();
                                }
                                if (m / n < new Money { Kop = 0, Rub = 0 })
                                {
                                    throw new My_Exep();
                                }
                                WriteLine($"{m} / {n} = {m / n}");
                            }
                            catch (DivideByZeroException e)
                            {
                                WriteLine(e.Message);
                            }
                            catch (My_Exep e)
                            {
                                WriteLine(e.Message);
                            }
                            WriteLine();
                        }
                        break;

                    case 4:
                        {
                            WriteLine("Умножение денежной суммы на коэффициент:\n");
                            Write("Введите сумму:\n");
                            Money m = new Money().iniz();
                            m = m.prov(m);

                            Write("Введите коэффициент: ");
                            int n = int.Parse(ReadLine());
                            try
                            {
                                if (m * n < new Money { Kop = 0, Rub = 0 })
                                {
                                    throw new My_Exep();
                                }
                                WriteLine($"{m} * {n} = {m * n}");
                            }
                            catch (My_Exep e)
                            {
                                WriteLine(e.Message);
                            }
                            WriteLine();
                        }
                        break;

                    case 5:
                        {
                            WriteLine("Увиличение суммы на одну копейку заданное количество раз\n");
                            Write("Введите сумму:\n");
                            Money m = new Money().iniz();
                            m = m.prov(m);

                            Write("Введите количество повторений: ");
                            int n = int.Parse(ReadLine());
                            for (int i = 0; i < n; i++)
                            {
                                WriteLine(m++);
                            }
                            WriteLine();
                        }
                        break;

                    case 6:
                        {
                            WriteLine("Уменьшение суммы на одну копейку заданное количество раз\n");
                            Write("Введите сумму:\n");
                            Money m = new Money().iniz();
                            m = m.prov(m);

                            Write("Введите количество повторений: ");
                            int n = int.Parse(ReadLine());

                            for (int i = 0; i < n; i++)
                            {
                                try
                                {
                                    
                                    if (m > new Money { Kop = 0, Rub = 0 })
                                    {
                                        WriteLine(m--);
                                    }
                                    else
                                        throw new My_Exep();
                                }
                                catch (My_Exep e)
                                {
                                    WriteLine(e.Message);
                                }
                            }
                            WriteLine();
                        }
                        break;

                    case 7:
                        {
                            WriteLine("Сравнение 2х сумм (<,>, =, !=)\n");
                            Write("Введите первую сумму:\n");
                            Money m = new Money().iniz();
                            m = m.prov(m);

                            Write("Введите вторую сумму:\n ");
                            Money n = new Money().iniz();
                            n = n.prov(n);

                            WriteLine($"m меньше n ? - {m < n}");
                            WriteLine($"m больше n ? - {m > n}");
                            WriteLine($"m равно n ? - {m == n}");
                            WriteLine($"m неравно n ? - {m != n}");
                        }
                        break;

                    case 8:
                        return;

                    default:
                        WriteLine("Вы выбрали несуществующий пункт меню. Выберите снова.");
                        continue;
                }
            }
        }
    }
}
