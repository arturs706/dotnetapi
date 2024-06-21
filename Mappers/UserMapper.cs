
using api.Dto;
using api.Dto.Users;
using api.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace api.Mappers 
{
    public static class UserMapper 
    {
        public static UsersDto ToUserDto(this User userModel)
        {
            return new UsersDto 
            {
                UserId = userModel.UserId,
                FullName = userModel.FullName,
                DOB = userModel.DOB,
                Gender = userModel.Gender,
                MobPhone = userModel.MobPhone,
                Email = userModel.Email,
                EmailVerified = userModel.EmailVerified,
                EmailVerToken = userModel.EmailVerToken,
                AuthMethod = userModel.AuthMethod,
                SocialId = userModel.SocialId,
                CreatedAt = userModel.CreatedAt
            };

        }

        public static UpdateUserReq ToUpdateUserReq(this User userModel)
        {
            return new UpdateUserReq
            {
                FullName = userModel.FullName,
                DOB = userModel.DOB,
                Gender = userModel.Gender
            };
        }
            
    }
}