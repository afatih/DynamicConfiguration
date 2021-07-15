using AutoMapper;
using DynamicConfiguration.Application.Configurations.Commands;
using DynamicConfiguration.Application.Configurations.Queries;
using DynamicConfiguration.ConfigurationReader.Interface;
using DynamicConfiguration.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DynamicConfiguration.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBeymenConfigurationProvider _beymenConfigurationProvider;
        private readonly IMapper _mapper;
        public HomeController(IBeymenConfigurationProvider beymenConfigurationProvider,
            IMapper mapper)
        {
            _beymenConfigurationProvider = beymenConfigurationProvider;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(ConfigurationViewModel model)
        {
            var configurations = await Mediator.Send(new GetAllConfigurationsQuery());
            model.Configurations = configurations;

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateConfigurationCommand model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            await Mediator.Send(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var configResult = await Mediator.Send(new GetConfigurationByIdQuery { Id = id });
            var mappedResult = _mapper.Map<UpdateConfigurationCommand>(configResult);

            return View(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateConfigurationCommand model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            await Mediator.Send(model);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await Mediator.Send(new DeleteConfigurationCommand { Id = Id });

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetConfigurationsFromLibrary()
        {
            var configurations = new ConfigurationsFromLibrary
            {
                SiteName = await _beymenConfigurationProvider.GetValue<string>("SiteName"),
                MaxItemCount = await _beymenConfigurationProvider.GetValue<int>("MaxItemCount"),
                IsBasketEnabled = await _beymenConfigurationProvider.GetValue<bool>("IsBasketEnabled")
            };

            return Json(configurations);
        }
    }
}