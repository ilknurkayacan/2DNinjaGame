using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject kapiacik;
    [SerializeField]
    private GameObject anahtarvar;
    [SerializeField]
    private AudioSource acikkapises;
    [SerializeField]
    private AudioSource kapalikapises;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && anahtarvar.activeSelf)
        {
            acikkapises.Play();
            gameObject.SetActive(false);
            kapiacik.SetActive(true);
            collision.gameObject.SetActive(false);
            SceneManager.LoadScene("GecisPart");
        }
        if(collision.gameObject.CompareTag("Player") && !anahtarvar.activeSelf)
        {
            kapalikapises.Play();
        }
    }
}
