using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;
    private bool isDialoguePlaying;

    private ItemSO item;

    public static DialogueManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {   
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!isDialoguePlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, ItemSO itemNPC)
    {
        currentStory = new Story(inkJSON.text);
        isDialoguePlaying = true;
        dialoguePanel.SetActive(true);

        item = itemNPC;
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void GiveItem()
    {
        if (item != null)
        {
            InventoryManager.instance.AddItem(item);
        }
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            GiveItem();
            ExitDialogueMode();
        }
    }
}
