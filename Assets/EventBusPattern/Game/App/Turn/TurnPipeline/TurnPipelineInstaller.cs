using Zenject;

namespace EventBusPattern
{
    public class TurnPipelineInstaller : IInitializable
    {
        [Inject] private TaskPipeline _taskPipeline;
        [Inject] private DiContainer _container;
        
        public void Initialize()
        {
            _taskPipeline.AddTask(new StartTask());
            _taskPipeline.AddTask(_container.Instantiate<PlayerInputTask>());
            _taskPipeline.AddTask(_container.Instantiate<EnemyMoveTask>());
            _taskPipeline.AddTask(_container.Instantiate<VisualTask>());
            _taskPipeline.AddTask(new FinishTask());
        }
    }
}