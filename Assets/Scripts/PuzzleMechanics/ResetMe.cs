using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetMe : MonoBehaviour
{

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    public void Reset()
    {
        transform.position = startPos;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
