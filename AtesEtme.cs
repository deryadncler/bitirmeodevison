using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtesEtme : MonoBehaviour
{
    RaycastHit hit;
    public GameObject MermiCikisNoktasi;
    public bool AtesEdebilir;
    float GunTimer;
    public float TaramaHizi;
    public ParticleSystem MuzzleFlash;
    AudioSource SesKaynak;
    public AudioClip AtesSesi;
    public float Menzil;
    public float demageenemy;
    public GeriTepme recoil;
    public GameObject mermiEfekti;
    public GameObject kanEfekti;


    public float mermi;
    public float sarjor;
    public float tasinanmermi;
    float eklenenmermi;
    float reloadTimer;
    public Text mermisayac;



    bool oyunDevam = true;
    bool oyunTamam = false;
    public Text zaman;
    float zamanSayaci = 300f;
    private float enemycount;

    // Start is called before the first frame update
    void Start()
    {
        SesKaynak = GetComponent<AudioSource>();
        enemycount = GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        mermisayac.text = "Mermi: "+"" + mermi + "/" + tasinanmermi;

        eklenenmermi = sarjor - mermi;
        if (eklenenmermi > tasinanmermi)
        {
            eklenenmermi = tasinanmermi;
        }
        if(Input.GetKey(KeyCode.R) && eklenenmermi>0 && tasinanmermi > 0)
            if(Time.time>reloadTimer)
        {
                StartCoroutine(Reload());
        }


        int currentEnemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;
        if (currentEnemyCount != enemycount)
        {
            enemycount = currentEnemyCount;
            
            if (enemycount <= 0)
            {
                oyunTamam = true;
                oyunDevam = false;
            }

        }

        zamanSayaci -= Time.deltaTime;
        zaman.text = (int)zamanSayaci + "";

        if (zamanSayaci <= 0)
        {
            oyunDevam = false;
            oyunTamam = true;
        }

            if (oyunDevam && !oyunTamam)
        {
            if (Input.GetKey(KeyCode.Mouse0) && AtesEdebilir == true && Time.time > GunTimer && mermi>0)
            {
                Fire();
                GunTimer = Time.time + TaramaHizi;
                recoil.Fire();

                if (hit.transform.tag == "enemy")
                {
                    Instantiate(kanEfekti, hit.point, Quaternion.LookRotation(hit.normal));
                }
                if (hit.transform.tag == "Untagged")
                {
                    Instantiate(mermiEfekti, hit.point, Quaternion.LookRotation(hit.normal));
                }

            }
        }
       
    }

    void Fire()
    {
        if (mermi <= 0)
        {
            AtesEdebilir = false;
        }
        if (mermi > 0)
        {
            AtesEdebilir = true;
            mermi--;
        }


        if (Physics.Raycast(MermiCikisNoktasi.transform.position, MermiCikisNoktasi.transform.forward, out hit, Menzil))
        {
            MuzzleFlash.Play();
            SesKaynak.Play();
            SesKaynak.clip = AtesSesi;
            Debug.Log(hit.transform.name);

            if (hit.transform.tag == "enemy")
            {
                enemyhealth enemyhealthScript = hit.transform.GetComponent<enemyhealth>();
                enemyhealthScript.DeductHealth(demageenemy);
            }
           
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.2f);
        mermi = mermi + eklenenmermi;
        tasinanmermi = tasinanmermi - eklenenmermi;
    }
      
}