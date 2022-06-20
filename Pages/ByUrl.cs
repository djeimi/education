

using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace SpecFlowTestProjectWithQRCode.Pages
{
    public class ByUrl : Form
    {
        private ITextBox TextBoxForUrl => ElementFactory.GetTextBox(By.XPath("//input[@type='text']"), "TextBox on the ByUrl page");
        private IButton ButtonByName(string text) => ElementFactory.GetButton(By.XPath($"//div[@class = 'formBottom']//input[@type='submit']"), $"Button with text {text}");
        private ITextBox TextBoxWithSourceOfImage => ElementFactory.GetTextBox(By.XPath(".//p[contains(text(),'ссылка на изображение:')]/following-sibling::div//input"), "TextBox With Source Of QR-code");

        public ByUrl() : base(By.XPath("//h1[contains(text(),'Ссылка на сайт в виде QR кода')]"), "Text of page, where generation by url")
        {

        }

        public void FillTextBoxAndClickButtonByName(string text, string nameButton)
        {
            TextBoxForUrl.ClearAndType(text);
            ButtonByName(nameButton).ClickAndWait();
        }

        public string GetUrlOfImage()
        {
            return TextBoxWithSourceOfImage.GetAttribute("value");
        }
    }
}
