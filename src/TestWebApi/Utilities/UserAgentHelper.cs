using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAParser;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace TestWebApi.Utilities
{
    internal static class UserAgentHelper
    {
        internal static void LogUserAgent (string path, string method, string uaString, ILogger logger)
        {
            var uaParser = Parser.GetDefault();

            ClientInfo c = uaParser.Parse(uaString);

            logger.LogInformation(String.Format("{0}({1})\n{2}", path, method, PrintProperties(c)));
        }

        private static string PrintProperties(object obj)
        {
            return PrintProperties(obj, 0);
        }
        private static string PrintProperties(object obj, int indent)
        {
            if (obj == null) return string.Empty;

            string indentString = new string(' ', indent);
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            string result = string.Empty;

            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);
                if (property.PropertyType.Assembly == objType.Assembly && !property.PropertyType.IsEnum)
                {
                    result += String.Format("\n{0}{1}:", indentString, property.Name);
                    result += PrintProperties(propValue, indent + 2);
                }
                else if (propValue != null)
                {
                    result += String.Format("\n{0}{1}: {2}", indentString, property.Name, propValue);
                }
            }

            return result;
        }
    }
}
