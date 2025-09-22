using Unity.VisualScripting;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    private Color myColor;
    private bool isSelected;
    private bool correctPosition;
    void Start()
    {
        isSelected = false;
        correctPosition = false;

        if (transform.gameObject.CompareTag("Cube")) {
            myColor = transform.GetComponent<Renderer>().materials[0].color;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (myColor == other.transform.GetComponent<Renderer>().material.color)
        {
            correctPosition = true;
            Debug.Log(correctPosition.ToString() + myColor);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        correctPosition = false;
        Debug.Log(correctPosition.ToString() + myColor);

    }

    public void ChangeColor()
    {
        if (isSelected)
        {
            transform.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            transform.GetComponent<Renderer>().material.color = myColor;
        }

    }

    public bool GetIsSelected()
    {
        return isSelected;
    }

    public void SetIsSelected(bool selected)
    {
        isSelected= selected;   
    }
    public bool GetCorrectPosition()
    {
        return correctPosition;
    }

}
