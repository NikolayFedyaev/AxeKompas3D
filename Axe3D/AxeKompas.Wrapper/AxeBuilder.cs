using Kompas6API5;
using KompasAPI7;
using AxeKompas.Model;

namespace AxeKompas.Wrapper
{
    /// <summary>
    /// Класс, отвечающий за построение Топора.
    /// </summary>
    public class AxeBuilder
    {
        // <summary>
        /// Оболочка Компас.
        /// </summary>
        private KompasWrapper _wrapper = new KompasWrapper();

        /// <summary>
        /// Создание штока.
        /// </summary>
        /// <param name="stockParameters">Параметры штока.</param>
        public void BuildAxe(AxeParameters axeParameters)
        {
            _wrapper.StartKompas();
            _wrapper.CreateDocument();
            _wrapper.SetProperties();

            var axeLength = axeParameters.GetParameterValue(AxeParametersType.AxeLength);
            var axePartLength = axeParameters.GetParameterValue(AxeParametersType.AxePartLength);
            var axeHeight = axeParameters.GetParameterValue(AxeParametersType.AxeHeight);
            var axePartHeight = axeParameters.GetParameterValue(AxeParametersType.AxePartHeight);
            var axeWidth = axeParameters.GetParameterValue(AxeParametersType.AxeWidth);
            var axeRounding  = axeParameters.GetParameterValue(AxeParametersType.Rounding);
            var thickness  = axeParameters.GetParameterValue(AxeParametersType.Thickness);

            BuildAxeBody(axeLength, axePartLength, axeHeight, axePartHeight, axeWidth, thickness);
            _wrapper.Fillet(axeRounding);
        }
        /// <summary>
        /// Построение скетча с формой штока.
        /// </summary>
        /// <param name="axeLength">длина.</param>
        /// <param name="axePartLength">длина малой части.</param>
        /// <param name="axeHeight"> высота</param>
        /// <param name="axePartHeight"> высота малой части</param>
        /// <param name="axeWidth"> ширина</param>
        /// <param name="thickness"> толщина</param>
        private void BuildAxeBody(double axeLength, double axePartLength,
            double axeHeight, double axePartHeight, double axeWidth, double thickness)
        {
            // Create spinner body.
            var sketch = _wrapper.CreateSketch(3);
            var start = new Point2D(0, 0);
            var start1 = new Point2D(-10, 10);
            var end = new Point2D(0, axeLength);
            var end1 = new Point2D(0, -axeLength);
            var arc1 = new Point2D(-axePartLength - 3, 0);
            var st1 = new Point2D(-axeWidth, -axeLength);
            var st2 = new Point2D(-axeWidth, axeLength);
            var arc2 = new Point2D(axePartLength + 3, 0);
            var st3 = new Point2D(axeWidth, -axeLength);
            var st4 = new Point2D(axeWidth, axeLength);
            var ty = new Point2D(-1, 0);
            short dir = -1;


            sketch.CreateLineSeg(start, end, 3);

            sketch.CreateCircle(arc1, 20, 1);
         

            sketch.CreateLineSeg(start, end1, 3);

            sketch.CreateArcBy3Points(st1, arc1, st2);
            sketch.CreateArcBy3Points(st3, arc2, st4);

            sketch.CreateArcByPoint(end1, axeWidth, st3, st1, dir);
            sketch.CreateArcByPoint(end, axeWidth, st2, st4, dir);


            sketch.EndEdit();
            _wrapper.Extrude(sketch, thickness, true);
        }

    }
}
