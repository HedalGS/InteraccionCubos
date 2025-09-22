using UnityEngine;

public class CubeInteractions : MonoBehaviour
{
    //Variables para el raycast del touch
    private Touch myTouch;
    private RaycastHit rayHit;
    private Vector3 touchRayPosition;
    
    //Variables para mover el cubo
    private float distanceCameraToCube;
    private bool cubeMoving = false;
    private Vector3 offsetDistance;
    private GameObject myCube;
    void Update()
    {
        if (Input.touchCount == 1)
        {
            //Hay un touch detectado!

            myTouch = Input.GetTouch(0); //Se guarda el primer touch
            touchRayPosition = myTouch.position; //Se guardan los valores del primer touch

            Ray ray = Camera.main.ScreenPointToRay(touchRayPosition); //Se lanza el rayo desde la posici�n del primer touch en la pantalla
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow); //Se dibuja el rayo del primer touch. Visible s�lo en el editor

            Vector3 vector; //Vector para almacenar informaci�n del movimiento respecto a la distancia desde la c�mara

            if (Physics.Raycast(ray, out rayHit))
            {
                //El rayo dio un hit!
                if (rayHit.collider.gameObject.CompareTag("Cube"))
                {
                    //El hit le dio a un gameObject que tiene un tag Cube
                    if(rayHit.collider.GetComponent<Cubes>() != null)
                    {
                        //El gameObject tambi�n tiene la clase Cubes
                        Cubes cubeSelected = rayHit.collider.transform.GetComponent<Cubes>();

                        //Fase Began
                        if (myTouch.phase == TouchPhase.Began)
                        {
                            //Si el touch est� en fase Began
                            myCube = rayHit.transform.gameObject; //El cubo que recibi� el hit
                            distanceCameraToCube = rayHit.transform.position.z - Camera.main.transform.position.z; //Calcular distancia entre camara y cubo

                            vector = new Vector3(touchRayPosition.x, touchRayPosition.y, distanceCameraToCube);
                            vector = Camera.main.ScreenToWorldPoint(vector);

                            offsetDistance = myCube.transform.position - vector; //C�lculo de distancia entre c�mara y cubo
                            cubeMoving = true;
                        }
                        //Fase Moved o Stationary
                        if (cubeMoving && (myTouch.phase == TouchPhase.Moved || myTouch.phase == TouchPhase.Stationary))
                        {
                            cubeSelected.SetIsSelected(true);
                            cubeSelected.ChangeColor();

                            vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceCameraToCube);
                            vector = Camera.main.ScreenToWorldPoint(vector);
                            myCube.transform.position = vector + offsetDistance; // C�lculo de posici�n del cubo

                        }
                        //Fase Ended o Canceled
                        if (cubeMoving && (myTouch.phase == TouchPhase.Ended || myTouch.phase == TouchPhase.Canceled))
                        {
                            cubeMoving = false;
                            cubeSelected.SetIsSelected(false);
                            cubeSelected.ChangeColor();
                        }
                    }
                }
                else
                {
                    Debug.Log("Touch al aire!");
                }

            }

        }
        else
        {
            //No hay un s�lo touch
            cubeMoving = false;
        }

    }
}
