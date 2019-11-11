using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovedorEnemigo : Movedor
{
    [SerializeField] Transform origen;
    [SerializeField] Transform destino;
    [SerializeField] float velocidad;
    [SerializeField] int direccion = 1;
    private SpriteRenderer sr;
    private float porcentaje = 0;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        porcentaje += Time.deltaTime * velocidad * direccion;
        transform.position =
            Vector2.Lerp(
                origen.position,
                destino.position,
                porcentaje);
        if (porcentaje >= 1 || porcentaje <= 0)
        {
            direccion *= -1;
            //sr.flipX = sr.flipX;
            porcentaje = Mathf.Clamp(porcentaje, 0, 1f);
        }
        else
        {
            //sr.flipX = !sr.flipX;
            porcentaje = Mathf.Clamp(porcentaje, 0, 1f);
        }
    }
}