using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPlayer : MonoBehaviour
{
private void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "Player"){
        Debug.Log("player enter");
         Debug.Log(other.gameObject);
        other.transform.SetParent(this.transform);
    }
}

private void OnTriggerExit(Collider other) {
    if(other.gameObject.tag == "Player"){
        other.transform.SetParent(null);
    }
}
}
