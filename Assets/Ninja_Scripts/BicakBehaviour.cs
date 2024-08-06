using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicakBehaviour : MonoBehaviour
{
    private Rigidbody2D myrigi;
    private Vector3 bicakyon;
    void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        myrigi.velocity = bicakyon * 15;
    }

    public void BicakYon(Vector3 yon)
    {
        this.bicakyon = yon;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
