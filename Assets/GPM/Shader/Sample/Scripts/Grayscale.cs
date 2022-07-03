using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0649
public class Grayscale : MonoBehaviour
{
    private const string SHADER_NAME = "GPM/GpmGrayscale";

    [SerializeField]
    private Texture mainTexture;

    [SerializeField]
    [Range(0f, 1f)]
    public float grayscale = 0.333f;

    private float delta = 1f / 60f;

    private Material material;

    private void Awake()
    {
        Shader shader = Shader.Find(SHADER_NAME);
        material = new Material(shader);
        material.hideFlags = HideFlags.DontSave;
        material.SetTexture("_MainTex", mainTexture);

        Image image = GetComponent<Image>();
        image.material = material;
    }

    private void OnDestroy()
    {
        if (material)
        {
            DestroyImmediate(material);
        }
    }

    private void Update()
    {
        if (material != null)
        {
            if (grayscale <= -0.5f)
            {
                delta = Time.deltaTime;
            }
            else if (grayscale >= 1.5f)
            {
                delta = -Time.deltaTime;
            }
            grayscale += delta;

            material.SetFloat("_Grayscale", Mathf.Clamp(grayscale, 0f, 1f));
        }
    }
}