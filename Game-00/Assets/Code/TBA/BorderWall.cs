using UnityEngine;

public class BorderWall : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer_;
    [SerializeField] private EdgeCollider2D edgeCollider_;
    [SerializeField] private float gradientSpeed_;

    Gradient gradient;
    GradientColorKey[] colorKeys;
    GradientAlphaKey[] alphaKeys;
    float timer;
    public float cycleDuration = 2f; // Duration of one complete cycle
    private float gradientTime_ = 0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        Player_Main.instance_.player_Sound_.PlayRandomSound();
        other.gameObject.transform.position = new Vector3(0, 0, 0);
    }


    public void UpdateGradient_Gradient()
    {
        // Update gradientTime with the gradient speed
        gradientTime_ += Time.deltaTime * gradientSpeed_;

        // Reset gradientTime if it's bigger than 1
        if (gradientTime_ >= 1f)
        {
            gradientTime_ -= 1f;
        }

        // Create a new gradient
        Gradient gradient = new Gradient();

        // Define new gradient keys based on gradientTime
        gradient.SetKeys(
            new GradientColorKey[] {
            new GradientColorKey(Color.blue, gradientTime_),
            new GradientColorKey(Color.green, 0.5f + gradientTime_),
            new GradientColorKey(Color.blue, 1.0f + gradientTime_) },
            new GradientAlphaKey[] {
            new GradientAlphaKey(1.0f, 0.0f),
            new GradientAlphaKey(1.0f, 1.0f) }
        );

        // Apply the gradient to the LineRenderer
        lineRenderer_.colorGradient = gradient;
    }


    void Awake()
    {
    }
    void Start()
    {
        //ConfigLineRenderer();
    }

    void Update()
    {
        UpdateGradient_Gradient();
    }

}
