using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject character;
    public float speed = 350;
    private CharacterController controller;
    private Vector3 playerVelocity;

    void Start() {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        controller.Move(move * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) this.Shot();
    }

    public void Shot() {
        Debug.Log("Shot");
    }
}
