
namespace Part1
{
    public interface IStateSwitcher
    {
        void SwitchState<State>() where State : IState;
    }
}
