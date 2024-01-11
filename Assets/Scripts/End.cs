using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField]
    private GameObject endNet;
    // Start is called before the first frame update
    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update() {
        if(gameManager.getLose()){
            endNet.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other) {
        gameManager.endGame();
    }
}
