using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhyschSceneLoader : MonoBehaviour
{
    public string psysicsSceneName;
    public float physicsSceneTimeScale = 1;
    private PhysicsScene physicsScene;

    // Start is called before the first frame update
    void Start()
    {
        LoadSceneParameters param = new LoadSceneParameters(LoadSceneMode.Additive, LocalPhysicsMode.Physics3D);
        Scene scene = SceneManager.LoadScene(psysicsSceneName, param);
        //carrega
        physicsScene = scene.GetPhysicsScene();
    }

    private void FixedUpdate()
    {
        //simula a cena no fixedupdate
        if (physicsScene != null)
        {
            physicsScene.Simulate(Time.fixedDeltaTime * physicsSceneTimeScale);
        }
    }
}
