using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helicopter : MonoBehaviour
{
    private HelicopterInput hi;

    public bool isPC;
    public bool isInverted;

    [HideInInspector]
    public Rigidbody rb;

    public float UpliftStrength;
    public float IntendedEngineSpeed;
    public float CurrentEngineSpeed;

    public Slider EngineSpeedSlider;       

    public Transform DefaultLerp_POS;
    public Transform InvertedLerp_POS;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hi = GetComponent<HelicopterInput>();
    }   

    void Update()
    {
        if (UpliftStrength < 19000)
            UpliftStrength += 100;

        StartupEngineProcess();
        InversionDirection();
    }

    #region Engine & Direction Functions
    private void StartupEngineProcess()
    {
        rb.AddForce(transform.up * Time.deltaTime * UpliftStrength);
        rb.AddForce(transform.up * Time.deltaTime * IntendedEngineSpeed);
    }

    private void EngineSpeedController()
    {
        IntendedEngineSpeed = EngineSpeedSlider.value;
    }   

    public void UpdateSpeedUI()
    {
        UIManager.instance.UpdateSpeedUI(EngineSpeedSlider.value);
    }

    private void InversionDirection()
    {
        if (!isInverted)
        {
            Quaternion targetRotation = Quaternion.LookRotation(DefaultLerp_POS.transform.position, transform.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 2 * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation = Quaternion.LookRotation(InvertedLerp_POS.transform.position, transform.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 2 * Time.deltaTime);
        }
    }

    private void InvertDirection()
    {
        isInverted = !isInverted;
    }
    #endregion
}
