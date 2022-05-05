﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Interactions
{
    class Resizable
    {
        public void Run(bool Continue)
        {
            IWebDriver Driver = new ChromeDriver();
            Actions actionProvider = new Actions(Driver);

            try
            {
                Driver.Manage().Window.Maximize();

                Driver.Navigate().GoToUrl("https://demoqa.com/sortable");

                Thread.Sleep(3000);

                //ConstraintBox(Driver, actionProvider);

                FreeBox(Driver, actionProvider);

                _ = 0;

                Driver.Close();
                Driver.Quit();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);

                Thread.Sleep(5000);

                Driver.Close();
                Driver.Quit();
            }

            if (Continue)
                new Droppable().Run(Continue);
        }
        static void ConstraintBox(IWebDriver driver, Actions action)
        {
            var RegularBox = driver.FindElement(By.XPath("//div[@id='resizableBoxWithRestriction']//span[contains(@class,'react-resizable-handle')]"));

            action.MoveToElement(RegularBox)
                .ClickAndHold()
                .MoveByOffset(300, 300)
                .MoveByOffset(-450, -450)
                .MoveByOffset(100, 200)
                .MoveByOffset(200, 100)
                .Release()
                .Build()
                .Perform();
        }

        static void FreeBox(IWebDriver driver, Actions action)
        {
            var RegularBox = driver.FindElement(By.XPath("//div[@id='resizable']//span[contains(@class,'react-resizable-handle')]"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("window.scrollBy(0, 600)");

            action.MoveToElement(RegularBox)
                .ClickAndHold()
                .MoveByOffset(200, 200)
                .MoveByOffset(-200, 200)
                .MoveByOffset(100, 100)
                .MoveByOffset(200, 200)
                .Release()
                .Build()
                .Perform();


        }
    }
}