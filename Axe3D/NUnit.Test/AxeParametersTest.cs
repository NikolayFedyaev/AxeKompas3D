using NUnit.Framework;
using AxeKompas.Model;

namespace NUnit.Test
{
    [TestFixture]
    public class AxeParametersTest
    {
        /// <summary>
        /// Spinner parameters.
        /// </summary>
        private readonly AxeParameters _parameters = new AxeParameters();

        [Test(Description = "Positive test set dependent parameter values.")]
        public void TestDependentParameterSet_CorrectValues()
        {
            var expectedDiameter = _parameters.GetParameterValue(AxeParametersType.AxeHeight);
            var expectedLength = _parameters.GetParameterValue(AxeParametersType.AxeLength);
            var expectedInnerRings = _parameters.GetParameterValue(AxeParametersType.AxeWidth);

            _parameters.SetParameterValue(AxeParametersType.AxeHeight, expectedDiameter);
            _parameters.SetParameterValue(AxeParametersType.AxeLength, expectedLength);
            _parameters.SetParameterValue(AxeParametersType.AxeWidth, expectedInnerRings);

            Assert.Multiple(() =>
            {
                Assert.That(_parameters.GetParameterValue(AxeParametersType.AxeHeight),
                    Is.EqualTo(expectedDiameter));
                Assert.That(_parameters.GetParameterValue(AxeParametersType.AxeLength),
                    Is.EqualTo(expectedLength));
                Assert.That(_parameters.GetParameterValue(AxeParametersType.AxeWidth),
                    Is.EqualTo(expectedInnerRings));
            });
        }

        [Test(Description = "Negative test set dependent parameter values.")]
        public void TestDependentParameterSet_IncorrectValues()
        {
            var actualDiameterException = Assert.Throws<System.ArgumentOutOfRangeException>(() =>
                _parameters.SetParameterValue(AxeParametersType.AxeHeight, 20));
            var actualLengthException = Assert.Throws<System.ArgumentOutOfRangeException>(() =>
                _parameters.SetParameterValue(AxeParametersType.AxeLength, 20));
            var actualInnerRingsException = Assert.Throws<System.ArgumentOutOfRangeException>(() =>
                _parameters.SetParameterValue(AxeParametersType.AxeWidth, 20));


            Assert.Multiple(() =>
            {
                Assert.That(actualDiameterException?.GetType(), Is.EqualTo(typeof(System.ArgumentOutOfRangeException)));
                Assert.That(actualLengthException?.GetType(), Is.EqualTo(typeof(System.ArgumentOutOfRangeException)));
                Assert.That(actualInnerRingsException?.GetType(), Is.EqualTo(typeof(System.ArgumentOutOfRangeException)));
            });
        }

    }
}
