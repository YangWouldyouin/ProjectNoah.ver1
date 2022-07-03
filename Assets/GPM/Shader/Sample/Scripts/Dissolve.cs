using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0649
public class Dissolve : MonoBehaviour
{
    private const string SHADER_NAME = "GPM/GpmDissolve";

    [SerializeField]
    private Texture mainTexture;

    [SerializeField]
    private Texture noiseTexture;

    [SerializeField]
    private Color edgeColor = Color.white;

    [SerializeField]
    [Range(0f, 1f)]
    private float edgeWidth = 0.1f;

    [SerializeField]
    [Range(0f, 1f)]
    private float dissolve = 0f;

    private float delta = 1f / 60f;

    private Material material;

    private void Awake()
    {
        Shader shader = Shader.Find(SHADER_NAME);
        material = new Material(shader);
        material.hideFlags = HideFlags.DontSave;
        material.SetTexture("_MainTex", mainTexture);
        material.SetTexture("_NoiseTex", noiseTexture);

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
            if (dissolve <= -0.5f)
            {
                delta = Time.deltaTime;
            }
            else if (dissolve >= 1.5f)
            {
                delta = -Time.deltaTime;
            }
            dissolve += delta;

            material.SetColor("_EdgeColor", edgeColor);
            material.SetFloat("_EdgeWidth", Mathf.Clamp(edgeWidth, 0f, 1f));
            material.SetFloat("_Dissolve", Mathf.Clamp(dissolve, 0f, 1f));
        }
    }
}
