using UnityEngine;
using Yarn.Unity;

public class audiosPlay : MonoBehaviour

{
    public AudioSource source;
    public AudioClip player;
    public AudioClip Bluep;
    public string whoAudio;

    public DialogueRunner dia;

        public void Awake()
    {
        dia.AddCommandHandler<int>("quemFala", fala);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        whoAudio = collision.name; 
    }

    void OTriggerExit2D(Collider2D collision)
    {
        whoAudio = null;
    }
    public void fala(int quemFala)
    {
        if (quemFala == 1)
        {
        }
    }
}
