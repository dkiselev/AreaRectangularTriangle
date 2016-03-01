using System;

namespace ru.Company.Library
{
    /// <summary>
    /// Статический класс для методов вычисления площади прямоугольного треугольника
    /// Для проверки валидности данных используйте методы:
    /// Если известны катеты
    /// bool IsValid(double a, double b)
    /// Если не известны катеты и даны все 3 длины сторон треугольника
    /// bool IsValid(double a, double b, double c)
    /// Для вычисления площади по 2 катетам
    /// double CalcArea(double a, double b)
    /// По трем сторонам
    /// double CalcArea(double a, double b, double с)
    /// </summary>
    public static class AreaRectangularTriangle
    {
        /// <summary>
        /// Проверить корреткнотсть длин 2 катетов
        /// </summary>
        /// <param name="a">Катет 1</param>
        /// <param name="b">Катет 2</param>
        /// <returns>bool true если аргументы больше или равны 0</returns>
        public static bool IsValid(double a, double b)
        {
            return a >= 0.0 && b >= 0.0;
        }

        /// <summary>
        /// Проверить корреткнотсть длин 3 сторон прямоугольного треугольника
        /// длины сторон должны быть не меньше 0 и соответствовать теореме Пифагора
        /// с1*с1 + с2*с2 = h*h
        /// с точностью precision знаков после запятой.
        /// </summary>
        /// <param name="a">Длина стороны A</param>
        /// <param name="b">Длина стороны B</param>
        /// <param name="c">Длина стороны C</param>
        /// <param name="precision">Точность 0 - 15 (округление до количества знаков в дробной части)</param>
        /// <returns>true если аргументы больше или равны 0 и длины сторон соответствуют теореме Пифагора</returns>
        public static bool IsValid(double a, double b, double c, int precision = 15)
        {
            var positive = a >= 0.0 && b >= 0.0 && c >= 0.0;
            if (positive) {
                var cat1 = (a > c ? c : a);
                var cat2 = (b > c ? c : b);
                var hyp = Math.Max(Math.Max(a, b), c);

                positive = Math.Round(cat1 * cat1 + cat2 * cat2, precision) == Math.Round(hyp * hyp, precision);
            }
            return positive;
        }

        /// <summary>
        /// Вычисислить площадь прямоугольного треуголльника по 2 катетам
        /// по Формуле S = 1/2*a*b
        /// </summary>
        /// <remarks>Метод не прверяет валидность аргументов (длины катетов меньше 0)</remarks>
        /// <param name="a">Длина 1 катета</param>
        /// <param name="b">Длина 2 катета</param>
        /// <returns>площадь</returns>
        public static double CalcArea(double a, double b)
        {
            return a * b * 0.5;
        }

        /// <summary>
        /// Вычисислить площадь треуголльника по 3 сторонам
        /// по Формуле Герона S=sqrt(p*(p-a)*(p-b)*(p-c))
        /// где p = (a+b+c)/2
        /// </summary>
        /// <remarks>Метод вычисляет площадь не телько прямоугольного треугольника.
        /// </remarks>
        /// <param name="a">Длина стороны А</param>
        /// <param name="b">Длина стороны B</param>
        /// <param name="c">Длина стороны C</param>
        /// <returns>площадь треугольника по 3 сторонам</returns>
        public static double CalcArea(double a, double b, double c)
        {
            var p = (a + b + c) * 0.5; // полупериметр
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
   }
}
