using AutoMapper;
using BSATask.Common.DTO;
using BSATask.Common.Interface;
using BSATask.DAL.Interfaces;

namespace BSATask.Common.Sevices
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamDTO>> GetTeamsAsync()
        {
            IEnumerable<TeamDTO> teamsDTO = null;
            var teams = await _unitOfWork.Teams.GetAllAsync<DAL.Entities.Team>();
            teamsDTO = _mapper.Map<IEnumerable<TeamDTO>>(teams);

            return teamsDTO;
        }

        public async Task<TeamDTO> AddTeamAsync(TeamDTO teamDTO)
        {
            if (teamDTO is not null)
            {
                var team = _mapper.Map<DAL.Entities.Team>(teamDTO);
                await _unitOfWork.Teams.InsertAsync<DAL.Entities.Team>(team);
                await _unitOfWork.CommitAsync();

                var allTeams = await _unitOfWork.Teams.GetAllAsync<DAL.Entities.Team>();
                var lastAddedTeam = allTeams.LastOrDefault();

                return _mapper.Map<TeamDTO>(lastAddedTeam);
            }

            return null;
        }

        public async Task<TeamDTO> GetTeamByIdAsync(int id)
        {
            TeamDTO teamDTO = null;

            var teams = await _unitOfWork.Teams.GetAllAsync<DAL.Entities.Team>();
            var findedByIdTeam = teams.FirstOrDefault(v => v.Id == id);

            if (findedByIdTeam is not null)
            {
                teamDTO = _mapper.Map<TeamDTO>(findedByIdTeam);
            }

            return teamDTO;
        }

        public async Task UpdateTeamAsync(TeamDTO teamDTO)
        {
            var foundTeam = await GetTeamByIdAsync(teamDTO.Id);
            if (foundTeam is not null)
            {
                var team = _mapper.Map<DAL.Entities.Team>(teamDTO);
                await _unitOfWork.Teams.UpdateAsync<DAL.Entities.Team>(team);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteTeamAsync(int id)
        {
            var team = await GetTeamByIdAsync(id);
            if (team is not null)
            {
                await _unitOfWork.Teams.DeleteAsync<DAL.Entities.Team>(id);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
