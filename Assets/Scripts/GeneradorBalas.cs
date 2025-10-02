using UnityEngine;

public class GeneradorBalas : MonoBehaviour
{
    public GameObject prefabBalas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GenerarBalas();
        }
    }

    private void GenerarBalas()
    {
        Instantiate(prefabBalas, transform.position, transform.rotation);
    }
}
