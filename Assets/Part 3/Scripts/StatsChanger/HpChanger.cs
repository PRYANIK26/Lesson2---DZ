using UnityEngine;

public class HpChanger : MonoBehaviour, IInteractable
{
    [SerializeField] private int _amount;
    private GameplayMediator _mediator;

    public void Initialize(GameplayMediator gameplayMediator)
    {
        _mediator = gameplayMediator;
    }
    
    public void Interact()
    {
        _mediator.ChangeHp(_amount);
    }

}
