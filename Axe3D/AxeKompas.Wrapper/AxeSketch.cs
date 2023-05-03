using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxeKompas.Model;
using KompasAPI7;

namespace AxeKompas.Wrapper
{
   public class AxeSketch
    {
        /// <summary>
        /// Документ 2D.
        /// </summary>
        private ksDocument2D _document2D;

        /// <summary>
        /// Интерфейс параметров эскиза.
        /// </summary>
        private ksSketchDefinition _sketchDefinition;

        /// <summary>
        /// Вернуть эскиз.
        /// </summary>
        public ksEntity Sketch { get; set; }

        /// <summary>
        /// Конструктор эскиза.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="type">1 - YZ; 2 - XZ; 3 - XY.</param>

        public AxeSketch(ksPart part, int type, double offset = 0)
        {
            ksEntity plane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition planeDefinition = (ksPlaneOffsetDefinition)plane.GetDefinition();
            if (type == 1)
            {
                planeDefinition.SetPlane(part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ));
            }
            else if (type == 2)
            {
                planeDefinition.SetPlane(part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ));
            }
            else
            {
                planeDefinition.SetPlane(part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            }

            planeDefinition.direction = true;
            planeDefinition.offset = offset;
            plane.Create();

            Sketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)Sketch.GetDefinition();
            _sketchDefinition.SetPlane(plane);
            Sketch.Create();
            _document2D = (ksDocument2D)_sketchDefinition.BeginEdit();
        }

        /// <summary>
        /// Конец редактирования редактирование.
        /// </summary>
        public void EndEdit()
        {
            _sketchDefinition.EndEdit();
        }

        /// <summary>
        /// Creates a circle on a sketch.
        /// </summary>
        /// <param name="center">Circle center.</param>
        /// <param name="radius">Circle diameter.</param>
        /// <param name="style">Style line.</param>
        public void CreateCircle(Point2D center, double radius, int style)
        {
            _document2D.ksCircle(center.X, center.Y, radius, style);
        }

        /// <summary>
        /// Creates an arc by three points on the sketch
        /// </summary>
        /// <param name="start">Start coordinates.</param>
        /// <param name="st1">Avrage coordinates.</param>
        /// <param name="st2">End coordinates</param>
        public void CreateArcBy3Points(Point2D start, Point2D st1, Point2D st2)
        {
            _document2D.ksArcBy3Points(start.X, start.Y, st1.X, st1.Y, st2.X, st2.Y, 1);
        }

        /// <summary>
        /// Creates an arc at the center and endpoints on sketch
        /// </summary>
        /// <param name="start">Center coordinates.</param>
        /// <param name="radius">Center coordinates.</param>
        /// <param name="st1">Coordinates of the first endpoint</param>
        /// <param name="st2">Coordinates of the second end point</param>
        /// <param name="direction">Direction an arc</param>
        public void CreateArcByPoint(Point2D start, double radius, Point2D st1, Point2D st2, short direction)
        {
            _document2D.ksArcByPoint(start.X, start.Y, radius, st1.X, st1.Y, st2.X, st2.Y, direction, 1);
        }

        /// <summary>
        /// Создание линии на эскизе.
        /// </summary>
        /// <param name="start">Start coordinates.</param>
        /// <param name="end">End coordinates.</param>
        /// <param name="style">Line style.</param>
        public void CreateLineSeg(Point2D start, Point2D end, int style)
        {
            _document2D.ksLineSeg(start.X, start.Y, end.X, end.Y, style);
        }
    }


}
