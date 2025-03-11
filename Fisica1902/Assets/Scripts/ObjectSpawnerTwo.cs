using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSpawnerTwo : MonoBehaviour
{
    public GameObject prefab; //pega o prefab feito em cena 
    public List<Transform> spawnPositions; //lista onde meus pontos vão aparecer
    public int toSpawn = 3; //quantos objs vão aparecer
    public string targetSceneName; // Nome da cena onde os objetos devem ser spawnados

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        //confirma o nº de posições
        if (spawnPositions.Count < toSpawn)
        {
            Debug.LogError("n tem posicoes suficientes");
            return;
        }

        //randomiza as posicoes
        List<Transform> embaralhar = new List<Transform>(spawnPositions);
        Shuffle(embaralhar);

        // spawna os objetos nas posições
        for (int i = 0; i < toSpawn; i++)
        {
            GameObject obj = Instantiate(prefab, embaralhar[i].position, embaralhar[i].rotation);
            MoveObjectToScene(obj, targetSceneName);
        }
    }

    //embaralha as posições
    void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int rmIndex = Random.Range(i, list.Count);
            list[i] = list[rmIndex];
            list[rmIndex] = temp;
        }
    }

    //move os objetos para a cena correta
    void MoveObjectToScene(GameObject obj, string sceneName)
    {
        Scene targetScene = SceneManager.GetSceneByName(sceneName);
        if (targetScene.IsValid())
        {
            SceneManager.MoveGameObjectToScene(obj, targetScene);
        }
        else
        {
            Debug.LogError($"Cena {sceneName} n ta aq");
        }
    }
}
