using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WalkingState : GroundedState
{
    private WalkingStateConfig _config;
    
    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.WalkingStateConfig;
    }


    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;
        View.StartRunning();
        View.SetSpeed(_config.AnimatorSpeed);
    }

    public override void Exit()
    {
        base.Exit();
        
        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();
        if (IsHorizontalInputZero())
        {
            StateSwitcher.SwitchState<IdlingState>();
        }
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();
        Input.Movement.IsSlow.canceled += OnSlowKeyReleased;
    }
    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();
        Input.Movement.IsSlow.canceled -= OnSlowKeyReleased;
    }
    private void OnSlowKeyReleased(InputAction.CallbackContext obj)
    {
        StateSwitcher.SwitchState<RunningState>();
    }
}
