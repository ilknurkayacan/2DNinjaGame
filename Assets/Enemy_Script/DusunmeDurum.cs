using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusunmeDurum : DusmanDurum
{
    private Dusman dusman;
    private float dusunmesuresi = 3;
    private float dusunmezamanlayici;
    public void Enter(Dusman dusman)
    {
        this.dusman = dusman;
    }

    public void Execute()
    {
        Dusunme();
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

    void Dusunme()
    {
        dusman.myanim.SetFloat("dusmanhizi", 0);
        dusunmezamanlayici += Time.deltaTime;
        if (dusunmezamanlayici >= dusunmesuresi)
        {
            dusman.DurumDegistir(new DevriyeDurum());
        }
    }
}
