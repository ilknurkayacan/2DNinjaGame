using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevriyeDurum : DusmanDurum
{
    Dusman dusman;
    private float devriyesuresi = 5;
    private float devriyazamanlayici;
    public void Enter(Dusman dusman)
    {
        this.dusman = dusman;
    }

    public void Execute()
    {
        Devriye();
        dusman.Hareket();
        if (dusman.hedef != null)
        {
            dusman.DurumDegistir(new GezmeDurum());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {

    }

    void Devriye()
    {
        devriyazamanlayici += Time.deltaTime;
        if(devriyazamanlayici >= devriyesuresi)
        {
            dusman.DurumDegistir(new DusunmeDurum());
        }
    }
}
