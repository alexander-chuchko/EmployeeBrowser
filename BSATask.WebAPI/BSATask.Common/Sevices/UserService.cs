using AutoMapper;
using BSATask.Common.DTO;
using BSATask.Common.Interface;
using BSATask.DAL.Entities;
using BSATask.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace BSATask.Common.Sevices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO> AddUserAsync(UserDTO userDTO)
        {
            if (userDTO is not null)
            {
                var user = _mapper.Map<User>(userDTO);
                await _unitOfWork.Users.InsertAsync<User>(user);
                await _unitOfWork.CommitAsync();

                var allUsers = await _unitOfWork.Users.GetAllAsync<User>();
                var lastAddedUser = allUsers.LastOrDefault();

                return _mapper.Map<UserDTO>(lastAddedUser);
            }

            return null;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            UserDTO userDTO = null;

            var users = await _unitOfWork.Users.GetAllAsync<User>();
            var findedByIdUser = users.FirstOrDefault(v => v.Id == id);

            if (findedByIdUser is not null)
            {
                userDTO = _mapper.Map<UserDTO>(findedByIdUser);
            }

            return userDTO;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            IEnumerable<UserDTO> usersDTO = null;
            var users = await _unitOfWork.Users.GetAllAsync<User>();
            usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);

            return usersDTO;
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            var foundUser = await GetUserByIdAsync(userDTO.Id);
            if (foundUser is not null)
            {
                var user = _mapper.Map<User>(userDTO);
                await _unitOfWork.Users.UpdateAsync<User>(user);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user is not null)
            {
                await _unitOfWork.Users.DeleteAsync<User>(id);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}