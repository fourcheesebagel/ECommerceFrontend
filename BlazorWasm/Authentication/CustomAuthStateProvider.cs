﻿using ClientLibrary.Helper;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlazorWasm.Authentication
{
    public class CustomAuthStateProvider(ITokenService tokenService) : AuthenticationStateProvider
    {
        private ClaimsPrincipal _anonymous = new(new ClaimsIdentity()); //default user not authenticated
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string jwt = await tokenService.GetJWTTokenAsync(Constant.Cookie.Name); //Get JWT from the cookie
            if (string.IsNullOrEmpty(jwt))
                return await Task.FromResult(new AuthenticationState(_anonymous)); //return if no jwt

            var claims = GetClaims(jwt);
            if (!claims.Any())
                return await Task.FromResult(new AuthenticationState(_anonymous));

            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            return await Task.FromResult(new AuthenticationState(claimPrincipal));
        }

        public void NotifyAuthenticationState()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        private static IEnumerable<Claim> GetClaims(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            return token.Claims.ToList();
        }
    }
}
