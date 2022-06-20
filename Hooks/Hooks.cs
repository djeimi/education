using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace SpecFlowCarTest.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            AqualityServices.Browser.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            AqualityServices.Browser.Quit();
        }
    }
}