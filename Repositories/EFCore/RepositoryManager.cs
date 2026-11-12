using Repositories.Contracts;
using Repositories.EFCore;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;

    private readonly ITaskRepository _taskRepository;
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IStatusRepository _statusRepository;


    public RepositoryManager(RepositoryContext context,
                             ITaskRepository taskRepository,
                             ICategoriesRepository categoriesRepository,
                             IStatusRepository statusRepository)
    {
        _context = context;
        _taskRepository = taskRepository;
        _categoriesRepository = categoriesRepository;
        _statusRepository = statusRepository;
    }
    public ITaskRepository Task => _taskRepository;
    public ICategoriesRepository Categories => _categoriesRepository;
    public IStatusRepository Status => _statusRepository;


    public void Save() => _context.SaveChanges();
}