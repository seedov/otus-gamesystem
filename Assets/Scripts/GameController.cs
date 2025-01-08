using VContainer;

namespace Lessons.Architecture.VContainer
{
    public class GameController
    {
        private GameEventsDispatcher gameEventsDispatcher;
        private IHealthComponent healthComponent;

        [Inject]
        private void Construct(GameEventsDispatcher gameEventsDispatcher, IHealthComponent healthComponent)
        {
            this.gameEventsDispatcher = gameEventsDispatcher;
            this.healthComponent = healthComponent;
            healthComponent.HpChanged += HealthComponent_HpChanged;
        }

        private void HealthComponent_HpChanged(float hp)
        {
            if(hp == 0)
            {
                FinishGame();
            }
        }

        public void StartGame()
        {
            gameEventsDispatcher.StartGame();
        }

        public void PauseGame()
        {
            gameEventsDispatcher.PauseGame();
        }

        public void ResumeGame()
        {
            gameEventsDispatcher.ResumeGame();
        }

        public void FinishGame()
        {
            gameEventsDispatcher.FinishGame();
        }
    }
}