using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float minSpeed;
    private float maxSpeedReached;
    private bool isBreaking = false;
    private Vector3 startPosition;
    
    public float speedX = 10f;
    public float speedY = 1f;
    public float decelerationY = 3f;
    public float accelerationY = 0.1f;
    public float slowAccelerationX = -0.1f;
    public float slowAccelerationY = -0.1f;
    public float distanceTravelled;
    public bool canMove = false;
    public GameObject pauseMenu;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        minSpeed = speedY * 0.25f;
        startPosition = transform.position;
    }
    
    //Update but for physics
    private void FixedUpdate()
    {
        if (!canMove) return;
        
        Vector3 movement = new Vector3 (movementX, 0.0f, 0.0f);
        rb.AddForce(movement*speedX);
        rb.AddForce(Vector3.forward*speedY, ForceMode.Acceleration);
        
        float effectiveAccelerationY = isBreaking ? slowAccelerationY : accelerationY;
        float effectiveAccelerationX = isBreaking ? slowAccelerationX : accelerationY;
        speedY += effectiveAccelerationY * Time.fixedDeltaTime;
        speedX += effectiveAccelerationX * Time.fixedDeltaTime;

        if (speedY > maxSpeedReached)
        {
            maxSpeedReached = speedY;
        }
        
        minSpeed = maxSpeedReached * 0.25f;
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
        distanceTravelled = Vector3.Distance(startPosition, transform.position);
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

    void OnPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Spieler hat ein Hindernis getroffen – Neustart!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
}
