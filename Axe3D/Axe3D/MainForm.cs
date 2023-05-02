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

        /// <summary>
        /// Константа для корректного цвета. 
        /// </summary>
        private readonly Color _correctColor = Color.White;

        /// <summary>
        /// Константа для цвета ошибки.
        /// </summary>
        private readonly Color _errorColor = Color.LightCoral;

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
                { AxePartFirstWidthTextBox, AxeParametersType.AxePartFirstWidth },
                { AxePartSecondWidthTextBox, AxeParametersType.AxePartSecondWidth }
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetDefaultValues(150, 58, 195, 150, 150, 25, 22);
        }

        private void SetParameter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            var isType = _textBoxToParameterType.TryGetValue(textBox, out var type);
            double.TryParse(textBox.Text, out var value);
            if (!isType) return;
            try
            {
                _parameters.SetParameterValue(type, value);
                _textBoxAndError[textBox] = "";
                textBox.BackColor = _correctColor;
                errorProvider.Clear();
            }
            catch (Exception textBoxError)
            {
                _textBoxAndError[textBox] = textBoxError.Message;
                textBox.BackColor = _errorColor;
                errorProvider.SetError(textBox, textBoxError.Message);
            }
        }

        /// <summary>
        /// Устанавливает значения по умолчанию.
        /// </summary>
        private void SetDefaultValues(int AxeLengthValue, int AxePartLengthValue,
            int AxeHeightValue, int AxePartHeightValue, int AxeWidthValue, int AxePartFirstWidthValue, int AxePartSecondWidthValue)
        {
            _parameters.SetParameterValue(AxeParametersType.AxeLength, AxeLengthValue);
            _parameters.SetParameterValue(AxeParametersType.AxePartLength, AxePartLengthValue);
            _parameters.SetDefaultParameterValue(AxeParametersType.AxeHeight, AxeHeightValue);
            _parameters.SetParameterValue(AxeParametersType.AxePartHeight, AxePartHeightValue);
            _parameters.SetDefaultParameterValue(AxeParametersType.AxeWidth, AxeWidthValue);
            _parameters.SetParameterValue(AxeParametersType.AxePartFirstWidth, AxePartFirstWidthValue);
            _parameters.SetParameterValue(AxeParametersType.AxePartSecondWidth, AxePartSecondWidthValue);

            AxeLengthTextBox.Text = AxeLengthValue.ToString();
            AxePartLengthTextBox.Text = AxePartLengthValue.ToString();
            AxeHeightTextBox.Text = AxeHeightValue.ToString();
            AxePartHeightTextBox.Text = AxePartHeightValue.ToString();
            AxeWidthTextBox.Text = AxeWidthValue.ToString();
            AxePartFirstWidthTextBox.Text = AxePartFirstWidthValue.ToString();
            AxePartSecondWidthTextBox.Text = AxePartSecondWidthValue.ToString();
        }

        /// <summary>
        /// Устанавливает минимальные размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimumButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(135, 48, 215, 135, 165, 22, 19);
        }

        /// <summary>
        /// Устанавливает средние размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void AverageButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(150, 58, 170, 135, 135, 22, 19);
        }

        /// <summary>
        /// Устанавливает максимальные размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void MaximumButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(165, 68, 215, 165, 165, 28, 25);
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
                builder.BuildDetail(_parameters);
            }
            else
            {
                MessageBox.Show("Fill All Required Parameters Correctly");
            }

        }
    }
}
