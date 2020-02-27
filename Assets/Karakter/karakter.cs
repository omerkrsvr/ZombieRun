using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class karakter : MonoBehaviour
{

    // Use this for initialization
    public float hiz;
    public float h;
    public float ziplama_gucu;
    Rigidbody2D fizik_karakter;
    Animator animasyon_oynatici;
    public bool yerdemi;
    public bool deadmi;
    public static int anahtar_sayisi;
    public static int can_sayisi;
    public Text textimiz;
    public Joystick joystick;
    float time = 0f;
    void Start()
    {
        fizik_karakter = GetComponent<Rigidbody2D>();
        animasyon_oynatici = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        //sol üstteki textler burada
        textimiz.text = anahtar_sayisi.ToString();
        //GetKeyDown tuşa bastığı anda zıplaması için.
        if (joystick.Vertical>0.5 && yerdemi)
        {
            fizik_karakter.velocity += new Vector2(0, ziplama_gucu);
            yerdemi = false;
        }
        if (transform.position.y < -20f)
        {
            
            dead();
            can_sayisi--;
        }

    }

    void FixedUpdate()
    {
        
        //x ekseninde gitmesini yaptık horizantal dediği yatay konum demek. Inputlardan yapıldı.
        h = joystick.Horizontal;
        transform.position += new Vector3(h * hiz * Time.deltaTime, 0, 0);
        // Burdaki if else ise karakterin sağ tarafa giderken sağa bakmasını sola giderken sola bakması için.
        if (h > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (h < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        animasyon_oynatici.SetFloat("hiz", Mathf.Abs(h));
        animasyon_oynatici.SetBool("yerde", yerdemi);
        //animasyon_oynatici.SetBool("deadmi", deadmi);

    }
 
    void can_azalma()
    {
        
        if(can_sayisi==0)
        {
            GameObject.Find("heart2").active = false;
        }
        if (can_sayisi == -1)
        {
            GameObject.Find("heart1").active = false ;
        }
        if (can_sayisi == -2)
        {
            GameObject.Find("heart0").active = false ;
           
        }
        if(can_sayisi<=-2)
        {
            deadmi = true;
            
            dead();
        }
        //deadmi = true;
        //animasyon_oynatici.SetBool("deadmi", deadmi);
        can_sayisi--;

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "tuzak")
        {
            if(time<=0)
            {
                
                Debug.Log(can_sayisi);
                can_azalma();
                time = 1f;
            }
        }
        else if(coll.gameObject.tag=="door")
        {
            if(anahtar_sayisi==3)
            {
                Application.LoadLevel("level2");
            }
        }
    }
    void dead()
    {
        time = 100f;
        can_sayisi = 1;
        anahtar_sayisi = 0;
        Application.LoadLevel(Application.loadedLevel);
    }
}



