using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float minSpeed;
    private float maxSpeedReached;
    private bool isBreaking = false;
    
    public float speedX = 10f;
    public float speedY = 1f;
    public float decelerationY = 3f;
    public float accelerationY = 1f;
    public float slowAccelerationY = 0.1f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        minSpeed = speedY * 0.75f;
    }
    
    //Update but for physics
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, 0.0f);
        rb.AddForce(movement*speedX);
        rb.AddForce(Vector3.forward*speedY, ForceMode.Acceleration);
        
        float effectiveAcceleration = isBreaking ? slowAccelerationY : accelerationY;
        speedY += effectiveAcceleration * Time.fixedDeltaTime;

        if (speedY > maxSpeedReached)
        {
            maxSpeedReached = speedY;
        }
        
        minSpeed = maxSpeedReached / 2f;
        speedY = Mathf.Max(speedY, minSpeed);
        
        //continious breaking
        /*if (isBreaking)
        {
            minSpeed = maxSpeedReached / 2f;
            speedY -= decelerationY * Time.fixedDeltaTime;
            speedY = Mathf.Max(speedY, minSpeed);
        }
        else
        {
            speedY += Time.fixedDeltaTime;
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
    }

    void OnBreak(InputValue breakingValue)
    {
        isBreaking = breakingValue.isPressed;
        Debug.Log("isBreaking: " + isBreaking);
    }
    
}
