using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RestClientProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            var Client =new RestClient("https://localhost:7039/");
            //Get 
            var getSiteisAll = new RestRequest("api/Citeies", Method.Get);
            //For Parameter => Key , Value ==>>>>   getSiteisAll.AddParameter("PhoneNumber", "09193270146");
            var result= Client.Get<List<CityWhthouyPointOfInterstDto>>(getSiteisAll);
            //  var resultjsone=getSiteisAll.AddJsonBody(result);
     
            foreach (var item in result)
            {
                Console.WriteLine($" {item.Id}= >_ Name : {item.Name} \n Description : {item.Description}");
            }
            ;
      
            Console.ReadKey();  
        }
    }

    public class CityWhthouyPointOfInterstDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }
    }
}
