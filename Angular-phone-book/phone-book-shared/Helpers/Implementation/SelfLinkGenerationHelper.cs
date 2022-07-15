using phone_book_shared.Helpers.Interface;

namespace phone_book_shared.Helpers.Implementation
{
    public class SelfLinkGenerationHelper : ISelfLinkGenerationHelper
    {
        public string GenerateSelfLinkValue(HttpContext context)
        {
            var selfLink = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path.Value}";
            return selfLink;
        }
    }
}
