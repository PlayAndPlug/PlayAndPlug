using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int vides = 3;
    public int numberScore = 0;
    public int oldScore = 0;
    public int HighScore = 0;
    private Canvas hud;
    public static GameManager Instance;
    public GameObject[] ElementsCanvaDerrota;
    public GameObject[] ElementsCanvaVictoria;
    public GameObject[] EnemicsMortals;
    public GameObject[] EnemicsImmortals;
    public GameObject boss;
    Canvascript canvascript; 
    PlayerController PlayerController; 
    public int nivell = 1;
    private void Awake()
    {
      if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    SceneManager.sceneLoaded += RecarregarTot;
    }

    void RecarregarTot(Scene scene, LoadSceneMode mode){
    boss = GameObject.FindGameObjectWithTag("Boss");
    hud = FindAnyObjectByType<Canvas>();
    ElementsCanvaDerrota = GameObject.FindGameObjectsWithTag("CanvaDerrota");
    ElementsCanvaVictoria = GameObject.FindGameObjectsWithTag("CanvaVictoria");
    EnemicsMortals = GameObject.FindGameObjectsWithTag("EnemicMortal");
    EnemicsImmortals = GameObject.FindGameObjectsWithTag("EnemicImmortal");
    canvascript = FindFirstObjectByType<Canvascript>(FindObjectsInactive.Include);
    PlayerController = FindFirstObjectByType<PlayerController>(FindObjectsInactive.Include);
    }

    void OnDestroy()
    {
    SceneManager.sceneLoaded -= RecarregarTot;
    }
    public void LoadScene(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    public void PerdreVida(){
        vides -= 1;
        canvascript.TreureVida(vides);
        if (vides == 0){
            Die();
        }
    }

    public void Die(){
        PlayerController.canMove = false;
        if(boss != null){
            boss.SetActive(false);
        }
        foreach (GameObject Enemic in EnemicsMortals){
            if(Enemic != null){
                Enemic.SetActive(false);
            }
        }
        foreach (GameObject Enemic in EnemicsImmortals){
            if(Enemic != null){
                Enemic.SetActive(false);
            }
        }
        for (int i = 0; i < vides; i++){
        canvascript.TreureVida(i);
        }
        foreach (GameObject obj in ElementsCanvaDerrota){
            obj.SetActive(true);
    }
    }

    public void Nextlevel(){
        canvascript.NextLevel();
    }

}

