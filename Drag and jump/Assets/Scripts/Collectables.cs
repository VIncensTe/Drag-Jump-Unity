using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

    #region
    public GameObject newObject;
    public GameObject newObject2;
    public GameObject newObject3;
    public GameObject newObject4;
    public GameObject newObject5;
    #endregion  

    void OnTriggerEnter(Collider other){

        //Wenn Player Trigger entered wird objekt deaktiviert und bis zu 5 objekte gespawned
        if (other.gameObject.CompareTag(tag: "Player")){
            this.gameObject.SetActive(false);
            Instantiate(newObject);
            Instantiate(newObject2);
            Instantiate(newObject3);
            Instantiate(newObject4);
            Instantiate(newObject5);
        }
    }
}
