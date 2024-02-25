using UnityEngine;

namespace Part1
{
    public class WalkingToHomeState : WalkingState
    {
        public WalkingToHomeState(IStateSwitcher stateSwitcher, Character character) : base(stateSwitcher, character)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Target = Character.WalkPoints[0];
            Debug.Log("Иду домой");
        }

        public override void Update()
        {
            base.Update();
            if (Direction.magnitude <= MinDistance)
            {
                StateSwitcher.SwitchState<ChillingState>();
            }
        }

    }
}
