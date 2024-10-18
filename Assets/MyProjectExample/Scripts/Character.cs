using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [SerializeField] private PlayerView _playerViev;
    [SerializeField] private TextView _textView;

    [SerializeField] private int _maxHealth;

    [SerializeField] private GameObject _flagPrefab;

    [SerializeField] private float _timeToStartIdle;
    [SerializeField] private int _timeToChanchePoint;
    [SerializeField] private float _radiusPositions;

    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private UserInput _userInput;

    public float Timer;

    public Health Health { get; private set; }
    public Movement Movement { get; private set; }
    public BoringBehavior BoringBehavior { get; private set; }

    private void Update()
    {
        Timer += Time.deltaTime;

        if (_timeToStartIdle < Timer)
        {
            BoringBehavior.Idle();
            _userInput.StopIdleBehavior(); 
        }
    }

    public void Initialization()
    {
        Health = new Health(_playerViev, _textView, _maxHealth);
        Movement = new Movement(_agent, _flagPrefab, transform, _playerViev);
        BoringBehavior = new BoringBehavior(transform, _timeToChanchePoint, _radiusPositions, _agent);
    }
}