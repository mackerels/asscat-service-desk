using SD.Models.Constants;

namespace SD.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public UserModel Commentator { get; set; }
    }
}