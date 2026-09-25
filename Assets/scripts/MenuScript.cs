using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject painelMenu;

    public void Play()
    {
        SceneManager.LoadScene("nave");

    }

    public void Exit()
    {
        Application.Quit();
    }
}
