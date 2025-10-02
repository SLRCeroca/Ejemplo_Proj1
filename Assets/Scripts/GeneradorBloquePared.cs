using UnityEngine;

public class GeneradorBloquePared : MonoBehaviour
{
    public float vel = 20f;
    private const float LIMITE_IZQUIERDA = -6f;
    private const float LIMITE_INFERIOR = -1f;
    private const float LIMITE_DERECHA = 6f;
    private const float LIMITE_SUPERIOR = 6f;
    private const float LIMITE_POSTERIOR = 90f;

    public GameObject prefabBloquePared;
    public GameObject prefabObstaculo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Param1: Funcion que se llama repetidamente
        //Param2: Cuanto tarda en llamarse desde que se inicia la escena
        //Param3: Cada cuanto tiempo se vuelve a llamar
        InvokeRepeating("GenerarBloquesPared", 0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerarBloquesPared()
    {
        GameObject ParedInferiorIzquierda = Instantiate(prefabBloquePared);
        ParedInferiorIzquierda.transform.position = new Vector3(
            LIMITE_IZQUIERDA,
            LIMITE_INFERIOR,
            LIMITE_POSTERIOR
        );
        GameObject ParedInferiorDerecha = Instantiate(prefabBloquePared);
        ParedInferiorDerecha.transform.position = new Vector3(
            LIMITE_DERECHA,
            LIMITE_INFERIOR,
            LIMITE_POSTERIOR
        );
        GameObject ParedSuperiorIzquierda = Instantiate(prefabBloquePared);
        ParedSuperiorIzquierda.transform.position = new Vector3(
            LIMITE_IZQUIERDA,
            LIMITE_SUPERIOR,
            LIMITE_POSTERIOR
        );
        GameObject ParedSuperiorDerecha = Instantiate(prefabBloquePared);
        ParedSuperiorDerecha.transform.position = new Vector3(
            LIMITE_DERECHA,
            LIMITE_SUPERIOR,
            LIMITE_POSTERIOR
        );
        GameObject Obstaculo = Instantiate(prefabObstaculo);
        Obstaculo.transform.position = new Vector3(
            Random.RandomRange(LIMITE_IZQUIERDA, LIMITE_DERECHA),
            Random.RandomRange(LIMITE_INFERIOR, LIMITE_SUPERIOR),
            LIMITE_POSTERIOR
        );
    }
}
