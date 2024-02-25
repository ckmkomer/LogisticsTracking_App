using AutoMapper;
using LogisticsTrackingApp.Core.Dtos.ContactDtos;
using LogisticsTrackingApp.Core.Dtos.ContactUsDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Service.Services.Abstract;
using LogisticsTrackingApp.Service.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsTrackingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactUsController : ControllerBase
	{
		private readonly IContactUsService _contactUsService;
		private readonly IMapper _mapper;

		public ContactUsController(IContactUsService contactUsService, IMapper mapper)
		{
			_contactUsService = contactUsService;
			_mapper = mapper;
		}


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _contactUsService.GetAllAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _contactUsService.GetIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateContactUsDto createContactUs)
		{
			var values = _mapper.Map<CreateContactUsDto, ContactUs>(createContactUs);
			await _contactUsService.InsertAsync(values);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateContactUsDto updateContactUs)
		{
			await _contactUsService.UpdateAsync(_mapper.Map<ContactUs>(updateContactUs));

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var contactUs = await _contactUsService.GetIdAsync(id);
			await _contactUsService.DeleteAsync(contactUs);
			return Ok();


		}



	}
}
