using System.Collections.Generic;
using SD.Models.Constants;

namespace SD.Models
{
    public class IssueModel
    {
        public int Id { get; set; }

        public string Name{get; set;}

        public string Memo { get; set; }

        public IssueStatus Status { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }

        public UserModel Issuer { get; set; }
        public UserModel Worker { get; set; }
    }
}