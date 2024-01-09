using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFlare : MonoBehaviour
{
    [SerializeField] private int gainFlare = 3;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
   private void OnTriggerEnter(Collider other) {
    gameManager.restockFlare(gainFlare);
   }
}
