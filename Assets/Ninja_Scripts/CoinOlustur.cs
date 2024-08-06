using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinOlustur : MonoBehaviour
{
    GameObject[] coins;
    private float xmax, xmin, ymax, ymin;
    private int duzenleyici;
    void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("coin");
        Vector3 alan = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        xmax = alan.x - 1f;
        xmin = -alan.x + 1f;
        ymax = alan.y - 1f;
        ymin = -alan.y + 1f;
        duzenleyici = 0;
        for (int i = 0; i < coins.Length; i++)
            coins[i].SetActive(false);
        
    }

    void Update()
    {
        Invoke(nameof(CoinYap), 3);
    }

    void CoinYap()
    {
        
        for(int i = 0; i < coins.Length; i++)
        {
            if (!coins[i].activeInHierarchy)
            {
                Vector3 konum = coins[i].transform.position;
                if (duzenleyici == 0)
                {
                    konum.x = Random.Range(0, xmax);
                    konum.y = Random.Range(-1, ymin) + 5f;
                   
                    duzenleyici = 1;
                }  
                if (duzenleyici == 1)
                {
                    konum.x = Random.Range(0, xmin);
                    konum.y = Random.Range(1, ymax)-5f;
                   
                    duzenleyici = 2;
                }
                if (duzenleyici == 2)
                {
                    konum.x = Random.Range(1, xmax);
                    konum.y = Random.Range(0, ymin) + 5f;
                    duzenleyici = 3;
                }
                if (duzenleyici == 3)
                {
                    konum.x = Random.Range(-1, xmin);
                    konum.y = Random.Range(0, ymax)-5f;
                    duzenleyici = 0;
                }
                coins[i].transform.position = konum;
                coins[i].SetActive(true);


            }
        }
    }
}
