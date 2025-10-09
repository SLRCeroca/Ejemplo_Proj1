using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private float vel = 50f;
    private const float LIMIT_Z_NEGATIVO = -10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z - vel * Time.deltaTime
        );
        if (transform.position.z < LIMIT_Z_NEGATIVO)
        {
            Destroy(gameObject);
        }

    }
    
    void OnTriggerEnter(Collider objectoTocado)
    {
        if(objectoTocado.tag == "AmogusJugador")
        {
            Destroy(gameObject);
        }else if(objectoTocado.tag == "Bala")
        {
            Destroy(gameObject);
        }
    }
}
