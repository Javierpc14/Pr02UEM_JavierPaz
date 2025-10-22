using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player movement")]
    public CharacterController controller; // este controlador se encarga de hacer los movimientos
    public float speed = 15f;

    [Header("Player UI")]
    public int life = 3;

    //para la gravedad utilizo un game object que detecta si esta tocando el suelo o no y creo un Layer para verificar esto
    //[Header("Player gravity")]
    //public float gravityMove = -9.8f;
    //public Transform floor;// calcula si el player esta tocando el suelo o no para el salto y para detener el valor de gravedad
    //public float distanceFloor; //esto es un radio que colisiona con el suelo
    //public LayerMask maskFloor;
    //bool onFloor;
    //Vector3 gravitySpeed;


    void Start()
    {
        
    }

    void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        //esto comprueba si esta tocando el suelo o no
        //onFloor = Physics.CheckSphere(floor.position, distanceFloor, maskFloor);

        //if (onFloor && gravitySpeed.y < 0)
        //{
        //    gravitySpeed.y = -2;
        //}
        // obtengo los valores de las teclas w,a,s,d
        float valorX = Input.GetAxis("Horizontal");
        float valorZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * valorX + transform.forward * valorZ;
        controller.Move(move * speed * Time.deltaTime);

        //// gravedad del personaje
        //gravitySpeed.y += gravityMove * Time.deltaTime;
        //controller.Move(gravitySpeed * Time.deltaTime);
    }
}
