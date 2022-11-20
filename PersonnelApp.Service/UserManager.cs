using PersonnelApp.Data.UOW;
using PersonnelApp.Entities;
using PersonnelApp.Model.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp.Service
{
    public class UserManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public UserManager()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void Insert(AddUserInput addUserInput)
        {
            User user = new();
            user.Username = addUserInput.Username;
            user.Password = addUserInput.Password;
            user.RoleId = addUserInput.RoleId;
            user.CreatedBy = 0;
            user.CreatedDate = DateTime.Now;
            user.IsDeleted = false;
            _unitOfWork.user.Add(user);
            _unitOfWork.SaveChanges();
        }

        public CheckUserResponseDto LoginCheck (LoginUserDto loginUserDto)
        {
            User user = _unitOfWork.user.Get(u => u.Username == loginUserDto.Username && u.Password == loginUserDto.Password);
            Role role = _unitOfWork.role.Get(r => r.Id == user.RoleId);
            CheckUserResponseDto checkUserResponseDto = new();
            checkUserResponseDto.Username = user.Username;
            checkUserResponseDto.Role = role.Definition;
            checkUserResponseDto.IsExist = false;
            checkUserResponseDto.Id = user.Id;
            return checkUserResponseDto;
        }
    }
}
