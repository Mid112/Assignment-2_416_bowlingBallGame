using UnityEngine;
using TMPro;
using UnityEngine.Events; // Ensure this is included

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score = 0; // Changed from float to int
    //A reference to our ballcontroller 
    [SerializeField] private BallController ball;
    //A reference for our PinCollection prefab we made in Section 2.2 
    [SerializeField] private GameObject pinCollection;
    //A reference for an empty Gamelbject which we'll
    [SerializeField] private Transform pinAnchor;
    //A reference for our input manager
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] pins;

    private void Start()
    {
        inputManager.OnResetPressed.AddListener(HandleReset);
    }
    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }
    private void SetPins()
    {
        if (pins)
        {
            foreach (Transform child in pinObject.transform)
            {
                Destroy(child.gameObject);
            }
                Destroy(pins);
            
        }
        pins = Instantiate(pinCollection, 
                pinAnchor.transform.position, Quaternion.identity, tranform);
        fallTriggers = pins.GetComponentsInChildren<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (FallTrigger pin in pins)
        {
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
