using UnityEngine;
using UnityEngine.UI;

public class MobileMatchHUD : MonoBehaviour
{
    [SerializeField] private MatchManager matchManager;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text oversText;

    private void Update()
    {
        if (matchManager == null) return;

        if (scoreText != null)
            scoreText.text = $"{matchManager.Runs}/{matchManager.Wickets}";

        if (oversText != null)
            oversText.text = $"{matchManager.LegalBalls / 6}.{matchManager.LegalBalls % 6} overs";
    }
}
