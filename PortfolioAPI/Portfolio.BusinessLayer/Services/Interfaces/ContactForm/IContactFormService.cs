using Portfolio.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.BusinessLayer.Services.Interfaces.ContactForm
{
    public interface IContactFormService
    {
        Task<bool> AddContactFormAsync(ContactFormDto contactFormDto);
        Task<bool> UpdateContactFormAsync(Guid id, ContactFormDto contactFormDto);
        Task<bool> DeleteContactFormAsync(Guid id);
        Task<List<ContactFormDto>> GetAllContactFormsAsync();
        Task<ContactFormDto> GetContactFormByIdAsync(Guid id);
    }
}
