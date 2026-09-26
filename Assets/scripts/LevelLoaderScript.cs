using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Animator transition;
    public float transitionTime;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel(int levelNum)
    {
        StartCoroutine(LoadLevel(levelNum));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        
    }
}
