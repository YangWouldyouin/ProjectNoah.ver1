using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InHouseNewsUI : MonoBehaviour
{
    //public GameObject[] UniverseImageList;
    public int UniListnum;

    public GameObject NewsImage;
    public Image PicNewsImage;
    public Sprite ChangeImage1;
    public Sprite ChangeImage2;
    public Sprite ChangeImage3;
    public Sprite ChangeImage4;
    public Sprite ChangeImage5;
    public GameObject NewsTitleText;
    public GameObject NewsBodyText;
    public GameObject ExitBT;

    public GameObject Day2Title;
    public GameObject Day3Title;
    public GameObject Day4Title;

    public GameObject Day2Image;
    public GameObject Day3Image;
    public GameObject Day4Image;

    public GameObject Day2Body;
    public GameObject Day3Body;
    public GameObject Day4Body;

    public GameObject InhouseNews_GUI;

    public InGameTime inGameTime;

    void Start()
    {
        //PicNewsImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inGameTime.timer >= 720 && inGameTime.timer <=721)
        {
            Debug.Log("2ÀÏ");
            InhouseNews_GUI.SetActive(true);
            ExitBT.SetActive(false);

            Day2Title.SetActive(true);
            Day3Title.SetActive(false);
            Day4Title.SetActive(false);
            NewsTitleText.SetActive(false);

            Day2Image.SetActive(true);
            Day3Image.SetActive(false);
            Day4Image.SetActive(false);
            NewsImage.SetActive(false);

            Day2Body.SetActive(true);
            Day3Body.SetActive(false);
            Day4Body.SetActive(false);
            NewsBodyText.SetActive(false);

            Invoke("ExitBTNotice", 3f);
            Invoke("NewUIFalse", 230f);
        }
        else if (inGameTime.timer >= 2160 && inGameTime.timer <= 2161)
        {
            InhouseNews_GUI.SetActive(true);
            ExitBT.SetActive(false);

            Day2Title.SetActive(false);
            Day3Title.SetActive(true);
            Day4Title.SetActive(false);
            NewsTitleText.SetActive(false);

            Day2Image.SetActive(false);
            Day3Image.SetActive(true);
            Day4Image.SetActive(false);
            NewsImage.SetActive(false);

            Day2Body.SetActive(false);
            Day3Body.SetActive(true);
            Day4Body.SetActive(false);
            NewsBodyText.SetActive(false);

            Invoke("ExitBTNotice", 3f);
            Invoke("NewUIFalse", 230f);
        }
        else if (inGameTime.timer >= 3600 && inGameTime.timer <= 3601)
        {
            InhouseNews_GUI.SetActive(true);
            ExitBT.SetActive(false);

            Day2Title.SetActive(false);
            Day3Title.SetActive(false);
            Day4Title.SetActive(true);
            NewsTitleText.SetActive(false);

            Day2Image.SetActive(false);
            Day3Image.SetActive(false);
            Day4Image.SetActive(true);
            NewsImage.SetActive(false);

            Day2Body.SetActive(false);
            Day3Body.SetActive(false);
            Day4Body.SetActive(true);
            NewsBodyText.SetActive(false);

            Invoke("ExitBTNotice", 3f);
            Invoke("NewUIFalse", 230f);
        }
        else if (inGameTime.timer >= 1440 && inGameTime.timer <= 1441)
        {
            if (GameManager.gameManager._gameData.IsPhotoCheck == true)
            {
                UniListnum = GameManager.gameManager._gameData.randomUPic;

                if (UniListnum == 0)
                {
                    PicNewsImage.sprite = ChangeImage1;
                }
                else if (UniListnum == 1)
                {
                    PicNewsImage.sprite = ChangeImage2;
                }
                else if (UniListnum == 2)
                {
                    PicNewsImage.sprite = ChangeImage3;
                }
                else if (UniListnum == 3)
                {
                    PicNewsImage.sprite = ChangeImage4;
                }
                else if (UniListnum == 4)
                {
                    PicNewsImage.sprite = ChangeImage5;
                }

                InhouseNews_GUI.SetActive(true);
                ExitBT.SetActive(false);

                Day2Title.SetActive(false);
                Day3Title.SetActive(false);
                Day4Title.SetActive(false);
                NewsTitleText.SetActive(true);

                Day2Image.SetActive(false);
                Day3Image.SetActive(false);
                Day4Image.SetActive(false);
                NewsImage.SetActive(true);

                Day2Body.SetActive(false);
                Day3Body.SetActive(false);
                Day4Body.SetActive(false);
                NewsBodyText.SetActive(true);

                Invoke("ExitBTNotice", 3f);
                Invoke("NewUIFalse", 230f);

                GameManager.gameManager._gameData.IsPhotoCheck = false;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }
        else if (inGameTime.timer >= 2880 && inGameTime.timer <= 2881)
        {
            if (GameManager.gameManager._gameData.IsPhotoCheck == true)
            {
                UniListnum = GameManager.gameManager._gameData.randomUPic;

                if (UniListnum == 0)
                {
                    PicNewsImage.sprite = ChangeImage1;
                }
                else if (UniListnum == 1)
                {
                    PicNewsImage.sprite = ChangeImage2;
                }
                else if (UniListnum == 2)
                {
                    PicNewsImage.sprite = ChangeImage3;
                }
                else if (UniListnum == 3)
                {
                    PicNewsImage.sprite = ChangeImage4;
                }
                else if (UniListnum == 4)
                {
                    PicNewsImage.sprite = ChangeImage5;
                }

                InhouseNews_GUI.SetActive(true);
                ExitBT.SetActive(false);

                Day2Title.SetActive(false);
                Day3Title.SetActive(false);
                Day4Title.SetActive(false);
                NewsTitleText.SetActive(true);

                Day2Image.SetActive(false);
                Day3Image.SetActive(false);
                Day4Image.SetActive(false);
                NewsImage.SetActive(true);

                Day2Body.SetActive(false);
                Day3Body.SetActive(false);
                Day4Body.SetActive(false);
                NewsBodyText.SetActive(true);

                Invoke("ExitBTNotice", 3f);
                Invoke("NewUIFalse", 230f);

                GameManager.gameManager._gameData.IsPhotoCheck = false;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }
        else if (inGameTime.timer >= 4320 && inGameTime.timer <= 4321)
        {
            if (GameManager.gameManager._gameData.IsPhotoCheck == true)
            {
                UniListnum = GameManager.gameManager._gameData.randomUPic;

                if (UniListnum == 0)
                {
                    PicNewsImage.sprite = ChangeImage1;
                }
                else if (UniListnum == 1)
                {
                    PicNewsImage.sprite = ChangeImage2;
                }
                else if (UniListnum == 2)
                {
                    PicNewsImage.sprite = ChangeImage3;
                }
                else if (UniListnum == 3)
                {
                    PicNewsImage.sprite = ChangeImage4;
                }
                else if (UniListnum == 4)
                {
                    PicNewsImage.sprite = ChangeImage5;
                }

                InhouseNews_GUI.SetActive(true);
                ExitBT.SetActive(false);

                Day2Title.SetActive(false);
                Day3Title.SetActive(false);
                Day4Title.SetActive(false);
                NewsTitleText.SetActive(true);

                Day2Image.SetActive(false);
                Day3Image.SetActive(false);
                Day4Image.SetActive(false);
                NewsImage.SetActive(true);

                Day2Body.SetActive(false);
                Day3Body.SetActive(false);
                Day4Body.SetActive(false);
                NewsBodyText.SetActive(true);

                Invoke("ExitBTNotice", 3f);
                Invoke("NewUIFalse", 230f);

                GameManager.gameManager._gameData.IsPhotoCheck = false;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }
        else if (inGameTime.timer >= 5760 && inGameTime.timer <= 5761)
        {
            if (GameManager.gameManager._gameData.IsPhotoCheck == true)
            {
                UniListnum = GameManager.gameManager._gameData.randomUPic;

                if (UniListnum == 0)
                {
                    PicNewsImage.sprite = ChangeImage1;
                }
                else if (UniListnum == 1)
                {
                    PicNewsImage.sprite = ChangeImage2;
                }
                else if (UniListnum == 2)
                {
                    PicNewsImage.sprite = ChangeImage3;
                }
                else if (UniListnum == 3)
                {
                    PicNewsImage.sprite = ChangeImage4;
                }
                else if (UniListnum == 4)
                {
                    PicNewsImage.sprite = ChangeImage5;
                }

                InhouseNews_GUI.SetActive(true);
                ExitBT.SetActive(false);

                Day2Title.SetActive(false);
                Day3Title.SetActive(false);
                Day4Title.SetActive(false);
                NewsTitleText.SetActive(true);

                Day2Image.SetActive(false);
                Day3Image.SetActive(false);
                Day4Image.SetActive(false);
                NewsImage.SetActive(true);

                Day2Body.SetActive(false);
                Day3Body.SetActive(false);
                Day4Body.SetActive(false);
                NewsBodyText.SetActive(true);

                Invoke("ExitBTNotice", 3f);
                Invoke("NewUIFalse", 230f);

                GameManager.gameManager._gameData.IsPhotoCheck = false;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }
        else if (inGameTime.timer >= 7200 && inGameTime.timer <= 7201)
        {
            if (GameManager.gameManager._gameData.IsPhotoCheck == true)
            {
                UniListnum = GameManager.gameManager._gameData.randomUPic;

                if (UniListnum == 0)
                {
                    PicNewsImage.sprite = ChangeImage1;
                }
                else if (UniListnum == 1)
                {
                    PicNewsImage.sprite = ChangeImage2;
                }
                else if (UniListnum == 2)
                {
                    PicNewsImage.sprite = ChangeImage3;
                }
                else if (UniListnum == 3)
                {
                    PicNewsImage.sprite = ChangeImage4;
                }
                else if (UniListnum == 4)
                {
                    PicNewsImage.sprite = ChangeImage5;
                }

                InhouseNews_GUI.SetActive(true);
                ExitBT.SetActive(false);

                Day2Title.SetActive(false);
                Day3Title.SetActive(false);
                Day4Title.SetActive(false);
                NewsTitleText.SetActive(true);

                Day2Image.SetActive(false);
                Day3Image.SetActive(false);
                Day4Image.SetActive(false);
                NewsImage.SetActive(true);

                Day2Body.SetActive(false);
                Day3Body.SetActive(false);
                Day4Body.SetActive(false);
                NewsBodyText.SetActive(true);

                Invoke("ExitBTNotice", 3f);
                Invoke("NewUIFalse", 230f);

                GameManager.gameManager._gameData.IsPhotoCheck = false;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }
    }

    public void ExitBTNotice()
    {
        ExitBT.SetActive(true);
    }

    public void NewUIFalse()
    {
        InhouseNews_GUI.SetActive(false);
        ExitBT.SetActive(false);
    }


    public void OnExitBT()
    {
        InhouseNews_GUI.SetActive(false);
        ExitBT.SetActive(false);
    }
}
