using BookingApp.Business.Operations.Users.Dtos;
using BookingApp.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Business.Operations.Users
{
    public interface IUserService
    {
        Task<ServiceMessage> AddUser(AddUserDto user);
        ServiceMessage<UserInfoDto> LoginUser(LoginUserDto user);
    }
}
