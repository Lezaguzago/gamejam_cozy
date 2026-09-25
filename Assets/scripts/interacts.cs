using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class interacts : MonoBehaviour
{
    public DialogueRunner dia;
    public string who;
    public bool conv;

    public bool estaConversando = false;
    
    public Animator anima;

    


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
        }
        else if(quemFala == 1)
        {
            anima.SetBool("charFalando", false);
        }
        else if(quemFala == 0)
        {
            anima.SetBool("charFalando", false);
        }
    }

    public void interact()
    {
        if (estaConversando == false)
        {
            if (conv == true)
            {
                dia.StartDialogue(who);
            }

            else if(conv == false && anima != null){
                anima.SetBool("interagir", true);
            }

            else if(who == "terminal")
            {
                SceneManager.LoadScene("Space");

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

        }

        else if(collision.gameObject.tag == "objeto")
        {
            conv = false;
            anima = collision.gameObject.GetComponent<Animator>();

        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        who = null;
        conv = false;
        anima = null; 
    }
}
