using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 50f;

    Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();

    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    private void ProcessTranslation()
    {
        float XOffset = movement.x * controlSpeed * Time.deltaTime;

        float YOffset = movement.y * controlSpeed * Time.deltaTime;

        transform.localPosition = new Vector3(transform.localPosition.x + XOffset, transform.localPosition.y + YOffset, 0f);
    }
}
