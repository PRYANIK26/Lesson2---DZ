using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FastRunningState : RunningState
{
    private FastRunningStateConfig _config;
    public FastRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.FastRunningStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;
        View.SetSpeed(_config.AnimatorSpeed);
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();
        Input.Movement.IsFast.canceled += OnFastRunKeyReleased;
    }
    
    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();
        Input.Movement.IsFast.started -= OnFastRunKeyReleased;
    }
    
    private void OnFastRunKeyReleased(InputAction.CallbackContext obj)
    {
        StateSwitcher.SwitchState<RunningState>();
    }

}
