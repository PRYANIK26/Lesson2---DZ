using UnityEngine;

namespace Part1
{
    public class ChillingState : MovementState
    {
        public ChillingState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Чиллю");
        }

        public override void Update()
        {
            base.Update();
            if (Input.GetKeyDown(KeyCode.W))
            {
                StateSwitcher.SwitchState<WalkingToWorkState>();
            }
        }
    }
}
