namespace phone_book_shared.Helpers.Interface
{
    public interface ISelfLinkGenerationHelper
    {
        string GenerateSelfLinkValue(HttpContext context);
    }
}
