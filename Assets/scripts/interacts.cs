using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;
using NUnit.Framework;

public class interacts : MonoBehaviour
{
    [SerializeField] LevelLoaderScript levelLoader;
    public DialogueRunner dia;
    public string who;
    public bool conv;
    public Animator animap;
    public bool estaConversando = false;
    
    public Animator anima;

    public bool isTrigger;

    public bool grojj = false;

    


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

    public void comecoFala()
    {
        estaConversando = true;
    }

    public void fimFala()
    {
        estaConversando = false;
    }

    public void fala(int quemFala)
    {
        Debug.Log(quemFala);
        if (quemFala == 2)
        {
            anima.SetBool("charFalando", true);
            animap.SetBool("fala", false);

        }
        else if(quemFala == 1)
        {
            anima.SetBool("charFalando", false);
            animap.SetBool("fala", true);
        }
        else if(quemFala == 0)
        {
            anima.SetBool("charFalando", false);
            animap.SetBool("fala", false);
        }
    }

    public void interact()
    {
        if (estaConversando == false)
        {
            if (conv == true && grojj == false)
            {
                dia.StartDialogue(who);
            }

            else if (conv == true && grojj == true)
            {
                int num = Random.Range(1, 6);
                if (num == 5)
                {
                    
                    dia.StartDialogue(who);

                }

                else
                {
                    dia.StartDialogue("grojnt");
                }
            }

            else if(conv == false && anima != null && isTrigger == false){
                anima.SetBool("interagir", true);
            }

            else if(conv == false && anima != null && isTrigger == true){
                anima.SetTrigger("interagir");
            }

            else if(who == "terminal")
            {
                levelLoader.LoadNextLevel(2);

            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        who = collision.name;
        if (collision.gameObject.tag == "personagem")
        {
            conv = true;
            anima = collision.gameObject.GetComponent<Animator>();
            isTrigger = false;

        }

        else if(collision.gameObject.tag == "grojj")
        {
            conv = true;
            grojj = true;
            anima = collision.gameObject.GetComponent<Animator>();
            isTrigger = false;
        }

        else if(collision.gameObject.tag == "objeto")
        {
            conv = false;
            anima = collision.gameObject.GetComponent<Animator>();
            isTrigger = false;

        }

        else if(collision.gameObject.tag == "objetoTrigger")
        {
            conv = false;
            anima = collision.gameObject.GetComponent<Animator>();
            isTrigger = true;

        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        who = null;
        conv = false;
        anima = null;
        isTrigger = false; 
        grojj = false;
    }
}
