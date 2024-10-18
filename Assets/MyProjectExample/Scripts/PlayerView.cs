using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    private readonly int IsDieKey = Animator.StringToHash("Die");
    private readonly int IsTakeDamageKey = Animator.StringToHash("TakeDamage");

    [SerializeField] private Animator _animator;
    [SerializeField] private TMP_Text _healthText;

    [SerializeField] private Character _player;

    [SerializeField] private ParticleSystem _explosionParticle;

    private int _layerIndex = 1;
    private float _multiplay = 0.3f;

    private void Start()
    {
        UpdateText(_player.Health.GetHealth);
    }

    private void Update()
    {
        if(_player.Health.GetCurrentHealth <= _player.Health.GetHealth * _multiplay)
        {
            _animator.SetLayerWeight(_layerIndex, 1);
        }
    }

    public void StartRunning() => _animator.SetBool(IsRunningKey, true);

    public void StopRunning() => _animator.SetBool(IsRunningKey, false);

    public void UpdateText(int value) => _healthText.text = value.ToString();

    public void SpawnExplosion(Transform transform)
    {
        Instantiate(_explosionParticle, transform.position, Quaternion.identity);
    }

    public void TakeDamageAnimation() => _animator.SetTrigger(IsTakeDamageKey);
    
    public void DieAnimation() => _animator.SetTrigger(IsDieKey);
}