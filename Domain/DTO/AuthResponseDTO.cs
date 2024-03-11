using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AuthResponseDTO
    {
        private string tokenString;

        public AuthResponseDTO(string tokenString)
        {
            this.tokenString = tokenString;
        }

        public string Token { get; set; }
    }
}
