using UnityEngine;
using UnityEngine.UI;

public class BaseCanvas : MonoBehaviour
{
    public static BaseCanvas _baseCanvas { get; private set; }

    void Awake()
    {
        _baseCanvas = this;
    }

    public GameObject noahPlayer;
    public GameObject noahFBX;
    public GameObject myMouth;
 
    public TMPro.TextMeshProUGUI objectText;
    public GameObject statPanel;
    public TMPro.TextMeshProUGUI statText;
    public GameObject clock;

    public GameObject objectNameTag;
    public TMPro.TextMeshProUGUI objectNameText;

    public PlayerEquipment equipment;
}
