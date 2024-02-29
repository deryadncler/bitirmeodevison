using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class dusmansayi : MonoBehaviour
{
    public Text enemyCountText; // UI Text elemaný
    private int enemyCount; // Düþman sayýsý

    private float enemycount;
    bool oyunDevam = true;
    bool oyunTamam = false;
    public Text durum;

    public Image back;


    void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;  // Baþlangýçta düþman sayýsýný al
        UpdateEnemyCountText(); // Baþlangýçta düþman sayýsýný göster
       
    }

    void  Update()
    {
        // Her güncellemede düþman sayýsýný kontrol etmek için gerekli deðil
        // Ancak baþka bir yerde düþmanlarýn dinamik olarak eklenip çýkarýldýðý durumlarda kullanýlabilir
        int currentEnemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;
        if (currentEnemyCount != enemyCount)
        {
            enemyCount = currentEnemyCount;
            UpdateEnemyCountText(); // Düþman sayýsýný güncelle
            if (enemyCount <= 0)
            {
                oyunTamam = true;
                durum.text = "ZAFER";
                back.gameObject.SetActive(true);
            }
           
        }
        
    }

    void UpdateEnemyCountText()
    {
        enemyCountText.text = "Düþman Sayýsý: " + enemyCount.ToString(); // UI Text elemanýnda düþman sayýsýný göster
    }
    
  
}
