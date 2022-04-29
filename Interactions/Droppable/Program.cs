﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Droppable
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            Actions actionProvider = new Actions(Driver);

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/droppable");

            Thread.Sleep(3000);

            //TestSimpleDroppable(Driver, actionProvider);

            //TestAccept(Driver, actionProvider);

            //PreventPropogation(Driver, actionProvider);

            //SwitchToRevert(Driver, actionProvider);

            _ = 0;

            Driver.Close();
            Driver.Quit();
        }

        static void TestSimpleDroppable(IWebDriver driver, Actions action)
        {
            var DragElement = driver.FindElement(By.XPath("//div[@id='simpleDropContainer']//div[@id='draggable']"));

            var DropBoxElement = driver.FindElement(By.XPath("//div[@id='simpleDropContainer']//div[@id='droppable']"));

            action.MoveToElement(DragElement)
                .ClickAndHold()
                .MoveToElement(DropBoxElement)
                .Release()
                .Build()
                .Perform();
        }

        static void TestAccept(IWebDriver driver, Actions action)
        {
            IWebElement ClickAcceptTab = driver.FindElement(By.Id("droppableExample-tab-accept"));
            ClickAcceptTab.Click();

            //IWebElement ParentElement = driver.FindElement(By.XPath("//div;[@id='acceptDropContainer']"));

            IWebElement ParentElement = driver.FindElement(By.Id("acceptDropContainer"));

            IWebElement AcceptDrop = driver.FindElement(By.Id("acceptable"));

            IWebElement DiscardDrop = driver.FindElement(By.XPath("//div[@id='acceptDropContainer']//div[@id='notAcceptable']"));

            IWebElement DroppableBox = driver.FindElement(By.XPath("//div[@id='acceptDropContainer']//div[@id='droppable']"));

            // Drop Acceptable
            action.MoveToElement(AcceptDrop)
                .ClickAndHold()
                .MoveToElement(DroppableBox)
                .MoveToElement(ParentElement)
                .Release()
                .Build()
                .Perform();

            // Drop Not Acceptavle
            action.MoveToElement(DiscardDrop)
                .ClickAndHold()
                .MoveToElement(DroppableBox)
                .Release()
                .Build().
                Perform();
        }

        static void PreventPropogation(IWebDriver driver, Actions action)
        {
            IWebElement ClickPropogationTab = driver.FindElement(By.Id("droppableExample-tab-preventPropogation"));
            ClickPropogationTab.Click();

            action.MoveToElement(driver.FindElement(By.Id("dragBox")))
                .ClickAndHold()
                .MoveToElement(driver.FindElement(By.Id("notGreedyInnerDropBox")))
                .Release()
                .Build()
                .Perform();

            action.MoveToElement(driver.FindElement(By.Id("dragBox")))
                .ClickAndHold()
                .MoveToElement(driver.FindElement(By.Id("greedyDropBox")))
                .Release()
                .ClickAndHold()
                .MoveToElement(driver.FindElement(By.Id("greedyDropBoxInner")))
                .Release()
                .Build()
                .Perform();
        }

        static void SwitchToRevert(IWebDriver driver, Actions action)
        {
            IWebElement ClickRevertTab = driver.FindElement(By.Id("droppableExample-tab-revertable"));
            ClickRevertTab.Click();

            IWebElement RevertBox = driver.FindElement(By.Id("revertable"));

            IWebElement NotRevertBox = driver.FindElement(By.Id("notRevertable"));

            IWebElement DroppableBox = driver.FindElement(By.XPath("//div[@class='revertable-drop-container']//div[@id='droppable']"));

            action.MoveToElement(RevertBox)
                .ClickAndHold()
                .MoveToElement(DroppableBox)
                .Release()
                .Build()
                .Perform();

            action.MoveToElement(NotRevertBox)
                .ClickAndHold()
                .MoveToElement(DroppableBox)
                .Release()
                .Build()
                .Perform();
        }
    }
}
