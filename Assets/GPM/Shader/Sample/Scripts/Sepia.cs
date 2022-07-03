using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0649
public class Sepia : MonoBehaviour
{
    private const string SHADER_NAME = "GPM/GpmSepia";

    [SerializeField]
    private Texture mainTexture;

    [SerializeField]
    private Color tint = Color.white;

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
            material.SetColor("_Color", tint);
        }
    }
}
