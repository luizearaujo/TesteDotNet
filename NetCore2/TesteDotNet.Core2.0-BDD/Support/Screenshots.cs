using OpenQA.Selenium;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using TechTalk.SpecFlow;

namespace TesteDotNet.Core2_0.BDD.Support
{
    public class Screenshots
    {
        private WebDriver _webDriver;
        
        string _pastaResultado = @"..\..\..\..\ResultadosTesteBDD\";
        string _dataAtual => DateTime.Now.ToString("yyyyMMddHHmmssffff");

        string _caminhoCenario;

        public Screenshots(WebDriver webDriver)
        {
            _webDriver = webDriver;

            if (!Directory.Exists(_pastaResultado))
                Directory.CreateDirectory(_pastaResultado);

            _caminhoCenario = Path.Combine(_pastaResultado, _dataAtual + "-" + ScenarioContext.Current.ScenarioInfo.Title);

            if (!Directory.Exists(_caminhoCenario))
                Directory.CreateDirectory(_caminhoCenario);
        }

        public void GetScreenshot([CallerMemberName] string caller = null)
        {
            if (_webDriver.Current is ITakesScreenshot takesScreenshot)
            {
                var screenshot = takesScreenshot.GetScreenshot();

                var textoStep = ScenarioStepContext.Current.StepInfo.Text.Replace("\"", "_");

                var tempFileName = Path.Combine(_caminhoCenario, _dataAtual + "-" + textoStep + ".Png");
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Png);
                Console.WriteLine($"SCREENSHOT[{tempFileName}]SCREENSHOT");
            }
        }
    }
}
