using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void AsyncLoading()
    {
        StartCoroutine(LoadSampleLevel());
    }

    IEnumerator LoadSampleLevel()
    {
        var load =  SceneManager.LoadSceneAsync("SampleScene");

        while (!load.isDone)
        {
            yield return null;
        }
    }

    public void ExitButton()
    {
        Application.Quit();    
    }
}