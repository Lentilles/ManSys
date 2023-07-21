using System.ComponentModel.DataAnnotations;
using TheRealManSys.Models;

namespace TheRealManSys.Data.ContactScripts
{
    public class ContactManager
    {
        private readonly ManSysRequestContext Store;

        public ContactManager(ManSysRequestContext store)
        {
            this.Store = store;
        }

        public async Task CreateAsync(Contact contact)
        {
            if(contact == null)
                throw new ArgumentNullException(nameof(contact));

            var result = ValidateContact(contact);

            if (result.Success)
                await Store.contacts.AddAsync(contact);
        }

        public void Update(Contact contact)
        {
            if(contact == null)
                throw new ArgumentNullException(nameof(contact));

            var result = ValidateContact(contact);

            if(result.Success)
                Store.contacts.Update(contact);
        }

        public void Delete(Contact contact)
        {
            if(contact == null)
                throw new ArgumentNullException(nameof(contact));

            Store.contacts.Remove(contact);
        }

        public RequestSystemResult ValidateContact(Contact contact)
        {
            var context = new ValidationContext(contact);
            var results = new List<ValidationResult>();
            RequestSystemResult result = new RequestSystemResult();
            
            result.Success = true;

            if(!Validator.TryValidateObject(contact, context, results, true))
            {
                foreach(var error in results)
                {
                    if(error.ErrorMessage != null)
                        result.Errors.Add(error.ErrorMessage);
                }
                result.Success = false;
            }

            return result;

        }

    }
}
