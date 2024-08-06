using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{


    GameObject[] coins;
    private void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("coin");
    }
    void Update()
    {

        Invoke(nameof(PasifYap), 3f);
    }
    void PasifYap()
    {
        gameObject.SetActive(false);
    }
 
}
