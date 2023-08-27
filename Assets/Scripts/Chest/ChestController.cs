using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private RangeOpen rangeOpen;

    private Animator animator;

    [SerializeField] private GameObject interactionUI;

    private void Awake()
    {
        rangeOpen = GetComponentInChildren<RangeOpen>();

        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        CheckPlayerIn();

        CheckClickOpen();
    }

    private void CheckPlayerIn()
    {
        if (rangeOpen.GetIsIn())
        {
            interactionUI.SetActive(true);
        }
        else
        {
            interactionUI.SetActive(false);
        }
    }

    private void CheckClickOpen()
    {
        if (interactionUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.Play("Open");
            }
        }
        else
        {
            animator.Play("Close");
        }
    }
}
