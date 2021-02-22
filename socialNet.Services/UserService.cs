using AutoMapper;
using socialNet.Data.Models;
using socialNet.Dtos;
using socialNet.Dtos.RequestDtos;
using socialNet.Repsitories.Interfaces.IUnitOfWork;
using socialNet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.Services
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await _unitOfWork.Users.GetUserByUsernameAsync(username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Create(SignUpRequestDto userDto)
        {
            if (await _unitOfWork.Users.UserNameIsTaken(userDto.Username))
                throw new ArgumentException("UsernameTaken");

            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = _mapper.Map<User>(userDto);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.Users.DeleteUserByIdAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _unitOfWork.Users.GetAllUsersAsync());
        }

        public async Task<UserDto> GetById(int id)
        {
            return _mapper.Map<UserDto>(await _unitOfWork.Users.GetUserByIdAsync(id));
        }

        public async Task Update(UpdateUserRequestDto userDto)
        {
            var user = await _unitOfWork.Users.GetUserByUsernameAsync(userDto.Username);

            if (user == null)
                throw new ArgumentException("UserNotFound");

            if (!string.IsNullOrWhiteSpace(userDto.Password))
            {
                CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _unitOfWork.Users.Update(user);
            await _unitOfWork.CommitAsync();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("PasswordIsNull");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("EmptyOrWhitespacePassword");

            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("PasswordIsNull");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("EmptyOrWhitespacePassword");
            if (storedHash.Length != 64) throw new ArgumentException("InvalidPasswordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("InvalidPasswordSalt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public async Task<IEnumerable<string>> GetUsersByStringAsync(string usernameString)
        {
             return await _unitOfWork.Users.GetUsersByStringAsync(usernameString);
        }

        public async Task<IEnumerable<string>> GetAllUsersByStringAsync(string usernameString)
        {
            return await _unitOfWork.Users.GetAllUsersByStringAsync(usernameString);
        }
        public async Task<UserProfileDto> GetUserProfileAsync(string username)
        {
            return await _unitOfWork.Users.GetUserProfileAsync(username);
        }

        public async Task<MyProfileDto> GetMyProfileAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(userId);
            var userProfileInfo = await _unitOfWork.Users.GetUserProfileAsync(user.Username);
            var userInvitations = await _unitOfWork.Friendships.GetUserInvitations(user);

            return await Task.FromResult(new MyProfileDto(
                userProfileInfo.Username,
                userProfileInfo.FirstName,
                userProfileInfo.LastName,
                userProfileInfo.City,
                userProfileInfo.DateOfBirth,
                userProfileInfo.ProfilePicture,
                userInvitations
                ));
        }


    }
}

