using System.ComponentModel.DataAnnotations.Schema;
using api.Models.Enums;

namespace api.Models
{
    [Table("users")]
    public class User
    {
        [Column("user_id")]
        public Guid UserId { get; set; }
        
        [Column("full_name")]
        public string FullName { get; set; }
        
        [Column("dob")]
        public string DOB { get; set; }
        
        [Column("gender")]
        public string Gender { get; set; }
        
        [Column("mob_phone")]
        public string MobPhone { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
        
        [Column("email_ver")]
        public bool EmailVerified { get; set; }
        
        [Column("email_ver_token")]
        public string EmailVerToken { get; set; }
        
        [Column("passwd")]
        public string Passwd { get; set; }
        
        [Column("auth_method", TypeName = "users_authmethod_type")]
        public AuthMethodType AuthMethod { get; set; }
        
        [Column("social_id")]
        public string SocialId { get; set; }
        
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User()
        {
            FullName = string.Empty;
            DOB = string.Empty;
            Gender = string.Empty;
            MobPhone = string.Empty;
            Email = string.Empty;
            EmailVerToken = string.Empty;
            Passwd = string.Empty;
            AuthMethod = AuthMethodType.LOCAL;
            SocialId = string.Empty;
        }
    }
}
