using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace TestProject
{
    public class MyAddedClass
    {

        IWebDriver driver;



        [SetUp]

        public void OpenBrowser()

        {

            driver = new FirefoxDriver();

        }



        public void GoToUrl(string url)

        {

            this.driver.Url = url;

        }


        [Test]

        public void MessageTest()
        {
            GoToUrl("http://www.seleniumeasy.com/test/basic-first-form-demo.html");
    		
    		//defining elements of the first part of the webpage (single input field)

            IWebElement message = driver.FindElement(By.XPath("//input[@id='user-message']"));
            IWebElement buttonShow = driver.FindElement(By.XPath("//button[contains(.,'Show Message')]"));
            IWebElement messageShown = driver.FindElement(By.XPath("//span[@id='display']")); //the displayed message element

            //defining what text will be entered in the message field
            string inMessage = "some wonderful text";
            //entering the text in the message field
            message.SendKeys(inMessage);
            //clicking on the "Show message" BUTTON
            buttonShow.Click();

            //saving the output text of the displayed message element
            string outMessage = messageShown.Text;

            //comparing what we entered with the output text
            bool chk = (inMessage == outMessage);
            //converting bool variable to string in order to write the result of this check into a file
            string result = Convert.ToString(chk);


            System.IO.File.WriteAllText(@"D:\QA\logQA.txt", "Time of executing the test: " + DateTime.Now + Environment.NewLine);
            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", Environment.NewLine);
            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", "The message is correctly displayed: " + result + Environment.NewLine);
            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", Environment.NewLine);

        }

		[Test]

        public void SumTest()
        {
            GoToUrl("http://www.seleniumeasy.com/test/basic-first-form-demo.html");
            
            //defining elements of the second part of the webpage (two input fields)

            IWebElement numOne = driver.FindElement(By.XPath("//input[@id='sum1']"));
            IWebElement numTwo = driver.FindElement(By.XPath("//input[@id='sum2']"));
            IWebElement buttonGet = driver.FindElement(By.XPath("//button[contains(.,'Get Total')]"));
            IWebElement sum = driver.FindElement(By.XPath("//span[@id='displayvalue']"));

            string inNumOne = "55";
            string inNumTwo = "45";

            //calculating the sum of two numbers that we are going to enter
            int sumTrue = Convert.ToInt32(inNumOne) + Convert.ToInt32(inNumTwo);

            numOne.SendKeys(inNumOne);
            numTwo.SendKeys(inNumTwo);
            buttonGet.Click();

            //saving the text content of the (above defined) sum web element in a string variable
            string sumTxt = sum.Text;
            //converting the sumTxt to integer in order to compare it with sumTrue
            int sumNum = Convert.ToInt32(sumTxt);

            bool total = (sumTrue == sumNum);
            string result = Convert.ToString(total);

            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", "Time of executing the test: " + DateTime.Now + Environment.NewLine);
            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", Environment.NewLine);
            System.IO.File.AppendAllText(@"D:\QA\logQAkurs.txt", "The displayed sum of entered numbers is correct: " + result + Environment.NewLine);
            System.IO.File.AppendAllText(@"D:\QA\logQAkurs.txt", Environment.NewLine);

        }

        [TearDown]

        public void CloseBrowser()

        {

            driver.Close();

        }
    }
}