using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))] //Sert de debug
public class PlayerControlleur : MonoBehaviour
{

    [HideInInspector] public float speed = 5f; //Permet d'afficher la variable en dessous de cette ligne


    [SerializeField] private float lookSensitivityX = 3f; //Permet d'afficher la variable en dessous de cette ligne
    [SerializeField] private float lookSensitivityY = 3f; //Permet d'afficher la variable en dessous de cette ligne


    private PlayerMotor motor;


    // Use this for initialization
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        ///////////////////////// Sprinter ///////////////
        if (Input.GetButton("Courir"))
        {
           speed = 10f;
        }
        else
        {
           speed = 5f;
        }

        #region CALCUL DE MOUVEMENTS & ROTATIONS 
        //Calcule de la vélocité du mouvement du joueur en un Vecteur 3D
        float _xMov = Input.GetAxisRaw("Gauche/Droite");
        float _zMov = Input.GetAxisRaw("Avancer/Reculer");


        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        motor.Move(_velocity);

        // Calcul de la rotation du joueur en un Vecteur 3D
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0, _yRot, 0) * lookSensitivityX;

        motor.Rotate(_rotation);

        // Calcul de la rotation de la camera en un Vecteur 3D
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotation = _xRot * lookSensitivityY;

        motor.RotateCamera(_cameraRotation);
        #endregion
    }

}