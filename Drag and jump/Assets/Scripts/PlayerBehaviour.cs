using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

    #region
    public float speed;
    public float jumpSpeed;
    private Vector3 moveDirection = Vector3.zero;
    bool grounded = false;
    float gravity = 15;
    CharacterController controller;
    int nrOfAlowedDJumps = 1; 
    int dJumpCounter = 0;
    private Vector3 pos0;
    public float threshold;
    #endregion

    void Start () {
        controller = GetComponent<CharacterController>();
        pos0 = new Vector3(0.3f, 0.7f, 0.3f);
    }
	
	void Update () {
        //setzt spieler zurück wenn er fällt
        if (transform.position.y < threshold)
            transform.position = pos0;
        //Bewegung an der z axis
        float movePh = Input.GetAxis("Horizontal") *-speed * Time.deltaTime;
        transform.Translate(movePh * Vector3.forward);
        //Sprung mit w Sprung Mechanik double jump und wall jump
        if (Input.GetKeyDown("w")) {
            if (controller.isGrounded){
                moveDirection.y = jumpSpeed;
                dJumpCounter = 0;
            }
            if (!controller.isGrounded && dJumpCounter < nrOfAlowedDJumps){
                moveDirection.y = jumpSpeed;
                dJumpCounter++;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag(tag: "Goal")) {
            other.gameObject.SetActive(false);
            //load new level  ToDo:MenuScreen+Victory/Defeat Screen
            SceneManager.LoadScene("Level2");
        }
        //Respawn bei Kontakt mit enemy
        if(other.gameObject.CompareTag(tag: "Respawn")){
            transform.position = pos0;
        }
    }

}

