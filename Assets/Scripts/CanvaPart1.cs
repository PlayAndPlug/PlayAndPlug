using UnityEngine;

public class CanvaPart1 : MonoBehaviour
{
    private GameObject[] Canva;
        void Start(){
            Canva = GameObject.FindGameObjectsWithTag("CanvaPart1");
            foreach (GameObject obj in Canva){
                obj.SetActive(false);
        }        
    }
    public void Reiniciar(){
        GameManager.Instance.LoadScene("Part1Joc");
    }

    public void Menu(){
        GameManager.Instance.LoadScene("MenuPrincipal");
    }
}
