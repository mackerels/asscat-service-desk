using System.Collections;
using System.Collections.Generic;
using SD.Models.Constants;

namespace SD.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public UserRole Role { get; set; }

        public string Email { get; set; }
        public string Login => Email;
        public string Password { get; set; }

        public IEnumerable<IssueModel> Issues { get; set; }
    }
}