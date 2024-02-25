using System;
using UnityEngine;

public class CharacterInteractions : MonoBehaviour
{
    public event Action Defeat;
    
    [SerializeField] private int _hp;
    [SerializeField] private int _score;

    private Character _character;
    private int _startHp;
    private int _startScore;

    public int Hp => _hp;
    public int Score => _score;

    private void Awake()
    {
        _character = GetComponent<Character>();
        _startHp = _hp;
        _startScore = _score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact();
        }
    }

    public void ChangeHP(int amount)
    {
        _hp += amount;
        if (_hp <= 0)
            Die();
    }

    public void ChangeScore(int amount)
    {
        _score += amount;
    }

    public void Revive()
    {
        _hp = _startHp;
        _score = _startScore;
        _character.Revive();
    }

    void Die()
    {
        _character.Die();
        Defeat?.Invoke();
    }
}
