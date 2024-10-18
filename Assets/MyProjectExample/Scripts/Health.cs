
public class Health
{
    private PlayerView _playerViev;
    private TextView _textView;
    private int _maxHealth;

    private int _currentHealth;

    public int GetHealth => _maxHealth;
    public int GetCurrentHealth => _currentHealth;

    public Health(PlayerView playerViev, TextView textView, int maxHealth)
    {
        _playerViev = playerViev;
        _textView = textView;
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(damage < 0)
            return;

        _currentHealth -= damage;
        _textView.UpdateText(_currentHealth);
        _playerViev.TakeDamageAnimation();

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            _playerViev.DieAnimation();
        }
    }
}