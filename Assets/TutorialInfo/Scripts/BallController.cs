using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform lauchIndicator;
    private Rigidbody ballRB;
    private bool isBallLaunched = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        //Need to make an initial commit
        Cursor.lockState = CursorLockMode.Locked;
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        
        ResetBall();

    } 

    public void ResetBall()
    {
        isBallLaunched = false;
        ballRB.isKinematic = true;
        lauchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        lauchIndicator.gameObject.SetActive(true);
    }

    // Update is called once per frame
    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(lauchIndicator.forward * force, ForceMode.Impulse);
        lauchIndicator.gameObject.SetActive(false);
    }

    //8 Ball by Jarlan Perez [CC-BY] via Poly Pizza
}
