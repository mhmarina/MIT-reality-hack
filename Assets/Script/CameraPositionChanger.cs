//using UnityEngine;

//public class CameraPositionChanger : MonoBehaviour
//{
//    public Transform targetPosition; // The position the camera will move to
//    public float transitionSpeed = 2f; // Speed of the transition
//    public Transform mainCamera; // Drag Main Camera here in the Inspector

//    private bool isMoving = false; // Whether the camera is currently moving

//    public void MoveCamera()
//    {
//        if (mainCamera != null && targetPosition != null)
//        {
//            isMoving = true;
//        }
//    }

//    private void Update()
//    {
//        if (isMoving && mainCamera != null && targetPosition != null)
//        {
//            // Smoothly move the Main Camera to the target position
//            mainCamera.position = Vector3.Lerp(mainCamera.position, targetPosition.position, Time.deltaTime * transitionSpeed);
//            mainCamera.rotation = Quaternion.Lerp(mainCamera.rotation, targetPosition.rotation, Time.deltaTime * transitionSpeed);

//            // Stop moving when close enough to the target
//            if (Vector3.Distance(mainCamera.position, targetPosition.position) < 0.05f)
//            {
//                isMoving = false;
//            }
//        }
//    }
//}
using UnityEngine;

public class CameraZoomMover : MonoBehaviour
{
    public Transform targetPosition; // The position the camera will move to
    public float transitionSpeed = 2f; // Speed of the camera movement
    public float targetFOV = 30f; // The target Field of View (Zoom In effect)
    public float zoomSpeed = 2f; // Speed of the FOV transition

    private Camera mainCamera; // Reference to the main camera
    private bool isMoving = false; // Whether the camera is currently moving
    private Transform xrRig; // Reference to the XR Rig

    private float originalFOV; // Store the original FOV

    private void Start()
    {
        // Find the XR Rig and main camera
        xrRig = GameObject.FindWithTag("Player").transform;
        mainCamera = Camera.main;

        if (xrRig == null)
        {
            Debug.LogError("XR Rig not found! Make sure your XR Rig is tagged as 'Player'.");
        }
        if (mainCamera != null)
        {
            originalFOV = mainCamera.fieldOfView; // Store the original FOV
        }
    }

    public void MoveAndZoom()
    {
        if (xrRig != null && targetPosition != null && mainCamera != null)
        {
            isMoving = true;
        }
    }

    private void Update()
    {
        if (isMoving && xrRig != null && targetPosition != null && mainCamera != null)
        {
            // Smoothly move the XR Rig to the target position
            xrRig.position = Vector3.Lerp(xrRig.position, targetPosition.position, Time.deltaTime * transitionSpeed);
            xrRig.rotation = Quaternion.Lerp(xrRig.rotation, targetPosition.rotation, Time.deltaTime * transitionSpeed);

            // Smoothly adjust the camera's Field of View (Zoom In effect)
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);

            // Stop moving and zooming when close enough to the target
            if (Vector3.Distance(xrRig.position, targetPosition.position) < 0.01f &&
                Mathf.Abs(mainCamera.fieldOfView - targetFOV) < 0.1f)
            {
                isMoving = false; // Stop the movement and zooming
            }
        }
    }

    public void ResetZoom()
    {
        // Reset the camera's FOV to the original value
        if (mainCamera != null)
        {
            mainCamera.fieldOfView = originalFOV;
        }
    }
}
