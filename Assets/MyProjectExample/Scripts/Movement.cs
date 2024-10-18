using UnityEngine;
using UnityEngine.AI;

public class Movement
{
    private NavMeshAgent _agent;
    private GameObject _cursorPrefab;
    private Transform _transform;
    private PlayerView _playerViev;

    private RaycastHit _hitInfo;
    private GameObject _flag;

    private bool _isWalking = false;

    public Movement(NavMeshAgent agent, GameObject cursorPrefab, Transform transform, PlayerView playerViev)
    {
        _agent = agent;
        _cursorPrefab = cursorPrefab;
        _transform = transform;
        _playerViev = playerViev;
    }

    public void Walk()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hitInfo))
        {
            NavMeshPath pathToTarget = new NavMeshPath();

            if (CalculatePath.GetPath(_agent, _hitInfo.point, pathToTarget))
            {
                _agent.SetDestination(_hitInfo.point);

                if (_flag != null)
                    Object.Destroy(_flag);

                _flag = Object.Instantiate(_cursorPrefab, _hitInfo.point, Quaternion.identity);
            }
            
        }
    }


    public bool UpdateWalkToFlag()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance && !_agent.pathPending)
        {
            if (!_isWalking)
                return false;

            _agent.isStopped = true;
            Debug.Log("I stay");
            _playerViev.StopRunning();

            _isWalking = false;
            return false;
        }
        else
        {
            if (_isWalking == false)
            {
                _agent.isStopped = false;
                _isWalking = true;
                _playerViev.StartRunning();
            }

            return true;
        }
    }
}