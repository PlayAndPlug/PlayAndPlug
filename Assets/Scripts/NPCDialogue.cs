using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class NPCDialogue : MonoBehaviour
{
    public GameObject ClicY;
    public TextMeshProUGUI indicador;
    private bool isActive = false;
    public TextMeshProUGUI dialogo;
    private int dialogonumber = 0;

    void Start()
    {
        ClicY.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            ClicY.SetActive(true);
            indicador.gameObject.SetActive(false);
            isActive = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            dialogonumber = 0;
            dialogo.text = "Clica Y per parlar amb el NPC";
            indicador.text = $"(Clica Y per seguir amb el dialogue)";
            ClicY.SetActive(false);
            isActive = false;
        }
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Y) && isActive){
            switch (dialogonumber)
            {
                case 0:
                dialogo.text = $"Bon dia Alumne, necessito que em facis un favor.";
                dialogo.fontSize = 30;
                indicador.gameObject.SetActive(true);
                dialogonumber++;
                break;

                case 1:
                dialogo.text = $"Podrias veure perque la sala de endolls no va?";
                dialogo.fontSize = 30;
                dialogonumber++;
                break;

                case 2:
                dialogo.text = $"Es estrany... tot esta endollat.";
                dialogo.fontSize = 40;
                dialogonumber++;
                indicador.text = $"(Clica Y per tancar el dialogue)";
                break;

                case 3:
                dialogonumber = 0;
                dialogo.text = "Clica Y per parlar amb el NPC";
                indicador.text = $"(Clica Y per seguir amb el dialogue)";
                dialogo.fontSize = 50;
                ClicY.SetActive(false);
                isActive = false;
                break;

                default:
                dialogo.text = "Clica Y per parlar amb el NPC";
                break;

            }
        }
    }
}
