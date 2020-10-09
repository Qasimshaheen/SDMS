using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ExtensionMethods
{
    public static class SDMSExtensions
    {

        public static string GenerateNextCode(this string code, string identifier)
        {
            if (string.IsNullOrEmpty(code))
                return $"{identifier}-000001";

            var newProductCode = Convert.ToInt32(code.Split(new char[] { '-' })[1]) + 1;

            return $"{identifier}-{newProductCode.ToString().PadLeft(6, '0')}";
        }
    }
}
