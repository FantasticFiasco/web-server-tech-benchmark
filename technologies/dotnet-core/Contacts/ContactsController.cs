using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Contacts
{
	[Route("contacts")]
	public class ContactsController : Controller
	{
		private readonly ContactRepository repository;

		public ContactsController(ContactRepository repository)
		{
			this.repository = repository;
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] Contact contact)
		{
			contact = await repository.AddAsync(contact);
            
			return CreatedAtAction(nameof(GetAsync), new { id = contact.Id }, contact);
		}

		[HttpGet("{id:int}")]
		public Task<Contact> GetAsync(int id)
		{
			return repository.GetAsync(id);
		}

		[HttpGet]
		public Task<IEnumerable<Contact>> GetAsync()
		{
			return repository.GetAsync();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			await repository.DeleteAsync(id);

			return NoContent();
		}
	}
}
