using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] Transform origen;
    [SerializeField] Transform destino;

    private float porcentaje = 0;
    private float velocidad = 0.5f;
    private int direccion = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = origen.position;
    }

    // Update is called once per frame
    void Update()
    {
        porcentaje += Time.deltaTime * velocidad * direccion;
        transform.position =
            Vector2.Lerp(origen.position,destino.position,porcentaje);
        // rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")

        {
            //quitar vida.

        }
    }
}
