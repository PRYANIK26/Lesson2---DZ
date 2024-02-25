using UnityEngine;

namespace Part1
{
    public class WalkingState : MovementState
    {
        public Character Character;
        public Transform Target;
        public Vector3 Direction;
        protected float MinDistance = 0.05f;

        public WalkingState(IStateSwitcher stateSwitcher, Character character) : base(stateSwitcher)
        {
            Character = character;
        }

        public override void Update()
        {
            base.Update();

            Direction = Target.position - Character.transform.position;
            Character.transform.Translate(Direction.normalized * Character.Speed * Time.deltaTime);
        }
    }
}
