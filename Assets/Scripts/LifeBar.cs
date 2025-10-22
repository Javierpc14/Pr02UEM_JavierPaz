using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image lifeBarFill; // controlara el relleno de la barra de vida
    private PlayerController playerController; //accedo a la clase del player para restarle las vidas
    private float maxLife; //comprueba cual es el maximo de la barra de vida

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>(); //busco al jugador por el nombre y obtengo su script
        maxLife = playerController.life; //obtengo las vidas que tiene el personaje al inicio
    }

    void Update()
    {
        lifeBarFill.fillAmount = playerController.life / maxLife;
    }
}
