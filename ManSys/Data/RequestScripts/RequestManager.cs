using System.ComponentModel.DataAnnotations;
using ManSys.Models;

namespace ManSys.Data.RequestScripts
{
    public class RequestManager
    {
        private readonly ManSysRequestContext Store;

        public RequestManager(ManSysRequestContext store)
        {
            Store = store;
        }

        public async Task CreateAsync(Request request)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));

            var result = ValidateRequest(request);

            if (!result.Success)
                throw new Exception(result.Errors.ToString());
                
                Store.request.Add(request);
                Store.SaveChanges();
        }


        public void Update(Request request)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));

            var result = ValidateRequest(request);

            if(result.Success)
                Store.request.Update(request);
        }

        public void Delete(Request request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            Store.request.Remove(request);
        }

        protected RequestSystemResult ValidateRequest(Request request)
        {
            var context = new ValidationContext(request);
            var results = new List<ValidationResult>();
            RequestSystemResult result = new RequestSystemResult();
            result.Success = true;

            if(!Validator.TryValidateObject(request, context, results, true))
            {
                result.Errors = new List<string>();
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
