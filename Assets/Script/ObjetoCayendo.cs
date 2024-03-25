using System.Collections;
using UnityEngine;

public class ObjetoCayendo : MonoBehaviour
{
    public GameObject[] SM_Rock_Boulder_01; // Array de prefabricados de objetos de lluvia
    public int numberOfObjectsToSpawn = 5; // Número de objetos a generar en cada intervalo
    public float spawnInterval = 1.0f; // Intervalo de generación
    public float spawnAreaRadius = 5.0f; // Radio del área de generación

    void Start()
    {
        // Comenzar la generación de lluvia en intervalos
        StartCoroutine(SpawnRain());
    }

    IEnumerator SpawnRain()
    {
        // Bucle infinito para generar lluvia
        while (true)
        {
            // Esperar el intervalo especificado
            yield return new WaitForSeconds(spawnInterval);

            // Generar varios objetos de lluvia
            for (int i = 0; i < numberOfObjectsToSpawn; i++)
            {
                // Calcular una posición aleatoria dentro del área de generación
                Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnAreaRadius;
                spawnPosition.y = transform.position.y; // Mantener la altura constante

                if (SM_Rock_Boulder_01.Length > 0)
                {
                    // Seleccionar aleatoriamente un prefab de lluvia de la lista
                    GameObject randomSM_Rock_Boulder_01 = SM_Rock_Boulder_01[Random.Range(0, SM_Rock_Boulder_01.Length)];

                    // Instanciar el objeto de lluvia seleccionado en la posición calculada
                    GameObject rain = Instantiate(randomSM_Rock_Boulder_01, spawnPosition, Quaternion.identity);

                    // Obtener el componente Rigidbody del objeto de lluvia
                    Rigidbody rb = rain.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        // Configurar una velocidad aleatoria hacia abajo para simular la lluvia cayendo
                        rb.velocity = Vector3.down * Random.Range(2f, 5f);
                    }
                }
            }
        }
    }
}

