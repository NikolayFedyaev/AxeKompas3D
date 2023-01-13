using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxeCompas.Model
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
                { AxeParametersType.AxePartHeght, new AxeParameter(150, 135, 165) },
                { AxeParametersType.AxeWidth, new AxeParameter(150, 135, 165) },
                { AxeParametersType.AxePartFirstWidth, new AxeParameter(25, 22, 28) },
                { AxeParametersType.AxePartSecondWidth, new AxeParameter(22, 19, 25) },
            };
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>

        public void SetDefaultParameterValue(AxeParametersType type, int value)
        {
            _parameters[type].Value = value;
        }

        /// <summary>
        /// Получает значения параметров.
        /// </summary>
        /// <param name="type">Тип параметра</param>
        /// <returns>Значение параметра</returns>
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
            switch (type)
            {
                case AxeParametersType.AxeLength:
                    {
                        _parameters.TryGetValue(AxeParametersType.AxePartLength, out var parameter);
                        if (value - parameter.Value < 100)
                        {
                            throw new ArgumentOutOfRangeException("AxeLength");
                        }
                        break;
                    }
                case AxeParametersType.AxeHeight:
                    {
                        _parameters.TryGetValue(AxeParametersType.AxePartHeght, out var parameter);
                        if (parameter.Value - value < 10)
                        {
                            throw new ArgumentOutOfRangeException("3");
                        }
                        break;
                    }
                case AxeParametersType.AxeWidth:
                    {
                        _parameters.TryGetValue(AxeParametersType.AxePartFirstWidth, out var parameter);
                        if (value - parameter.Value < 10)
                        {
                            throw new ArgumentOutOfRangeException("4");
                        }
                        break;
                    }
                case AxeParametersType.AxePartSecondWidth:
                    {
                        _parameters.TryGetValue(AxeParametersType.AxeWidth, out var parameter);
                        if (value - parameter.Value < 10)
                        {
                            throw new ArgumentOutOfRangeException("5");
                        }
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
        }
    }
}
