using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{ 
    public string scene;
    private GameObject player;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().origin = SceneManager.GetActiveScene().name;
        if (collision.gameObject.tag.Equals("Player"))
            SceneManager.LoadScene(scene);
    }
}