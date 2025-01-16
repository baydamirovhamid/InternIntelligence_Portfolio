using Microsoft.AspNetCore.Mvc;
using Portfolio.BusinessLayer.DTOs;
using Portfolio.BusinessLayer.Services.Interfaces.ContactForm;
using Portfolio.BusinessLayer.Services.Interfaces.Mail;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly IContactFormService _contactFormService;
        private readonly IMailService _mailService;

        public ContactFormController(IContactFormService contactFormService, IMailService mailService)
        {
            _contactFormService = contactFormService;
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> AddContactFormAsync([FromBody] ContactFormDto contactFormDto)
        {
            if (contactFormDto == null)
            {
                return BadRequest("Contact form data is null.");
            }

            var isAdded = await _contactFormService.AddContactFormAsync(contactFormDto);
            if (isAdded)
            {
                await _mailService.SendEmailAsync(contactFormDto.Email, contactFormDto.Subject, contactFormDto.Message);
                return Ok("Contact form added and email sent successfully.");
            }

            return BadRequest("Failed to add contact form.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactFormAsync(Guid id, [FromBody] ContactFormDto contactFormDto)
        {
            if (contactFormDto == null)
            {
                return BadRequest("Contact form data is null.");
            }

            var isUpdated = await _contactFormService.UpdateContactFormAsync(id, contactFormDto);
            if (isUpdated)
            {
                return Ok("Contact form updated successfully.");
            }

            return NotFound("Contact form not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactFormAsync(Guid id)
        {
            var isDeleted = await _contactFormService.DeleteContactFormAsync(id);
            if (isDeleted)
            {
                return Ok("Contact form deleted successfully.");
            }

            return NotFound("Contact form not found.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContactFormsAsync()
        {
            var contactForms = await _contactFormService.GetAllContactFormsAsync();
            return Ok(contactForms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactFormByIdAsync(Guid id)
        {
            var contactForm = await _contactFormService.GetContactFormByIdAsync(id);
            if (contactForm == null)
            {
                return NotFound("Contact form not found.");
            }

            return Ok(contactForm);
        }
    }
}
