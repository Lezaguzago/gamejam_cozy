using UnityEngine;
using Yarn.Unity;

public class interacts : MonoBehaviour
{
    public DialogueRunner dia;
    public string who;
    public bool conv;
    
    public Animator anima;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact()
    {
        if (conv == true)
        {
            dia.StartDialogue(who);
        }

        else if(conv == false && anima != null){
            anima.SetBool("interagir", true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        who = collision.name;
        if (collision.gameObject.tag == "personagem")
        {
            conv = true;
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
