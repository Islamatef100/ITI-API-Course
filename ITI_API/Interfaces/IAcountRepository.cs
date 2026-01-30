using ITI_API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ITI_API.Interfaces
{
    public interface IAcountRepository
    {
        public Task<string?> LoginAsync(LogInDTO user);   
    }
}
