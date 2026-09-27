using UnityEngine;
using Yarn.Compiler;
using Yarn.Unity;

public class audiosPlay : MonoBehaviour

{
    public AudioSource source;
    public AudioClip player1;
    public AudioClip player2;
    public AudioClip player3;

    public AudioClip Bluep;
    public AudioClip grojj;
    public AudioClip klaudio;

    private AudioClip esse;
    public string whoAudio;

    public DialogueRunner dia;

        public void Awake()
    {
        dia.AddCommandHandler<int>("quemFalaAudio", fala);
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
        if (whoAudio == "Bluep")
            {
                esse = Bluep;
            }
        else if (whoAudio == "Grojj")
            {
                esse = grojj;
            }
        else if (whoAudio == "Klaudio")
            {
                esse = klaudio;
            }
    }

    void OTriggerExit2D(Collider2D collision)
    {
        whoAudio = null;
        esse = null;
    }
    public void fala(int quemFala)
    {
        if (quemFala == 2)
        {
            source.PlayOneShot(esse);
        }
        else if (quemFala == 1)
        {

            int num = Random.Range(1, 4);
            if(num == 1)
            {
                source.PlayOneShot(player1);
            }
            else if(num == 2)
            {
                source.PlayOneShot(player2);
            }
            else if(num == 3)
            {
                source.PlayOneShot(player3);
            }
        }
    }
}
