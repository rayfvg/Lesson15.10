using UnityEngine;
using UnityEngine.AI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;

    [SerializeField] private TextView _textView;

    [SerializeField] private int _maxHealth;

    [SerializeField] private GameObject _flagPrefab;

    [SerializeField] private float _timeToStartIdle;
    [SerializeField] private int _timeToChanchePoint;
    [SerializeField] private float _radiusPositions;

    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private Character _playerPrefab;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField]  private Character _player;

    private void Awake()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        _player = Instantiate(_playerPrefab);
        _player.transform.position = _spawnPoint.position;
        _player.Initialization(_textView, _maxHealth, _agent, _flagPrefab, _timeToChanchePoint, _radiusPositions);
    }
}