using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AxeKompas.Model;


namespace AxeKompas.Wrapper
{
    /// <summary>
    /// Класс для запуска библиотеки в Компас-3D.
    /// </summary>
    /// 
    public class KompasWrapper
    {
        /// <summary>
        /// Объект Компас API.
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Деталь.
        /// </summary>
        private ksPart _part;

        // <summary>
        /// Документ-модель.
        /// </summary>
        private ksDocument3D _document;

        /// <summary>
        /// Запуск Компас-3D.
        /// </summary>
        public void StartKompas()
        {
            try
            {
                if (_kompas != null)
                {
                    _kompas.Visible = true;
                    _kompas.ActivateControllerAPI();
                }
                if (_kompas != null) return;
                {
                    var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                    _kompas = (KompasObject)Activator.CreateInstance(kompasType);
                    StartKompas();
                    if (_kompas == null)
                    {
                        throw new Exception("Не удается открыть Компас-3D.");
                    }
                }

            }
            catch (COMException)
            {
                _kompas = null;
                StartKompas();
            }
        }

        /// <summary>
        /// Создание документа в Компас-3D.
        /// </summary>
        public void CreateDocument()
        {
            try
            {
                _document = (ksDocument3D)_kompas.Document3D();
                _document.Create();
                _document = (ksDocument3D)_kompas.ActiveDocument3D();
            }
            catch
            {
                throw new ArgumentException("Не удается построить деталь");
            }
        }
        
        /// <summary>
        /// Установка свойств детали.
        /// </summary>
        public void SetProperties()
        {
            _part = _document.GetPart((short)Part_Type.pTop_Part);
            _part.name = "Топор";
            _part.SetAdvancedColor(4737096, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8);
            _part.Update();
        }

        /// <summary>
        /// Создать эскиз.
        /// </summary>
        /// <param name="type">Плоскость эскиза.</param>
        /// <param name="offset">Отступ эскиза от начала координат.</param>
        /// <returns>Эскиз Компас 3D.</returns>
        public AxeSketch CreateSketch(int type, double offset = 0)
        {
            return new AxeSketch(_part, type, offset);
        }

        /// <summary>
        /// Sketch extrusion.
        /// </summary>
        /// <param name="kompasSketch">Kompas sketch.</param>
        /// <param name="depth">Глубина экструзии.</param>
        /// <param name="type">Экструзия direction.</param>
        public void Extrude(AxeSketch kompasSketch, double depth, bool type)
        {
            ksEntity extrudeEntity = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            ksBaseExtrusionDefinition extrudeDefinition =
                (ksBaseExtrusionDefinition)extrudeEntity.GetDefinition();
            if (type == false)
            {
                extrudeDefinition.directionType = (short)Direction_Type.dtReverse;
            }
            else
            {
                extrudeDefinition.directionType = (short)Direction_Type.dtNormal;
            }
            extrudeDefinition.SetSideParam(type, (short)End_Type.etBlind, depth);
            extrudeDefinition.SetSketch(kompasSketch.Sketch);
            extrudeEntity.Create();
        }

        /// <summary>
        /// Rounds edges.
        /// </summary>
        /// <param name="radius">Rounded angle.</param>
        public void Fillet(double radius)
        {
            var roundedEdges = GetCylinderFaces();
            if (roundedEdges.Count.Equals(0))
            {
                throw new Exception("Edge collection is empty.");
            }

            var filletEntity = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_fillet);
            ksFilletDefinition filletDefinition = (ksFilletDefinition)filletEntity.GetDefinition();
            ksEntityCollection items = (ksEntityCollection)filletDefinition.array();

            filletDefinition.radius = radius;
            roundedEdges.ForEach(edge => items.Add(edge));
            filletEntity.Create();
        }


        /// <summary>
        /// Returns all cylindrical faces of a part.
        /// </summary>
        /// <returns>List of Cylindrical Faces.</returns>
        private List<ksFaceDefinition> GetCylinderFaces()
        {
            var body = (ksBody)_part.GetMainBody();
            var faces = (ksFaceCollection)body.FaceCollection();

            var facesCount = faces.GetCount();
            if (facesCount == 0)
            {
                return new List<ksFaceDefinition>();
            }

            var cylinderFaces = new List<ksFaceDefinition>();
            var i = 0;
            while (faces.Next() != null)
            {
                var currentFace = (ksFaceDefinition)faces.GetByIndex(i);
                if (currentFace.IsValid())
                {
                    cylinderFaces.Add(currentFace);
                }

                ++i;
            }

            return cylinderFaces;

        }

    }
}