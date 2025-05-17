using TMPro;
using UnityEngine;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public int countdownTime = 5;
    public GameObject player;

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        int timeLeft = countdownTime;

        while (timeLeft > 0)
        {
            countdownText.text = timeLeft.ToString();
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
        
        player.GetComponent<PlayerController>().canMove = true;
    }
}
