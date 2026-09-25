using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletDestroy = 1f;

    private void Awake()
    {
        Destroy(gameObject, bulletDestroy);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
