using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxeKompas.Model;
using AxeKompas.Wrapper;

namespace Axe3D
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Параметры топора.
        /// </summary>
        private readonly AxeParameters _parameters;

        /// <summary>
        /// Текстовые поля и ошибки в них.
        /// </summary>
        private readonly Dictionary<TextBox, string> _textBoxAndError;

        /// <summary>
        /// Соответствующий каждому полю тип параметра.
        /// </summary>
        private readonly Dictionary<TextBox, AxeParametersType> _textBoxToParameterType;

        public MainForm()
        {
            InitializeComponent();
            _parameters = new AxeParameters();
            _textBoxToParameterType = new Dictionary<TextBox, AxeParametersType>
            {
                { AxeLengthTextBox, AxeParametersType.AxeLength },
                { AxePartLengthTextBox, AxeParametersType.AxePartLength },
                { AxeHeightTextBox, AxeParametersType.AxeHeight },
                { AxePartHeightTextBox, AxeParametersType.AxePartHeight },
                { AxeWidthTextBox, AxeParametersType.AxeWidth },
                { AxePartFirstWidthTextBox, AxeParametersType.Rounding },
                { AxePartSecondWidthTextBox, AxeParametersType.Thickness }
            };
            _textBoxAndError = new Dictionary<TextBox, string>
            {
                { AxeLengthTextBox, "" },
                { AxePartLengthTextBox, "" },
                { AxeHeightTextBox, "" },
                { AxePartHeightTextBox, "" },
                { AxeWidthTextBox, "" },
                { AxePartFirstWidthTextBox, "" },
                { AxePartSecondWidthTextBox, "" }
            };
        }

 

        /// <summary>
        /// Устанавливает значения по умолчанию при загрузке формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetParameter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            var isType = _textBoxToParameterType.TryGetValue(textBox, out var type);
            var textValue = textBox.Text.Replace('.', ',');
            double.TryParse(textValue, out var value);
            value = Math.Round(value, 1);

            if (!isType) return;

            try
            {
                _parameters.SetParameterValue(type, value);
                _textBoxAndError[textBox] = "";
                errorProvider.Clear();
            }
            catch (ArgumentOutOfRangeException error)
            {
                _textBoxAndError[textBox] = error.ParamName;
                errorProvider.SetError(textBox, error.ParamName);
            }
        }

        /// <summary>
        /// Устанавливает значения по умолчанию.
        /// </summary>
        /// <param name="axeLengthValue"></param>
        /// <param name="axePartLengthValue"></param>
        /// <param name="axeHeightValue"></param>
        /// <param name="axePartHeightValue"></param>
        /// <param name="axeWidthValue"></param>
        /// <param name="axePartFirstWidthValue"></param>
        /// <param name="axePartSecondWidthValue"></param>
        private void SetDefaultValues(double axeLengthValue, double axePartLengthValue,
            double axeHeightValue, double axePartHeightValue, double axeWidthValue, 
            double axeroundingValue, double thicknessValue)
        {
            _parameters.SetParameterValue(AxeParametersType.AxeLength, axeLengthValue);
            _parameters.SetParameterValue(AxeParametersType.AxePartLength, axePartLengthValue);
            _parameters.SetParameterValue(AxeParametersType.AxeHeight, axeHeightValue);
            _parameters.SetParameterValue(AxeParametersType.AxePartHeight, axePartHeightValue);
            _parameters.SetParameterValue(AxeParametersType.AxeWidth, axeWidthValue);
            _parameters.SetParameterValue(AxeParametersType.Rounding, axeroundingValue);
            _parameters.SetParameterValue(AxeParametersType.Thickness, thicknessValue);

            AxeLengthTextBox.Text = axeLengthValue.ToString();
            AxePartLengthTextBox.Text = axePartLengthValue.ToString();
            AxeHeightTextBox.Text = axeHeightValue.ToString();
            AxePartHeightTextBox.Text = axePartHeightValue.ToString();
            AxeWidthTextBox.Text = axeWidthValue.ToString();
            AxePartFirstWidthTextBox.Text = axeroundingValue.ToString();
            AxePartSecondWidthTextBox.Text = thicknessValue.ToString();
        }

        /// <summary>
        /// Проверяет заполнены ли текстовые поля.
        /// </summary>
        /// <returns></returns>
        private bool CheckTextBoxes()
        {
            var isError = true;
            foreach (var item in _textBoxAndError.Where(item => item.Value != ""))
            {
                isError = false;
                errorProvider.SetError(item.Key, item.Value);
            }
            return isError;
        }

        /// <summary>
        /// Кнопка построения модели.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BuildButton_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes())
            {
                var builder = new AxeBuilder();
                builder.BuildAxe(_parameters);
            }
            else
            {
                MessageBox.Show(@"Fill all required parameters correctly",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        /// <summary>
        /// Устанавливает минимальные размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimumButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(135, 48, 170, 135, 135, 5, 50);
        }

        /// <summary>
        /// Устанавливает средние размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void AverageButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(150, 58, 195, 150, 150, 10, 60);
        }

        /// <summary>
        /// Устанавливает максимальные размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void MaximumButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(165, 68, 215, 165, 165, 15, 70);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
