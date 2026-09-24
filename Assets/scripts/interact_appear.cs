using UnityEngine;

public class interact_appear : MonoBehaviour
{
    public GameObject indicator;
    SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = indicator.GetComponent<SpriteRenderer>();
        sr.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        sr.enabled = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        sr.enabled = false;
    }
}
