using UnityEngine;

public class CanvaPart1 : MonoBehaviour
{
    private GameObject[] CanvaDerrota;
    private GameObject[] CanvaVictoria;
    public GameObject[] vides;

    void Start(){
            CanvaDerrota = GameObject.FindGameObjectsWithTag("CanvaDerrota");
            CanvaVictoria = GameObject.FindGameObjectsWithTag("CanvaVictoria");
        foreach (GameObject obj in CanvaDerrota){
                obj.SetActive(false);
        }
        foreach (GameObject obj in CanvaVictoria){
                obj.SetActive(false);
        }
        GameManager.Instance.vides = 3;       
    }
    public void Reiniciar(){
        RestaurarVides();
        GameManager.Instance.LoadScene($"Part{GameManager.Instance.nivell}Joc");
    }

    public void Menu(){
        GameManager.Instance.LoadScene("MenuPrincipal");
    }

    public void NextLevel(){
        GameManager.Instance.nivell += 1;
        GameManager.Instance.LoadScene($"Part{GameManager.Instance.nivell}Joc");
    }

    public void TreureVida(int index){
    vides[index].SetActive(false);   
}

    public void RestaurarVides(){
        GameManager.Instance.vides = 3; 
    }
}
