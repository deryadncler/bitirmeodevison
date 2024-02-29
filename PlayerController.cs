using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController characterController;
    public Transform cam;
    public float lookSensivity;
    public float maxXRot;
    public float minXRot;
    private float curXRot;

    bool oyunDevam = true;
    bool oyunTamam = false;
    public Text zaman;
    float zamanSayaci = 300f;
    public Image back;
    public Text durum;
    private int enemyCount; // Düþman sayýsý

    private void Start()
    {
       
         
        enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;

    }
    private void Update()
    {
        
           if(Input.GetKey(KeyCode.G))
            {
                SceneManager.LoadScene(1);
            }
        

        int currentEnemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;
        if (currentEnemyCount != enemyCount)
        {
            enemyCount = currentEnemyCount;
           
            if (enemyCount <= 0)
            {
                oyunTamam = true;
                oyunDevam = false;
                back.gameObject.SetActive(true);
            }

        }

        zamanSayaci -= Time.deltaTime;
        zaman.text = (int)zamanSayaci + "";

        if (zamanSayaci <= 0)
        {
            oyunDevam = false;
            oyunTamam = true;
            durum.text = "YENÝLGÝ!";
            back.gameObject.SetActive(true);
        }
        if (oyunDevam && !oyunTamam)
        {
            Move();
            Look();
        }
       
        
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir.Normalize();

        dir *= moveSpeed * Time.deltaTime;
        characterController.Move(dir);
    }
    void Look()
    {
        float x = Input.GetAxis("Mouse X") * lookSensivity;
        float y = Input.GetAxis("Mouse Y") * lookSensivity;

        transform.eulerAngles += Vector3.up * x;

        curXRot += y;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);
        cam.localEulerAngles = new Vector3(-curXRot, 0.0f, 0.0f);

    }
   
   
}
