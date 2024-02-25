using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMediator : MonoBehaviour
{
    [SerializeField] private CharacterInteractions _characterInteractions;
    [SerializeField] private GameUI _gameUI;
    [SerializeField] private DefeatPanel _defeatPanel;

    private void Awake()
    {
        _defeatPanel.Initialize(this);
        _gameUI.ChangeHpText(_characterInteractions.Hp);
        _gameUI.ChangeScoreText(_characterInteractions.Score);

        IInteractable[] interactables = FindObjectsOfType<MonoBehaviour>().OfType<IInteractable>().ToArray();
        foreach (var interactable in interactables) 
            interactable.Initialize(this);
        
    }

    private void OnEnable()
    {
        _characterInteractions.Defeat += OnDefeat;
    }

    private void OnDisable()
    {
        _characterInteractions.Defeat -= OnDefeat;
    }

    public void ChangeHp(int amount)
    {
        _characterInteractions.ChangeHP(amount);
        _gameUI.ChangeHpText(_characterInteractions.Hp);
    }

    public void ChangeScore(int amount)
    {
        _characterInteractions.ChangeScore(amount);
        _gameUI.ChangeScoreText(_characterInteractions.Score);
    }

    public void Restart()
    {
        _characterInteractions.Revive();
        _defeatPanel.Hide();
        _gameUI.Show();
        _gameUI.ChangeHpText(_characterInteractions.Hp);
        _gameUI.ChangeScoreText(_characterInteractions.Score);
    }

    void OnDefeat()
    {
        _defeatPanel.Show();
        _gameUI.Hide();
    }
}
