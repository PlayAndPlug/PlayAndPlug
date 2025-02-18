using UnityEngine;

public class CanvaPart1 : MonoBehaviour
{
    private GameObject[] Canva;
    public GameObject[] vides;

    public void TreureVida(int index){
    vides[index].SetActive(false);   
}

public void RestaurarVides(){
        GameManager.Instance.vides = 3; 
    }
    void Start(){
            Canva = GameObject.FindGameObjectsWithTag("CanvaPart1");
            foreach (GameObject obj in Canva){
                obj.SetActive(false);
        }
        GameManager.Instance.vides = 3;       
    }
    public void Reiniciar(){
        RestaurarVides();
        GameManager.Instance.LoadScene("Part1Joc");
    }

    public void Menu(){
        GameManager.Instance.LoadScene("MenuPrincipal");
    }
}
