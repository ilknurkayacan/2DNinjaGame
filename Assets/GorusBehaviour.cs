using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorusBehaviour : MonoBehaviour
{
    public Dusman dusman;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dusman.hedef = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dusman.hedef = null;
        }
    }
}
