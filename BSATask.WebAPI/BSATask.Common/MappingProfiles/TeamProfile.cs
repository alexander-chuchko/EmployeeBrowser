using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSATask.Common.MappingProfiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<DAL.Entities.Team, DTO.TeamDTO>();

            CreateMap<DTO.TeamDTO, DAL.Entities.Team>();
        }
    }
}
