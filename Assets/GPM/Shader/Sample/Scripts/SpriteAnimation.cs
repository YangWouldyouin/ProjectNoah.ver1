using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0649
public class SpriteAnimation : MonoBehaviour
{
    private const string SHADER_NAME = "GPM/GpmSpriteAnimation";

    [SerializeField]
    private Texture mainTexture;

    [SerializeField]
    public float horizontalAmount = 2f;

    [SerializeField]
    public float verticalAmount = 2f;

    [SerializeField]
    public float speed = 10f;

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
            material.SetFloat("_HorizontalAmount", horizontalAmount);
            material.SetFloat("_VerticalAmount", verticalAmount);
            material.SetFloat("_Speed", speed);
            material.SetFloat("_CurrentTime", Time.realtimeSinceStartup);
        }
    }
}
