using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class UserInput : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private GameObject _flagForClick;
    [SerializeField] private Viev _playerViev;

    private const int LeftMouseButton = 0;
    private Movement _movement;

    private void Awake()
    {
        _movement = new Movement(_navMeshAgent, _flagForClick, transform);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            _movement.Walk();
        }
        if (_movement.UpdateWalkToFlag())
        {
            _playerViev.StartRunning();
        }
        else
        {
            _playerViev.StopRunning();
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
    }
}