using UnityEngine;
using UnityEngine.AI;

public class Movement
{
    private NavMeshAgent _agent;
    private GameObject _cursorPrefab;
    private Transform _transform;

    private RaycastHit _hitInfo;
    private GameObject _flag;

    private bool _isWalking = false;

    public Movement(NavMeshAgent agent, GameObject cursorPrefab, Transform transform)
    {
        _agent = agent;
        _cursorPrefab = cursorPrefab;
        _transform = transform;
    }

    public void Walk()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hitInfo))
        {
            NavMeshPath pathToTarget = new NavMeshPath();

            if (GetPath(pathToTarget))
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

            _isWalking = false;
            return false;
        }
        else
        {
            if (_isWalking == false)
            {
                _agent.isStopped = false;
                _isWalking = true;
            }

            return true;
        }
    }

    public bool GetPath(NavMeshPath pathToTarget)
    {
        pathToTarget.ClearCorners();

        if (_agent.CalculatePath(_hitInfo.point, pathToTarget) && pathToTarget.status != NavMeshPathStatus.PathInvalid)
            return true;

        Debug.Log("I can't get in there.");
        return false;
    }
}