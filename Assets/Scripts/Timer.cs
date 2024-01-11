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

    [SerializeField]
    private AudioSource FirstMusic;
    [SerializeField]
    private AudioSource SecondMusic;
    [SerializeField]
    private AudioSource ThirdMusic;

    private float oui = 35f;


    // Start is called before the first frame update
    void Start()
    {
        timeLeft = maxTime;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timeLeft);

        if (timeLeft > 0 &&  inGame == true) {
            timeLeft -= Time.deltaTime;
            timerbar.fillAmount = timeLeft/maxTime;
        } else {
            gameManager.setLose();
        }

        if (timeLeft < 360f && timeLeft > 240f)
        {
            FirstMusic.mute = false;
            SecondMusic.mute = true;
            ThirdMusic.mute = true;
        }
        else if (timeLeft < 240f && timeLeft > 120f)
        {
            FirstMusic.mute = true;
            SecondMusic.mute = false;
            ThirdMusic.mute = true;

            FirstMusic.Stop();
            SecondMusic.Play();
        }
        else if (timeLeft < 120f)
        {
            FirstMusic.mute = true;
            SecondMusic.mute = true;
            ThirdMusic.mute = false;
        }
    }
}
