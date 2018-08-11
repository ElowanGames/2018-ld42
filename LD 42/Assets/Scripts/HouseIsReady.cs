using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseIsReady : MonoBehaviour {

    bool IsReady = false;
    int WaitingTime;

	void Start () {
        IsReady = false;
	}
	
	void Update () {
        if (IsReady == false)
        {
            gameObject.tag = "Unreadyhouse";
            StartCoroutine(WaitToReady());
        }
        if (IsReady == true)
        {
            gameObject.tag = "ReadyHouse";
        }
	}

    IEnumerator WaitToReady()
    {
        WaitingTime = Random.Range(1, 10);
        yield return new WaitForSeconds(WaitingTime);
        IsReady = true;
        
    }

}
