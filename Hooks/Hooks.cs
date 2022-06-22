using SpecFlowTestProjectForCalculatorTestStackWhite.AdditionalUtils;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpecFlowCarTest.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        Process myProcess;

        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            myProcess = Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (UtilsForCalculator.session != null)
            {
                UtilsForCalculator.session.Quit();
                UtilsForCalculator.session = null;
            }
            
            myProcess.Kill();
        }
    }
}