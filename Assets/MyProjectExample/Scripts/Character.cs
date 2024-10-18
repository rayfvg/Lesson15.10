using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [SerializeField] private PlayerView _playerViev;

    [SerializeField] private int _maxHealth;

    [SerializeField] private GameObject _flagPrefab;

    [SerializeField] private float _timeToStartIdle;
    [SerializeField] private int _timeToChanchePoint;
    [SerializeField] private float _radiusPositions;

    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private UserInput _userInput;

    public Health Health { get; private set; }
    public Movement Movement { get; private set; }
    public BoringBehavior BoringBehavior { get; private set; }

    private void Update()
    {
        float time = 0;
        time += Time.deltaTime;

        if (_timeToStartIdle > time)
        {
            if (_userInput.StopIdleBehavior())
                return;

            BoringBehavior.Idle();
        }
    }

    public void Initialization()
    {
        Health = new Health(_playerViev, _maxHealth);
        Movement = new Movement(_agent, _flagPrefab, transform, _playerViev);
        BoringBehavior = new BoringBehavior(transform, _timeToChanchePoint, _radiusPositions, _agent);
    }
}