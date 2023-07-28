using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button start;

    void Start()
    {
        start = this.gameObject.GetComponent<Button>();
        start.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Outside");
    }
}
