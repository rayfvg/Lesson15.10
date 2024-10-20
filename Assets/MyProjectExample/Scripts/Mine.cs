using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _timeToExplosion;
    [SerializeField] private float _rangeToExplosion;
    [SerializeField] private float _rangeToDetected;

    [SerializeField] private int _damage;

    private PlayerView _view;

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<UserInput>() != null)
        {
            _timeToExplosion -= Time.deltaTime;

            if ( _timeToExplosion <= 0)
            {
                Collider[] targets = Physics.OverlapSphere(transform.position, _rangeToExplosion);

                foreach(Collider target in targets)
                {
                    Character player = target.GetComponent<Character>();

                    if (player != null)
                    {
                        player.Health.TakeDamage(_damage);
                        _view = FindObjectOfType<PlayerView>();
                        _view.SpawnExplosion(this.transform);
                        Destroy(gameObject);
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