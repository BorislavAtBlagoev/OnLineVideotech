using AutoMapper;

namespace OnLineVideotech.Web.Infrastructure.Mapping
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}