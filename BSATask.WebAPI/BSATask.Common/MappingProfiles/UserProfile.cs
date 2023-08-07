namespace BSATask.Common.MappingProfiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<DAL.Entities.User, DTO.UserDTO>();

            CreateMap<DTO.UserDTO, DAL.Entities.User>();
        }
    }
}
