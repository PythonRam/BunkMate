using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System.Net;
namespace Bunk_Mate
{
    class Request
    {
        public List<string> info;
        public bool loginFailed;
        public string webSisStatus;
        public bool networkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();


        public  Request(string loginLink,string dataLink,string USERNAME, string PASSWORD)
        {
           
           if(networkUp)
            {

                WebRequest request = WebRequest.Create(loginLink);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response == null || response.StatusCode != HttpStatusCode.OK) { loginFailed = true; webSisStatus = " down at " + DateTime.Now.ToString(); }
                else
                {
                    var driverService = PhantomJSDriverService.CreateDefaultService();
                    // var driverService = PhantomJSDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true;

                    try
                    {
                        using (var myDriver = new PhantomJSDriver(driverService))
                        {

                            myDriver.Navigate().GoToUrl(loginLink);
                            webSisStatus = " up and running";
                            var userNameField = myDriver.FindElementById("userName");
                            var userPasswordField = myDriver.FindElementById("password");
                            var loginButton = myDriver.FindElementByXPath("//*[@id=\"loginbox\"]/div[1]/div/form/div[3]/button");
                            int a = myDriver.PageSource.Length;
                            userNameField.SendKeys(USERNAME);
                            userPasswordField.SendKeys(PASSWORD);
                            loginButton.Click();
                            myDriver.Navigate().GoToUrl(dataLink);
                            int b = myDriver.PageSource.Length;
                            if (a > b) { loginFailed = true; }
                            else
                            {
                                loginFailed = false;
                                info = Sorting.GetTables(myDriver.PageSource);

                                myDriver.GetScreenshot().SaveAsFile(@"websisScreenShot.png", System.Drawing.Imaging.ImageFormat.Png);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("loginFailed:" + loginFailed);
                        Console.Read();
                    }
                }
            }
            else
            {
                webSisStatus="no internet connection available";
                loginFailed = true;
                
            }
        }
    }
}
