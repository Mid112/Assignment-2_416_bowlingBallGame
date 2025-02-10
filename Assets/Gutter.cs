using UnityEngine;

public class Gutter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider triggerBody)
    {
        Rigidbody ballRigidBody = triggerBody.GetComponent<Rigidbody>();

        //We store the velocity magnitude before resetting the velocity
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        //It is important to reset the linear AND angular velocity
        //This is because the ball is rotating on the ground when moving
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;
        //Now we add force in the forward direction of the gutter
        ballRigidBody .AddForce(transform.forward * velocityMagnitude,
        ForceMode.VelocityChange);


    }
}
