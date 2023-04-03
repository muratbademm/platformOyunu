using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renk_degisim : MonoBehaviour
{
    // Start is called before the first frame update
    public Color[] renkler ;
    Color ilk_renk;
    Color ikinci_renk;
    public Material zemin_materyali;
    int br_renk;
    void Start()
    {
        br_renk = Random.Range(0, renkler.Length);// birinci renk 0 la 6 arası renk ataması yaptım
        zemin_materyali.color = renkler[br_renk];
        Camera.main.backgroundColor = renkler[br_renk];
        ikinci_renk = renkler[İkinci_renk_belirleme()];
    }

    // Update is called once per frame
    int İkinci_renk_belirleme()
    {
        int ik_renk;
        if (renkler.Length<=1)
         {
            ik_renk = br_renk;
            return ik_renk;
         }
        ik_renk = Random.Range(0, renkler.Length);
        while (ik_renk==br_renk)
        {
            ik_renk = Random.Range(0, renkler.Length);
        }
        return ik_renk;
    }
    void Update()
    {
        
        zemin_materyali.color = Color.Lerp(zemin_materyali.color,ikinci_renk,0.01f);
        
    }
}
