using Microsoft.Extensions.Configuration;
using Portfolio.BusinessLayer.DTOs;
using Portfolio.BusinessLayer.Services.Interfaces.ContactForm;
using Portfolio.BusinessLayer.Services.Interfaces.Mail;
using Portfolio.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.BusinessLayer.Services.Implementations.ContactForm
{
    public class ContactFormService : IContactFormService
    {
        private readonly IRepository<Domain.Entities.ContactForm> _repository;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;

        public ContactFormService(IRepository<Domain.Entities.ContactForm> repository, IMailService mailService, IConfiguration configuration)
        {
            _repository = repository;
            _mailService = mailService;
            _configuration = configuration;
        }

        public async Task<bool> AddContactFormAsync(ContactFormDto contactFormDto)
        {
            var contactForm = new Domain.Entities.ContactForm
            {
                Name = contactFormDto.Name,
                Email = contactFormDto.Email,
                Subject = contactFormDto.Subject,
                Message = contactFormDto.Message,
                SubmittedAt = DateTime.UtcNow
            };

            var isAdded = await _repository.AddAsync(contactForm);
            if (isAdded)
            {
                await _mailService.SendEmailAsync(_configuration["Mail:Username"], contactForm.Subject, contactForm.Message);
            }
            return isAdded;
        }

        public async Task<bool> UpdateContactFormAsync(Guid id, ContactFormDto contactFormDto)
        {
            var existingForm = await _repository.GetByIdAsync(id);
            if (existingForm == null)
                return false;

            existingForm.Name = contactFormDto.Name;
            existingForm.Email = contactFormDto.Email;
            existingForm.Subject = contactFormDto.Subject;
            existingForm.Message = contactFormDto.Message;

            return await _repository.UpdateAsync(existingForm);
        }

        public async Task<bool> DeleteContactFormAsync(Guid id)
        {
            var contactForm = await _repository.GetByIdAsync(id);
            if (contactForm == null)
                return false;

            return await _repository.RemoveAsync(contactForm);
        }

        public async Task<List<ContactFormDto>> GetAllContactFormsAsync()
        {
            var contactForms = await _repository.GetAllAsync();
            var contactFormDtos = new List<ContactFormDto>();

            foreach (var form in contactForms)
            {
                contactFormDtos.Add(new ContactFormDto
                {
                    Name = form.Name,
                    Email = form.Email,
                    Subject = form.Subject,
                    Message = form.Message,
                    SubmittedAt = form.SubmittedAt
                });
            }

            return contactFormDtos;
        }

        public async Task<ContactFormDto> GetContactFormByIdAsync(Guid id)
        {
            var form = await _repository.GetByIdAsync(id);
            if (form == null)
                return null;

            return new ContactFormDto
            {
                Name = form.Name,
                Email = form.Email,
                Subject = form.Subject,
                Message = form.Message,
                SubmittedAt = form.SubmittedAt
            };
        }
    }
}
