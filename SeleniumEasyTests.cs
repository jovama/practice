using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPractice
{
    public class TestClass
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

        public void TestDropDown()
        {
            GoToUrl("http://www.seleniumeasy.com/test/basic-select-dropdown-demo.html");
            Thread.Sleep(2000);

            //selecting the day in a DropDown menu
            IWebElement day = driver.FindElement(By.XPath("//select[@id = 'select-demo']/option[contains(.,'Wednesday')]"));
	    	day.Click();
            Thread.Sleep(1000);

            //selecting the message under the DropDown menu 
            IWebElement message = driver.FindElement(By.XPath("//p[@class = 'selected-value']"));

            //getting the "value" of the day we selected/clicked in the DropDown menu
            string outDay = day.GetAttribute("value");

            //getting the textual content of the displayed message under the DropDown menu
            string messageText = message.Text;

            //checking if the displayed message is correct - if it contains indeed the day we selected (Wednesday)
            bool chk = messageText.Contains(outDay);
            //converting the chk variable to string so that we can write the result of the check in a file
            string result = Convert.ToString(chk);

            //writing the time when we ran the test in a file
	    	System.IO.File.AppendAllText(@"D:\QA\logQA.txt", "Time and date of the DropDown test: " + DateTime.Now + Environment.NewLine);
            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", Environment.NewLine);

            //writing the result of our check in a file
            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", "The selected day was displayed in the message under the dropdown menu: " + result + Environment.NewLine);
            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", Environment.NewLine);

        }


        [Test]

        public void TestMultiCheckBox()
        {
            GoToUrl("http://www.seleniumeasy.com/test/basic-checkbox-demo.html");
            Thread.Sleep(2000);

            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", "Time and date of the MultiCheckBox test: " + DateTime.Now + Environment.NewLine);
            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", Environment.NewLine);

            //defining the "Check All" BUTTON and then clicking on it
            IWebElement checkAllBtn = driver.FindElement(By.XPath("//input[@value = 'Check All']"));
	    	checkAllBtn.Click();

	    	//defining all 4 checkboxes as IWebElements
	    	IWebElement checkB1 = driver.FindElement(By.XPath("//input[@type = 'checkbox' and contains(following-sibling::text(), 'Option 1')]"));
	    	IWebElement checkB2 = driver.FindElement(By.XPath("//input[@type = 'checkbox' and contains(following-sibling::text(), 'Option 2')]"));
	    	IWebElement checkB3 = driver.FindElement(By.XPath("//input[@type = 'checkbox' and contains(following-sibling::text(), 'Option 3')]"));
	    	IWebElement checkB4 = driver.FindElement(By.XPath("//input[@type = 'checkbox' and contains(following-sibling::text(), 'Option 4')]"));
			
	    	//verifying if indeed all the checkboxes are checked - our first check
	    	bool chkIfAll1 = checkB1.Selected && checkB2.Selected && checkB3.Selected && checkB4.Selected;

	    	//writing the results of the check into a specified file
            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", "All the checkboxes are checked " + 
            "after clicking the 'Check All' BUTTON: " + Convert.ToString(chkIfAll1) + Environment.NewLine);
            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", Environment.NewLine);

            //defining the "Uncheck All" BUTTON as IWebElement
    	    IWebElement unCheckAllBtn = driver.FindElement(By.XPath("//input[@value = 'Uncheck All']"));
	    	//checking if the button is indeed displayed - is this superfluous?
	    	bool unChk = unCheckAllBtn.Displayed;

	    	//writing the results of the check into a file
	    	System.IO.File.AppendAllText(@"D:\QA\logQA.txt", "The 'Uncheck All' BUTTON is displayed: " + Convert.ToString(unChk) + Environment.NewLine);
            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", Environment.NewLine);

            //unchecking all checkboxes by clicking the "Uncheck All" BUTTON
	    	unCheckAllBtn.Click();
            Thread.Sleep(1000);

            //now checking if all the checkboxes are unchecked
            bool chkIfAll2 = !(checkB1.Selected && checkB2.Selected && checkB3.Selected && checkB4.Selected);

	    	//writing the results of the check into a file
	    	System.IO.File.AppendAllText(@"D:\QA\logQA.txt", "All the checkboxes are unchecked " + 
            "after clicking the 'Uncheck All' BUTTON: " + Convert.ToString(chkIfAll2) + Environment.NewLine);
            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", Environment.NewLine);


	    	//until now we checked that: after clicking on the 'Check All' button all checkboxes are checked at once
	    	//when all the checkboxes are checked, the button changes to 'Uncheck All'
	    	//finally, we are checking if, by unchecking at least one checkbox, the button changes to 'Check All'
            checkAllBtn.Click();
            //unchecking checkbox no. 2
            checkB2.Click(); 

            bool chkUnchkBtn = unCheckAllBtn.Displayed; //we defined the "Uncheck All" before, so we are now checking if it's displayed again

	    	System.IO.File.AppendAllText(@"D:\QA\logQA.txt", "After unchecking one checkbox, " + 
            "the 'Uncheck All' BUTTON changed to 'Check All' BUTTON: " + Convert.ToString(chkUnchkBtn) + Environment.NewLine);
            System.IO.File.AppendAllText(@"D:\QA\logQA.txt", Environment.NewLine);

            Thread.Sleep(1000);


        }

        

        [TearDown]

        public void CloseBrowser()

        {

            driver.Close();

        } 
    }
}
