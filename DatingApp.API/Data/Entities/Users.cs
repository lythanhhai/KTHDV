using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Data.Entities
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Username { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(32)]
        public string KnownAs { get; set; }

        [MaxLength(6)]
        public string Gender { get; set; }

        [MaxLength(256)]
        public string City { get; set; }

        [MaxLength(256)]
        public string Introduction { get; set; }

        [MaxLength(256)]
        public string Avatar { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}