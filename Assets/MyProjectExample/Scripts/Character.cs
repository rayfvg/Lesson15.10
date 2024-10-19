using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    private PlayerView _playerView;
    private TextView _textView;

    private int _maxHealth;

    private GameObject _flagPrefab;

    private float _timeToStartIdle;
    private int _timeToChanchePoint;
    private float _radiusPositions;

    private NavMeshAgent _agent;

    private IBehaviour _iBehaviourIdle;
    private IBehaviour _iBehaviourWalk;

    public Health Health { get; private set; }
    public Movement Movement { get; private set; }
    public BoringBehavior BoringBehavior { get; private set; }


    private void Awake()
    {
        _playerView = GetComponentInChildren<PlayerView>();
    }

    private void Start()
    {
        _textView.UpdateText(_maxHealth);
    }

    public void Initialization(TextView textView, int maxHealth, NavMeshAgent agent,
        GameObject flagPrefab, int timeToChanchePoint, float radiusPositions)
    {

        _textView = textView;
        _maxHealth = maxHealth;
        _agent = agent;
        _flagPrefab = flagPrefab;
        _timeToChanchePoint = timeToChanchePoint;
        _radiusPositions = radiusPositions;

        Health = new Health(_playerView, _textView, _maxHealth);
        Movement = new Movement(_agent, _flagPrefab, transform, _playerView);
        BoringBehavior = new BoringBehavior(transform, _timeToChanchePoint, _radiusPositions, _agent);
    }
}