using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue : MonoBehaviour {

    public Text text;

    public string[] BadJokes;
    public GameObject canvas;

	void Start () {
        canvas.SetActive(false);
	}

    public void SayStuff()
    {
        StartCoroutine(PopInAndOut());
    }

    IEnumerator PopInAndOut()
    {
        yield return new WaitForSeconds(.5f);
        canvas.gameObject.SetActive(true);
        text.text = BadJokes[Random.Range(0, BadJokes.Length)];
        yield return new WaitForSeconds(6);
        canvas.gameObject.SetActive(false);
    }

}
