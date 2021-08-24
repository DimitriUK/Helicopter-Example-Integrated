using UnityEngine;

public class HelicopterInput : MonoBehaviour
{
    private Helicopter helicopter;

    [HideInInspector]
    public FixedJoystick FJ;

    [SerializeField]
    private bool isPC;

    private void Awake()
    {
        helicopter = GetComponent<Helicopter>();
        FJ = FindObjectOfType<FixedJoystick>();
    }

    void Update()
    {
        MobileTurnSpeedController();

#if UNITY_EDITOR
        if (isPC)
            DesktopInputDebugging();
#endif
    }

    public void MobileTurnSpeedController()
    {
        if (!helicopter.isInverted)
        {
            helicopter.rb.AddTorque(transform.right * Time.deltaTime * FJ.Horizontal * 500);

        }
        else
        {
            helicopter.rb.AddTorque(-transform.right * Time.deltaTime * FJ.Horizontal * 500);
        }
    }

    #region PC Debugging Input Functions

    public void DesktopInputDebugging()
    {
        float hor = Input.GetAxis("Horizontal");

        if (hor != 0)
        {
            if (!helicopter.isInverted)
            {
                if (hor < 0)
                    PCRotateController(-transform.right);
                else PCRotateController(transform.right);
            }
            else
            {
                if (hor < 0)
                    PCRotateController(transform.right);
                else PCRotateController(-transform.right);
            }
        }
    }

    public void PCRotateController(Vector3 direction)
    {
        helicopter.rb.AddTorque(direction * Time.deltaTime * 500);
    }
    #endregion
}
