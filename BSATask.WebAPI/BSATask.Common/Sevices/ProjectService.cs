using AutoMapper;
using BSATask.Common.DTO;
using BSATask.Common.Interface;
using BSATask.DAL.Interfaces;
using BSATask.DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace BSATask.Common.Sevices
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjectsAsync()
        {
            IEnumerable<ProjectDTO> projectsDTO = null;
            var projects = await _unitOfWork.Projects.GetAllAsync<Project>();
            projectsDTO = _mapper.Map<IEnumerable<ProjectDTO>>(projects);

            return projectsDTO;
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int id)
        {
            ProjectDTO projectDTO = null;

            var projects = await _unitOfWork.Projects.GetAllAsync<Project>();
            var findedByIdProject = projects.FirstOrDefault(p => p.Id == id);

            if (findedByIdProject is not null)
            {
                projectDTO = _mapper.Map<ProjectDTO>(findedByIdProject);
            }

            return projectDTO;
        }

        public async Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDTO)
        {
            if (projectDTO is not null)
            {
                var project = _mapper.Map<DAL.Entities.Project>(projectDTO);
                await _unitOfWork.Projects.InsertAsync<Project>(project);
                await _unitOfWork.CommitAsync();
                var allProjects = await _unitOfWork.Projects.GetAllAsync<Project>();
                var lastAddedTeam = allProjects.LastOrDefault();

                return _mapper.Map<ProjectDTO>(lastAddedTeam);
            }

            return null;
        }

        public async Task UpdateProjectAsync(ProjectDTO projectDTO)
        {
            var foundProject = await GetProjectByIdAsync(projectDTO.Id);
            if (foundProject is not null) 
            {
                var project = _mapper.Map<Project>(projectDTO);
                await _unitOfWork.Projects.UpdateAsync<Project>(project);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await GetProjectByIdAsync(id);
            if (project is not null)
            {
                await _unitOfWork.Projects.DeleteAsync<Project>(id);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}