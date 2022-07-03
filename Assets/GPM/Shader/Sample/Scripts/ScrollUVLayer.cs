using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0649
public class ScrollUVLayer : MonoBehaviour
{
    private const string SHADER_NAME = "GPM/GpmScrollUVLayer";

    [SerializeField]
    private Texture mainTexture;

    [SerializeField]
    private Texture rearTexture;

    [SerializeField]
    public float xSpeed = 1f;

    [SerializeField]
    public float ySpeed = 0f;

    [SerializeField]
    public float rearXSpeed = 0f;

    [SerializeField]
    public float rearYSpeed = 0f;

    private Material material;

    private void Awake()
    {
        Shader shader = Shader.Find(SHADER_NAME);
        material = new Material(shader);
        material.hideFlags = HideFlags.DontSave;
        material.SetTexture("_MainTex", mainTexture);
        material.SetTexture("_RearTex", rearTexture);

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
            material.SetFloat("_XSpeed", xSpeed);
            material.SetFloat("_YSpeed", ySpeed);
            material.SetFloat("_RearXSpeed", rearXSpeed);
            material.SetFloat("_RearYSpeed", rearYSpeed);
            material.SetFloat("_CurrentTime", Time.realtimeSinceStartup);
        }
    }
}
