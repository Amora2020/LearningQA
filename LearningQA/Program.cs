using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;


namespace LearningQA
{
    class Program
    {

        static void Main(String[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();




            IWebElement pesquisa = driver.FindElement(By.Name("q"));
            pesquisa.SendKeys("Sensedia");

            pesquisa.SendKeys(Keys.Enter);

            IWebElement nome = driver.FindElement(By.XPath("//h3[contains(text(), 'Sensedia')]"));
            Assert.Equal("Sensedia API Platform - Plataforma de APIs | Gerenc" +
                "iamento ...", nome.Text);

            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(@"C:\\Users\\aline.oliveira\\source\\repos\\LearningQA\\LearningQA\\image.png", ScreenshotImageFormat.Png);
            driver.Close();
        }

    }
}