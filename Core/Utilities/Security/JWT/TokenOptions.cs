using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public string Audience {  get; set; } //tokenın kulllanıcı kitlesi
        public string Issuer { get; set; } //imzalayan gibi düşün
        public int AccessTokenExpiration {  get; set; }
        public string SecurityKey { get; set; }
    }
}
