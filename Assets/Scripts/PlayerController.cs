using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;
    private int clues;
    public TextMeshProUGUI CluesText;

    public Camera BuildingEntrance;
    public Camera BuildingIndoors;
    public Camera BuildingIndoors2;
    public Camera BuildingIndoors3;

    private float movementX;
    private float movementY;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        clues = 0;

        BuildingEntrance.enabled = true;
        BuildingIndoors.enabled = false;
        BuildingIndoors2.enabled = false;
        BuildingIndoors3.enabled = false;
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    public void SetCluesText()
    {
        CluesText.text = "Clues: " + clues.ToString();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        SetCluesText();
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CamSwapTrigger"))
        {

            BuildingEntrance.enabled = false;
            BuildingIndoors.enabled = true;
            BuildingIndoors2.enabled = false;
            BuildingIndoors3.enabled = false;

        }
        if (other.gameObject.CompareTag("CamSwapTrigger2"))
        {

            BuildingEntrance.enabled = true;
            BuildingIndoors.enabled = false;
            BuildingIndoors2.enabled = false;
            BuildingIndoors3.enabled = false;

        }
        if (other.gameObject.CompareTag("CamSwapTriggerHouse2"))
        {
            BuildingEntrance.enabled = false;
            BuildingIndoors2.enabled = true;
            BuildingIndoors.enabled = false;
            BuildingIndoors3.enabled = false;
        }
        if (other.gameObject.CompareTag("CamSwapTriggerHouse3"))
        {
            BuildingIndoors3.enabled = true;
            BuildingEntrance.enabled = false;
            BuildingIndoors2.enabled = false;
            BuildingIndoors.enabled = false;
        }
        if (other.gameObject.CompareTag("CamSwapTriggerGas"))
        {
            SceneManager.LoadScene(sceneName: "GasStationLevel");
        }


        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                clues = clues + 1;
            }
            if (other.gameObject.CompareTag("GasStationLeave1"))
            {
                SceneManager.LoadScene(sceneName: "SmallTown");
            }


        }
    }
}