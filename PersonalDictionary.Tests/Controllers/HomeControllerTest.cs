using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalDictionary;
using PersonalDictionary.Controllers;
using PersonalDictionary.Core.Domain;
using PersonalDictionary.Core;
using System.Threading.Tasks;

namespace PersonalDictionary.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        IUnitOfWork _unitOfWork;

        [TestInitialize()]
        public void Initialize()
        {
            _unitOfWork = new UnitOfWork();
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(_unitOfWork);

            //// Act
            Task<ActionResult> result = controller.Index() as Task<ActionResult>;

            //// Assert
            Assert.IsNotNull(result);
        }
    }
}
