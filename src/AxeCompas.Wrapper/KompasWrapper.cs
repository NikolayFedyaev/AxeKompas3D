using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxeCompas.Wrapper
{
    /// <summary>
    /// Класс для запуска библиотеки в Компас-3D.
    /// </summary>
    class KompasWrapper
    {
        /// <summary>
        /// Объект Компас API.
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Деталь.
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Документ-модель.
        /// </summary>
        private ksDocument3D _document;

        /// <summary>
        /// Коллекция эскизов на смещенных плоскостях.
        /// </summary>
        private ksEntityCollection _offsetSketchCollection;

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
                var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompas = (KompasObject)Activator.CreateInstance(kompasType);
                StartKompas();
                if (_kompas == null)
                {
                    throw new Exception("Не удается открыть Компас-3D.");
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
                _document = _kompas.Document3D();
                _document.Create();
                _document = _kompas.ActiveDocument3D();
            }
            catch
            {
                throw new ArgumentException("Не удается построить деталь");
            }
        }
        /// <summary>
        /// Установка свойств детали.
        /// </summary>
        public void SetDetailProperties()
        {
            _part = _document.GetPart((short)Part_Type.pTop_Part);
            _part.name = "Топор";
            _part.SetAdvancedColor(4737096, 0.5, 0.6,
                0.8, 0.8, 1, 0.5);
            _part.Update();
            _offsetSketchCollection = _part.EntityCollection((short)Obj3dType.o3d_sketch);
        }

    }
}
