using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject character;
    public float speed = 350;
    float movement = Input.GetAxis("Horizontal");

    void Update()
    {
        this.character.transform.position = new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) this.Shot();
    }

    public void Shot() {
        Debug.Log("Shot");
    }
}
