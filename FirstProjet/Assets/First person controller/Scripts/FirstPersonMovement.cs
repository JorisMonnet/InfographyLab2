using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    Vector2 velocity;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    public GameObject cyborgObject;
    Vector3 previousPosition;

    private void Start()
    {
        previousPosition = cyborgObject.transform.position;
    }

    void FixedUpdate()
    {
        // Move.
        IsRunning = canRun && Input.GetKey(runningKey);
        float movingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            movingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        velocity.y = Input.GetAxis("Vertical") * movingSpeed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * movingSpeed * Time.deltaTime;

        float playerVelocity = ((cyborgObject.transform.position - previousPosition).magnitude) / Time.deltaTime;
        previousPosition = cyborgObject.transform.position;

        Animator cyborgAnimator = cyborgObject.GetComponent<Animator>();
        cyborgAnimator.SetBool("isMoving", playerVelocity > 0);

        cyborgAnimator.SetFloat("Speed", Input.GetAxis("Vertical") * movingSpeed);
        cyborgAnimator.SetFloat("Direction", Input.GetAxis("Horizontal") * movingSpeed);

        transform.Translate(velocity.x, 0, velocity.y);
    }
}