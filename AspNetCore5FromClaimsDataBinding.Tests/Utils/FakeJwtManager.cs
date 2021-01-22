using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AspNetCore5FromClaimsDataBinding.Tests.Utils
{
    public static class FakeJwtManager
    {
        public static string Issuer { get; } = Guid.NewGuid().ToString();
        public static string Audience { get; } = Guid.NewGuid().ToString();
        public static SigningCredentials SigningCredentials { get; }
        public static SecurityKey SecurityKey { get; }

        private static readonly RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
        private static readonly JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private static readonly byte[] s_key = new byte[32];

        static FakeJwtManager()
        {
            randomNumberGenerator.GetBytes(s_key);
            SecurityKey = new SymmetricSecurityKey(s_key) { KeyId = Guid.NewGuid().ToString() };
            SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
        }

        public static string GenerateJwtToken(IEnumerable<Claim> claims)
        {
            return jwtSecurityTokenHandler.WriteToken(new JwtSecurityToken(Issuer, null, claims, null, DateTime.UtcNow.AddMinutes(20), SigningCredentials));
        }
    }
}
