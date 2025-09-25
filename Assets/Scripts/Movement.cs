using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vel = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        transform.position += nuevoDesplazamiento;
    }
}
