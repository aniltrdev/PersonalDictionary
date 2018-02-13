using PersonalDictionary.Core.Repositories;
using PersonalDictionary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PersonalDictionary.Core.Domain.Service
{
    public class PersonService : Repository<Person>, IPersonRepository
    {
        /// <summary>
        /// Get all persons from Web Service and pets are grouped by it's owner's gender.
        /// </summary>
        /// <returns>Asychronous call returns a list of pets owner's genderwise.</returns>
        public async Task<List<PersonViewModel>> GetAllPetsGroupedByOwnersGender()
        {
            List<Person> PersonList = await GetPersonListFromWebService<List<Person>>();

            var petGroupsByOwnerGender = PersonList.GroupBy(g => g.Gender).Select(g => new PersonViewModel
            {
                Gender = g.Key,
                Pets = g.SelectMany(p => (p.Pets != null) ? p.Pets : new List<Pet>()).Where(s => s.Type == PetType.Cat).OrderBy(p => p.Name).ToList()
            }).ToList();
            return petGroupsByOwnerGender;
        }

        /// <summary>
        /// Deserialize the JSON data from web service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public T DeserializeResults<T>(string result)
        {
            T returnValue;
            JavaScriptSerializer js = new JavaScriptSerializer();
            returnValue = js.Deserialize<T>(result);
            return returnValue;
        }

        private async Task<T> GetPersonListFromWebService<T>()
        {
            T returnValue =
                default(T);
            try
            {
                using (var client = new HttpClient())
                {
                    string uri = ConfigurationManager.AppSettings["JsonTestDataUrl"].ToString();

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode();
                    var result = ((HttpResponseMessage)response).Content.ReadAsStringAsync().Result;
                    //string result = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";
                    returnValue = DeserializeResults<T>(result);
                }
                return returnValue;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }
    }
}