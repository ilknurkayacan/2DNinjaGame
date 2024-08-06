using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SifreBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject sifrevar;
    [SerializeField]
    private AudioSource sifreses;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sifreses.Play();
            gameObject.SetActive(false);
            sifrevar.SetActive(true);
        }
    }
}
