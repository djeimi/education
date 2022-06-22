using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace SpecFlowTestProjectForCalculatorTestStackWhite.AdditionalUtils
{
    public static class UtilsForCalculator
    {
        public static WindowsDriver<WindowsElement> session;
        private const string CalculatorAppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        public static void StartSession()
        {
            if (session == null)
            {
                AppiumOptions options = new AppiumOptions();
                options.AddAdditionalCapability("deviceName", "WindowsPC");
                options.AddAdditionalCapability("platformName", "Windows");
                options.AddAdditionalCapability("app", CalculatorAppId);

                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options);
                Assert.IsNotNull(session);

                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            }

        }

        public static void ClickDigit(string digit)
        {
            if (digit.Equals(','))
            {
                session.FindElementByName("Десятичный разделитель").Click();
                return;
            }

            switch (Convert.ToInt32(digit))
            {
                case 0:
                    session.FindElementByName("Ноль").Click();
                    break;
                case 1:
                    session.FindElementByName("Один").Click();
                    break;
                case 2:
                    session.FindElementByName("Два").Click();
                    break;
                case 3:
                    session.FindElementByName("Три").Click();
                    break;
                case 4:
                    session.FindElementByName("Четыре").Click();
                    break;
                case 5:
                    session.FindElementByName("Пять").Click();
                    break;
                case 6:
                    session.FindElementByName("Шесть").Click();
                    break;
                case 7:
                    session.FindElementByName("Семь").Click();
                    break;
                case 8:
                    session.FindElementByName("Восемь").Click();
                    break;
                case 9:
                    session.FindElementByName("Девять").Click();
                    break;
            }
        }

        public static void ClickButton(string buttonName)
        {
            switch (buttonName)
            {
                case "=":
                    session.FindElementByName("Равно").Click();
                    break;
                case "+":
                    session.FindElementByName("Плюс").Click();
                    break;
                case "_":
                    session.FindElementByName("Минус").Click();
                    break;
                case "/":
                    session.FindElementByName("Разделить на").Click();
                    break;
                case "*":
                    session.FindElementByName("Умножить на").Click();
                    break;
                case "M+":
                    session.FindElementByName("Добавление памяти").Click();
                    break;
                case "MR":
                    session.FindElementByName("Вызов из памяти").Click();
                    break;
                case "M-":
                    session.FindElementByName("Вычитание памяти").Click();
                    break;
                case "MS":
                    session.FindElementByName("Сохранение в памяти").Click();
                    break;
                case "%":
                    session.FindElementByName("Процент").Click();
                    break;
                case "CE":
                    session.FindElementByName("Очистить запись").Click();
                    break;
                case "C":
                    session.FindElementByName("Очистить").Click();
                    break;
                case "backspace":
                    session.FindElementByName("Удаление предыдущего").Click();
                    break;
                case "1/":
                    session.FindElementByName("Обратная величина").Click();
                    break;
                case "**":
                    session.FindElementByName("Квадрат").Click();
                    break;
                case "sqrt":
                    session.FindElementByName("Квадратный корень").Click();
                    break;
                case "+-":
                    session.FindElementByName("Положительное отрицательное").Click();
                    break;
            }
        }

        public static int GetResult()
        {
            return Convert.ToInt32(session.FindElementByAccessibilityId("CalculatorResults").Text.Replace("Отображать как", string.Empty).Replace("\u00A0", String.Empty));
        }
    }
}
