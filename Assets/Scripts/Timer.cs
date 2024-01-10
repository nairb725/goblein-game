using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Image timerbar;
    [SerializeField] private float maxTime;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            timerbar.fillAmount = timeLeft/maxTime;
        }
    }
}
