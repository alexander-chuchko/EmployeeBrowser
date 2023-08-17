namespace BSATask.Common.MappingProfiles
{
    public class TaskProfile : AutoMapper.Profile
    {
        public TaskProfile()
        {
            CreateMap<DAL.Entities.Task, DTO.TaskDTO>();

            CreateMap<DTO.TaskDTO, DAL.Entities.Task>();
        }
    }
}
