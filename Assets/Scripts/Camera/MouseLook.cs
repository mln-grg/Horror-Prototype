using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSensitivity =100f;

    private float xRotation = 0f;

    [SerializeField] private float normalView = 60f;
    [SerializeField] private float zoomedView = 20f;
    [SerializeField] private float viewTransitionSmoothening = 5f;
    [SerializeField] private float RotationClampUp = -50f;
    [SerializeField] private float RotationClampDown = 25f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,RotationClampUp, RotationClampDown);
        
        playerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Camera Zoom
        if (Input.GetMouseButton(1))
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoomedView, viewTransitionSmoothening * Time.deltaTime);
        }
        else
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normalView, viewTransitionSmoothening * Time.deltaTime);

    }

}
