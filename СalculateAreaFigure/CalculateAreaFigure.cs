using СalculateAreaFigure.Services;
using System;

namespace СalculateAreaFigure
{
    public class CalculateAreaFigure : IDisposable
    {
        private static CalculateAreaFigureService _calculateAreaFigureService = new CalculateAreaFigureService();

        /// <summary>
        /// Расчёт площади фигуры
        /// </summary>
        /// <param name="ps">Стороны фигуры (либо радиус для круга)</param>
        /// <returns></returns>
        public static double CalculateArea(params double[] ps)
        {
            double area = 0.0;

            if (ps.Length > 0)
                area = _calculateAreaFigureService.Calculate(ps);

            return area;
        }

        public void Dispose()
        {

        }
    }
}
