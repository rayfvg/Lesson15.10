using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _timeToExplosion;
    [SerializeField] private float _rangeToExplosion;
    [SerializeField] private float _rangeToDetected;

    [SerializeField] AudioManager _audioExample;

    [SerializeField] private int _damage;

    private PlayerView _view;
    private bool _isDetonation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<UserInput>() != null)
        {
            Debug.Log("Я сдетонировала");
           _isDetonation = true;
            _audioExample.PreExplosion();
        }
    }

    private void Update()
    {
        if (_isDetonation == false)
            return;

        if (_isDetonation)
        {
            _timeToExplosion -= Time.deltaTime;
            if (_timeToExplosion <= 0)
            {
                Collider[] targets = Physics.OverlapSphere(transform.position, _rangeToExplosion);

                _view = FindObjectOfType<PlayerView>();
                _view.SpawnExplosion(this.transform);
                _audioExample.ExsplosionSound();
                Destroy(gameObject);

                foreach (Collider target in targets)
                {
                    Character player = target.GetComponent<Character>();

                    if (player != null)
                    {
                        player.Health.TakeDamage(_damage);
                        Debug.Log("Я нанесла урон");      
                    }
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        GetComponent<SphereCollider>().radius = _rangeToDetected;
        Gizmos.DrawWireSphere(transform.position, _rangeToDetected);
        Gizmos.DrawWireSphere(transform.position, _rangeToExplosion);
    }
}