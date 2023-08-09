using System.ComponentModel.DataAnnotations;
using ManSys.Models;

namespace ManSys.Data.StatusScripts
{
    public class StatusManager
    {
        private readonly ManSysRequestContext Store;

        public StatusManager(ManSysRequestContext store)
        {
            this.Store = store;
        }

        public async Task CreateAsync(Status status)
        {
            if(status == null)
                throw new ArgumentNullException(nameof(status));

            var result = ValidateStatus(status);

            if(result.Success)
                await Store.statuses.AddAsync(status);

            await Store.SaveChangesAsync();
        }

        public void Update(Status status)
        {
            if(status == null)
                throw new ArgumentNullException(nameof(status));

            var result = ValidateStatus(status);

            if (result.Success)
                Store.statuses.Update(status);
        }

        public void Delete(Status status)
        {
            if(status == null)
                throw new ArgumentNullException(nameof(status));

            var result = ValidateStatus(status);

            if(result.Success)
                Store.statuses.Remove(status);

            Store.SaveChanges();
        }

        protected RequestSystemResult ValidateStatus(Status status)
        {
            var context = new ValidationContext(status);
            var results = new List<ValidationResult>();
            RequestSystemResult result = new RequestSystemResult();

            result.Success = true;

            if (!Validator.TryValidateObject(status, context, results, true))
            {
                foreach (var error in results)
                {
                    if (error.ErrorMessage != null)
                    {
                        result.Errors.Add(error.ErrorMessage);
                    }
                }
                result.Success = false;
            }
            return result;
        }
    }
}
