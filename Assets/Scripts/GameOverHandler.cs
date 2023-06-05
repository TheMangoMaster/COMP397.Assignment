using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/*

Author: Jacob Todasco
Student #: 301251200
Date Modified: 02/06/2023
Description: This takes anything that collides with it (On Trigger enabled on the FINISH Object)
and sends the player to the GameOver screen.

*/


public class GameOverHandler : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy")
        {
            //Debug.Log("Enemy has breached the FINISH Line!");
            SceneManager.LoadScene("GameOver");
        }
    }

}
