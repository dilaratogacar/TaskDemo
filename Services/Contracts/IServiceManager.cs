namespace Services.Contracts
{
    public interface IServiceManager
    {
        ITaskService TaskService { get; }
        ICategoriesService CategoriesService { get; }
        IStatusService StatusService { get; }

    }
}