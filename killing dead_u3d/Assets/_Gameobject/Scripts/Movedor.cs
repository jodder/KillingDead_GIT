using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movedor : MonoBehaviour {
    public Transform izq;
    public Transform dcha;
    //public Transform detector;
    //public float distanciaDeteccion;
    //public LayerMask whatIsPivot;
    public float velocidad;
    public int direccion = 1;
    private SpriteRenderer sr;
    private float cantidadMovimiento = 0;
    private void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update() {
        cantidadMovimiento += Time.deltaTime * velocidad * direccion;
        transform.position =
            Vector2.Lerp(
                dcha.position,
                izq.position,
                cantidadMovimiento);
        cantidadMovimiento = Mathf.Clamp(cantidadMovimiento, 0, 1f);
        if (transform.position == izq.position) {
            direccion *= -1;
            Quaternion newRot = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            transform.rotation = newRot;
        } else if (transform.position == dcha.position) {
            direccion *= -1;
            Quaternion newRot = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            transform.rotation = newRot;

        }
    }

    //    private void Update() {
    //        MoverseHaciaDelante();
    //        DetectarGiro();
    //    }

    //    private void MoverseHaciaDelante() {
    //        transform.position = new Vector3((transform.position.x + (Time.deltaTime * velocidad * direccion)), transform.position.y, transform.position.z);
    //    }
    //    private void DetectarGiro() {
    //        RaycastHit2D pivotHit = Physics2D.Raycast(detector.transform.position, detector.transform.right * direccion, distanciaDeteccion, whatIsPivot);
    //        if (pivotHit.collider != null) {
    //            if (pivotHit.collider.transform == izq || pivotHit.collider.transform == dcha) {
    //                direccion *= -1;
    //                Quaternion newRot = Quaternion.Euler(transform.rotation.x, direccion == 1 ? 180 : 0, transform.rotation.z);
    //                transform.rotation = newRot;
    //            }            
    //        }
    //    }

    //private void OnDrawGizmosSelected() {
    //        Debug.DrawRay(detector.transform.position, -detector.transform.right * distanciaDeteccion, Color.yellow);
    //    }
}