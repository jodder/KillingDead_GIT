
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int numeroVidasMaximo;
    [SerializeField] int numeroVidas;
    [SerializeField] float vidaMaxima = 1;
    [SerializeField] float vida;
    [SerializeField] int puntuacion;
    private const string PARAM_X = "x";
    private const string PARAM_Y = "y";

    public void ResetGame()
    {
        numeroVidas = numeroVidasMaximo;
        vida = vidaMaxima;
        GetComponent<UIManager>().ResetVidas();
    }
    public int GetNumeroVidasMaximo()
    {
        return numeroVidasMaximo;
    }
    public bool QuitarVida(float quita)
    {
        float resto;
        //Restamos la vida
        vida = vida - quita;
        resto = vida;
        if (vida <= 0)
        {
            GetComponent<UIManager>().ActualizarVida(numeroVidas, 0);
            numeroVidas = numeroVidas - 1;
            vida = vidaMaxima;
            if (numeroVidas <= 0)
            {
                //MUELTE - GAME OVER
                print("GameOver");
                return true;
            }
        }
        if (resto < 0)
        {
            QuitarVida(resto * -1);
        }
        GetComponent<UIManager>().ActualizarVida(numeroVidas, vida);
        return false;
    }
    public void IncrementarPuntuacion(int incrementoPuntuacion)
    {
        puntuacion = puntuacion + incrementoPuntuacion;
        GetComponent<UIManager>().ActualizarPuntuacion(puntuacion);
    }
    public void StorePlayerPosition(Vector2 position)
    {
        PlayerPrefs.SetFloat(PARAM_X, position.x);
        PlayerPrefs.SetFloat(PARAM_Y, position.y);
        PlayerPrefs.Save();
    }
    public Vector2 GetStoredPlayerPosition(Vector2 initialPlayerPos)
    {
        float x = PlayerPrefs.GetFloat(PARAM_X, initialPlayerPos.x);
        float y = PlayerPrefs.GetFloat(PARAM_Y, initialPlayerPos.y);
        return new Vector2(x, y);
    }

    //public bool HasStoredPlayerPosition()
    //{
    //    return PlayerPrefs.HasKey(PARAM_X);
    //}
}