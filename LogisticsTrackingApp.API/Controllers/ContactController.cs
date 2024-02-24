using AutoMapper;
using LogisticsTrackingApp.Core.Dtos.AboutDtos;
using LogisticsTrackingApp.Core.Dtos.AdressDtos;
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
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public ContactController(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _contactService.GetAllAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _contactService.GetIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateContactDto createContact)
		{
			var values = _mapper.Map<CreateContactDto, Contact>(createContact);
			await _contactService.InsertAsync(values);
			return Ok("Başarılı şekilde eklendi");
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateContactUsDto updateContact)
		{
			await _contactService.UpdateAsync(_mapper.Map<Contact>(updateContact));

			return Ok("Başarılı şekilde güncellendi");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var contact = await _contactService.GetIdAsync(id);
			await _contactService.DeleteAsync(contact);
			return Ok("Başarılı şekilde silindi");


		}

	}
}
