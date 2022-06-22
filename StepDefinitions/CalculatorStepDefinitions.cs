using NUnit.Framework;
using SpecFlowTestProjectForCalculatorTestStackWhite.AdditionalUtils;
using TechTalk.SpecFlow;

namespace SpecFlowTestProjectForCalculatorTestStackWhite.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        
        [Given(@"the calculator is opened")]
        public void OpenApplication()
        {
            UtilsForCalculator.StartSession();
        }
        [When(@"user enteres (.*)")]
        public void EnterNumber(int number)
        {
            for(int i = 0; i < number.ToString().Length; i++)
            {
                UtilsForCalculator.ClickDigit(number.ToString()[i].ToString());
            }   
        }

        [When(@"user clicks on the (.*) button")]
        public void ClicksButton(string buttonName)
        {
            UtilsForCalculator.ClickButton(buttonName);
        }

        [Then(@"the result should be (.*)")]
        public void IsResultCorrect(int result)
        {
            Assert.IsTrue(UtilsForCalculator.GetResult().Equals(result), "Result ia not correct");
        }
    }
}