using UnityEngine.InputSystem;

public class RunningState : GroundedState
{
    private RunningStateConfig _config;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig;

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
            StateSwitcher.SwitchState<IdlingState>();
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();
        Input.Movement.IsFast.started += OnFastRunKeyPressed;
        Input.Movement.IsSlow.started += OnSlowRunKeyPressed;
    }
    
    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();
        Input.Movement.IsFast.started -= OnFastRunKeyPressed;
        Input.Movement.IsSlow.started -= OnSlowRunKeyPressed;
    }
    
    private void OnFastRunKeyPressed(InputAction.CallbackContext obj)
    {
        StateSwitcher.SwitchState<FastRunningState>();
    }
    private void OnSlowRunKeyPressed(InputAction.CallbackContext obj)
    {
        StateSwitcher.SwitchState<WalkingState>();
    }
}
