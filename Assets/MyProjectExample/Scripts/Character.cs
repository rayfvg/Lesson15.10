using UnityEngine;

public class Character : MonoBehaviour
{
    private IBehaviour _basicbehavior;
    private IBehaviour _idlebehavior;

    private IBehaviour _currentBehavior;

    private float _timeToStartIdleBehavior = 3;

    private UserInput _userInput;

    public float Timer = 0;

    public Health Health { get; private set; }
    public Movement Movement { get; private set; }
    public BoringBehavior BoringBehavior { get; private set; }

    private void Start()
    {
        _userInput = FindObjectOfType<UserInput>();

        _idlebehavior = BoringBehavior;
        _basicbehavior = Movement;

        _currentBehavior = _basicbehavior;
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if (_timeToStartIdleBehavior < Timer)
        {
            _currentBehavior = _idlebehavior;
            _idlebehavior.Update();
            _userInput.StopIdle();
        }  
    }

    public void Initialize(Health health, Movement movemen, BoringBehavior boringBehavior)
    {
        Health = health;
        Movement = movemen;
        BoringBehavior = boringBehavior;
    }
}