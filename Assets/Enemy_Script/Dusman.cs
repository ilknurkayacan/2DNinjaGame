using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : IskeletScript
{
    DusmanDurum mevcutdurum;
    public GameObject hedef { get; set; }
    private static Dusman dusman;
    public bool Firlat { get; set; }
    public static Dusman Dus
    {
        get
        {
            if (dusman == null)
            {
                dusman = GameObject.FindObjectOfType<Dusman>();
            }
            return dusman;
        }
    }

    public override void Start()
    {
        base.Start();
        myrigi = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
        DurumDegistir(new DusunmeDurum());
    }

    // Update is called once per frame
    void Update()
    {
        if (!oldumu)
        {
           
            if (!Darbede)
            {
                mevcutdurum.Execute();
            }
            DusmanTakip();
        }
    }
    public void Hareket()
    {
        transform.Translate(Yon() * 10 * Time.deltaTime);
        myanim.SetFloat("dusmanhizi", 1);
    }
    Vector2 Yon()
    {
        return sagabak ? Vector2.right : Vector2.left;
    }
    public void DusmanTakip()
    {
        if (hedef != null)
        {
            float mesafe = hedef.transform.position.x-transform.position.x;

            if (mesafe < 0 && sagabak || mesafe > 0 && !sagabak)
                YonDegistir();
        }
    }
    public void DurumDegistir(DusmanDurum yenidurum)
    {
        if(mevcutdurum != null)
        {
            mevcutdurum.Exit();
        }
        mevcutdurum = yenidurum;
        mevcutdurum.Enter(this);
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        mevcutdurum.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag("engel"))
        {
            YonDegistir();
        }
    }
    public override void BicakFirlat(int value)
    {
        myanim.SetFloat("dusmanhizi", 0);
        myrigi.velocity = Vector2.zero;
        base.BicakFirlat(value);
    }
    //firlatma alani
    [SerializeField]
    private float FirlatmaSahasi;
    public bool FirlatmaAlani()
    {
        if (hedef != null)
        {
            return Vector2.Distance(hedef.transform.position, transform.position) <= FirlatmaSahasi;
        }

        return false;
    }
    //atak alani
    [SerializeField]
    private float KavgaSahasi;

    public bool KavgaAlani()
    {
        if (hedef != null)
        {
            return Vector2.Distance(hedef.transform.position, transform.position) <= KavgaSahasi;
        }
        return false;
    }
    //darbe olum durumlarý
    public override bool oldumu
    {
        get
        {
            return enerji <= 0;
        }
        
    }
    public override IEnumerator Darbe()
    {
        enerji -= 10;
        if (!oldumu)
        {
            myanim.SetTrigger("e_darbe");
        }
        else
        {
            myanim.SetTrigger("e_olum");
           
        }
        yield return null;

    }

}
