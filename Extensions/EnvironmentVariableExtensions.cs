using System;
using Microsoft.Extensions.Configuration;

namespace Extensions
{
    public static class EnvironmentVariableExtensions
    {
        public static string GetConnectionStringFromEnvironment(this IConfiguration configuration, string name = null)
        {
            if(string.IsNullOrEmpty(name))
            {
                return Environment.GetEnvironmentVariable("CONNECTION_STRING_MYSQL");
            }
            else
            {
                return Environment.GetEnvironmentVariable(name);
            }
        }
    }
}
