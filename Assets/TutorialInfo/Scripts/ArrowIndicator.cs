using UnityEngine;
using Unity.Cinemachine;

public class ArrowIndicator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private CinemachineCamera FreeLookCamera;
    

    // Update is called once per frame
    void Update()
    {
        transform.forward = FreeLookCamera.transform.forward;
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
