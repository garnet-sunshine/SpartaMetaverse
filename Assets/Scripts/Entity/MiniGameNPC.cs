using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameNPC : MonoBehaviour
{
    [SerializeField] private GameObject interactionButton;
    [SerializeField] private SceneTransitionTrigger transitionTrigger;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Debug.Log("E Å° ´­¸²");
    }

    private void Start()
    {
        if (interactionButton != null)
            interactionButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactionButton != null)
        {
            interactionButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactionButton != null)
        {
            interactionButton.SetActive(false);        
        } 
    }

    public void OnClickEnterButton()
    {
        transitionTrigger.StartTransition();
    }
}
