using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour {

	// referenses to controlled game objects
	public GameObject avatar1, avatar2;
    public Camera camera1, camera2;

    public int whichAvatarIsOn = 1;

    Vector3 LastAvatar1Stance;
    Vector3 LastAvatar2Stance;

    public Canvas timeCanvas;

    TimeBar timeBar;

    public ParticleSystem player1particle, player2particle;

    void Start () {

		avatar1.gameObject.SetActive (true);
		avatar2.gameObject.SetActive (false);
        timeBar = FindObjectOfType<TimeBar>().GetComponent<TimeBar>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            whichAvatarIsOn *= -1;
        }
        //Debug.Log(whichAvatarIsOn);
        SwitchAvatar();

        LastAvatar1Stance = new Vector3(avatar1.transform.position.x, avatar1.transform.position.y,-5f);
        //Debug.Log("Avatar1 " + LastAvatar1Stance);
        LastAvatar2Stance = new Vector3(avatar2.transform.position.x, avatar2.transform.position.y,-5f);
        //Debug.Log("Avatar2 " + LastAvatar2Stance);

        player1particle.transform.position = LastAvatar1Stance;

        player2particle.transform.position = LastAvatar2Stance;
        if (Input.GetKeyDown(KeyCode.X))
        {
            avatar1.transform.position = LastAvatar2Stance;
        }

        if(timeBar.time.timeAmount <= 1)
        {
            whichAvatarIsOn = -1;

        }

    }

    // public method to switch avatars by pressing UI button
    public void SwitchAvatar()
	{

		switch (whichAvatarIsOn) {

            //Maail enabled
		case 1:
            timeBar.TimeReducing();
			avatar1.gameObject.SetActive (true);
			avatar2.gameObject.SetActive (false);
            camera1.gameObject.SetActive(true);
            camera2.gameObject.SetActive(false);
            player1particle.Play();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            timeCanvas.enabled = true;

                break;


            //Liaam Enabled
        case -1:
            timeBar.time.timeAmount = 100   ;
            avatar1.gameObject.SetActive (false);
			avatar2.gameObject.SetActive (true);
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(true);
            player2particle.Play();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            timeCanvas.enabled = false;
            
            break;
		}
			
	}
}
