using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace SpecFlowTestProjectWithQRCode.Pages
{
    public class Main : Form
    {
        private IButton ButtonFromItem(string item, string link) => ElementFactory.GetButton(By.XPath($"//div[contains(text(),'{item}')]//a[contains(text(),'{link}')]"), $"Button from {item} item, with text {link}");

        public Main() : base(By.XPath("//h1[contains(text(),'Генератор QR кодов')]"), "Text of main page")
        {

        }

        public void ClickButton(string item, string link)
        {
            ButtonFromItem(item, link).ClickAndWait();
        }
    }
}
