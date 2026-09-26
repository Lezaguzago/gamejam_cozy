using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] LevelLoaderScript levelLoader;

    [SerializeField] GameObject painelMenu;

    public void Play()
    {
        levelLoader.LoadNextLevel(1);


    }

    public void Exit()
    {
        Application.Quit();
    }
}
