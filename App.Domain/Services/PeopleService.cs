using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using App.Domain.Infrastructure.Exceptions;
using App.Domain.Models;

namespace App.Domain.Services
{  
    public class PeopleService : IPeopleService
    {
        private readonly DataContractJsonSerializer _serializer;
        private readonly string _requestURI;
        
        // public PeopleService(string requestURI){
        //     _serializer = new DataContractJsonSerializer(typeof(ICollection<People.Person>));
        //     _requestURI = requestURI;
        // } 

         public PeopleService(){
            _serializer = new DataContractJsonSerializer(typeof(ICollection<People.Person>));
            _requestURI = "http://agl-developer-test.azurewebsites.net/people.json";
        } 

        public async Task<ICollection<People.Person>> GetPeopleAsync()
        {
            // get data
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(_requestURI);
            if(result.StatusCode != HttpStatusCode.OK){
                var ex = new PeopleFetchException($"Fetch failed with status code {result.StatusCode}");                
            }

            // deserialise
            var people = _serializer.ReadObject(await result.Content.ReadAsStreamAsync()) as ICollection<People.Person>;
            return people;
        }
    }
}
