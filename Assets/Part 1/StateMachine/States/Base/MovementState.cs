using UnityEngine;

namespace Part1
{

    public abstract class MovementState : IState
    {
        protected IStateSwitcher StateSwitcher;

        protected MovementState(IStateSwitcher stateSwitcher)
        {
            StateSwitcher = stateSwitcher;
        }

        public virtual void Enter()
        {
            Debug.Log(GetType());
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
        }
    }
}
