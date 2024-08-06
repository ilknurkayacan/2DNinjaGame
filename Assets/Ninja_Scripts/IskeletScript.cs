using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IskeletScript : MonoBehaviour
{
    public Rigidbody2D myrigi;
    public Animator myanim;
    public bool sagabak;
    //atak
    public bool Atak { get; set; }
    
    public virtual void Start()
    {
        sagabak = true;
    }

    
    void Update()
    {
        
    }

    public void YonDegistir()
    {
        sagabak = !sagabak;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }
    //BicakFirlatma
    [SerializeField]
    private GameObject bicak;
    [SerializeField]
    private Transform bicakkonum;

    public virtual void BicakFirlat(int value)
    {
        if (sagabak)
        {
            GameObject clonsag = (GameObject)Instantiate(bicak, bicakkonum.position, Quaternion.Euler(0, 0, -90));
            clonsag.GetComponent<BicakBehaviour>().BicakYon(Vector2.right);
        }
        else
        {
            GameObject clonsol = (GameObject)Instantiate(bicak, bicakkonum.position, Quaternion.Euler(0, 0, 90));
            clonsol.GetComponent<BicakBehaviour>().BicakYon(Vector2.left);
        }
    }

    //olum ve Darbe durumlarý
    [SerializeField]
    private List<string> darbeKaynaklari;
    [SerializeField]
    protected int enerji;
    public abstract bool oldumu { get; }

    public abstract IEnumerator Darbe();
    public bool Darbede { get; set; }
    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (darbeKaynaklari.Contains(col.tag))
        {
            StartCoroutine(Darbe());
            Debug.Log(col.tag.ToString());
        }
    }
    //kýlýc iþlemleri
    [SerializeField]
    private EdgeCollider2D kilickolider;
    public void KavgaAtak()
    {
        kilickolider.enabled = true;
    }
    public EdgeCollider2D KilicCollider
    {
        get
        {
            return kilickolider;
        }
    }
}
