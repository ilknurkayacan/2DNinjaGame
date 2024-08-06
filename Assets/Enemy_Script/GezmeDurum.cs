using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GezmeDurum : DusmanDurum
{
    Dusman dusman;
    private float firlatmasuresi = 5;
    private float firlatmazamanlayici;
    private bool firlatabilir = true;
    public void Enter(Dusman dusman)
    {
        this.dusman = dusman;
    }

    public void Execute()
    {
        Firlat();
        if (dusman.KavgaAlani())
        {
            dusman.DurumDegistir(new KavgaDurum());
        }
        else if (dusman.hedef != null)
        {

            dusman.Hareket();
        }
        else
        {
            dusman.DurumDegistir(new DusunmeDurum());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {

    }
    void Firlat()
    {
          
        firlatmazamanlayici += Time.deltaTime;
        if (firlatmazamanlayici >= firlatmasuresi)
        {
            firlatabilir = true;
            firlatmazamanlayici = 0;
        }
        if (firlatabilir)
        {
            firlatabilir = false;
            dusman.myanim.SetTrigger("e_firlat");

        }
    }
}
