using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditStatus : MonoBehaviour
{
    public GameObject stage;
    Vector3 currentPosit;
    float currentrotate;
    public float moveAmount = 0.02f;
    public float rotAmount = 2f;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("stagex"))
        {
            currentPosit.x = PlayerPrefs.GetFloat("stagex");
        }
        else
        {
            currentPosit.x = stage.transform.position.x;
            PlayerPrefs.SetFloat("stagex", currentPosit.x);

        }
        if (PlayerPrefs.HasKey("stagey"))
        {
            currentPosit.y = PlayerPrefs.GetFloat("stagey");
        }
        else
        {
            currentPosit.y = stage.transform.position.y;
            PlayerPrefs.SetFloat("stagey", currentPosit.y);
        }
        if (PlayerPrefs.HasKey("stagez"))
        {
            currentPosit.z = PlayerPrefs.GetFloat("stagez");
        }
        else
        {
            currentPosit.z = stage.transform.position.z;
            PlayerPrefs.SetFloat("stagez", currentPosit.z);
        }
        if (PlayerPrefs.HasKey("rotate"))
        {
            currentrotate = PlayerPrefs.GetFloat("rotate");
        }
        else
        {
            Vector3 rotbuf = stage.transform.rotation.eulerAngles;
            currentrotate = rotbuf.y;
            PlayerPrefs.SetFloat("rotate", currentrotate);
            
        }
        Quaternion newRotation = Quaternion.Euler(0f, currentrotate, 0f);
        stage.transform.rotation = newRotation;
        stage.transform.position = currentPosit;
    }

    public void frontMove()
    {
        if (PlayerPrefs.HasKey("stagez"))
        {
            currentPosit.z += moveAmount;
            PlayerPrefs.SetFloat("stagez", currentPosit.z);
            stage.transform.position = currentPosit;
        }
    }
    public void backMove()
    {
        if (PlayerPrefs.HasKey("stagez"))
        {
            currentPosit.z -= moveAmount;
            PlayerPrefs.SetFloat("stagez", currentPosit.z);
            stage.transform.position = currentPosit;
        }
    }
    public void rightMove()
    {
        if (PlayerPrefs.HasKey("stagex"))
        {
            currentPosit.x += moveAmount;
            PlayerPrefs.SetFloat("stagex", currentPosit.x);
            stage.transform.position = currentPosit;
        }
    }
    public void leftMove()
    {
        if (PlayerPrefs.HasKey("stagex"))
        {
            currentPosit.x -= moveAmount;
            PlayerPrefs.SetFloat("stagex", currentPosit.x);
            stage.transform.position = currentPosit;
        }
    }
    public void upMove()
    {
        if (PlayerPrefs.HasKey("stagey"))
        {
            currentPosit.y += moveAmount;
            PlayerPrefs.SetFloat("stagey", currentPosit.y);
            stage.transform.position = currentPosit;
        }
    }
    public void downMove()
    {
        if (PlayerPrefs.HasKey("stagey"))
        {
            currentPosit.y -= moveAmount;
            PlayerPrefs.SetFloat("stagey", currentPosit.y);
            stage.transform.position = currentPosit;
        }
    }
    public void plusRot()
    {
        if (PlayerPrefs.HasKey("rotate"))
        {
            currentrotate += rotAmount;
            PlayerPrefs.SetFloat("rotate", currentrotate);
            Quaternion newRotation = Quaternion.Euler(0f, currentrotate, 0f);
            stage.transform.rotation = newRotation;
        }
    }
    public void minusRot()
    {
        if (PlayerPrefs.HasKey("rotate"))
        {
            currentrotate -= rotAmount;
            PlayerPrefs.SetFloat("rotate", currentrotate);
            Quaternion newRotation = Quaternion.Euler(0f, currentrotate, 0f);
            stage.transform.rotation = newRotation;
        }
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
