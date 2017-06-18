using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag(TagNames.GameController);
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(TagNames.Boundary) || other.CompareTag(TagNames.Enemy) )
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
        }
        
        if (other.CompareTag(TagNames.Player))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}

static class TagNames
{
    public static string Boundary = "Boundary";
    public static string Player = "Player";
    public static string GameController = "GameController";
    public static string Enemy = "Enemy";
}