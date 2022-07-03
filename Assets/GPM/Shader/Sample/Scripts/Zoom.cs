using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0649
public class Zoom : MonoBehaviour
{
    private const string SHADER_NAME = "GPM/GpmZoom";

    [SerializeField]
    private Texture mainTexture;

    [SerializeField]
    [Range(0f, 1f)]
    private float zoom = 0f;

    [SerializeField]
    [Range(0f, 1f)]
    private float centerX = 0.5f;

    [SerializeField]
    [Range(0f, 1f)]
    private float centerY = 0.5f;

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
            if (zoom <= -0.5f)
            {
                delta = Time.deltaTime;
            }
            else if (zoom >= 1.5f)
            {
                delta = -Time.deltaTime;
            }
            zoom += delta;

            material.SetFloat("_Zoom", Mathf.Clamp(zoom, 0f, 1f));
            material.SetFloat("_CenterX", Mathf.Clamp(centerX, 0f, 1f));
            material.SetFloat("_CenterY", Mathf.Clamp(centerY, 0f, 1f));
        }
    }
}
