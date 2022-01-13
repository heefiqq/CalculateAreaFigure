using System;
using System.Linq;

namespace СalculateAreaFigure.Services
{
    internal class CalculateAreaFigureService
    {
        internal double Calculate(params double[] ps)
        {
            var area = 0.0;
            var countElements = ps.Length;
            var sameElements = ps.Distinct().ToArray();
            var countSameElements = sameElements.Count();

            switch (countElements)
            {
                case 1:
                    {
                        //круг
                        area = 3.14 * ps[0];
                        break;
                    }
                case 3:
                    {
                        var triangle = sameElements.OrderByDescending(x => x).ToArray();
                        if (triangle.Length > 2)
                        {
                            var firstSide = triangle[0];
                            var secondSide = triangle[1];
                            var firdSide = triangle[2];
                            if (firstSide > secondSide + firdSide)
                                throw new Exception("Сумма двух сторон должна быть больше третьей");

                            var theorem = Math.Pow(firdSide, 2) == Math.Pow(secondSide, 2) + Math.Pow(firdSide, 2);

                            //Прямоугольный треульник
                            if (theorem)
                            {
                                area = secondSide * firdSide / 2;
                            }
                            else
                            {
                                var semiPerimeter = (firstSide + secondSide + firdSide) / 2;

                                area = Math.Sqrt(
                                    semiPerimeter * (semiPerimeter - firstSide) * (semiPerimeter - secondSide) * (semiPerimeter - firdSide)
                                );
                            }
                        }
                        else
                        {
                            var firstSide = triangle[0];
                            var secondSide = triangle[1];
                            //равнобедренный треугольник 0.75
                            area = secondSide / 4 * Math.Sqrt
                                (
                                    4 * Math.Pow(firstSide, 2) - Math.Pow(secondSide, 2)
                                );
                        }
                        break;
                    }
                case 4:
                    {            
                        // Квадрат
                        if (countSameElements == 1)
                        {
                            var side = ps[0];
                            area = Math.Pow(side, 2);
                        }

                        //прямоугольник
                        if (countSameElements == 2)
                        {
                            var firstSide = sameElements[0];
                            var secondSide = sameElements[1];

                            area = firstSide * secondSide;
                        }

                        //трапеция
                        if (countSameElements == 3)
                        {
                            var trapeze = sameElements.OrderByDescending(x => x).ToArray();
                            var groupElements = ps.GroupBy(x => x);
                            var side = groupElements.Where(x => x.Count() > 1).Select(x => x.Key).FirstOrDefault();
                            var bases = groupElements.Where(x => x.Key != side).Select(x => x.Key).ToArray();
                            var firstBase = bases[0];
                            var secondBase = bases[1];

                            area = ((firstBase + secondBase) / 2) * Math.Sqrt
                            (
                                side * side -
                                Math.Pow
                                (
                                    Math.Pow(firstBase - secondBase, 2) / (2 * (firstBase - secondBase)), 2
                                )
                            );
                        }

                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return Math.Round(area, 2);
        }
    }
}
