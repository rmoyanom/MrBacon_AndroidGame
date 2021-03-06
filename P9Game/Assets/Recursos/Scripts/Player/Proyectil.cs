using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float dañoaEnemigo;
    public float velocidad;
    public AudioClip Inicio;

    Vector3 localScale;

    Transform destructor;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        destructor = GameObject.Find("destructorRight").GetComponent<Transform>();
       
        if (GetComponent<AudioSource>() != null)
        {
            sound = GetComponent<AudioSource>();
            sound.clip = Inicio;
            sound.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {

        localScale = this.transform.position;
        localScale.x += velocidad;
        transform.Translate(new Vector3(velocidad,0) * Time.deltaTime);

        
        if (transform.position.x > destructor.position.x)
        {
            Destroy(this.gameObject);
        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Meteorito")
        {
            if (collision.gameObject.GetComponent<movimiento>().elementoActivado)
            {
                collision.gameObject.GetComponent<movimiento>().elementoActivado = false;
                collision.gameObject.GetComponent<Animator>().SetBool("destroy", true);
                collision.gameObject.GetComponent<AudioSource>().Play();

               
                Destroy(collision.gameObject,0.4f);
                Destroy(this.gameObject);
            }
        }


        if (collision.gameObject.tag == "Enemigo")
        {

            collision.gameObject.GetComponent<IaBasic>().QuitarVida(dañoaEnemigo);
            Destroy(this.gameObject);
            
            
        }


    }
}
