using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace RESTSharp_Testing
{
    public class AddressBook
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    [TestClass]
    public class AddressBookTesting
    {
        RestClient client;
        [TestMethod]
        public void OnCallingGetMethod_CompareCount_ShouldReturnCountOfAddressBookList()
        {
            client = new RestClient("http://localhost:4000");
            //Arrange
            RestRequest request = new RestRequest("/AddressBook", Method.Get);
            //Act
            RestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<AddressBook> list = JsonConvert.DeserializeObject<List<AddressBook>>(response.Content);
            Assert.AreEqual(4, list.Count);
            foreach (AddressBook value in list)
            {
                Console.WriteLine("Id:" + value.id + ",\t " + value.FirstName + ",\t " + value.LastName + ",\t" + value.Address + ",\t " + value.City + ",\t" + value.State + ",\t " + value.ZipCode + ",\t" + value.PhoneNumber + ",\t " + value.Email);
            }
        }
    }
}