using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyun : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 yon;
    public float hız;
    public zemin_olustur zemin_olusturma;
    public static bool dustu_mu;
    public float hızlanma_zorlugu;
    float skor;
    public int skor_artması;
    public Text text_skor;
    int enyuksek_skor;
    void Start()
    {
        enyuksek_skor = PlayerPrefs.GetInt("en yüksek skor");// oyun başında hep önceki en yüksek skorla başlamamızı sağladım
        dustu_mu = false;

        yon = Vector3.back;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dustu_mu==true)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(yon.x==0)
            {
                yon = Vector3.right;// 3 boyutlu olduğunu ve sağa doğru gitmesini sağladım
            }
            else
            {
                yon = Vector3.back;
            }
        }
        if (transform.position.y<2.80f)
        {
            Olunce();
        }
    }

    void Olunce()
    {
        if (enyuksek_skor < (int)skor)
        {
            enyuksek_skor = (int)skor;
            PlayerPrefs.SetInt("en yüksek skor", enyuksek_skor);
            Debug.Log("yeni yüksek skor");
        }
        dustu_mu = true;
        Debug.Log("öldün");
    }
     void FixedUpdate()
    {
        if (dustu_mu)
        {
            return;
        }
        Vector3 hareket = yon * Time.deltaTime * hız; // hız değişkeni ile hareket yönümün hızını belirledim
        transform.position += hareket;
        hız += hızlanma_zorlugu * Time.deltaTime;// oyun her 0.2 saniyede bir hızlanıcak;
        skor += (skor_artması * hız*Time.deltaTime);
        text_skor.text = ((int)skor).ToString();
    }
    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag=="zemin")
        {
            
           StartCoroutine (zeminkaldır (coll.gameObject));
            zemin_olusturma.zemin_olusturma();
        }
    }
    IEnumerator zeminkaldır(GameObject kaldirilacak) // bu Ienumerator fonksiyonumuz ile bekletme işlemlerini yaptım
    {
        yield return new WaitForSeconds(0.3f);// zeminin yok edilme süresini 0.3 saniye yaptım topumuz ilerledikçe 0.3 saniyede geride ki zemin gidecek
        kaldirilacak.AddComponent<Rigidbody>(); // rigibody bileşeni ile düşerken de kaç saniye gözükeceğini belirledim
        yield return new WaitForSeconds(1.0f);
        Destroy(kaldirilacak);
    }
}
