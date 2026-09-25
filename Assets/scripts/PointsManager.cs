using System;
using TMPro;
using UnityEngine;
using System.Collections;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointScreen;
    [SerializeField] TextMeshProUGUI saved;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GeralManager.instance.pontos >= 0)
        {
            pointScreen.text = "$ " + GeralManager.instance.pontos.ToString();
        }
        else
        {
            pointScreen.text = "$ IN DEPT";
            GeralManager.instance.pontos = -30;
        }
        if (GeralManager.instance.saved)
        {
            StartCoroutine(NewAlien());
        }
    }
    IEnumerator NewAlien()
    {
        saved.text = "SAVED";
        yield return new WaitForSeconds(1f);
        saved.text = "";
        GeralManager.instance.saved = false;
    }
}
