using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;

    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    [SerializeField] private TextView _textView;
    
    [SerializeField] private int _maxHealth;

    [SerializeField] private GameObject _flagPrefab;

    [SerializeField] private float _timeToStartIdle;
    [SerializeField] private int _timeToChanchePoint;
    [SerializeField] private float _radiusPositions;

    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private MonoBehaviour _context;
    [SerializeField] private float _jumpDuration;

    [SerializeField] private Character _playerPrefab;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private Character _player;

    [SerializeField] private AudioManager _audioExample;

    private Coroutine _jumpCorotine;

    private NavMeshAgent _agent;
    private PlayerView _playerView;
    private Health Health;
    private Movement Movement;
    private BoringBehavior BoringBehavior;

    private void Awake()
    {
        _textView.UpdateText(_maxHealth);
    }

    private void Update()
    {
        if (_userInput.StartGame())
            SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _player = Instantiate(_playerPrefab, _spawnPoint.position, Quaternion.identity);

        _virtualCamera.Follow = _player.transform;

        _playerView = _player.GetComponentInChildren<PlayerView>();
        _agent = _player.GetComponent<NavMeshAgent>();

        Health = new Health(_playerView, _textView, _maxHealth);
        Movement = new Movement(_agent, _flagPrefab, _player.transform, _playerView, _jumpCurve, _context, _jumpDuration, _audioExample);
        BoringBehavior = new BoringBehavior(_player.transform, _timeToChanchePoint, _radiusPositions, _agent);

        _player.Initialize(Health, Movement, BoringBehavior);
    }
}