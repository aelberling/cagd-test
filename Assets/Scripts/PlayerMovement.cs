using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private CharacterController controller;
	public float speed = 3.0f;
	public float jumpSpeed = 2.0f;
	public float gravity = 10.0f;
	public float moveAmount;
	KeyboardInput userInput;
	Vector3 movement = Vector3.zero;

	void Start(){
		controller = gameObject.GetComponent<CharacterController>  ();
		userInput = gameObject.GetComponent<KeyboardInput>();
	}


	void Update(){
		//if (controller.isGrounded) {
			if (userInput.XAxis > 0) {  //forward
				movement = new Vector3 (1, 0, 0) * Time.deltaTime;
			} else if (userInput.XAxis < 0) {  //backward
					movement = new Vector3 (-1, 0, 0) * Time.deltaTime;
			}
			
			if (userInput.JumpButtonPressedThisFrame) {  //jumping
			movement.y = jumpSpeed;
			}


			movement = transform.TransformDirection(movement);
			movement *= speed;
			movement.y -=gravity * Time.deltaTime;
			controller.Move (movement);
		movement = Vector3.zero;
		//}
	}//end of update


    /*
     * TO DO:
     * Movement
     *      Should use the CharacterController which is already attached to this GameObject
     *      Be able to move left and right
     *      Collide with/be stopped by walls
     *      Not move too quickly or slowly
     *          Remember that movement happens every frame
     * Jumping/Falling
     *      Fall to the ground, and not through it
     *      Able to jump
     *      Can reach platforms to the right, but not the one on the left
     *      Only able to jump while standing on the ground
     * Input
     *      Ideally, use the KeyboardInput script which is already attached to this GameObject
     *      A & D for left and right movement
     *      Space for jumping
     * Moving Platform
     *      When standing on the platform, the character should stay on it/move relative to the moving platform
     *      When not standing on the platform, revert to normal behavior
     * Enemy
     *      If the character touches the enemy, he should "die"
     *      
     * 
     * 
     * 
     * Variables you might want:
     *      References to the CharacterController and Keyboard input classes
     *      Speed values for moving, falling, and jumping
     *      A value to keep track of the player's movement speed and direction
     *      You will probably need to use the Update function as well as create functions for moving platforms and enemies
     */

}