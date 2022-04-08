using UnityEngine;
using UnityEngine.UI;

public class BaseCanvas : MonoBehaviour
{
    public static BaseCanvas _baseCanvas { get; private set; }

    [Header("기본 상호작용 버튼")]
    public Button barkButton;
    public Button sniffButton;
    public GameObject biteDestroyButton;

    public Button pushButton;
    public Button pressButton;

    [Header("추가 상호작용 버튼")]
    public Button noCenterButton;
    
    public Button upDownButton;
    public Button observeButton;
    public Button insertButton;
    public Button eatButton;

    public Button upDownDisableButton;
    public Button observeDisableButton;
    public Button insertDisableButton;
    public Button eatDisableButton;

    // Start is called before the first frame update
    void Awake()
    {
        _baseCanvas = this;
    }
}
