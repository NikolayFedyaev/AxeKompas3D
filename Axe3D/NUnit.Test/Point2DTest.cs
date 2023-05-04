using NUnit.Framework;
using AxeKompas.Model;

namespace NUnit.Test
{
    [TestFixture]
    public class Point2DTest
    {
        [Test(Description = "Positive test Get X.")]
        public void TestXGet_CorrectValue()
        {
            const double expected = 10;

            var point2D = new Point2D(expected, 20);
            var actual = point2D.X;

            //Assert.That() выдает исключение +выдает подробное сообщение о том, что было не так.
            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test(Description = "Positive test Get Y.")]
        public void TestYGet_CorrectValue()
        {
            const double expected = 10;

            var point2D = new Point2D(20, expected);
            var actual = point2D.Y;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}