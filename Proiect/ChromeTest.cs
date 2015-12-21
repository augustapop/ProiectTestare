using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
  public  class ChromeTest:SeleniumTest
    {
      public ChromeTest()
      {
          this.driver = new ChromeDriver();
      }
    }
}
