using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;

    public Rigidbody rb;

    public void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        rb = GetComponent<Rigidbody>();
    }
    public void MovePlayer(Vector2 direction)
    {
        Vector3  moveDirection = new (direction.x, 0f, direction.y);
        rb.AddForce(moveDirection * speed);
    }
    
}
