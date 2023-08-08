using Zenject;

namespace EventBusPattern
{
    public class TurnPipelineInstaller : IInitializable
    {
        [Inject] private TurnTaskPipeline _turnTaskPipeline;
        [Inject] private DiContainer _container;
        
        public void Initialize()
        {
            _turnTaskPipeline.AddTask(new StartTask());
            _turnTaskPipeline.AddTask(_container.Instantiate<PlayerInputTask>());
            _turnTaskPipeline.AddTask(new FinishTask());
        }
    }
}