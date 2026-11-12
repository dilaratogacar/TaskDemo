
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITaskService> _taskService;
        private readonly Lazy<ICategoriesService> _categoriesService;
        private readonly Lazy<IStatusService> _statusService;


        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _taskService = new Lazy<ITaskService>(() => new TaskManager(repositoryManager));
            _categoriesService = new Lazy<ICategoriesService>(() => new CategoriesManager(repositoryManager));
            _statusService = new Lazy<IStatusService>(() => new StatusManager(repositoryManager));

        }
        public ITaskService TaskService => _taskService.Value;
        public ICategoriesService CategoriesService => _categoriesService.Value;
        public IStatusService StatusService => _statusService.Value;

    }
}
