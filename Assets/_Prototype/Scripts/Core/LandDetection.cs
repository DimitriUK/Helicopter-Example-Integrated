using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandDetection : MonoBehaviour
{
    bool firstTouch;
    bool isStopped;

    public float firstTouchSpeed;
    public float currentSpeed;

    private void Start()
    {
        StartCoroutine(UpdateCurrentSpeed());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BadWall")
        {
            GameManager.instance.EndGame(false, 0);
        }

        if (firstTouch)
            return;

        if (other.tag == "Helipad")
        {
            firstTouchSpeed = currentSpeed;       

            firstTouch = true;
        }
    }


    void Update()
    {
        if (isStopped)
            return;

        if (firstTouch)
        {
            if (GameManager.instance.HCPlayer.rb.velocity.magnitude < 0.01f)
            {
                isStopped = true;
                GameManager.instance.EndGame(true, firstTouchSpeed);
            }
        }
    }

    public IEnumerator UpdateCurrentSpeed()
    {
        yield return new WaitForSeconds(0.2f);
        currentSpeed = GameManager.instance.HCPlayer.rb.velocity.magnitude;
        StartCoroutine(UpdateCurrentSpeed());
    }
}
