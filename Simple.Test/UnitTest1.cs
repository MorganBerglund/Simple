using NUnit.Framework;
using Simple.API.Controllers;
namespace Simple.Test
{
    public class Tests
    {
        WeatherForecastController controller = new WeatherForecastController();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetWeatherForecastequlatodaysDate()
        {
            var result = controller.Get();

            Assert.AreEqual(result.Date, System.DateTime.Now.Date);
        }
    }
}