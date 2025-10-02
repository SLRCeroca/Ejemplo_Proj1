using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vel = 10f;
    private Camera camera;
    private Vector3 limiteInferiorIzquierda;
    private Vector3 limiteSuperiorDerecha;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
        //Buscamos la distancia entre camara y objeto que no queremos que salga del viewport en el axis Z
        float distanciaZCameraNave = Mathf.Abs(transform.position.z - camera.transform.position.z);
        limiteInferiorIzquierda = camera.ViewportToWorldPoint(new Vector3(0,0, distanciaZCameraNave));
        limiteSuperiorDerecha = camera.ViewportToWorldPoint(new Vector3(1,1, distanciaZCameraNave));
    }

    // Update is called once per frame
    void Update()
    {
        ControlLimitesPantalla();
        MovimientoNave();
    }

    void MovimientoNave()
    {
        //Movimiento nave
        float direccionHorizontal = Input.GetAxisRaw("Horizontal");
        float direccionVertical = Input.GetAxisRaw("Vertical");
        Vector3 direccion = new Vector3(direccionHorizontal, direccionVertical, 0).normalized; // (x, y, z)
        //Debug.Log("Direccion: " + direccion);

        Vector3 nuevoDesplazamiento = new Vector3(
        vel * direccion.x * Time.deltaTime,
        vel * direccion.y * Time.deltaTime,
        vel * direccion.z * Time.deltaTime
        );
        //Debug.Log("Time.deltatime: " + Time.deltaTime);

        //Control de los limites de la pantalla
        //El metodo Math.Clamp nos devuelve el primer parametro, pero si el primer parametro es mas pequeño que el segundo devuelve el segundo,
        //Pero si tiene un valor mas grande que el tercero nos devuelve el tercer parametro.
        nuevoDesplazamiento.x = Math.Clamp(nuevoDesplazamiento.x, limiteInferiorIzquierda.x, limiteSuperiorDerecha.x);
        nuevoDesplazamiento.y = Math.Clamp(nuevoDesplazamiento.y, limiteInferiorIzquierda.y, limiteSuperiorDerecha.y);

        //Aplicamos el desplazamiento
        transform.position += nuevoDesplazamiento;
    }

    void ControlLimitesPantalla()
    {
        //No podemos modificar el transform.position.x, solo consultarlo, asi que hacemos una nueva variable
        Vector3 nuevaPosicion = transform.position;
        //Control de los limites de la pantalla
        //El metodo Math.Clamp nos devuelve el primer parametro, pero si el primer parametro es mas pequeño que el segundo devuelve el segundo,
        //Pero si tiene un valor mas grande que el tercero nos devuelve el tercer parametro.
        nuevaPosicion.x = Math.Clamp(nuevaPosicion.x, limiteInferiorIzquierda.x, limiteSuperiorDerecha.x);
        nuevaPosicion.y = Math.Clamp(nuevaPosicion.y, limiteInferiorIzquierda.y, limiteSuperiorDerecha.y);

        //Aplicamos la posicion
        transform.position = nuevaPosicion;
    }
}
