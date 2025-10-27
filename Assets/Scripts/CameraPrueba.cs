using Unity.Mathematics;
using UnityEngine;

public class CameraPrueba : MonoBehaviour
{

    [Header("Camera movement")]
    public float cameraSpeed = 100f;

    public float rotHorizontal = 0f;
    public float rotVertical = 0f;

    public float verticalLimitation = 80f;

    [Header("Player rotation")]
    public Transform player;

    void Start()
    {
        // bloqueo el cursor al centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        //oculto el cursor al empezar el juego
        Cursor.visible = false;
    }

    
    void Update()
    {
        CameraLogic();
    }

    public void CameraLogic()
    {
        //leo los valores del raton de X e Y
        float valorX = Input.GetAxis("Mouse X") * cameraSpeed * Time.deltaTime; // cambio los valores en vez de por frame lo cambio a segundos con deltaTime
        float valorY = Input.GetAxis("Mouse Y") * cameraSpeed * Time.deltaTime;

        //movimiento de la camara
        rotHorizontal += valorX;
        rotVertical -= valorY;

        //limito la rotacion de la camara
        rotVertical = math.clamp(rotVertical, -verticalLimitation, verticalLimitation);

        transform.localRotation = Quaternion.Euler(rotVertical, 0, 0); //con esto la camara gira de forma vertical

        //rotacion del personaje
        player.Rotate(Vector3.up * valorX); //Vector3.up rotacion vertical hacia arriba
    }
}
