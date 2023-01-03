﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumXUnit.Driver
{
    public class BrowserDriver : IBrowserDriver
    {
        public BrowserDriver()
        {
        }

        public IWebDriver GetChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }

        public IWebDriver GetFirefoxDriver()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }

    }
}

public enum BrowserType {
    Chrome,
    Firefox,
    Safari,
    Edge
}

