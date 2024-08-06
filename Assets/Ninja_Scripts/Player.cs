using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : IskeletScript
{
    private int coincount;
    [SerializeField]
    private Text skortext;
    [SerializeField]
    private GameObject coinvar;
    [SerializeField]
    private GameObject anahtar;
    [SerializeField]
    private GameObject anahtarvar;
    [SerializeField]
    private AudioSource coinses;
    [SerializeField]
    private AudioSource keyses;
    //ziplama
    [SerializeField]
    private Transform[] temasalani;
    [SerializeField]
    private float temascapi;
    [SerializeField]
    private LayerMask hangizemin;
    [SerializeField]
    private float ziplamakuvveti;
    public bool zeminde;

    public bool Zipla { get; set; }
    public bool Kayma { get; set; }


    private static Player player;
    public static Player Play
    {
        get
        {
            if (player == null)
            {
                player = GameObject.FindObjectOfType<Player>();
            }
            return player;
        }
    }
   
    public override void Start()
    {
        base.Start();
        myrigi = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
       
    }

   
    void FixedUpdate()
    {
        if (!oldumu && !Darbede)
        {
            float konum = Input.GetAxis("Horizontal");
            zeminde = ZemindeKontrol();
            KatmanKontrol();
            Yon(konum);
            HareketEt(konum);
        }
    }
    
    private void Update()
    {
        if (!oldumu && !Darbede)
        {
            HareketKontrol();
        }
    }

    void HareketEt(float konum)
    {
        if (!Atak)
        {
            myrigi.velocity = new Vector3(konum * 15, myrigi.velocity.y);
        }
        if(Zipla && myrigi.velocity.y==0)
        {      
            myrigi.AddForce(new Vector2(0, ziplamakuvveti));
           
        }
        if (myrigi.velocity.y < 0)
        {
            myanim.SetTrigger("dus");
          
        }
        myanim.SetFloat("karakterhizi", Mathf.Abs(myrigi.velocity.x));
    }
    void Yon(float konum)
    {
        if ((konum < 0 && sagabak || konum > 0 && !sagabak))
        {
            YonDegistir();
        }
    }

    void HareketKontrol()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            myanim.SetTrigger("kayma");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            myanim.SetTrigger("atak");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            myanim.SetTrigger("yuksel");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            myanim.SetTrigger("firlat");
          
        }
        if(Input.GetKeyDown(KeyCode.X) && !zeminde)
        {
            myanim.SetTrigger("zipla_firlat");
          
        }
        if(!zeminde && Input.GetKeyDown(KeyCode.A))
        {
            myanim.SetTrigger("zipla_atak");
        }
    }
    void KatmanKontrol()
    {
        if (!zeminde)
        {
            myanim.SetLayerWeight(1, 1);
        }
        else
        {
            myanim.SetLayerWeight(1, 0);
        }
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag("coin"))
        {
            coinses.Play();
            coinvar.SetActive(true);
            collision.gameObject.SetActive(false);
            coincount += 1;
            SkorAyarla(coincount * 100);
            if (coincount == 15)
            {
                anahtar.SetActive(true);
            
            }
        }
        if (collision.gameObject.CompareTag("key"))
        {
            keyses.Play();
            collision.gameObject.SetActive(false);
            anahtarvar.SetActive(true);
        }

    }

    void SkorAyarla(int puan)
    {
        skortext.text = "Skor: "+ puan.ToString();
    }
    //zipla
    bool ZemindeKontrol()
    {
        if (myrigi.velocity.y <= 0)
        {
           
            foreach(Transform nokta in temasalani)
            {
                Collider2D[] col = Physics2D.OverlapCircleAll(nokta.position, temascapi, hangizemin);
                for (int i = 0; i < col.Length; i++)
                {
                    if (col[i].gameObject != gameObject)
                    {
                        myanim.ResetTrigger("dus");
                        myanim.ResetTrigger("yuksel");
                        return true;
                    }
                }

            }
         
        }

        return false;
    }
    //BickFirlatma

    public override void BicakFirlat(int value)
    {
        if(value ==0 || value ==1)
            base.BicakFirlat(value);
    }
    //olum darbe
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
            myrigi.velocity = new Vector2(0, 0);
            myanim.SetTrigger("darbe");
        }
        else
        {
            myanim.SetLayerWeight(1, 0);
            myanim.SetTrigger("olum");
         
        }
        yield return null;
    }
}
