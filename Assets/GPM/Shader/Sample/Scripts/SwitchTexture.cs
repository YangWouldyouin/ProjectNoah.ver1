using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0649
public class SwitchTexture : MonoBehaviour
{
    private const string SHADER_NAME = "GPM/GpmSwitchTexture";

    [SerializeField]
    private Texture mainTexture;

    [SerializeField]
    private Texture switchTexture;

    [SerializeField]
    [Range(0f, 1f)]
    public float switchAmount = 0f;

    private float delta = 1f / 60f;

    private Material material;

    private void Awake()
    {
        Shader shader = Shader.Find(SHADER_NAME);
        material = new Material(shader);
        material.hideFlags = HideFlags.DontSave;
        material.SetTexture("_MainTex", mainTexture);
        material.SetTexture("_SwitchTex", switchTexture);

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
            if (switchAmount <= -0.5f)
            {
                delta = Time.deltaTime;
            }
            else if (switchAmount >= 1.5f)
            {
                delta = -Time.deltaTime;
            }
            switchAmount += delta;

            material.SetFloat("_SwitchAmount", Mathf.Clamp(switchAmount, 0f, 1f));
        }
    }
}
