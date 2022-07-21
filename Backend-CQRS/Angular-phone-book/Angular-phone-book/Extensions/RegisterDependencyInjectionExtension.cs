using Angular_phone_book.BusinessLogicLayer.Implementation;
using Angular_phone_book.BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using phone_book_shared.Helpers.Implementation;
using phone_book_shared.Helpers.Interface;
using phone_book_shared.Services.Implementation.DataAccess;
using phone_book_shared.Services.Interface.DataAccess;

namespace Angular_phone_book.Extensions
{
    public static class RegisterDependencyInjectionExtension
    {
        public static void RegisterAppDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ISelfLinkGenerationHelper, SelfLinkGenerationHelper>();
            services.AddSingleton<IPaginationGenerationLinkMetaHelper, PaginationGenerationLinkMetaHelper>();
            services.AddSingleton(typeof(IBaseContainerDal<>), typeof(BaseContainerDal<>));
            services.AddScoped<IPhonebookBll, PhonebookBll>();
            //services.AddScoped<IPhonebookDal, PhonebookDal>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}
