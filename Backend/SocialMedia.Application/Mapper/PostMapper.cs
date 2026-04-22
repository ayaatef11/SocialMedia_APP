using SocialMedia.Core.Domain.DTOs.Responses;
using AutoMapper;
using SocialMedia.Core.Domain.Entities.Business.Profiles;
namespace SocialMedia.API.Mapper;
public class PostMapper : Profile
{
    public PostMapper()
    {
        CreateMap<Post, PostResponse>();
        CreateMap<Follow, FollowResponse>(); 
        CreateMap<User, UserResponse>();
        CreateMap<UserProfile, ProfileResponse>();
    }
}

