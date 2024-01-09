using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_HUDText;

    [SerializeField]
    private float FlareTimer;

    [SerializeField]
    private float FlareNumber;

    [SerializeField]
    public bool isLightning = false;

    // Start is called before the first frame update
    void Start()
    {
        m_HUDText.text = ("X" + FlareNumber);
        isLightning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (FlareNumber != 0) && (isLightning == false))
        {
            FlareNumber = FlareNumber - 1;
            m_HUDText.text = ("X" + FlareNumber);
            isLightning = true;
            Invoke("timeFlare", FlareTimer);
        }
    }
    public void timeFlare()
    {
    isLightning = false;
    }
    public void restockFlare(int nbFlare){
        FlareNumber += nbFlare;
    }
}
