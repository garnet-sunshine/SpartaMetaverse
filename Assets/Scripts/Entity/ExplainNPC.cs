using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplainNPC : MonoBehaviour
{
    [SerializeField] private GameObject explainCanvas;
    [SerializeField] private GameObject explainUI;

    private void Start()
    {
        explainCanvas.SetActive(false);

        if(explainUI != null )
            explainUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            explainCanvas.SetActive(true);

            if(explainUI != null )
                explainUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            explainCanvas.SetActive(false);

            if (explainUI != null )
                explainUI.SetActive(false);
        }
    }
}
