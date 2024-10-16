using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Viev _playerViev;
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public int GetMaxHealth => _maxHealth;
    public int GetHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(damage < 0)
            return;

        _currentHealth -= damage;
        _playerViev.UpdateText(_currentHealth);
        _playerViev.TakeDamageAnimation();

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            _playerViev.DieAnimation();
        }
    }
}