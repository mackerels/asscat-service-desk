using System.Collections.Generic;
using SD.Models;

namespace SD.Storage
{
    public interface IServiceDeskStorage
    {
        IEnumerable<UserModel> Users { get; }
        IEnumerable<IssueModel> Issues { get; }
        IEnumerable<CommentModel> Comments { get; }
    }
}