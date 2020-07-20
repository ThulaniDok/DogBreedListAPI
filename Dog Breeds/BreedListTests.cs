using System;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;

namespace Dog_Breeds
{
    public class BreedListTests
    {
        /// <summary>
        /// Representing identity management login endpoint.
        /// </summary>
        private const string BaseUrl = "https://dog.ceo/api";
        
        /// <summary>
        /// Tests that retriever is in the list of dog breeds.
        /// </summary>
        [Test]
        public void TestRetrieverInDogBreedList()
        {
            var endPoint = "/breeds/list/all";
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(endPoint, Method.GET);
            
            var response = client.Execute(request);
            Console.WriteLine(response);
            
            var responseObject = new JsonDeserializer().Deserialize<dynamic>(response);
            var retriever = responseObject["message"]["retriever"];
            Assert.NotNull(retriever);
        }
        
        /// <summary>
        /// Tests that retriever sub breed list is returned successfully.
        /// </summary>
        [Test]
        public void TestRetrieverSubBreedListReturnSuccessfully()
        {
            var endPoint = "/breed/retriever/list";
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(endPoint, Method.GET);
            
            var response = client.Execute(request);
            Console.WriteLine(response);
            
            var responseObject = new JsonDeserializer().Deserialize<dynamic>(response);
            var status = responseObject["status"];
            var expected =
                "success";
            Assert.IsTrue(status.Contains(expected));
        }
        
        /// <summary>
        /// Tests that random breed image returns successfully.
        /// </summary>
        [Test]
        public void TestRandomBreedImage()
        {
            var endPoint = "/breeds/image/random";
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(endPoint, Method.GET);
            
            var response = client.Execute(request);
            Console.WriteLine(response);
            
            var responseObject = new JsonDeserializer().Deserialize<dynamic>(response);
            var status = responseObject["status"];
            var expected =
                "success";
            Assert.IsTrue(status.Contains(expected));
        }
    }
}