using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

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
