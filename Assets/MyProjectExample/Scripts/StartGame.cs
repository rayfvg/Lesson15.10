using Cinemachine;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private GameObject _menu;

    private void Start()
    {
        _userInput.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _userInput.enabled = true;
            _camera.enabled = false;
            _menu.gameObject.SetActive(false);
        }
    }
}
