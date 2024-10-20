using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInput : MonoBehaviour
{
    private const int LeftMouseButton = 0;

    private Character _player;

    private void Start()
    {
        _player = GetComponent<Character>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            _player.Movement.Walk();
        }

        _player.Movement.Update();

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
    }

    public bool StartGame() => Input.GetKeyDown(KeyCode.Space);

    public void StopIdle()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
            _player.Timer = 0;
    }
}