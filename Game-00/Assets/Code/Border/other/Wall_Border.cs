using System.Collections;
using UnityEngine;

public class Wall_Border : MonoBehaviour
{
    [SerializeField] private float gradientSpeed_ = 0.5f;
    private LineRenderer lineRenderer_;
    private EdgeCollider2D edgeCollider_;
    private float gradientTime_ = 0f;

    private void Awake()
    {
        lineRenderer_ = GetComponent<LineRenderer>();
        edgeCollider_ = GetComponent<EdgeCollider2D>();
        ConfigLineRenderer();
    }

    private void Start()
    {
        StartCoroutine(UpdateGradientRoutine());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameMusic_Main.instance_.gameMusic_SFX_.PlayRandomSound();
        other.transform.position = CONSTANTS.DEFAULT_START_POINT;
    }

    private IEnumerator UpdateGradientRoutine()
    {
        while (true)
        {
            UpdateGradient();
            yield return null;
        }
    }

    private void UpdateGradient()
    {
        gradientTime_ = (gradientTime_ + Time.deltaTime * gradientSpeed_) % 1f;

        Gradient gradient = new Gradient();

        GradientColorKey[] colorKeys = new GradientColorKey[]
        {
            new GradientColorKey(Color.blue, gradientTime_),
            new GradientColorKey(Color.red, (gradientTime_ + 0.25f) % 1f),
            new GradientColorKey(Color.green, (gradientTime_ + 0.5f) % 1f),
            new GradientColorKey(Color.yellow, (gradientTime_ + 0.75f) % 1f),
            new GradientColorKey(Color.blue, (1f + gradientTime_) % 1f),
        };

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[]
        {
            new GradientAlphaKey(1.0f, 0.0f),
            new GradientAlphaKey(1.0f, 1.0f),
        };

        gradient.SetKeys(colorKeys, alphaKeys);
        lineRenderer_.colorGradient = gradient;
    }

    private void ConfigLineRenderer()
    {
        lineRenderer_.useWorldSpace = true;
        lineRenderer_.loop = true;
        lineRenderer_.widthMultiplier = CONSTANTS.DEFAULT_BORDER_THICKNESS;

        lineRenderer_.startWidth = CONSTANTS.DEFAULT_BORDER_WIDTH;
        lineRenderer_.endWidth = CONSTANTS.DEFAULT_BORDER_WIDTH;
        lineRenderer_.sortingOrder = -1;
    }
}
