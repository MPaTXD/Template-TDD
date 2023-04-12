using Microsoft.Extensions.DependencyInjection;
using System;

namespace Template.API.Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));

            service.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}
