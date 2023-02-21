using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    InGame,
    GameOver
}
public class GameManager : MonoBehaviour
{
    public Player player;
    public GameState state;

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
        state = GameState.InGame;

        //domyœlnie jak przechodzimy do nowej sceny to wszystko co jest w poprzedniej scenie jest usuwane
        //dziêki tej funkcji game manager nie zostanie usuniêty
        DontDestroyOnLoad(gameObject);
    }

    public void GameOverScreen()
    {
        ViewManager.Show<GameOverView>(false);
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void Replay()
    {
        state= GameState.InGame;
        ViewManager.Show<InGameView>(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
