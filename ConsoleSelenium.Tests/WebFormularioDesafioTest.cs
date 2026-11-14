using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

[TestClass]
public class WebFormularioDesafioTest
{
    private IWebDriver _driver;
    private const string Url = "https://www.selenium.dev/selenium/web/web-form.html";

    [TestInitialize]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        // options.AddArgument("--headless"); // Descomente se quiser rodar sem abrir a janela do navegador
        _driver = new ChromeDriver(options);
    }

    [TestCleanup]
    public void TearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }

    [TestMethod]
    public void Exercicio1_CadastroCompleto()
    {
        _driver.Navigate().GoToUrl(Url);

        _driver.FindElement(By.Name("my-text")).SendKeys("Seu Nome Completo");
        _driver.FindElement(By.Name("my-password")).SendKeys("SenhaSegura123");
        _driver.FindElement(By.Name("my-textarea")).SendKeys("Experiencia com testes automatizados usando C# e Selenium.");

        var readonlyInput = _driver.FindElement(By.Name("my-readonly"));
        Assert.AreEqual("Readonly input", readonlyInput.GetAttribute("value"));

        _driver.FindElement(By.CssSelector("button[type='submit']")).Click();

        var message = _driver.FindElement(By.Id("message")).Text;
        Assert.AreEqual("Received!", message);
    }

    [TestMethod]
    public void Exercicio2_SeletoresDatalist()
    {
        _driver.Navigate().GoToUrl(Url);

        var selectElement = new SelectElement(_driver.FindElement(By.Name("my-select")));
        selectElement.SelectByValue("2");
        Assert.AreEqual("2", selectElement.SelectedOption.GetAttribute("value"));

        var datalistInput = _driver.FindElement(By.Name("my-datalist"));
        datalistInput.SendKeys("Seattle");

        _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        Assert.IsNotNull(_driver.FindElement(By.Id("message")));
    }

    [TestMethod]
    public void Exercicio3_EstadosCheckboxesRadios()
    {
        _driver.Navigate().GoToUrl(Url);

        var check1 = _driver.FindElement(By.Id("my-check-1"));
        Assert.IsTrue(check1.Selected);

        var check2 = _driver.FindElement(By.Id("my-check-2"));
        if (!check2.Selected) check2.Click();

        var radio2 = _driver.FindElement(By.Id("my-radio-2"));
        if (!radio2.Selected) radio2.Click();

        var colorPicker = _driver.FindElement(By.Name("my-colors"));
        colorPicker.SendKeys("#00ff00");

        _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        Assert.IsNotNull(_driver.FindElement(By.Id("message")));
    }
}