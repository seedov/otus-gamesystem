using System;
using VContainer;

namespace Lessons.Architecture.VContainer
{
    public class GameController : IDisposable
    {
        private GameEventsDispatcher gameEventsDispatcher;
        private IHealthComponent healthComponent;

        public GameController(GameEventsDispatcher gameEventsDispatcher, IHealthComponent healthComponent)
        {
            this.gameEventsDispatcher = gameEventsDispatcher;
            this.healthComponent = healthComponent;
            this.healthComponent.HpChanged += HealthComponent_HpChanged;
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

        void IDisposable.Dispose()
        {
            this.healthComponent.HpChanged -= HealthComponent_HpChanged;
        }
    }
}