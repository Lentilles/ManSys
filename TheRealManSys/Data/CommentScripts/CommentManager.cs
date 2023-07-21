using System.ComponentModel.DataAnnotations;
using TheRealManSys.Models;

namespace TheRealManSys.Data.CommentScripts
{
    public class CommentManager
    {
        private readonly ManSysRequestContext Store;
        public CommentManager(ManSysRequestContext Store) 
        {
            this.Store = Store;
        }


        public async Task CreateAsync(Comment comment)
        {
            if(comment == null)
                throw new ArgumentNullException(nameof(comment));

            var result = ValidateComment(comment);

            if(result.Success)
                await Store.SaveChangesAsync();
        }

        public void Update(Comment comment)
        {
            if(comment == null)
                throw new ArgumentNullException(nameof(comment));

            var result = ValidateComment(comment);

            if(result.Success)
                Store.Update(comment);
        }

        public void Delete(Comment comment)
        {
            if(comment == null)
                    throw new ArgumentNullException(nameof(comment));

            var result = ValidateComment(comment);

            if (result.Success)
                Store.comments.Remove(comment);
        }


        protected RequestSystemResult ValidateComment(Comment comment)
        {
            var context = new ValidationContext(comment);
            var results = new List<ValidationResult>();

            RequestSystemResult result = new RequestSystemResult();
            result.Success = true;

            if(!Validator.TryValidateObject(comment, context, results, true)) 
            {
                foreach(var error in results)
                {
                    if(error.ErrorMessage != null && result.Errors != null)
                    {
                        result.Errors.Add(error.ErrorMessage);
                    }
                    result.Success = false;
                }
            }

            return result;
        }
    }
}
