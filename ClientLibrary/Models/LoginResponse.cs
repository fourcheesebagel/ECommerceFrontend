﻿namespace ClientLibrary.Models
{
    public record LoginResponse
        (bool Success = false, 
        string Message = null!,
        string Token = null!,
        string RefreshToken = null!);
}
