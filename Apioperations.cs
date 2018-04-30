using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingPostman
{
    class Apioperations
    {

        string Url = "http://localhost:8080/landlords";

        public IRestResponse Post(string Data)
        {
            RestClient client = new RestClient(Url);
            RestRequest request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", Data, ParameterType.RequestBody);

            IRestResponse responseofpost = client.Execute(request);
            return (responseofpost);


            // Landlord object = JsonConvert.DeserializeObject<Landlord>(json);
            //Console.Error.Write(responseofpost.Content);
        }
        
        public IRestResponse GetAll()
        {
            RestClient client = new RestClient(Url);
            RestRequest request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");
            IRestResponse responseofpost = client.Execute(request);
            return (responseofpost);
            
         }

        public IRestResponse DeletebyId(string idd)
        {


            RestClient client = new RestClient(Url+"//"+idd);
            RestRequest request = new RestRequest(Method.DELETE);

            request.AddHeader("Content-Type", "application/json");
            IRestResponse responseofpost = client.Execute(request);
            return (responseofpost);


        }
                      
    }
}
