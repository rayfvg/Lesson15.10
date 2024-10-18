using UnityEngine;
using UnityEngine.AI;

public class BoringBehavior
{
    private float _timeToStartIdle;

    private int _timeToChanchePoint;
    private float _radiusPositions;

    private NavMeshAgent _agent;

    private Vector3 _randomDirection;
    private Movement _movement;
    private Transform _transform;

    private float _timeChangePoint;
    private float _timeForStartIdle;

    public BoringBehavior(Transform transform, int timeToChanchePoint, float radiusPositions, NavMeshAgent agent)
    {
        _timeToChanchePoint = timeToChanchePoint;
        _radiusPositions = radiusPositions;
        _agent = agent;
        _transform = transform;
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
                _randomDirection += _transform.position;
            }
            while (CalculatePath.GetPath(_agent, _randomDirection, pathToTarget) == false);

            _agent.SetDestination(_randomDirection);
        }
    }
}