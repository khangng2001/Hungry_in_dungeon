using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : MonoBehaviour
{
    public bool fall = false;
    [SerializeField] private GameObject player;

    private void Update()
    {
        if (fall)
        {
            player.GetComponent<PlayerInput>().enabled = false;
            player.GetComponent<PlayerController>().enabled = false;


            if (player.transform.localScale.x == 0f || player.transform.localScale.y <= 0f)
            {

            }
            else if (player.transform.localScale.x < 0f)
            {
                player.transform.localScale -= new Vector3(-0.1f, 0.1f, 0f);
            }
            else
            {
                player.transform.localScale -= new Vector3(0.1f, 0.1f, 0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hole"))
        {
            fall = true;
        }
    }
}
