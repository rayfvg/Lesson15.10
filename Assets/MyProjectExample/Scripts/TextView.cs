using TMPro;
using UnityEngine;

public class TextView : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;

    public void UpdateText(int value) => _healthText.text = value.ToString();
}