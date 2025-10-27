using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    [Header("Player movement")]
    public float walkSpeed = 6.0f;
    public float runSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    private Vector3 move = Vector3.zero; //inicializa al player en la posicion (0,0,0)-

    [Header("Player gravity")]
    public float gravity = 20.0f;
    public bool isGrounded;

    [Header("Player UI")]
    public int life = 3;

    [Header("Camera movement")]
    public Camera camera;
    public float mouseHorizontal = 3.0f;
    public float mouseVertical = 3.0f;
    public float minRotation = -65.0f;
    public float maxRotation = 65.0f;
    float h_mouse, v_mouse; //obtener la entrada del raton



    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // bloqueo el cursor al centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        //oculto el cursor al empezar el juego
        Cursor.visible = false;
    }

    void Update()
    {
        CameraLogic();
        PlayerMovement();
    }

    public void CameraLogic()
    {
        h_mouse = mouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse += mouseVertical * Input.GetAxis("Mouse Y");

        //limitar el movimiento vertical
        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);

        //modificar rotacion local
        camera.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0);//para invertir el eje vertical
        transform.Rotate(0, h_mouse, 0); // rotar en el eje horizontal

        
    }

    public void PlayerMovement()
    {
        if (characterController.isGrounded)
        {
            isGrounded = true; //por defecto empieza verdadero

            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            //validacion para que el player corra
            if (Input.GetKey(KeyCode.LeftShift))
            {
                move = transform.TransformDirection(move) * runSpeed;
            }
            else
            {
                move = transform.TransformDirection(move) * walkSpeed;
            }

            //salto del player
            if (Input.GetKey(KeyCode.Space))
            {
                move.y = jumpSpeed;
                isGrounded = false;
            }
        }

        //gravedad del player
        move.y -= gravity * Time.deltaTime;
        characterController.Move(move * Time.deltaTime);

    }
}
