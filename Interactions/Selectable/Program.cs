﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;
namespace Selectable
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            Actions actionProvider = new Actions(Driver);

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/sortable");

            Thread.Sleep(3000);

            //TestList(Driver, actionProvider);

            TestGrid(Driver, actionProvider);

            _ = 0;

            Driver.Close();
            Driver.Quit();
        }

        static void TestList(IWebDriver driver, Actions action)
        {
            var ListItems = driver.FindElements(By.XPath("//div[@id='demo-tabpane-list']//li[contains(@class,'list-group-item')]"));

            action.MoveToElement(ListItems[0])
                .Click()
                .MoveToElement(ListItems[1])
                .Click()
                .MoveToElement(ListItems[2])
                .Click()
                .MoveToElement(ListItems[3])
                .Click()
                .MoveToElement(ListItems[0])
                .Click()
                .MoveToElement(ListItems[1])
                .Click()
                .MoveToElement(ListItems[2])
                .Click()
                .MoveToElement(ListItems[3])
                .Click()
                .Release()
                .Build()
                .Perform();

        }

        static void TestGrid(IWebDriver driver, Actions action)
        {
            IWebElement ClickGridTab = driver.FindElement(By.Id("demo-tab-grid"));

            var GridItems = driver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//li[contains(@class,'list-group-item')]"));

            action.MoveToElement(GridItems[0])
                .Click()
                .MoveToElement(GridItems[3])
                .Click()
                .MoveToElement(GridItems[4])
                .Click()
                .MoveToElement(GridItems[5])
                .Click()
                .MoveToElement(GridItems[8])
                .Click()
                .MoveToElement(GridItems[6])
                .Click()
                .MoveToElement(GridItems[2])
                .Click()
                .MoveToElement(GridItems[1])
                .Click()
                .MoveToElement(GridItems[0])
                .Click()
                .MoveToElement(GridItems[3])
                .Click()
                .MoveToElement(GridItems[4])
                .Click()
                .MoveToElement(GridItems[5])
                .Click()
                .MoveToElement(GridItems[8])
                .Click()
                .MoveToElement(GridItems[6])
                .Click()
                .MoveToElement(GridItems[2])
                .Click()
                .MoveToElement(GridItems[1])
                .Click()
                .Release()
                .Build()
                .Perform();

        }
    }
}
