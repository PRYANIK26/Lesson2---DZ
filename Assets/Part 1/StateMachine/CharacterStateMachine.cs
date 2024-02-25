using System.Collections.Generic;
using System.Linq;

namespace Part1
{
    public class CharacterStateMachine : IStateSwitcher
    {
        private List<IState> _states;
        private IState _currentState;

        public CharacterStateMachine(Character character)
        {
            _states = new List<IState>()
            {
                new ChillingState(this),
                new WalkingToWorkState(this, character),
                new WorkingState(this, character),
                new WalkingToHomeState(this, character),
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<State>() where State : IState
        {
            IState state = _states.FirstOrDefault(state => state is State);

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Update() => _currentState.Update();
    }
}
