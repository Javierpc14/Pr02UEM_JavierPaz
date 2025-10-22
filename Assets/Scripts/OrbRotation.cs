using UnityEngine;

public class OrbRotation : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;
    public GameObject coin;

    void Update()
    {
        //Hacer que rote la moneda, modificamos el Transform de la moneda para modificar la rotacion
        coin.transform.Rotate(xAngle, yAngle, zAngle);
    }
}
