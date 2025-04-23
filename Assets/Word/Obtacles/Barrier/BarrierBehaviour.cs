using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarrierBehaviour : MonoBehaviour
{
    public Player Player;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player = collision.gameObject.GetComponent<Player>();
            Player.IsDead = true;
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Level"); 
    }
}
