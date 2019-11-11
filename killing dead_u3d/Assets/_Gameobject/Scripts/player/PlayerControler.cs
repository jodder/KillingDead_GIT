using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform puntoDisparo;
    [SerializeField] float fuerzaDisparo;
    [SerializeField] float jumpForce;
    [SerializeField] Transform puntoDeteccion;
    [SerializeField] LayerMask layerSuelo;
    [SerializeField] PhysicsMaterial2D pm2d;
    //private AudioSource[] audios;
    private float x, y;
    private Rigidbody2D rb;
    private GameManager gm;
    [SerializeField] Animator animator;
    private const int AUDIO_SHOT = 0;
    private const int AUDIO_JUMP = 1;
    private Vector2 posInicial;
    //private bool inFloor = false;

    void Start()
    {
        posInicial = transform.position;
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("UIManager").GetComponent<GameManager>();
        //animator = this.gameObject.GetComponentInChildren<Animator>();
        //audios = GetComponents<AudioSource>();
        
        IniciarPosicion();
    }

    

    private void IniciarPosicion()
    {
        transform.position = gm.GetStoredPlayerPosition(posInicial);
    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
            animator.SetBool("Disparando", true);
           
        }
        if (Input.GetButtonDown("Jump"))
        {
            Saltar();
        }
    }
    void LateUpdate()
    {
        if (Mathf.Abs(x) > 0)
        {
            animator.SetBool("Isruning", true);
            rb.velocity = new Vector2(x * speed, rb.velocity.y);
            //float  alturafuego = puntoDisparo.position.y;
            if (x > 0.1f)
            {
                Quaternion newRot = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
                transform.rotation = newRot;
                //GetComponentInChildren<SpriteRenderer>().flipX = false;
                //puntoDisparo.position = new Vector2(-puntoDisparo.position.x, alturafuego);
            }
            else
            {
                if (x < -0.1f)
                {

                    Quaternion newRot = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
                    transform.rotation = newRot;
                    //GetComponentInChildren<SpriteRenderer>().flipX = true;
                    
                    //puntoDisparo.position = new Vector2(-puntoDisparo.position.x, alturafuego);
                }
            }
        }
        else
        {
            animator.SetBool("Isruning", false);
            rb.velocity = new Vector2(0, 0);
        }

    }
    public void RecibirDanyo(float danyo)
    {
        if (gm.QuitarVida(danyo))
        {
            //Ha perdido todas las vidas
            gm.ResetGame();
            IniciarPosicion();
        }
    }
    private void Disparar()
    {
        GameObject proyectil = Instantiate(
            prefabProyectil,
            puntoDisparo.position,
            puntoDisparo.rotation);
        
        proyectil.GetComponent<Rigidbody2D>().AddForce(puntoDisparo.right * fuerzaDisparo);
        //audios[AUDIO_SHOT].Play();
    }
    private void Saltar()
    {
        if (InFloor())
        {
            //rb.AddForce(Vector2.up * jumpForce);//Alternativa mediante impulso
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //audios[AUDIO_JUMP].Play();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        InFloor();
    }
    private bool InFloor()
    {
        Collider2D c2d = Physics2D.OverlapBox(puntoDeteccion.position, new Vector2(0.605f, 0.1f), 0, layerSuelo);
        if (c2d != null)
        {
            GetComponent<BoxCollider2D>().sharedMaterial = null;
            return true;
        }
        GetComponent<BoxCollider2D>().sharedMaterial = pm2d;
        return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Adhesivo"))
        {
            transform.SetParent(collision.gameObject.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Adhesivo"))
        {
            transform.SetParent(null);
        }
    }
}
