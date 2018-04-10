using System;
using App.Domain.Infrastructure.Exceptions;
using App.Domain.Services;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace UnitTests.Services.PeopleServiceTests
{
    public class FetchPeople
    {
        private readonly IConfigurationRoot _config;

        public FetchPeople(){
            _config = new ConfigurationBuilder()
                .AddJsonFile("testsettings.json")
                .Build();
        }

        [Fact]
        public async void FetchPeople_InvalidBaseURI_InvalidOperationException()
        {
            var peopleService = new PeopleService();
            await Assert.ThrowsAsync<InvalidOperationException>(async ()=> await peopleService.GetPeopleAsync(null));
        }

        [Fact]
        public async void FetchPeople_ValidBaseURI_FetchRecords()
        {
            var peopleService = new PeopleService();
            var collection = await peopleService.GetPeopleAsync(_config.GetSection("PeopleURI").Value);
            Assert.True(collection.Count > 0);
        }
    }
}
