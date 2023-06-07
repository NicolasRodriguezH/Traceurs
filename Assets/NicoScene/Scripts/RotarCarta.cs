using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarCarta : MonoBehaviour
{
    [HideInInspector] public string myName;
    // Start is called before the first frame update
    private float maxElevacionCarta = .5f;
    private float minElevacionCarta = 0.005f;

    //private float minRotacionZ = 0;// Límite de rotación en grados en el eje Z
    private float rotacionFinalZ = 180;// Rotación actual en grados en el eje Z
    //private float velocidadRotacion = 200;// Velocidad de rotación en grados por segundo

    private float maxRotacionZ = 180f;// Límite de rotación en grados en el eje Z
    private float minRotacionZ = 0;// Límite de rotación en grados en el eje Z
    private float rotacionActualZ = 0;// Rotación actual en grados en el eje Z
    private float velocidadRotacion = 180f;// Velocidad de rotación en grados por segundo
    public bool estaTapada = true;
    [SerializeField] private GameObject revesCarta;
    void Start()
    {
        myName = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log(estaTapada);
        if (revesCarta.activeSelf == true)
        {
            revesCarta.SetActive(false);

            //InvokeRepeating("ElevarCarta", 0f, .001f);
            //Invoke("DetenerElevacion", .2f);
            //
            //InvokeRepeating("DestaparCarta", .5f, .001f);
            //Invoke("DetenerDestapado", 1.3f);
            //
            //InvokeRepeating("DescenderCarta", 1.2f, .001f);
            //Invoke("DetenerDescenso", 1.4f);

        }

        estaTapada = !estaTapada;

        if (estaTapada)
        {
            DesvelarCarta();
        }

        if (estaTapada == false)
        {
            EsconderCartas();
        }

    }
    private void ElevarCarta()
    {
        if (maxElevacionCarta > transform.position.y)
        {
            transform.position += Vector3.up * 1f * Time.deltaTime;
        }
    }

    void DetenerElevacion()
    {
        // Detener la repetición de la llamada a MoveObject
        CancelInvoke("ElevarCarta");
    }

    private void DescenderCarta()
    {
        if (transform.position.y > minElevacionCarta)
        {
            transform.position += Vector3.down * 1f * Time.deltaTime;
        }
    }

    void DetenerDescenso()
    {
        // Detener la repetición de la llamada a MoveObject
        CancelInvoke("DescenderCarta");
    }

    private void DestaparCarta()
    {
        float RotacionAdicionalZ = velocidadRotacion * Time.deltaTime;
        if (rotacionActualZ + RotacionAdicionalZ > maxRotacionZ)
        {
            // Restringir la rotación adicional dentro del límite de rotación en el eje Z
            RotacionAdicionalZ = maxRotacionZ - rotacionActualZ;
        }
        // Rotar el objeto en el eje Z según la rotación adicional
        //transform.Rotate(0f, RotacionAdicionalZ, 0f);
        transform.Rotate(0f, 0f, Mathf.Abs(RotacionAdicionalZ));


        // Actualizar la rotación actual en el eje Z
        //rotacionActualZ += RotacionAdicionalZ;
        rotacionActualZ = Mathf.Abs(rotacionActualZ + RotacionAdicionalZ);

    }

    void DetenerDestapado()
    {
        // Detener la repetición de la llamada a MoveObject
        CancelInvoke("DestaparCarta");
        rotacionActualZ = 0;
    }

    private void TaparCarta()
    {
        float RotacionAdicionalZ = (velocidadRotacion * Time.deltaTime) * -1;
        if (rotacionFinalZ + RotacionAdicionalZ < minRotacionZ)
        {
            // Restringir la rotación adicional dentro del límite de rotación en el eje Z
            RotacionAdicionalZ = minRotacionZ + rotacionFinalZ;
        }
        // Rotar el objeto en el eje Z según la rotación adicional
        transform.Rotate(0f, 0f, RotacionAdicionalZ);

        // Actualizar la rotación actual en el eje Z
        rotacionFinalZ = rotacionFinalZ + RotacionAdicionalZ;
    }
    void DetenerTapado()
    {
        // Detener la repetición de la llamada a MoveObject
        CancelInvoke("TaparCarta");
        rotacionFinalZ = 180;
    }

    /* ------------------------------------------------------------ */

    public void DesvelarCarta()
    {
        InvokeRepeating("ElevarCarta", 0f, .001f);
        Invoke("DetenerElevacion", .2f);


        InvokeRepeating("DestaparCarta", .5f, .001f);
        Invoke("DetenerDestapado", 1.3f);

        InvokeRepeating("DescenderCarta", 1.2f, .001f);
        Invoke("DetenerDescenso", 1.4f);
    }
    public void EsconderCartas()
    {
        InvokeRepeating("ElevarCarta", 0f, .001f);
        Invoke("DetenerElevacion", .2f);

        InvokeRepeating("TaparCarta", .5f, .001f);
        Invoke("DetenerTapado", 1.3f);

        InvokeRepeating("DescenderCarta", 1.2f, .001f);
        Invoke("DetenerDescenso", 1.4f);
    }

    /*-------------------------------------------------------------------------------*/
    //void InformacionObjeto(GameObject objetoSeleccionado)
    //{
    //    // Obtiene el nombre del objeto y lo imprime en la consola
    //    string nombre = objetoSeleccionado.name;
    //    Debug.Log("El objeto seleccionado es: " + nombre);
    //
    //    // Obtiene la posición del objeto y lo imprime en la consola
    //    Vector3 posicion = objetoSeleccionado.transform.position;
    //    Debug.Log("La posición del objeto es: " + posicion);
    //}

    private int _id;
    public int id{
        get {return _id;}
    
    }
    
    public void CambiarSprite(int id, Sprite nuevaImagen){
        _id = id;
        GetComponent<SpriteRenderer>().sprite = nuevaImagen;
    }

        public void Unreveal()
    {
        revesCarta.SetActive(true);
    }
}
