using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region GameManager Instance 
    public static GameManager instance { get; private set; }
    #endregion GameManager Instance

    #region Private Variables
    [SerializeField] GameObject HeadsUpDisplay;
    [SerializeField] GameObject WinMenu;
    #endregion Private Variables

    #region Public Variables
    int collectedSphere;
    #endregion Public Variables

    #region Private Methods
    void Awake()
    {
        // One Instance that Manages the Scene
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1f;
    }

    void Start()
    {
        collectedSphere = 0;
        HeadsUpDisplay.SetActive(true);
        WinMenu.SetActive(false);
    }
    #endregion Private Methods

    #region GetScore(), AddScore(), Win(), Restart()
    public int GetScore()
    {
        return collectedSphere;
    }

    public void AddScore()
    {
        collectedSphere += 1;
    }

    public void Win()
    {
        Time.timeScale = 0f;
        HeadsUpDisplay.SetActive(false);
        WinMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //HeadsUpDisplay.SetActive(true);
        //WinMenu.SetActive(false);
    }
    #endregion GetScore(), AddScore(), Win(), Restart()
}
