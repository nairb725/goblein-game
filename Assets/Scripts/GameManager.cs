using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private float winDelay = 1.0f;
    [SerializeField]
    private float loseDelay = 5.0f;
    public bool isLightning = false;
    private bool isLose = false;

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
        m_HUDText.text = ("X" + FlareNumber);
    }

    public void setLose(){
        isLose = true;
    }
    public bool getLose(){
        return isLose;
    }

    public void endGame() {
        if(isLose == false){
            Invoke("returnToMenu", loseDelay);
        }else{
            Invoke("returnToMenu", winDelay);
        }
    }

    public void returnToMenu(){
        SceneManager.LoadScene("MenuScene");
    }

    public bool getIsLightning(){
        return isLightning;
    }
}
