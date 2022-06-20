using Aquality.Selenium.Browsers;
using NUnit.Framework;
using SpecFlowTestProjectWithQRCode.Pages;
using SpecFlowTestProjectWithQRCode.Utils;

namespace SpecFlowTestProjectWithQRCode.StepDefinitions
{
    [Binding]
    public sealed class Steps
    {
        private readonly Main mainPage = new();
        private readonly ByUrl byUrlPage = new();

        private string sourceOfImage;

        [Given(@"following link was opened: (.*)")]
        public void FollowingLinkWasOpened(string url)
        {
            AqualityServices.Browser.GoTo(url);
            AqualityServices.Browser.WaitForPageToLoad();
        }

        [When("user in the (.*) item, clicks on the text (.*)")]
        public void ClickOnButtonByItemAndText(string item, string link)
        {
            mainPage.ClickButton(item, link);
        }

        [When("user enteres text (.*) in the url-field and clicks (.*) button")]
        public void FillTextBoxAndClickButton(string text, string buttonName)
        {
            byUrlPage.FillTextBoxAndClickButtonByName(text, buttonName);
        }

        [Then("website for generating QR codes with text (.*) has been opened")]
        public void IsSiteOpened(string text)
        {
            switch (text)
            {
                case "√енератор QR кодов":
                    Assert.IsTrue(mainPage.State.IsDisplayed, @"website for generating QR codes with text {text} hasn't been opened");
                    break;
                case "—сылка на сайт в виде QR кода":
                    Assert.IsTrue(byUrlPage.State.IsDisplayed, @"website for generating QR codes with text {text} hasn't been opened");
                    break;
            }
        }

        [Then(@"picture with QR-code appeared in special block")]
        public void ThenPictureWithQR_CodeAppearedInSpecialBlock()
        {
            sourceOfImage = byUrlPage.GetUrlOfImage();
        }

        [Then(@"user compares received url from QR-code with original link (.*)")]
        public void CompareOfReceivedUrlAndOriginalLink(string url)
        {
            Assert.IsTrue(url.Equals(ZxingForQRCode.DecodeQrCode(sourceOfImage)), "Links varies");
        }

    }
}