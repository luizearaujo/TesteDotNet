using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.IO;

namespace TesteDotNet.Core2_0.BDD.Support
{
    public class WebDriver
    {
        private IWebDriver _currentWebDriver;

        protected string BrowserConfig => "Chrome";
        protected string FirefoxPath => "/Mozilla Firefox/firefox.exe";

        public IWebDriver Current
        {
            get
            {
                if (_currentWebDriver != null)
                    return _currentWebDriver;

                switch (BrowserConfig)
                {
                    case "Chrome":
                        _currentWebDriver = new ChromeDriver(Directory.GetCurrentDirectory());
                        break;
                    case "IE":
                        _currentWebDriver = new InternetExplorerDriver();
                        break;
                    case "Firefox":
                        FirefoxOptions ffExecPath = new FirefoxOptions
                        {
                            BrowserExecutableLocation = FirefoxPath
                        };
                        _currentWebDriver = new FirefoxDriver(ffExecPath);
                        break;
                }

                return _currentWebDriver;
            }
        }

        private WebDriverWait _wait;
        public WebDriverWait Wait
        {
            get
            {
                if (_wait == null)
                {
                    this._wait = new WebDriverWait(Current, TimeSpan.FromSeconds(10));
                }
                return _wait;
            }
        }



        public void Quit()
        {
            _currentWebDriver?.Quit();
        }
    }
}