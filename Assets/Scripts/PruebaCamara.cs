//using Unity.Mathematics;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class PruebaCamara : MonoBehaviour
//{
//    // camara
//    [Header("Camara 3 persona")]
//    public Transform cameraAxis; // movimiento del eje de la camara
//    public Transform cameraTrack; // seguimiento del personaje
//    private Transform camera; //posicion camara
//    Transform characterTr;

//    private Vector2 lookInput;

//    //Rotacion de la camara
//    private float rotY = 0f;
//    private float rotX = 0f;

//    public float camRotSpeed = 200f;
//    public float minAngle = -45f; //establezco un rango de vision para que la camara se vea bien
//    public float maxAngle = 45f;
//    public float cameraSpeed = 200f;

//    // personaje
    
    


//    void Start()
//    {
//        characterTr = this.transform;
//        camera = Camera.main.transform; //accedo a la clase de la camara principal para poder modificar su transform
//    }

    
//    void Update()
//    {
//        CameraLogic();
//    }

//    public void OnLook(InputAction.CallbackContext context)
//    {
//        lookInput = context.ReadValue<Vector2>();
//    }

//    public void CameraLogic()
//    {
//        // obtengo el movimiento del raton

//        float time = Time.deltaTime;

//        //calculos para la rotacion de la camara
//        rotY += lookInput.y * time + camRotSpeed;
//        rotX = lookInput.x * time + camRotSpeed;

//        characterTr.Rotate(0, rotX, 0); // para que el personaje rote junto a la cámara

//        rotY = Mathf.Clamp(rotY, minAngle, maxAngle); // para la rotacion de Y, le paso por paramentros un valor maximo y minimo para que la camara no se vuelva loca

//        // la rotacion local del eje de la camera
//        Quaternion localRotation = quaternion.Euler(-rotY, 0, 0);
//        cameraAxis.localRotation = localRotation;

//        //calculo la posicion de la camara y su rotacion
//        camera.position = Vector3.Lerp(camera.position, cameraTrack.position, cameraSpeed * time);
//        camera.rotation = Quaternion.Lerp(camera.rotation, cameraTrack.rotation, cameraSpeed * time);
//    }
//}
