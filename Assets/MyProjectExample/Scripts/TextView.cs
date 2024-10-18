using TMPro;
using UnityEngine;

public class TextView : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Character _player;

    private void Start()
    {
        UpdateText(_player.Health.GetHealth);
    }

    public void UpdateText(int value) => _healthText.text = value.ToString();
}