using UnityEngine;
using UnityEngine.SceneManagement;
using Types;

public class InitSceneController : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene(SceneType.MenuScene.ToString());
    }
}
