using UnityEngine;

namespace Part1
{
    public class WorkingState : MovementState
    {
        private float _timer;
        private Character _character;

        public WorkingState(IStateSwitcher stateSwitcher, Character character) : base(stateSwitcher)
        {
            _character = character;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Работаю");
        }

        public override void Update()
        {
            base.Update();
            _timer += Time.deltaTime;
            if (_timer >= _character.WorkTime)
            {
                _timer = 0;
                StateSwitcher.SwitchState<WalkingToHomeState>();
            }
        }
    }
}
