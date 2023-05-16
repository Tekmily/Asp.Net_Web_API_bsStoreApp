using System.Runtime.CompilerServices;
using WebApi.Utilitis.Formatters;

namespace WebApi.Extentions
{
    public static class IMvcBuilderExtensions
    {
        public static IMvcBuilder AddCostumCsvFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(config=>
            config.OutputFormatters
            .Add(new CsvOutputFormatter()));
    }
}
