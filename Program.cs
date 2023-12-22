using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAlgorithms
{


    internal class Program
    {
        static double CalculateCoveredArea(double ropeLength, double squareSide)
        {
            double radius = ropeLength;
            double theta = 2 * Math.Acos(squareSide / (2 * radius));

            double coveredArea = 0.5 * radius * radius * (theta - Math.Sin(theta));

            return coveredArea;
        }

        static int CalculateSum(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }


        static double CalculateClockAngle(int hours, int minutes)
        {
            const int degreesPerHour = 30;
            const int degreesPerMinute = 6;

            // Проверка введенных значений
            if (hours < 1 || hours > 12 || minutes < 0 || minutes > 59)
            {
                throw new ArgumentException("Неверные значения часов или минут");
            }

            // Вычисление угла для часовой стрелки
            double hourAngle = (hours % 12 + minutes / 60.0) * degreesPerHour;

            // Вычисление угла для минутной стрелки
            double minuteAngle = minutes * degreesPerMinute;

            // Вычисление угла между часовой и минутной стрелками
            double angle = Math.Abs(hourAngle - minuteAngle);

            // Угол не должен превышать 180 градусов
            if (angle > 180)
            {
                angle = 360 - angle;
            }

            return angle;
        }
        static void Main(string[] args)
        {

            do
            {
                Console.WriteLine("Выберите метод:");
                Console.WriteLine("1. replace");
                Console.WriteLine("2. ReverseNumber");
                Console.WriteLine("3. CalculateAngle");
                Console.WriteLine("4. amountNumbers");
                Console.WriteLine("5. numberYears");
                Console.WriteLine("6. distancePoints");
                Console.WriteLine("7. SearchVectors");
                Console.WriteLine("8. IntersectioPoint");
                Console.WriteLine("9. Calculate");
                Console.WriteLine("10. CalculateClock");
                Console.WriteLine("11. CalculateTime");
                Console.WriteLine("12. CalculatedArea");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            replace();
                            break;
                        case 2:
                            ReverseNumber();
                            break;
                        case 3:
                            CalculateAngle();
                            break;
                        case 4:
                            amountNumbers();
                            break;
                        case 5:
                            numberYears();
                            break;
                        case 6:
                            distancePoints();
                            break;
                        case 7:
                            SearchVectors();
                            break;
                        case 8:
                            IntersectioPoint();
                            break;
                        case 9:
                            Calculate();
                            break;
                        case 10:
                            CalculateClock();
                            break;
                        case 11:
                            CalculateTime();
                            break;
                        case 12:
                            CalculatedArea();
                            break;
                        default:
                            Console.WriteLine("Неправильный выбор.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Введите корректное число.");
                }

                Console.WriteLine("Нажмите Enter, чтобы продолжить...");
            } while (Console.ReadLine() == "");
            Console.ReadKey();
        }
        static void replace()
        {
            int x = 0, y = 0;
            Console.WriteLine("Введите целое число a: ");
            if (int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Введите натуральное число b: ");
                if (int.TryParse(Console.ReadLine(), out y))
                {
                    y = x + y - x;
                    Console.WriteLine($"Результат: {y} {x}");
                }
                else
                {
                    Console.WriteLine("Введено неверное число b ");
                }
            }
            else
            {
                Console.WriteLine("Введено неверное значение для a");
            }

        }
        static void ReverseNumber()
        {
            int x = 0;
            int a = 0;
            Console.WriteLine("Введите трехзначное число");
            if (int.TryParse(Console.ReadLine(), out x) && (x >= 100 && x <= 999) && (x % 100 != 0))
            {
                while (x > 0)
                {
                    a = a * 10 + x % 10;
                    x = x / 10;
                }
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine("Введите корректное трехзначное число.");
            }

        }
        static void CalculateAngle()
        {
            double angle = 0;
            Console.Write("Введите время в часах (1-12): ");
            if (int.TryParse(Console.ReadLine(), out int hours) && hours >= 1 && hours <= 12)
            {
                Console.Write("Введите количество минут (0-59): ");
                if (int.TryParse(Console.ReadLine(), out int minutes) && minutes >= 0 && minutes <= 59)
                {
                    angle= Math.Abs((30 * hours + 0.5 * minutes) - (6 * minutes));
                    angle = Math.Min(angle, 360 - angle); // учитываем, что угол между стрелками не зависит от направления
                    Console.WriteLine($"Угол между часовой и минутной стрелками: {angle} градусов");
                }
                else
                {
                    Console.WriteLine("Неверное количество минут");
                }
            }
            else
            {
                Console.WriteLine("Неверное время в часах");
            }

        }
        static void amountNumbers()
        {
            Console.WriteLine("Введите длину строки ");
            int l = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            int[] array = new int[l];
            int KolNum = 0;
            int n = 50;
            int x = 5, y = 7;


            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 100);
                Console.Write(array[i] + " ");
                if (i<n)
                {
                    if (i % x == 0 || i % y ==0)
                    {
                        KolNum++;

                    }

                }

            }
            Console.WriteLine("");
            Console.WriteLine($"Количество чисел менше N({n}), которые имею простой делитель X({x}) или простой делитель Y({y}): " + KolNum);

        }
        static void numberYears()
        {
            int a = 2000;
            int b = 2024;

            // Используйте LINQ и лямбда-выражение для подсчета високосных лет
            int leapYearsCount = Enumerable.Range(a, b - a + 1).Count(year => DateTime.IsLeapYear(year));

            Console.WriteLine($"Количество високосных лет на отрезке [{a}, {b}]: {leapYearsCount}");

        }
        static void distancePoints()
        {

            double x1 = 1, y1 = 2;
            double x2 = 4, y2 = 6;

            // Координаты точки, до которой считаем расстояние
            double x0 = 3, y0 = 4;

            // Вычисление расстояния
            double distance = Math.Abs((y2 - y1) * x0 - (x2 - x1) * y0 + x2 * y1 - y2 * x1) / Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2));

            Console.WriteLine($"Расстояние от точки ({x0}, {y0}) до прямой, проходящей через точки ({x1}, {y1}) и ({x2}, {y2}), равно {distance}");

        }
        static void SearchVectors()
        {
            Console.WriteLine("Введите коэффициенты прямой вида Ax+By+C=0");

            Console.Write("A: ");
            double A = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("B: ");
            double B = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("C: ");
            double C = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine($"Вектор, параллельный прямой: a({B}:{-A})");
            Console.WriteLine($"Вектор, перпендикулярный прямой: b({A}:{B})");
            Console.ReadLine();

        }
        static void IntersectioPoint()
        {
            // Пример задания прямой L
            double A = 2;
            double B = -3;
            double C = 4;

            // Пример задания точки A
            double xA = 1;
            double yA = 5;

            // Находим коэффициенты уравнения прямой P
            double D = B * xA - A * yA;

            // Выводим уравнение прямой P
            Console.WriteLine($"Уравнение прямой P: {B}x - {A}y + {D} = 0");

            // Находим точку пересечения прямой L с прямой P
            double xIntersection = (B * C - A * D) / (A * A + B * B);
            double yIntersection = (-A * C - B * D) / (A * A + B * B);

            Console.WriteLine($"Точка пересечения: ({xIntersection}, {yIntersection})");
        }
        static void Calculate()
        {
            Console.WriteLine("Введите значение N:");
            int n = Convert.ToInt32(Console.ReadLine());

            int result = CalculateSum(n);

            Console.WriteLine($"Сумма чисел от 1 до {n} равна: {result}");


        }
        static void CalculateClock()
        {
            Console.WriteLine("Введите часы (от 1 до 12): ");
            int hours = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите минуты (от 0 до 59): ");
            int minutes = Convert.ToInt32(Console.ReadLine());

            double angle = CalculateClockAngle(hours, minutes);

            Console.WriteLine($"Угол между часовой и минутной стрелкой: {angle} градусов");
        }
        static void CalculateTime()
        {
            Console.WriteLine("Введите высоту h (м): ");
            double h = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите время разгона до высоты h t (сек): ");
            double t = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите максимальную скорость v (м/с): ");
            double v = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите пороговую скорость x (м/с): ");
            double x = Convert.ToDouble(Console.ReadLine());

            double t_min, t_max;

            if (x >= v)
            {
                // Если скорость разгона до высоты h не превышает x,
                // то минимальное время - время разгона до максимальной скорости v
                t_min = h / v;
            }
            else
            {
                // Иначе, минимальное время - время разгона до высоты h
                t_min = Math.Sqrt(2 * h / x);
            }

            // Максимальное время - время разгона до максимальной скорости v
            // плюс время, которое самолет поддерживает эту скорость на высоте h
            t_max = t + (h - t * v) / v;

            Console.WriteLine($"Минимальное время: {t_min} сек");
            Console.WriteLine($"Максимальное время: {t_max} сек");
        }
        static void CalculatedArea()
        {
            Console.WriteLine("Введите длину веревки (радиус круга): ");
            double ropeLength = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите размер стороны квадратного огорода: ");
            double squareSide = Convert.ToDouble(Console.ReadLine());

            double areaCovered = CalculateCoveredArea(ropeLength, squareSide);

            Console.WriteLine($"Площадь, объеденная козлом: {areaCovered} квадратных метров");
        }
    }
}
