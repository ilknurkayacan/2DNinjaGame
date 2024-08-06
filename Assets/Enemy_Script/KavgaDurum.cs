using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KavgaDurum :DusmanDurum
{
    Dusman dusman;
    private float kavgasuresi = 3;
    private float kavgazamanlayici;
    private bool kavgaedebilir;
    public void Enter(Dusman dusman)
    {
        this.dusman = dusman;
    }

    public void Execute()
    {

        if (dusman.KavgaAlani())
        {
            Kavga();
            dusman.myanim.SetFloat("dusmanhizi", 0);
        }
        if (dusman.FirlatmaAlani() && !dusman.KavgaAlani())
        {
            dusman.DurumDegistir(new GezmeDurum());
        }
        else if(dusman.hedef==null)
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

    void Kavga()
    {
        kavgazamanlayici += Time.deltaTime;
        if (kavgazamanlayici >= kavgasuresi)
        {
            kavgazamanlayici = 0;
            kavgaedebilir = true;
        }
        if (kavgaedebilir)
        {
            kavgaedebilir = false;
            dusman.myanim.SetTrigger("e_atak");
        }
    }
}
