using UnityEngine;
using UnityEngine.UI;

public class DefeatPanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    private GameplayMediator _mediator;

    public void Initialize(GameplayMediator mediator)
    {
        _mediator = mediator;
    }
    
    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);
    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartClick);
    }
    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartClick);
    }

    private void OnRestartClick()
    {
        _mediator.Restart();
    }

}
