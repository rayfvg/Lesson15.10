using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInput : MonoBehaviour
{
    private const int LeftMouseButton = 0;

private Character _player;

    private void Awake()
    {
        _player = GetComponent<Character>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            _player.Movement.Walk();
        }

        _player.Movement.UpdateWalkToFlag();

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
    }

    public bool StartGame() => Input.GetKeyDown(KeyCode.Space);
}