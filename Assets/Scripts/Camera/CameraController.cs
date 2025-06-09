using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 horizontalPosition;
    [SerializeField] Vector3 rotate;
    [SerializeField] float distance;
    [SerializeField] float speed = 5f;
    [SerializeField] float rotateSpeed = 5f;

    Vector2 moveInput;
    float rotateInput;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnRotate(InputValue value)
    {
        rotateInput = value.Get<float>();
    }

    private void Update()
    {
        var dt = Time.deltaTime;
        horizontalPosition += speed * dt * (Quaternion.Euler(0, rotate.y, 0) * new Vector3(moveInput.x, 0, moveInput.y));
        rotate.y += rotateInput * rotateSpeed * dt;

        transform.rotation = Quaternion.Euler(rotate);
        if (Physics.Raycast(horizontalPosition + Vector3.up * 100, Vector3.down, out var hit))
        {
            transform.position = hit.point - transform.forward * distance;
        }
        else
        {
            transform.position = horizontalPosition - transform.forward * distance;
        }
    }
}
