using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.interfaces
{    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId,int likeUserId);
        Task<AppUser> GetUserWithLikes(int userId);
        Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);
    }
}