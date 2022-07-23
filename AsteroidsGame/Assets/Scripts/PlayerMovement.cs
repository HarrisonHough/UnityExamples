using UnityEngine;

[RequireComponent(typeof(InputController), typeof(ShipMotor))]
public class PlayerMovement : MonoBehaviour
{
    [Range(0, 5)] [SerializeField]
    private float rotateSpeed = 1;
    [SerializeField]
    private ShipMotor shipMotor;
    private InputController inputController;
    [SerializeField]
    private ParticleSystem thrustParticles;

    private void Start()
    {
        inputController = GetComponent<InputController>();
        shipMotor = GetComponent<ShipMotor>();
        if (thrustParticles == null)
            thrustParticles = transform.GetComponentInChildren<ParticleSystem>();
    }
    
    private void FixedUpdate()
    {
        Rotate(inputController.XInput);

        if (inputController.YInput > 0)
        {
            shipMotor.Thrust(inputController.YInput);
            if (!thrustParticles.isPlaying)
                thrustParticles.Play();
        }
        else
        {
            shipMotor.Slow();
            thrustParticles.Stop();
        }
    }

    /// <summary>
    /// Rotates object over time, called from InputController class 
    /// (in FixedUpdate() for accurate physics)
    /// </summary>
    /// <param name="value"></param>
    public void Rotate(float value)
    {
        transform.Rotate(0, Time.deltaTime * value * (rotateSpeed * 100), 0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    public void MouseLook(Vector3 target)
    {
        target.y = 0;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, target, rotateSpeed / 20, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
