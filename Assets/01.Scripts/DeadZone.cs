using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<JumperPlayer>())
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
            WWWGameManager.instance.ShowRestartGame();
        }
    }

}
