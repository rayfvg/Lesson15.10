using Cinemachine;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;

    [SerializeField] private UserInput _userInput;
    [SerializeField] private Character _character;

    [SerializeField] private GameObject _menu;

    private void Awake()
    {
        _character.Initialization();
        _userInput.enabled = false;
    }

    private void Update()
    {
        if (_userInput.StartGame())
        {
            _userInput.enabled = true;
            _camera.enabled = false;
            _menu.gameObject.SetActive(false);
        }
    }
}