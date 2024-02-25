using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    public void ChangeHpText(int hp) => _hpText.text = $"Hp: {hp}";
    public void ChangeScoreText(int score) => _scoreText.text = $"Score: {score}";
    
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
    
}
