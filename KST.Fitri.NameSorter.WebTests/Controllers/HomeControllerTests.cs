using KST.Fitri.NameSorter.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KST.Fitri.NameSorter.WebTests.Controllers
{
    public class HomeControllerTests
    {
        public void TestWeb()
        {
            var controller = new HomeController();
            var result = controller.Names;
            Assert.AreNotEqual(0, result.Count);
        }    
    }
}
