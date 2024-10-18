
public class Health
{
    private PlayerView _playerViev;
    private int _maxHealth;

    private int _currentHealth;

    public int GetHealth => _maxHealth;
    public int GetCurrentHealth => _currentHealth;

    public Health(PlayerView playerViev, int maxHealth)
    {
        _playerViev = playerViev;
        _maxHealth = maxHealth;
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