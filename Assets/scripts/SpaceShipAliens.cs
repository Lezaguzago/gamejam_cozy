using System;
using UnityEngine;

public class SpaceShipAliens : MonoBehaviour
{
    [SerializeField] int spawnThis;
    void Start()
    {
        if (GeralManager.instance.lifeSaveds >= spawnThis)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
