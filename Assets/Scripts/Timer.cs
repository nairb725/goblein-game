using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Image timerbar;
    [SerializeField] 
    private float maxTime;
    private float timeLeft;
    private bool inGame = true;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = maxTime;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0 &&  inGame == true) {
            timeLeft -= Time.deltaTime;
            timerbar.fillAmount = timeLeft/maxTime;
        } else {
            gameManager.setLose();
        }
    }
}
