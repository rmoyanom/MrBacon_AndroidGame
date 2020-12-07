﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DirectorGame : MonoBehaviour
{
    public GameObject jugador;
    public GameObject[] vidas;

    public GameObject SliderEscudo;
    private Slider escudoView;


   // public GameObject SliderLaser;

    private Player scriptjugador;
    private int vidaMostrada;

    void Start()
    {
        scriptjugador = jugador.GetComponent<Player>();
        vidaMostrada = scriptjugador.vida;
        MostrarVida(vidaMostrada);
        escudoView = SliderEscudo.GetComponent<Slider>();


        escudoView.minValue = 0;
        escudoView.maxValue = scriptjugador.timeMaxOfEscudo;

    }

    // Update is called once per frame
    void Update()
    {
        if(scriptjugador.vida != vidaMostrada)
        {
            MostrarVida(scriptjugador.vida);
            vidaMostrada = scriptjugador.vida;
        }
        RefescarBarras();
    }


    void MostrarVida(int vida) {

        if(vida < vidaMostrada) 
            for(int i = vida ; i < vidaMostrada; i++)
            {
                vidas[i].SetActive(false);
            }
        else
            for (int i = vida; i < vidaMostrada; i++)
            {
                vidas[i].SetActive(false);
            }
    }


    void RefescarBarras() {
        escudoView.value = scriptjugador.timeRemainingEscudo;
    }
}