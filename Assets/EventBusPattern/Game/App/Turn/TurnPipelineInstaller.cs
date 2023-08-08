using Zenject;

namespace EventBusPattern
{
    public class TurnPipelineInstaller : IInitializable
    {
        [Inject] private TurnTaskPipeline _turnTaskPipeline;
        
        public void Initialize()
        {
            _turnTaskPipeline.AddTask(new StartTurnTask());
            _turnTaskPipeline.AddTask(new FinishTurnTask());
        }
    }
}