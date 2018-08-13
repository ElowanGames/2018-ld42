using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour{

    public AudioSource song01;
    public AudioSource song02;

    static GM instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            print("Duplicate Destroyed");
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(LoopSong());
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void LoadSame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoopSong()
    {
        Start:
        song01.Play();
        yield return new WaitForSeconds(88.248f);
        song02.Play();
        yield return new WaitForSeconds(88.248f);
        goto Start;
    }

}
