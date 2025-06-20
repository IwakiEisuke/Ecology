using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] LayerMask terrainLayer;
    [SerializeField] Vector3 horizontalPosition;
    [SerializeField] Vector3 rotate;
    [SerializeField] float distance;
    [SerializeField] float speed = 5f;
    [SerializeField] float rotateSpeed = 5f;
    [SerializeField] float zoomSpeed = 5f;
    [SerializeField] float minDistance = 5f;
    [SerializeField] float maxDistance = 100f;

    Vector2 moveInput;
    Vector2 rotateInput;
    float zoomInput;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnRotate(InputValue value)
    {
        rotateInput = value.Get<Vector2>();
    }

    public void OnZoom(InputValue value)
    {
        zoomInput = value.Get<float>();
    }

    private void Update()
    {
        var dt = Time.deltaTime;
        horizontalPosition += speed * dt * (Quaternion.Euler(0, rotate.y, 0) * new Vector3(moveInput.x, 0, moveInput.y));
        rotate += rotateSpeed * dt * new Vector3(rotateInput.y, rotateInput.x);
        distance = Mathf.Clamp(distance - zoomInput * zoomSpeed * dt, minDistance, maxDistance);

        transform.rotation = Quaternion.Euler(rotate);
        if (Physics.Raycast(horizontalPosition + Vector3.up * 100, Vector3.down, out var hit, 100f, terrainLayer.value))
        {
            transform.position = hit.point - transform.forward * distance;
        }
        else
        {
            transform.position = horizontalPosition - transform.forward * distance;
        }
    }
}
