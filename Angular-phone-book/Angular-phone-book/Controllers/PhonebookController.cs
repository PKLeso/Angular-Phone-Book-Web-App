using Angular_phone_book.BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using phone_book_shared.Entities;
using phone_book_shared.Helpers.Interface;
using phone_book_shared.Models;

namespace Angular_phone_book.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1")]
    public class PhonebookController : BaseController<PhoneBook>
    {
        protected new readonly IPhonebookBll _businessLayer;

        public PhonebookController(IPhonebookBll businessLayer, ILogger<PhonebookController> logger,
                                   ISelfLinkGenerationHelper selfLinkGenerationHelper,
                                   IPaginationGenerationLinkMetaHelper paginationGenerationLinkMetaHelper) : base(businessLayer,
                                   logger, selfLinkGenerationHelper, paginationGenerationLinkMetaHelper)
        {
            _businessLayer = businessLayer;
        }


        [HttpGet("{id}")]
        public new async Task<ActionResult> GetById([FromRoute] int id)
        {
            return await base.GetById(id);

        }

        [HttpDelete("{id}")]
        public new async Task<ActionResult> DeleteById([FromRoute] int id)
        {
            return await base.DeleteById(id);

        }

        [HttpPost]
        public new async Task<ActionResult> CreateItem([FromBody] RequestPayload<PhoneBook> model)
        {
            return await base.CreateItem(model);
        }

        [HttpPut("{id}")]
        public new async Task<ActionResult> UpdateItem([FromRoute] string id, [FromBody] RequestPayload<PhoneBook> model)
        {
            return await base.UpdateItem(id, model);
        }
    }
}
