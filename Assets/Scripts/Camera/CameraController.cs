using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Vector2 moveInput;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * new Vector3(moveInput.x, 0, moveInput.y);
    }
}
