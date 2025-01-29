using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public TextMeshProUGUI loadingText;
    void Start()
    {
        if (PlayerPrefs.HasKey("Levelindex") == false)
        {
            PlayerPrefs.SetInt("Levelindex", 1);
        }
        StartCoroutine("LoadingBar");
        LevelControl();
    }
    public void LevelControl()
    {
        int level = PlayerPrefs.GetInt("Levelindex");
        SceneManager.LoadSceneAsync(level);
    }
    public IEnumerator LoadingBar()
    {
        while (true)
        {
            loadingText.text = "Loading".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            loadingText.text = "Loading.".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            loadingText.text = "Loading..".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            loadingText.text = "Loading...".ToString();
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
