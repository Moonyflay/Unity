using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(int scene_number)
    {
        StartCoroutine(LoadAsync(scene_number));

    }
    IEnumerator LoadAsync(int scene_number) 
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(scene_number);
        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress/.9f);
            Debug.Log(progress); 
            yield return null; 
        }
          
    }
}