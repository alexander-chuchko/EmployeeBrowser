using BSATask.Common.DTO;

namespace BSATask.Common.Interface
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDTO>> GetTeamsAsync();
        Task<TeamDTO> GetTeamByIdAsync(int id);

        Task<TeamDTO> AddTeamAsync(TeamDTO teamDTO);

        Task UpdateTeamAsync(DTO.TeamDTO teamDTO);

        Task DeleteTeamAsync(int id);
    }
}
