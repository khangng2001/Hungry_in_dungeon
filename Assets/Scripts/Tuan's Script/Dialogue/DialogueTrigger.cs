using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject cue;

    [SerializeField] private TextAsset wizzardInk;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        cue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange)
        {
            cue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogueManager.instance.EnterDialogueMode(wizzardInk);
            }
        } 
        else
        {
            cue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
