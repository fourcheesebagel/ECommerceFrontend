namespace ClientLibrary.Models
{
    public record LoginResponse
        (bool Success = false, 
        string Message = null!, 
        string RefreshToken = null!);
}
