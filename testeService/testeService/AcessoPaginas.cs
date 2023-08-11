using Microsoft.Extensions.Options;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace testeService.testeService
{
    public class AcessoPaginas
    {
        public IWebDriver Driver { get; set; }

        public void Start()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("no-sandbox");
            Driver = new ChromeDriver(chromeOptions);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
            Driver.Manage().Window.Minimize();
        }

        public string BuscaNoticiaUol()
        {
            Driver.Navigate().GoToUrl("https://www.uol.com.br/");
            var noticia = Driver.FindElement(By.ClassName("headlineMain__title")).Text;
            return noticia;     
        }

        public string BuscaNoticiaTerra()
        {
            Driver.Navigate().GoToUrl("https://www.terra.com.br/");
            var noticia = Driver.FindElement(By.ClassName("card-news__text--title")).Text;
            return noticia;
        }
    }
}
