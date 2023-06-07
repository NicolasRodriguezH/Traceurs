using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearCartas : MonoBehaviour
{
   
    public int filas = 5; // El número de filas en la matriz
    public int columnas = 5; // El número de columnas en la matriz
    public GameObject objeto; // El objeto que se instanciará

public List<GameObject> objetosAInstanciar; // La lista de objetos que se instanciarán

    // Start is called before the first frame update

    void Start()
    {
        // Bucle para recorrer las filas de la matriz
        for (int fila = 0; fila < filas; fila++)
        {
            // Bucle para recorrer las columnas de la matriz
            for (int columna = 0; columna < columnas; columna++)
            {
                // Calcular la posición de la celda actual
                Vector3 posicion = new Vector3(fila, 0, columna);

                // Instanciar un objeto en la posición actual
                GameObject nuevoObjeto = Instantiate(objeto, posicion, Quaternion.identity);

                // Asignar un nombre único al objeto
                // nuevoObjeto.name = "Objeto (" + fila + "," + columna + ")";
            }
        }
    }



    // Update is called once per frame
    void Update()
    {

    }

}
