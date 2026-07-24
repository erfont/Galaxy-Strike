using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;

    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField]  float targetDistance = 250;
    bool isFiring;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Cursor.visible = false; // Hide OS cursor
        isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {   
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    private void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position; // To calculate the laser direction we use the ship's position instead of each laser's position, to make sure lasers fire on a straight line
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }

    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    private void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }

    private void ProcessFiring()
    {
        // Or ParticleSystem.EmissionModule if don't wanna use the generic var
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
        
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
}
