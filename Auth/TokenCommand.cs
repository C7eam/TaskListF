using Domain.Context;
using Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using ConfigurationManager = TaskListF.Auth.ConfigurationManager;

namespace TaskListF.Auth
{
    public class TokenCommand : IRequest<TokenCommandResponse>
    {
        public string Login { get; set; } = default!;
        public string Password { get; set; } = default!;
    }

    public class TokenCommandHandler : IRequestHandler<TokenCommand, TokenCommandResponse>
    {
        private readonly IConfiguration _config;
        private readonly ApplicationContext _applicationContext;

        public TokenCommandHandler(ApplicationContext context, IConfiguration config)
        {
            _applicationContext = context;
            _config = config;
        }

        public async Task<TokenCommandResponse> Handle(TokenCommand request, CancellationToken cancellationToken)
        {

            var user = await _applicationContext.Users.FirstAsync(u => u.Login == request.Login, cancellationToken);


            if (user is null || request.Password != user.Password)
            {
                throw new();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Key"]));
            var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: ConfigurationManager.AppSetting["JWT:Issuer"],
                audience: ConfigurationManager.AppSetting["JWT:Audience"],
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signinCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            await _applicationContext.Users
                .Where(p => p.Login == request.Login)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Token, tokenString), cancellationToken);


            return new TokenCommandResponse
            {
                AccessToken = tokenString
            };
        }
    }

    public class TokenCommandResponse
    {
        public string AccessToken { get; set; } = default!;
    }
}