using api.Models.Enums;

namespace api.Dto.Users {
    public class UsersDto {
        public Guid UserId { get; set; }        
        public string? FullName { get; set; }
        public string? DOB { get; set; }
        public string? Gender { get; set; }
        public string? MobPhone { get; set; }
        public required string Email { get; set; }
        public bool? EmailVerified { get; set; }
        public string? EmailVerToken { get; set; }
        public required AuthMethodType AuthMethod { get; set; }
        public string? SocialId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }

}