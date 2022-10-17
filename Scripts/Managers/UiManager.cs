using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public void MoveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ShowPopup(string path)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Ui/" + path);
        Instantiate(prefab);
    }

    public void ShowPopup(string path, GameObject data)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Ui/" + path);
        Instantiate(prefab);
    }

    public void ClosePopup(GameObject popup)
    {
        Destroy(popup);
    }

}
