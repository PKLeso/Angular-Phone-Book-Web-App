using Angular_phone_book.BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using phone_book_shared.Exceptions;
using phone_book_shared.Helpers.Interface;
using phone_book_shared.Models;

namespace Angular_phone_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TModel> : ControllerBase
    {
        protected readonly IBaseBll<TModel> _businessLayer;
        protected readonly ILogger<BaseController<TModel>> _logger;

        protected readonly ISelfLinkGenerationHelper _selfLinkGenerationHelper;
        protected readonly IPaginationGenerationLinkMetaHelper _paginationGenerationLinkMetaHelper;

        public BaseController(IBaseBll<TModel> businessLayer, ILogger<BaseController<TModel>> logger,
                               ISelfLinkGenerationHelper selfLinkGenerationHelper,
                               IPaginationGenerationLinkMetaHelper paginationGenerationLinkMetaHelper )
        {
            _businessLayer = businessLayer;
            _logger = logger;
            _selfLinkGenerationHelper = selfLinkGenerationHelper;
            _paginationGenerationLinkMetaHelper = paginationGenerationLinkMetaHelper;
        }

        [NonAction]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var item = await this._businessLayer.GetByIdAsync(id);
            var response = _BuildResponsePayload(item);
            return Ok(response);
        }

        [NonAction]
        public async Task<ActionResult> DeleteById([FromRoute] int id)
        {
            var item = await this._businessLayer.DeleteByIdAsync(id);
            var resp = _BuildResponsePayload(item);
            return Ok(resp);
        }

        [NonAction]
        public async Task<ActionResult> CreateItem([FromBody] RequestPayload<TModel> model)
        {
            if (!ModelState.IsValid)
                throw new InvalidPostDataException(ModelState);

            var item = await this._businessLayer.CreateAsync(model.Data);
            var resp = _BuildResponsePayload(item);
            return Ok(resp);
        }

        [NonAction]
        protected async Task<ActionResult> UpdateItem([FromRoute] string id, [FromBody] RequestPayload<TModel> model)
        {
            if (!ModelState.IsValid)
                throw new InvalidPostDataException(ModelState);

            var item = await this._businessLayer.UpdateAsync(model.Data);
            var resp = _BuildResponsePayload(item);
            return Ok(resp);
        }

        [NonAction]
        public async Task<ActionResult> GetPage([FromQuery] PageRequestPayload request)
        {
            if (!ModelState.IsValid)
                throw new InvalidPostDataException(ModelState);

            var item = await this._businessLayer.GetPageAsync(request);
            var resp = _BuildResponsePayload(item.Item1, request.Page, request.PageSize, item.Item2);
            return Ok(resp);
        }



        protected ResponsePayload<TModel> _BuildResponsePayload(TModel model)
        {

            var resp = new ResponsePayload<TModel>()
            {
                Data = model,
                Links =
                {
                    Self = _selfLinkGenerationHelper.GenerateSelfLinkValue(HttpContext)
                },
                Meta = new ApiReponseMeta()
            };
            return resp;
        }

        protected ResponsePayload<TModel> _BuildResponsePayload()
        {

            var resp = new ResponsePayload<TModel>()
            {
                Links =
                {
                    Self = _selfLinkGenerationHelper.GenerateSelfLinkValue(HttpContext)
                },
                Meta = new ApiReponseMeta()
            };
            return resp;
        }


        protected ResponsePayload<List<TModel>> _BuildResponsePayload(List<TModel> model)
        {

            var resp = new ResponsePayload<List<TModel>>()
            {
                Data = model,
                Links =
                {
                    Self = _selfLinkGenerationHelper.GenerateSelfLinkValue(HttpContext)
                },
                Meta = new ApiReponseMeta()
            };
            return resp;
        }

        protected ResponsePayload<List<TModel>> _BuildResponsePayload(List<TModel> data, int page, int pageSize, int totalRecords)
        {
            var self = _selfLinkGenerationHelper.GenerateSelfLinkValue(HttpContext);
            var resp = new ResponsePayload<List<TModel>>()
            {
                Data = data
            };

            if (page == 1 && pageSize == -1)
            {
                pageSize = totalRecords;
            }

            var pageData = _paginationGenerationLinkMetaHelper.GenerateLinksAndMeta(page, pageSize, totalRecords, self);
            resp.Links = pageData.Links;
            resp.Meta = pageData.Meta;
            return resp;
        }
    }
}
