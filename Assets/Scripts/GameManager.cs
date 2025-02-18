using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int vides = 3;
    private Canvas hud;
    public static GameManager Instance;
    private static GameObject[] ElementsCanva;
    private GameObject[] EnemicsMortals;
    private GameObject[] EnemicsImmortals;
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
    ElementsCanva = GameObject.FindGameObjectsWithTag("CanvaPart1");
    EnemicsMortals = GameObject.FindGameObjectsWithTag("EnemicMortal");
    EnemicsImmortals = GameObject.FindGameObjectsWithTag("EnemicImmortal");
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
        CanvaPart1 canvascript = FindFirstObjectByType<CanvaPart1>(FindObjectsInactive.Include);
        canvascript.TreureVida(vides);
        if (vides == 0){
            Die();
        }
    }

    public void Die(){
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
        CanvaPart1 canvascript = FindFirstObjectByType<CanvaPart1>(FindObjectsInactive.Include);
        for (int i = 0; i < vides; i++){
        canvascript.TreureVida(i);
        }
        foreach (GameObject obj in ElementsCanva){
        obj.SetActive(true);
    }

}
}
