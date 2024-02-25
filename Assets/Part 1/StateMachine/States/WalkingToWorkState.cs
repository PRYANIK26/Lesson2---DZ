using UnityEngine;

namespace Part1
{
    public class WalkingToWorkState : WalkingState
    {
        public WalkingToWorkState(IStateSwitcher stateSwitcher, Character character) : base(stateSwitcher, character)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Target = Character.WalkPoints[1];
            Debug.Log("Иду на завод");
        }

        public override void Update()
        {
            base.Update();
            if (Direction.magnitude <= MinDistance)
            {
                StateSwitcher.SwitchState<WorkingState>();
            }
        }
    }
}
