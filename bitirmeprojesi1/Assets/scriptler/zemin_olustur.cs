using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zemin_olustur : MonoBehaviour
{
    public GameObject  son_zemin;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            zemin_olusturma();
        }
        
    }
    public void zemin_olusturma() //oyun.cs den ulaşabilmek için public olarak oluşturdum fonksiyonumu
    {
        Vector3 yon;
        if (Random.Range(0, 2) == 0)
        {
            yon = Vector3.right;

        }
        else
        {
            yon = Vector3.back;
        }

       son_zemin= Instantiate(son_zemin, son_zemin.transform.position + yon, son_zemin.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
