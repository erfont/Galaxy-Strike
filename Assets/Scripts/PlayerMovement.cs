using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 50f;

    [SerializeField] float rotationSpeed = 8f;

    [SerializeField] float controlRollFactor = 45f;

    [SerializeField] float XOffsetClampMin = -19, XOffsetClampMax = 19, YOffsetClampMin = -8f, YOffsetClampMax= 20f;   


    Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();

    }


    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    private void ProcessTranslation()
    {

        
        float XOffset = movement.x * controlSpeed * Time.deltaTime;
        float clampedNewXPos = Mathf.Clamp(transform.localPosition.x + XOffset, XOffsetClampMin, XOffsetClampMax);

        float YOffset = movement.y * controlSpeed * Time.deltaTime;
        float clampedNewYPos = Mathf.Clamp(transform.localPosition.y + YOffset, YOffsetClampMin, YOffsetClampMax);


        transform.localPosition = new Vector3(clampedNewXPos, clampedNewYPos, 0f);
    }
    private void ProcessRotation()
    {
        // -controlRollFactor * movement.y // rotating on the X axis doesn't look much better
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -controlRollFactor * movement.x);

        Quaternion lerpedRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);

        transform.localRotation = lerpedRotation;
    }
}
