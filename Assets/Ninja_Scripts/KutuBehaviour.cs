using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutuBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject sifre;
    [SerializeField]
    private AudioSource kapises;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && Player.Play.myanim.GetCurrentAnimatorStateInfo(0).IsTag("kayma"))
        {
            sifre.SetActive(true);
            gameObject.SetActive(false);
        }
        if(collision.gameObject.CompareTag("Player") && !Player.Play.myanim.GetCurrentAnimatorStateInfo(0).IsTag("kayma"))
        {
            kapises.Play();
        }
    }
}
