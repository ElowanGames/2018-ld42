using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour{

    public AudioClip song01;
    public AudioClip song02;
    public AudioSource song03;
    public float WaitTime;

    static GM instance = null;

    Scene currentScene;


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
        }
    }

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
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

    private void Update()
    {
        
    }

    void StopAllAudio()
    {
        AudioSource[] allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    IEnumerator LoopSong()
    {
        string sceneName = currentScene.name;
        Start:
        //if (sceneName == "Menu" || sceneName == "GameOver")
        //{
        //    StopAllAudio();
        //    print("this part works");
        //    yield break;
        //}

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            song03.Play();
            yield return new WaitForSeconds(15.351f);
        }
        AudioSource.PlayClipAtPoint(song01, gameObject.transform.position, 1);
        yield return new WaitForSeconds(WaitTime);
        AudioSource.PlayClipAtPoint(song02, gameObject.transform.position, 1);
        yield return new WaitForSeconds(WaitTime);
        goto Start;
    }

}
