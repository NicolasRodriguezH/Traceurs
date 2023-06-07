using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarCartas : MonoBehaviour
{

    private RotarCarta[] currentSelection = new RotarCarta[2];
    private bool sonPareja = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // Crea un rayo desde la cámara hasta la posición del cursor del mouse
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Si el rayo intersecta con un objeto, obtiene información sobre él
            if (Physics.Raycast(rayo, out hit))
            {
                var selectedCard = hit.collider.gameObject.GetComponent<RotarCarta>();
                if (selectedCard != null)
                {
                    SelectCard(selectedCard);
                }
            }
        }
    }
    void SelectCard(RotarCarta selectedCard)
    {
        if (currentSelection[0] == null)
        {
            // Primer carta seleccionada
            currentSelection[0] = selectedCard;
        }
        else if (currentSelection[1] == null)
        {
            // Segunda carta seleccionada
            currentSelection[1] = selectedCard;

            // Comparar las dos cartas seleccionadas
            bool match = CompareCards(currentSelection[0], currentSelection[1]);
            if (!match)
            {
                // Las dos cartas forman una pareja, ejecutar lógica de juego
                Debug.Log("son pareja");
                InvokeRepeating("EliminarCartasPares", 2f, 2f);
                Invoke("DetenerAccion3", 3f);
                
            }
            else
            {
                sonPareja = false;
                Debug.Log("NO son pareja");
                // Las dos cartas no forman una pareja, ejecutar lógica de juego
                if (sonPareja == true)
                {
                    InvokeRepeating("OcultarCartas", 2f, 2f);
                    Invoke("DetenerAccion", 2.4f);
                }

            }
            // Limpiar la selección actual del usuario
            InvokeRepeating("EjecutarLimpieza", 3.5f, .001f);
            Invoke("DetenerAccion2", 3.6f);
        }
    }

    public bool CompareCards(RotarCarta card1, RotarCarta card2)
    {
        //return card1.myName == card2.myName;
        return card1.name == card2.name;
    }

    void OcultarCartas()
    {
        currentSelection[0].EsconderCartas();
        currentSelection[1].EsconderCartas();
    }
    void DetenerAccion()
    {
        // Detener la repetición de la llamada a MoveObject
        CancelInvoke("OcultarCartas");
    }


    void EjecutarLimpieza()
    {
        // Detener la repetición de la llamada a MoveObject
        currentSelection[0] = null;
        currentSelection[1] = null;
    }
    void DetenerAccion2()
    {
        // Detener la repetición de la llamada a MoveObject
        CancelInvoke("EjecutarLimpieza");
    }

    void EliminarCartasPares()
    {
        Destroy(currentSelection[0].gameObject);
        Destroy(currentSelection[1].gameObject);
    }
    void DetenerAccion3()
    {
        // Detener la repetición de la llamada a MoveObject
        CancelInvoke("EliminarCartasPares");
    }
}
