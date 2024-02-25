using UnityEngine;

public class ScoreChanger : MonoBehaviour, IInteractable
{
    [SerializeField] private int _amount;
    private GameplayMediator _mediator;
    
    public void Initialize(GameplayMediator gameplayMediator)
    {
        _mediator = gameplayMediator;
    }
    
    public void Interact()
    {
        _mediator.ChangeScore(_amount);
    }
}
