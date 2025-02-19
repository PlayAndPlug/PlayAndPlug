using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int vides = 3;
    private Canvas hud;
    public static GameManager Instance;
    public GameObject[] ElementsCanvaDerrota;
    public GameObject[] ElementsCanvaVictoria;
    public GameObject[] EnemicsMortals;
    public GameObject[] EnemicsImmortals;
    CanvaPart1 canvascript; 
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
    
    hud = FindAnyObjectByType<Canvas>();
    ElementsCanvaDerrota = GameObject.FindGameObjectsWithTag("CanvaDerrota");
    ElementsCanvaVictoria = GameObject.FindGameObjectsWithTag("CanvaVictoria");
    EnemicsMortals = GameObject.FindGameObjectsWithTag("EnemicMortal");
    EnemicsImmortals = GameObject.FindGameObjectsWithTag("EnemicImmortal");
    canvascript = FindFirstObjectByType<CanvaPart1>(FindObjectsInactive.Include);
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

