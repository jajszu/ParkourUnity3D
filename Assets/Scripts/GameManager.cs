using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public delegate void MyEventHandler();
    public event MyEventHandler updateUI;
    public Player player;

    [HideInInspector]
    public static GameManager instance;

    [SerializeField]
    private Transform playerSpawnPoint;
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private InGameView inGameView;
    void Awake()
    {
        //to sprawia ¿e gdyby by³ w scenie drugi game manager to zostanie usuniêty
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //spawn gracza
        player = Instantiate(playerPrefab, playerSpawnPoint).GetComponent<Player>();
        inGameView.UpdateUI(player.hp, player.maxHp);

        //domyœlnie jak przechodzimy do nowej sceny to wszystko co jest w poprzedniej scenie jest usuwane
        //dziêki tej funkcji game manager nie zostanie usuniêty
        DontDestroyOnLoad(gameObject);
    }

    public void InvokeUpdateUI()
    {
        updateUI?.Invoke();
    }
    public void GameOverScreen()
    {
        ViewManager.Show<GameOverView>(false);
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
