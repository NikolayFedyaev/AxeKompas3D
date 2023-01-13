using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxeCompas.Model;
using AxeCompas.Wrapper;

namespace AxeCompas.View
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
                { AxeLength, AxeParametersType.AxeLength },
                { AxePartLength, AxeParametersType.AxePartLength },
                { AxeHeight, AxeParametersType.AxeHeight },
                { AxePartHeght, AxeParametersType.AxePartHeght },
                { AxeWidth, AxeParametersType.AxeWidth },
                { AxePartFirstWidth, AxeParametersType.AxePartFirstWidth },
                { AxePartSecondWidth, AxeParametersType.AxePartSecondWidth }
            };
            _textBoxAndError = new Dictionary<TextBox, string>
            {
                { AxeLength, "" },
                { AxePartLength, "" },
                { AxeHeight, "" },
                { AxePartHeght, "" },
                { AxeWidth, "" },
                { AxePartFirstWidth, "" },
                { AxePartSecondWidth, "" }
            };
        }
        /// <summary>
        /// Устанавливает значения по умолчанию при загрузке формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetDefaultValues(150, 58, 195, 150, 38, 25, 22);
        }

        /// <summary>
        /// Устанавливает значения параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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
        private void SetDefaultValues(double AxeLengthValue, double AxePartLengthValue,
            double AxeHeightValue, double AxePartHeghtValue, double AxeWidthValue, double AxePartFirstWidthValue, double AxePartSecondWidthValue)
        {
            _parameters.SetParameterValue(AxeParametersType.AxeLength, AxeLengthValue);
            _parameters.SetParameterValue(AxeParametersType.AxePartLength, AxePartLengthValue);
            _parameters.SetDefaultParameterValue(AxeParametersType.AxeHeight, AxeHeightValue);
            _parameters.SetParameterValue(AxeParametersType.AxePartHeght, AxePartHeghtValue);
            _parameters.SetDefaultParameterValue(AxeParametersType.AxeWidth, AxeWidthValue);
            _parameters.SetParameterValue(AxeParametersType.AxePartFirstWidth, AxePartFirstWidthValue);
            _parameters.SetParameterValue(AxeParametersType.AxePartSecondWidth, AxePartSecondWidthValue);

            AxeLength.Text = AxeLengthValue.ToString();
            AxePartLength.Text = AxePartLengthValue.ToString();
            AxeHeight.Text = AxeHeightValue.ToString();
            AxePartHeght.Text = AxePartHeghtValue.ToString();
            AxeWidth.Text = AxeWidthValue.ToString();
            AxePartFirstWidth.Text = AxePartFirstWidthValue.ToString();
            AxePartSecondWidth.Text = AxePartSecondWidthValue.ToString();
        }

        /// <summary>
        /// Устанавливает минимальные размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void MinimumButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(135, 48, 170, 135, 135, 22, 19);
        }

        /// <summary>
        /// Устанавливает средние размеры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AverageButton_Click(object sender, EventArgs e)
        {
            SetDefaultValues(150, 58, 195, 150, 150, 25, 22);
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AxeLengthTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AxeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
