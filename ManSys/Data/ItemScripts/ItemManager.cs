using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using ManSys.Models;

namespace ManSys.Data.ItemScripts
{
    public class ItemManager
    {

        private readonly ManSysRequestContext Store;

        public ItemManager(ManSysRequestContext store)
        {
            this.Store = store;
        }


        public void CreateAsync(Item item)
        {
            if(item == null)
                throw new ArgumentNullException("item");

            var result = Validate(item);

            if (!result.Success)
                throw new Exception(result.Errors.ToString());

            Store.items.Add(item);
            Store.SaveChanges();
        }

        public async Task CreateRangeAsync(IEnumerable<Item> items)
        {
            if (items == null)
                throw new ArgumentNullException("item");

            var result = Validate(items);

            if (!result.Success)
                throw new Exception(result.Errors.ToString());

            
            await Store.items.AddRangeAsync(items);
            await Store.SaveChangesAsync();
        }

        public void UpdateItems(IEnumerable<Item> items)
        {
            if(items == null)
                throw new ArgumentNullException("items");

            var result = Validate(items);

            if(result.Success)
                Store.items.UpdateRange(items);
        }

        public void UpdateItem(Item item)
        {
            if(item == null)
               throw new ArgumentNullException("item");

            var result = Validate(item);

            if(result.Success)
                Store.items.Update(item);
        }

        public void DeleteItem(Item item)
        {
            if (item == null) 
                throw new ArgumentNullException();

            var result = Validate(item);

            if(result.Success)
                Store.items.Remove(item);
        }
        
        public void DeleteItems(IEnumerable<Item> items)
        {
            if (items == null)
                throw new ArgumentNullException();

            var result = Validate(items);

            if (result.Success)
                Store.items.RemoveRange(items);
        }

        protected RequestSystemResult Validate(Item item)
        {
            var context = new ValidationContext(item);
            var results = new List<ValidationResult>();

            RequestSystemResult result = new RequestSystemResult();
            result.Success = true;

            if(!Validator.TryValidateObject(item, context, results, true))
            {
                foreach(var error in results)
                {
                    if(error.ErrorMessage != null)
                    {
                        result.Errors.Add(error.ErrorMessage);
                    }
                }
                result.Success = false;
            }

            return result;
        }

        

        protected RequestSystemResult Validate(IEnumerable<Item> items)
        {
            if(items == null)
                throw new ArgumentNullException();

            if(items.Count() == 0)
                throw new ArgumentException($"{nameof(items)} could not be empty");

            var result = new RequestSystemResult();
            
            result.Success = true;

            foreach(var item in items)
            {
                var context = new ValidationContext(item);
                var results = new List<ValidationResult>();

                if (item == null)
                    throw new NullReferenceException();

                if (!Validator.TryValidateObject(item, context, results, true))
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
            }

            return result;
        }
    }
}
