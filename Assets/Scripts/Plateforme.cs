using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateforme : MonoBehaviour
{
    [SerializeField] 
    private float travelTime;
    [SerializeField]
    private GameObject firstPoint;
    [SerializeField]
    private GameObject secondPoint;
    private Vector3 firstPosition;
    private Vector3 secondPosition;
    private float timePass = 0f;
    private bool backtrack = false;

    // Start is called before the first frame update
    void Start()
    {
        this.firstPosition = firstPoint.transform.position;
        this.secondPosition = secondPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(backtrack) {
            timePass = Mathf.Min(timePass + Time.deltaTime, travelTime);
            float ratio = timePass / travelTime;
            transform.position = Vector3.Lerp(secondPosition, firstPosition, ratio);
            if (timePass >= travelTime)
                {
                    backtrack = false;
                    timePass = 0f;
                }

        } else {
            timePass = Mathf.Min(timePass + Time.deltaTime, travelTime);
            float ratio = timePass / travelTime;
            transform.position = Vector3.Lerp(firstPosition, secondPosition, ratio);
             if (timePass >= travelTime)
                {
                    backtrack = true;
                    timePass = 0f;
                }
        }
    }
}
