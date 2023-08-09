using System.ComponentModel.DataAnnotations;
using ManSys.Models.Requests;

namespace ManSys.Data.DraftScripts
{
    public class DraftManager
    {
        /*
        private readonly ManSysRequestContext Store;
        public DraftManager(ManSysRequestContext Store) 
        {
            this.Store = Store;
        }


        public async Task CreateAsync(Draft draft)
        {
            if(draft == null)
                throw new ArgumentNullException(nameof(draft));

            var result = ValidateComment(draft);

            if (result.Success)
            {
                await Store.drafts.AddAsync(draft);
                await Store.SaveChangesAsync();
            }
        }

        public void Create(Draft draft)
        {
            if (draft == null)
                throw new ArgumentNullException(nameof(draft));

            var result = ValidateComment(draft);

            if (result.Success)
            {
                Store.drafts.Add(draft);
                Store.SaveChanges();
            }
        }

        public void Update(Draft draft)
        {
            if(draft == null)
                throw new ArgumentNullException(nameof(draft));

            var result = ValidateComment(draft);

            if(result.Success)
                Store.Update(draft);
        }

        public void Delete(Draft draft)
        {
            if(draft == null)
                    throw new ArgumentNullException(nameof(draft));

            var result = ValidateComment(draft);

            if (result.Success)
                Store.drafts.Remove(draft);
        }


        protected RequestSystemResult ValidateComment(Draft draft)
        {
            var context = new ValidationContext(draft);
            var results = new List<ValidationResult>();

            RequestSystemResult result = new RequestSystemResult();
            result.Success = true;

            if(!Validator.TryValidateObject(draft, context, results, true)) 
            {
                foreach(var error in results)
                {
                    if(error.ErrorMessage != null)
                    {
                        result.Errors.Add(error.ErrorMessage);
                    }
                    result.Success = false;
                }
            }

            return result;
        }
        */
    }
}
