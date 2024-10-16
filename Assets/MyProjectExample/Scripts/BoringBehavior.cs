using UnityEngine;
using UnityEngine.AI;

public class BoringBehavior : MonoBehaviour
{
    private const int LeftMouseButton = 0;

    [SerializeField] private float _timeToStartIdle;

    [SerializeField] private int _timeToChanchePoint;
    [SerializeField] private float _radiusPositions;

    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private NavMeshAgent _agent;

    private Vector3 _randomDirection;
    private Movement _movement;

    private float _timeChangePoint;
    private float _timeForStartIdle;


    private void Update()
    {
        _timeForStartIdle += Time.deltaTime;

        if (_timeForStartIdle >= _timeToStartIdle)
        {
            Idle();  
        }

        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            _timeForStartIdle = 0;
        }
    }

    public void Idle()
    {
        _timeChangePoint += Time.deltaTime;

        if (_timeChangePoint >= _timeToChanchePoint)
        {
            _timeChangePoint = 0;

            NavMeshPath pathToTarget = new NavMeshPath();

            do
            {
                _randomDirection = Random.insideUnitSphere * _radiusPositions;
                _randomDirection += transform.position;
            }
            while (GetPath(pathToTarget) == false);

            _agent.SetDestination(_randomDirection);
        }
    }

    public bool GetPath(NavMeshPath pathToTarget)
    {
        pathToTarget.ClearCorners();

        if (_agent.CalculatePath(_randomDirection, pathToTarget) && pathToTarget.status != NavMeshPathStatus.PathInvalid)
            return true;

        Debug.Log("Invalid dot");
        return false;
    }
}
