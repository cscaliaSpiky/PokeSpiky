using TMPro;
using UnityEngine;

public class CurrentLevelIndex : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    private void Start()
    {
        levelText.text = $"LEVEL {DefaultUserManager.Instance.UserData.CurrentLevel + 1}";
    }
}
