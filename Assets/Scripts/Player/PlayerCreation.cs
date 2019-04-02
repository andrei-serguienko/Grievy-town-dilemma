using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCreation : MonoBehaviour
{
    private Vector3 spawnPoint;
    public GameObject prefabPlayer;
    private GameObject player;

    // Use this for initialization
    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            player = Instantiate(prefabPlayer) as GameObject;
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(GameObject.Find("dialogueManager"));
            DontDestroyOnLoad(GameObject.Find("Canvas"));
            DontDestroyOnLoad(GameObject.Find("PlayerManager"));
        }
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            spawnPoint = GameObject.Find("FirstSpawn").transform.position;
            player.transform.position = spawnPoint;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
