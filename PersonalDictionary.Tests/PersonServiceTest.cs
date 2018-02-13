using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalDictionary.Core.Domain;
using PersonalDictionary.Core.Domain.Service;
using PersonalDictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nito.AsyncEx.UnitTests;
using PersonalDictionary.Core;

namespace PersonalDictionary.Tests
{
    [TestClass]
    public class PersonServiceTest
    {
        string personData;
        IUnitOfWork _unitOfWork;

        [TestInitialize()]
        public void Initialize()
        {
            personData = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";
            _unitOfWork = new UnitOfWork();
        }

        [TestMethod]
        public void FetchDataFromWebServiceTest()
        {
            // Arrange
            //// Act
            List<Person> persons = _unitOfWork.Persons.DeserializeResults<List<Person>>(personData);
            //Task<ActionResult> result = controller.Index() as Task<ActionResult>;

            ////// Assert
            Assert.IsTrue(persons.Count > 0);
        }

        [TestMethod]
        public void PetsAreGroupedByGenderTest()
        {
            // Arrange
            //// Act
            List<PersonViewModel> petGroups = _unitOfWork.Persons.GetAllPetsGroupedByOwnersGender().Result;
            //Task<ActionResult> result = controller.Index() as Task<ActionResult>;

            ////// Assert
            Assert.IsTrue(petGroups.Where(p => p.Gender == "Male").Count() > 0);
        }
    }
}
