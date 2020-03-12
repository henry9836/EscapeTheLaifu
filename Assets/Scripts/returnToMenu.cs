using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnToMenu : MonoBehaviour
{
    private GameObject manager;
    void Start()
    {
        manager = GameObject.Find("GameManager").gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EndCube")
        {
            if (manager.GetComponent<GameManager>().playing == false)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
