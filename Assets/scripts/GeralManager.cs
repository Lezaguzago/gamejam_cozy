using UnityEngine;

public class GeralManager : MonoBehaviour
{
    public float pontos = 0;
    public int lifeSaveds = 0;
    public bool saved = false;
    public static GeralManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
