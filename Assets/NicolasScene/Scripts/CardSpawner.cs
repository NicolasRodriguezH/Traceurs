using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    //aqui se necesita una variable de tipo lista que almace los prefabs de las cartas q tenemos
    public List<GameObject> cardPrefabs;
    public float screenWidth;
    public float cardSpacing = 2f;

    //private GameManager gameManager;

    public void CreateMatrix(int size)
    {
        //metodo para crear matriz

        // Calcular la posición inicial de la primera carta
        float startX = -screenWidth * (size - 1) / 2f;
        float startZ = 1f;

        // Calcular el ancho de la pantalla
        float aspectRatio = Camera.main.aspect;
        float camHeight = Camera.main.orthographicSize * 2;
        float camWidth = camHeight * aspectRatio;
        screenWidth = camWidth / size;

        // Calcular la separación entre las cartas
        cardSpacing = screenWidth / (size - 1);
        

        // calcular el número total de cartas en la matriz
        int numCards = size * size;

        // lista para almacenar las cartas en orden aleatorio
        // Este almacena las cartas y con el for se agregan de forma aleatoria
        List<GameObject> shuffledCards = new List<GameObject>();

        // llenar la lista de cartas en orden aleatorio
        for (int i = 0; i < numCards; i++)
        {
            int randomIndex = Random.Range(0, cardPrefabs.Count);
            GameObject randomCard = cardPrefabs[randomIndex];
            if (!shuffledCards.Contains(randomCard))
            {
                shuffledCards.Add(randomCard);
            }
        }

        // crear la matriz de cartas en la escena
        int cardIndex = 0;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                // Calcular la posición de la carta actual
                float posX = startX + row * cardSpacing;
                float posZ = startZ - col * cardSpacing;

                // calcular la posición de spawn de la carta
                Vector3 spawnPos = new Vector3(col, 2, row);

                // instanciar la carta en la posición de spawn
                GameObject card = Instantiate(shuffledCards[cardIndex], spawnPos, Quaternion.Euler(-90f, 180f, 0f));
                card.transform.position = new Vector3(posX, 1f, posZ);
                //float rotate = card.gameObject.transform.rotation.x;

                // card.gameObject.transform.rotation.x = -90;

                // aumentar el índice de la carta para la próxima iteración
                //SpawnCardsInMatrix(size);

                cardIndex++;
            }
        }
    }

    //void SpawnCardsInMatrix(int size)
    //{
    //    //metodo para spawnear las cartas en las posciones de la matriz
    //
    //
    //    // Calcular la posición inicial de la primera carta
    //    float startX = -screenWidth * (size - 1) / 2f;
    //    float startY = 0f;
    //
    //    // Instanciar las cartas en una matriz ordenada
    //    for (int i = 0; i < size; i++)
    //    {
    //        for (int j = 0; j < size; j++)
    //        {
    //            // Calcular la posición de la carta actual
    //            float posX = startX + j * cardSpacing;
    //            float posY = startY - i * cardSpacing;
    //
    //            // Instanciar la carta en la posición calculada
    //            GameObject cardObj = Instantiate(cardPrefabs[Random.Range(0, cardPrefabs.Count)], transform);
    //            cardObj.transform.position = new Vector3(posX, posY, 0f);
    //        }
    //    }
    //}


}
