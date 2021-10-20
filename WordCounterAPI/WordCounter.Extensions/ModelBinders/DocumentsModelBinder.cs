using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;
using WordCounter.Contracts.Commands;

namespace WordCounter.Extensions.ModelBinders
{
    public class DocumentsModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Document doc = null;
            IFormFile file = bindingContext.HttpContext?.Request?.Form?.Files?.FirstOrDefault();
            if (file != null)
            {
                doc = new Document
                {
                    Size = file.Length,
                    Name = file.FileName,
                    Extension = System.IO.Path.GetExtension(file.FileName),
                    Content = file.OpenReadStream()
                };
            }
            bindingContext.Result = ModelBindingResult.Success(doc);

            return Task.CompletedTask;
        }


    }
}
