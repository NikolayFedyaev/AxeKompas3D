using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxeCompas.Wrapper
{
    /// <summary>
    /// Класс, отвечающий за построение топора.
    /// </summary>
    public class AxeBuilder
    {
        /// <summary>
        /// Связь с Компас-3D.
        /// </summary>
        private readonly KompasWrapper _wrapper = new KompasWrapper();

        /// <summary>
        /// Построение детали по заданным параметрам.
        /// </summary>
        /// <param name="parameters">Объект заданных параметров топора.</param>
        public void BuildDetail(AxeParameters parameters)
        {
            _wrapper.StartKompas();
            _wrapper.CreateDocument();
            _wrapper.SetDetailProperties();
            var axelength =
                parameters.GetParameterValue(AxeParametersType.AxeLength);
            var axepartlength =
                parameters.GetParameterValue(AxeParametersType.AxePartLength);
            var axeheight =
                parameters.GetParameterValue(AxeParametersType.AxeHeight);
            var axepartheght =
                parameters.GetParameterValue(AxeParametersType.AxePartHeght);
            var axewidth =
                parameters.GetParameterValue(AxeParametersType.AxeWidth);
            var axepartfirstwidth =
                parameters.GetParameterValue(AxeParametersType.AxePartFirstWidth);
            var axepartsecondwidth =
                parameters.GetParameterValue(AxeParametersType.AxePartSecondWidth);
            BuildAxe(axelength, axepartlength, axeheight, axepartheght, axewidth, 
                axepartfirstwidth, axepartsecondwidth);
        }
    }
}
