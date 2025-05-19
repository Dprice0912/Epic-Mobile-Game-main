using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class BallonController : MonoBehaviour
{
    public float UpSpeed;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.position.y > 7f)
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(0, UpSpeed, 0);
    }

    private void OnMouseDown()
    {
        GameManager.Instance.AddScore(1);

        audioSource.Play();
        ResetPosition();
    }

    private void ResetPosition()
    {
        float randomX = Random.Range(-2.5f, 2.5f);
        transform.position = new Vector2(randomX, -7f);
    }
}