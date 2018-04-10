using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using Microsoft.Extensions.Logging;
using App.Domain.Services;
using App.Constants;
using App.Domain.Infrastructure.Exceptions;
using Microsoft.Extensions.Options;
using App.Domain.Infrastructure.Settings;

namespace App.Controllers
{
    public class CatsController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ILogger<CatsController> _logger;
        private readonly IOptions<APISettings.People> _options;

        public CatsController(IPeopleService peopleService, ILogger<CatsController> logger, IOptions<APISettings.People> options)
        {
            _peopleService = peopleService;
            _logger = logger;
            _options = options;
        }

        public async Task<IActionResult> Index()
        {            
            try
            {
                var people = await _peopleService.GetPeopleAsync(_options.Value.PeopleURI);

                // filter people wit cats and not null
                var catPeople = people.Where(_ => _.pets != null)
                .Where(_ => _.pets.Any(p => p.type.ToLower() == PetType.Cat.ToString().ToLower()));

                // create cats list
                var cats = new List<Cat>();
                foreach (var person in catPeople)
                {
                    cats.AddRange(
                        person.pets.Select(_ => new Cat
                        {
                            Name = _.name,
                            OwnerGender = person.gender
                        })
                    );
                }

                // prepare model
                var model = new CatViewModel
                {
                    Cats = cats.OrderBy(_ => _.OwnerGender).ToList()
                };
                return View(model);

            }
            catch (PeopleFetchException ex)
            {
                _logger.LogError(ex, "Error loading cats");
                return View(new CatViewModel{
                    HasError = true, 
                    ErrorMessage = $"Error loading cats. {ex.Message}"
                });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Unknown Exception");
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
