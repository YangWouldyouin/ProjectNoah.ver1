using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BaseCanvas : MonoBehaviour
{
    public static BaseCanvas _baseCanvas { get; private set; }

    void Awake()
    {
        _baseCanvas = this;
    }

    public GameObject noahPlayer;
    public GameObject noahFBX;
    public NavMeshAgent agent;
    public GameObject myMouth;
 
    public TMPro.TextMeshProUGUI objectText;
    public GameObject statPanel;
    public TMPro.TextMeshProUGUI statText;
    public GameObject clock;

    public GameObject objectNameTag;
    public TMPro.TextMeshProUGUI objectNameText;

    public PlayerEquipment equipment;

    public PortableObjectData workRoomData;
    public PortableObjectData livingRoomData;
    public PortableObjectData engineRoomData;
    public PortableObjectData controlRoomData;

    public TMPro.TextMeshProUGUI CameraNumText;
}
