using UnityEngine;
using TMPro;
using UnityEngine.Events; // Ensure this is included

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score = 0; // Changed from float to int
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] pins;

    private void Start()
    {
        pins = FindObjectsOfType<FallTrigger>(); // Removed FindObjectsInactive.Include for compatibility
        foreach (FallTrigger pin in pins)
        {
            if (pin.OnPinFall == null) // Ensure event is initialized
                pin.OnPinFall = new UnityEvent();

            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    public void IncrementScore()
    {
        score++;
        if (scoreText != null) // Added null check for safety
        {
            scoreText.text = $"Score: {score}";
        }
        else
        {
            Debug.LogError("ScoreText is not assigned in the Inspector!");
        }
    }
}
