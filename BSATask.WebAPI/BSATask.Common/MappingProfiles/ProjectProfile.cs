using AutoMapper;

namespace BSATask.Common.MappingProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile ()
        {
            CreateMap<DAL.Entities.Project, DTO.ProjectDTO>();

            CreateMap<DTO.ProjectDTO, DAL.Entities.Project>();
        }
    }
}
