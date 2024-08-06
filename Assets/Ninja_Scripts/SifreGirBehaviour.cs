using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SifreGirBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject sifrevar;
    [SerializeField]
    private GameObject acikkapi;
    [SerializeField]
    private GameObject kapikapali;
    [SerializeField]
    private AudioSource kapiacikses;
    [SerializeField]
    private AudioSource kapikapalises;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && sifrevar.activeSelf)
        {
            gameObject.SetActive(false);
            kapiacikses.Play();
            kapikapali.SetActive(false);
            acikkapi.SetActive(true);
            collision.gameObject.SetActive(false);
            
        }
        if (collision.gameObject.CompareTag("Player") && sifrevar.activeSelf)
        {
            kapikapalises.Play();
        }
    }
}
