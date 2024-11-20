using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRandManager : MonoBehaviour
{
    void Start()
    {
        // Obtém todos os filhos do GameObject atual
        int childCount = transform.childCount;

        if (childCount == 0)
        {
            Debug.LogWarning("O GameObject não possui filhos para selecionar.");
            return;
        }

        // Escolhe um índice aleatório entre os filhos
        int randomIndex = Random.Range(0, childCount);

        // Itera pelos filhos, ativando o selecionado e desativando os demais
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            GameObject childObject = child.gameObject;

            if (i == randomIndex)
            {
                // Ativa o GameObject selecionado
                childObject.SetActive(true);

                // Define uma rotação aleatória no eixo Y
                float[] possibleRotations = { 0f, 90f, 180f, 270f };
                float randomYRotation = possibleRotations[Random.Range(0, possibleRotations.Length)];
                childObject.transform.rotation = Quaternion.Euler(0, randomYRotation, 0);
            }
            else
            {
                // Desativa os outros GameObjects
                childObject.SetActive(false);
            }
        }
    }
}
