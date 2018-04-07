using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TesteDotNet.Core2_0.BDD.Support;

namespace TesteDotNet.Core2_0.BDD
{
    [Binding]
    [Scope(Tag = "CenarioTeste")]
    public class Steps
    {
        private WebDriver _webDriver;
        Screenshots _screenshots;

        string _nomeItem = "";

        public Steps(WebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.Current.Manage().Window.Maximize();

            _screenshots = new Screenshots(webDriver);
        }

        [Given(@"que eu acesse a pagina ""(.*)""")]
        public void DadoQueEuAcesseAPagina(string path)
        {
            var driver = _webDriver.Current;
            switch (path)
            {
                case "inicial":
                    driver.Url = "http://localhost:2223/Home/Index";
                    break;
                default:
                    break;
            }

            _screenshots.GetScreenshot();
        }
        
        [When(@"eu clicar no botão ""(.*)""")]
        public void QuandoEuClicarNoBotao(string textoBotao)
        {
            _webDriver.Wait.Until(el => el.FindElement(By.XPath("//*[contains(text(),'" + textoBotao + "')]"))).Click();

            _screenshots.GetScreenshot();
        }

        [When(@"eu clicar na busca")]
        public void QuandoEuClicarNaBusca()
        {
            _webDriver.Wait.Until(el => el.FindElement(By.Id("botaoBusca"))).Click();

            _screenshots.GetScreenshot();
        }


        [Then(@"eu verei o texto ""(.*)""")]
        public void EntaoEuVereiOTexto(string texto)
        {
            BuscaInformacao("body", texto);
            _screenshots.GetScreenshot();
        }

        [When(@"eu clicar no botão ""(.*)"" do ""(.*)"" item")]
        public void QuandoEuClicarNoBotaoDoItem(string textoBotao, string linha)
        {
            _webDriver.Wait.Until(el => el.FindElement(By.LinkText(textoBotao))).Click();

            _screenshots.GetScreenshot();
        }

        [When(@"no campo ""(.*)"" eu digitar ""(.*)""")]
        public void QuandoNoCampoEuDigitar(string idCampo, string tipoValor)
        {
            string valor = "";
            switch (tipoValor)
            {
                case "novoItem":
                    _nomeItem = "Item " + RandomString(5);
                    valor = _nomeItem;
                    break;
                case "itemAnterior":
                    valor = _nomeItem;
                    break;
                case "textoAleatorio":
                    valor = RandomString(5);
                    break;
                case "novaDescricao":
                case "descricaoAnterior":
                    valor = "Descrição do item " + _nomeItem;
                    break;
                default:
                    break;
            }

            var obj = _webDriver.Wait.Until(el => el.FindElement(By.Id(idCampo)));

            obj.Clear();
            obj.SendKeys(valor);

            _screenshots.GetScreenshot();
        }

        [When(@"eu selecionar no campo ""(.*)"" o valor ""(.*)""")]
        public void QuandoEuSelecionarNoCampoOValor(string idCampo, string textoSelecionar)
        {
            var objeto = By.Id(idCampo);
            _webDriver.Wait.Until(el => el.FindElement(objeto)).Click();

            new SelectElement(_webDriver.Wait.Until(el => el.FindElement(objeto))).SelectByText(textoSelecionar);

            _screenshots.GetScreenshot();
        }

        [Then(@"eu verei o item digitado ""(.*)""")]
        public void EntaoEuVereiOItemDigitado(string p0)
        {
            BuscaInformacao("body", _nomeItem);
            _screenshots.GetScreenshot();
        }

        [Then(@"eu não verei o item digitado ""(.*)""")]
        public void EntaoEuNaoVereiOItemDigitado(string p0)
        {
            NaoBuscaInformacao("body", _nomeItem);
            _screenshots.GetScreenshot();
        }


        [Then(@"não verei o texto ""(.*)""")]
        public void EntaoNaoVereiOTexto(string p0)
        {
            NaoBuscaInformacao("body", _nomeItem);
            _screenshots.GetScreenshot();
        }

        [AfterScenario]
        public void Final()
        {
            if (_webDriver != null)
            {
                _webDriver.Quit();
            }
        }

        private void BuscaInformacao(string seletor, string textoExperado)
        {
            try
            {
                var element = _webDriver.Wait.Until(el => el.FindElement(By.CssSelector(seletor)));
                var conteudo = element.Text.Replace("\n", " ");
                Assert.AreNotEqual(conteudo.IndexOf(textoExperado), -1);
            }
            catch (Exception e)
            {
                throw new Exception("[O elemento <" + seletor + "> não foi encontrado!]", e);
            }
        }

        private void NaoBuscaInformacao(string seletor, string textoExperado)
        {
            try
            {
                var element = _webDriver.Wait.Until(el => el.FindElement(By.CssSelector(seletor)));
                var conteudo = element.Text.Replace("\n", " ");
                Assert.AreEqual(conteudo.IndexOf(textoExperado), -1);
            }
            catch (Exception e)
            {
                throw new Exception("[O elemento <" + seletor + "> não foi encontrado!]", e);
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
