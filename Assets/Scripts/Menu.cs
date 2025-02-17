using UnityEngine;

public class Menu : MonoBehaviour
{
    private GameObject[] objectesPrincipal;
    private GameObject[] objectesControls;
    public void Awake()
    {
        objectesPrincipal = GameObject.FindGameObjectsWithTag("MenuPrincipal");
        objectesControls = GameObject.FindGameObjectsWithTag("MenuControls");
        foreach (GameObject obj in objectesControls)
        {
            obj.SetActive(false);
        }
    }

    public void Credits()
    {
        foreach (GameObject obj in objectesPrincipal)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in objectesControls)
        {
            obj.SetActive(true);
        }
    }

    public void TornarPrincipal()
    {
        foreach (GameObject obj in objectesPrincipal)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in objectesControls)
        {
            obj.SetActive(false);
        }
    }

    public void Jugar(){
        GameManager.Instance.LoadScene("Part1Joc");
    }
}
