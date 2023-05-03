using System;
using System.Collections.Generic;

namespace AxeKompas.Model
{
    public class AxeParameters
    {
        // <summary>
        /// Типы параметров и их значения.
        /// </summary>
        private readonly Dictionary<AxeParametersType, AxeParameter> _parameters;
        /// <summary>
        /// Определение параметров топора.
        /// </summary>
        public AxeParameters()
        {
            _parameters = new Dictionary<AxeParametersType, AxeParameter>()
            {
                { AxeParametersType.AxeLength, new AxeParameter(150, 135, 165) },
                { AxeParametersType.AxePartLength, new AxeParameter(58, 48, 68) },
                { AxeParametersType.AxeHeight, new AxeParameter(195, 170, 215) },
                { AxeParametersType.AxePartHeight, new AxeParameter(150, 135, 165) },
                { AxeParametersType.AxeWidth, new AxeParameter(150, 135, 165) },
                { AxeParametersType.Rounding, new AxeParameter(10, 5, 15) },
                { AxeParametersType.Thickness, new AxeParameter(60, 50, 70) },
            };
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void SetParameterValue(AxeParametersType type, double value)
        {
            var parameter = _parameters[type];
            CheckDependencies(type, value);
            parameter.Value = value;
        }

        /// <summary>
        /// Gets parameter value.
        /// </summary>
        /// <param name="type">Spinner parameter type.</param>
        /// <returns>Parameter value.</returns>
        /// <exception cref="Exception">If parameter value does not exist.</exception>
        public double GetParameterValue(AxeParametersType type)
        {
            return _parameters[type].Value;
        }

        /// <summary>
        /// Проверка зависимых параметров.
        /// </summary>
        /// <param name="type">Тип параметра</param>
        /// <param name="value">Значение параметра</param>
        /// <exception cref="Exception">Если значение параметра некорректное.</exception>
        private void CheckDependencies(AxeParametersType type, double value)
        {
            if (type == AxeParametersType.AxePartHeight)
            {
                _parameters.TryGetValue(AxeParametersType.AxeHeight, out var parameter);
                if (value > 0.83 * parameter.Value || value < 0.66 * parameter.Value)
                {
                    throw new ArgumentOutOfRangeException("Высота части не может быть" +
                        "больше 1/12 или меньше 1/15 высоты топора");
                }
            }
            if (type == AxeParametersType.AxePartLength)
            {
                _parameters.TryGetValue(AxeParametersType.AxeLength, out var parameter);
                if (value < 100 - parameter.Value)
                {
                    throw new ArgumentOutOfRangeException("Длина части не может быть" +
                        "больше длиннее или короче длины топора топора");
                }
            }
            
        }
    }
}
