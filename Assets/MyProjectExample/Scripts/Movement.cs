using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Movement : IBehaviour
{
    public bool IsJumping;
    private NavMeshAgent _agent;
    private GameObject _cursorPrefab;
    private Transform _transform;
    private PlayerView _playerViev;

    private RaycastHit _hitInfo;
    private GameObject _flag;

    private bool _isWalking = false;

    private Coroutine _jumpCorotine;
    private AnimationCurve _jumpCurve;
    private MonoBehaviour _context;
    private float _jumpDuration;

    private AudioManager _audioExample;

    public Movement(NavMeshAgent agent, GameObject cursorPrefab, Transform transform, PlayerView playerViev,
        AnimationCurve jumpCurve, MonoBehaviour context, float jumpDuration, AudioManager audioExample)
    {
        _agent = agent;
        _cursorPrefab = cursorPrefab;
        _transform = transform;
        _playerViev = playerViev;
        _jumpCurve = jumpCurve;
        _context = context;
        _jumpDuration = jumpDuration;
        _audioExample = audioExample;
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


    public void Update()
    {
        if (_agent.isOnOffMeshLink)
        {
            if(_jumpCorotine == null)
            {
                _context.StartCoroutine(Jump(_jumpDuration));
            }
        }

        if (_agent.remainingDistance <= _agent.stoppingDistance && !_agent.pathPending)
        {
            _agent.isStopped = true;
            Debug.Log("I stay");
            _playerViev.StopRunning();

            _isWalking = false;
        }
        else
        {
            if (_isWalking == false)
            {
                _agent.isStopped = false;
                _isWalking = true;
                _playerViev.StartRunning();
            }
        }
    }

    private IEnumerator Jump(float duration)
    {
        _playerViev.StartJumping();
        _audioExample.JumpSound();
        IsJumping = true;
        OffMeshLinkData data = _agent.currentOffMeshLinkData;
        Vector3 startPos = _agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * _agent.baseOffset;

        float progress = 0;

        while (progress < duration)
        {
            float yOffset = _jumpCurve.Evaluate(progress / duration);
            _agent.transform.position = Vector3.Lerp(startPos, endPos, progress / duration) + yOffset * Vector3.up;
            _transform.rotation = Quaternion.LookRotation(endPos - startPos);
            progress += Time.deltaTime;
            yield return null;
        }

        _agent.transform.position = endPos;
        _agent.CompleteOffMeshLink();
        _jumpCorotine = null;
        IsJumping = false;
        _playerViev.StopJumping();
    }
}