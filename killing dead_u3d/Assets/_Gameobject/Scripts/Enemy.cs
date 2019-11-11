using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float vida = 1f;
    [SerializeField] Slider sliderVida;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void RecibirDanyo(float danyo)
    {
        audioSource.Play();
        vida -= danyo;
        sliderVida.value = vida;
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}