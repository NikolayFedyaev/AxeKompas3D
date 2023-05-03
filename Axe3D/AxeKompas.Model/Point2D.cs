using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxeKompas.Model
{
    /// <summary>
    /// Класс для задачи координат в двумерном пространстве.
    /// </summary>
    public class Point2D
    {
        /// <summary>
        /// Значение х.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Значение y.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Point2D конструктор.
        /// </summary>
        /// <param name="x">Координата Х</param>
        /// <param name="y">Координата y</param>
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Проверка на равенство.
        /// </summary>
        /// <param name="expected">Сравниеваемый объект.</param>
        /// <returns>Returns true if the elements are equal,
        /// false - otherwise.</returns>
        public bool Equals(Point2D expected)
        {
            return expected != null &&
                   expected.X.Equals(X) &&
                   expected.Y.Equals(Y);
        }

    }
}
