using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //Con estas variables definiremos la rapidez tanto del desplazamiento como la rotacion
    public float velocidadMovimiento = 1f;
    public float velocidadRotacion = 1f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    //Actualizaremos la posicion del player con cada ciclo de motor
    void Update()
    {
        RotarPersonaje();
        MoverPersonaje();
    }

    private void MoverPersonaje()
    {
        //Desplazamiento hacia adelante y atras
        float movimientoVertical = Input.GetAxis("Vertical");
        Vector3 desplazamiento = transform.forward * movimientoVertical * velocidadMovimiento * Time.deltaTime;     //velocidadMovimiento * Time.deltaTime Para que el desplazamiento 
                                                                                                                    //en este caso no se vea afectado por el frame rate.
                                                                                                                    //Ahora hay que aplicar ese movimiento al CharacterController
        characterController.Move(desplazamiento);

    }
    private void RotarPersonaje()
    {
        //Rotacon de izquierda a derecha
        float movimientoHorizontal = Input.GetAxis("Horizontal"); ;
        Vector3 rotacion = new Vector3(0f, movimientoHorizontal, 0f) * velocidadRotacion * Time.deltaTime;
        transform.Rotate(rotacion);
    }
}
