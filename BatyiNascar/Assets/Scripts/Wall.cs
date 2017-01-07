using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Wall : MonoBehaviour {
  //  public Text title;
    void Start () {
    }
   
    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Car"))
        {
            SceneManager.LoadScene("Won");
        }
        else
        {
            SceneManager.LoadScene("Lost");
        }
    }
    void Update()
    {          
        if (Input.GetKeyDown("space")) SceneManager.LoadScene("Menu");
    }
}
