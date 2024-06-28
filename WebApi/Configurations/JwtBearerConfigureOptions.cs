using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace WebApi.Configurations
{
  public class JwtBearerConfigureOptions(IConfiguration configuration) : IConfigureNamedOptions<JwtBearerOptions>
  {
    private const string ConfigurationSectionName = "JwtBearer";

    public void Configure(string? name, JwtBearerOptions options)
    {
      Configure(options);
    }

    public void Configure(JwtBearerOptions options)
    {
      configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
  }
}
