using PathCreation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public ControladorDeObstaculos cdObs;
    public ControladorDeUI controladorDeUI;
    public static bool iniciarjuego = false;
    public static bool iniciandoJuego = false;


    // Update is called once per frame
    void Update()
    {
        if (!iniciandoJuego)
        {
                controladorDeUI.showMenu();

                iniciandoJuego = true;
                StartCoroutine(CuentaAtras());

                //cdObs.PuedeGenerarObstaculos = true;
                //iniciarjuego = true;
                //gameObject.SetActive(false);
        }
    }

    public IEnumerator CuentaAtras() {
        controladorDeUI.setCount("3");
        yield return new WaitForSeconds(1);
        controladorDeUI.setCount("2");
        yield return new WaitForSeconds(1);
        controladorDeUI.setCount("1");
        yield return new WaitForSeconds(1);
        controladorDeUI.setCount("Go!");
        yield return new WaitForSeconds(1);
        controladorDeUI.hideCount();

        cdObs.PuedeGenerarObstaculos = true;
        iniciarjuego = true;
        gameObject.SetActive(false);
    }

    public static void reiniciarJuego()
    {
        SceneManager.LoadScene("Escenario1");
    }
}
