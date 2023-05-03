using System;

namespace AxeKompas.Model
{
    public class AxeParameter
    {
        /// <summary>
        /// Значение параметра.
        /// </summary>
        private double _value;

        /// <summary>
        /// Минимальное допустимое значение.
        /// </summary>
        private readonly double _minValue;
        /// <summary>
        /// Максимальное допустимое значение.
        /// </summary>
        private readonly double _maxValue;

        /// <summary>
        /// AxeParameter constructor.
        /// </summary>
        /// <param name="value">Parameter value.</param>
        /// <param name="minValue">Minimum allowed parameter value.</param>
        /// <param name="maxValue">Maximum allowed parameter value.</param>
        public AxeParameter(double value, double minValue, double maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            Value = value;
        }

        /// <summary>
        /// Устанавливает и возвращает значение установленного парамера.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (IsRangeOut(value))
                {
                    throw new ArgumentOutOfRangeException($"Value Can Be Only Between {_minValue} And {_maxValue}");
                }
                _value = value;
            }
        }
        /// <summary>
        /// Проверяет допустимость значения параметра.
        /// </summary>
        /// <param name="value">Значение параметра</param>
        /// <returns></returns>
        private bool IsRangeOut(double value)
        {
            return value < _minValue || value > _maxValue;
        }
    }
}
