using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class StartGame : MonoBehaviour
{
    [SerializeField]  private UserInput _userInput;

    [SerializeField] CinemachineVirtualCamera _virtualCamera;

    [SerializeField] private TextView _textView;
    private PlayerView _playerView;

    [SerializeField] private int _maxHealth;

    [SerializeField] private GameObject _flagPrefab;

    [SerializeField] private float _timeToStartIdle;
    [SerializeField] private int _timeToChanchePoint;
    [SerializeField] private float _radiusPositions;

    private NavMeshAgent _agent;

    [SerializeField] private Character _playerPrefab;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private Character _player;

    public Health Health { get; private set; }
    public Movement Movement { get; private set; }
    public BoringBehavior BoringBehavior { get; private set; }

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
        Movement = new Movement(_agent, _flagPrefab, transform, _playerView);
        BoringBehavior = new BoringBehavior(_player.transform, _timeToChanchePoint, _radiusPositions, _agent);

        _player.Initialize(Health, Movement, BoringBehavior);
    }
}