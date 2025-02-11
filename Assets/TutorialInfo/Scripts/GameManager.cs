using UnityEngine;
using TMPro;
using UnityEngine.Events; // Ensure this is included

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private BallController ballController;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] pins;
    private GameObject pinObjects;
    public void Start()
    {
        inputManager.OnSpacePressed.AddListener(HandleReset);
        SetPins();
    }
    private void HandleReset()
    {
        ballController.ResetBall();
        SetPins();
    }
    private void SetPins()
    {
        if(pinObjects != null)
        {
            foreach(Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }
        pinObjects = Instantiate(pinCollection, 
        pinAnchor.transform.position, Quaternion.identity, transform);

        pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach(FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }
    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
    
}
