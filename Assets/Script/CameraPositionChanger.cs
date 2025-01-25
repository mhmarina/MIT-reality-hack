using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CameraPositionChanger : MonoBehaviour
{
    public Transform targetPosition; // The position the camera will move to
    public float transitionSpeed = 2f; // Speed of the transition

    private bool isMoving = false; // Whether the camera is currently moving
    private Transform xrRig; // Reference to the XR Rig

    private void Start()
    {
        // Find the XR Rig (assuming it's tagged as "Player")
        xrRig = GameObject.FindWithTag("Player").transform;

        if (xrRig == null)
        {
            Debug.LogError("XR Rig not found! Make sure your XR Rig is tagged as 'Player'.");
        }
    }

    public void MoveCamera()
    {
        if (xrRig != null && targetPosition != null)
        {
            isMoving = true;
        }
    }

    private void Update()
    {
        if (isMoving && xrRig != null && targetPosition != null)
        {
            // Smoothly move the XR Rig to the target position
            xrRig.position = Vector3.Lerp(xrRig.position, targetPosition.position, Time.deltaTime * transitionSpeed);
            xrRig.rotation = Quaternion.Lerp(xrRig.rotation, targetPosition.rotation, Time.deltaTime * transitionSpeed);

            // Stop moving when close enough to the target
            if (Vector3.Distance(xrRig.position, targetPosition.position) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
}
