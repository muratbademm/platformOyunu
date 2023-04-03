using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameratakip : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform takip_edilecek_nesne;
    Vector3 fark;
    void Start()
    {
        fark = transform.position - takip_edilecek_nesne.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
       
        if (oyun.dustu_mu==false)
        {
            transform.position = takip_edilecek_nesne.position + fark;
        }
    }
}
