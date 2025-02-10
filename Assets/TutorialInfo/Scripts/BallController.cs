using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    private Rigidbody ballRB;
    private bool isBallLaunched = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        //Need to make an initial commit
        inputManager.OnSpacePressed.AddListener(LaunchBall);

    } 


    // Update is called once per frame
    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
