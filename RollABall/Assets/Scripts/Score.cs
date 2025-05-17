using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public float distanceTravelled;
    public TextMeshProUGUI scoreText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled = FindFirstObjectByType<PlayerController>().distanceTravelled;
        score = Mathf.FloorToInt(distanceTravelled);
        scoreText.text = "Score: " + score;
    }
}
