using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.DTO.DTOs.Responses
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TimeExpired { get; set; }

        public TokenResponse(string token, string refreshToken, DateTime timeExpired)
         {
            Token = token;
            RefreshToken = refreshToken;
            TimeExpired = timeExpired;
        }
   }
}
