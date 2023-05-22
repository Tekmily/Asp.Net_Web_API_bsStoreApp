
using System.ComponentModel.DataAnnotations;


namespace Entities.DataTransferObjects
{
    public record class UserForRegistrationDto
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }

        [Required(ErrorMessage ="UserName İs Required.")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password İs Required.")]
        public string? Password { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public ICollection<string>? Roles { get; init; }

    }
}
