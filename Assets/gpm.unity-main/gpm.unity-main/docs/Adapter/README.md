# Adapter

๐ [English](README.en.md)

## ๐ฉ ๋ชฉ์ฐจ

* [๊ฐ์](#๊ฐ์)
* [์คํ](#์คํ)
* [AdapterTool](#-adaptertool)
* [API](#-api)
* [Release notes](./ReleaseNotes.md)

## ๊ฐ์

Facebook, Google ๋ฑ์ IdP๋ Unity๋ก ๊ฐ๋ฐ ์ค์ธ ์ ํ๋ฆฌ์ผ์ด์์์ ์ฝ๊ณ  ๋น ๋ฅด๊ฒ IdP์ ๊ธฐ๋ฅ์ ์ฌ์ฉํ  ์ ์๋๋ก Unity SDK๋ฅผ ์ ๊ณตํ๊ณ  ์์ต๋๋ค. ํ์ง๋ง IdP๋ง๋ค API๊ฐ ์๋ก ๋ค๋ฅด๋ฏ๋ก, ์ฌ๋ฌ IdP์ ๊ธฐ๋ฅ์ ๊ฐ๊ฐ ๊ตฌํ ์ ๋ง์ ํ์ต๊ณผ ์๊ฐ์ด ํ์ํฉ๋๋ค.
Adapter๋ ํ๋์ ๊ณตํตํ๋ ์ธํฐํ์ด์ค๋ฅผ ์ ๊ณตํด ์ฌ๋ฌ IdP์ ๊ธฐ๋ฅ์ ์ฝ๊ฒ ์ ์ฉํ  ์ ์์ต๋๋ค.

## ์คํ

### Unity ์ง์ ๋ฒ์ 

* 2018.4.0 ์ด์

### ์ง์ IdP

๊ฐ IdP SDK๋ ์ง์  ๋ค์ด๋ก๋ ๋ฐ ์ค์นํ์์ผ ํฉ๋๋ค.

* Google Play Games plugin for Unity
    * [Download](https://github.com/playgameservices/play-games-plugin-for-unity)
    * Tested version
        * 0.9.56
        * 0.9.57
        * 0.9.63
        * 0.9.64
        * 0.10.09
* Facebook SDK for Unity 
    * [Download](https://developers.facebook.com/docs/unity/downloads)
    * Tested version
        * 7.15.0
        * 7.15.1
        * 7.16.0
        * 7.16.1
        * 7.17.0
        * 7.17.1
        * 7.17.2
        * 7.18.0
        * 7.18.1
        * 7.19.0
        * 7.19.1
        * 7.19.2

## ๐ง AdapterTool

Adapter์์ ์ง์ํ๋ IdP SDK๊ฐ ์์ผ๋ฉด ์๋์ ๊ฐ์ ์ค๋ฅ๊ฐ ๋ฐ์ํฉ๋๋ค.

```cs
error CS0103: The name 'FB' does not exist in the current context
```

์ฌ์ฉํ๋ IdP์ ๋ฐ๋ผ์ Adapter ์ค์ ์ด ํ์ํฉ๋๋ค.

![GPMAdapterSettingTool](./images/GPMAdapterSettingTool_001.png)

### ์ฌ์ฉ๋ฐฉ๋ฒ

1. Menu > Tools > GPM > Adapter > Settings
2. ์ฌ์ฉ ์ฌ๋ถ์ ๋ฐ๋ผ ์ฒดํฌ๋ฒํผ์ ์ ํํ๊ฑฐ๋ ์ ํ์ ํด์ ํฉ๋๋ค.
3. Set ๋ฒํผ์ ํด๋ฆญํ์ฌ ์ค์ ์ ์๋ฃํฉ๋๋ค.

> [`์ฃผ์`]
>
> Adapter์ ํด๋ ๊ตฌ์กฐ๋ฅผ ๋ณ๊ฒฝํ์ง ๋ง์ญ์์ค.
> Adapter์ ์ฝ๋ ๋ฐ ํ์ผ์ ์๋์ผ๋ก ์ญ์ ํ์ง ๋ง์ญ์์ค.


## ๐จ API

### IsSuccess

AdapterError ๊ฐ์ฒด๋ก ์ฑ๊ณต ์ฌ๋ถ๋ฅผ ํ์ธํฉ๋๋ค.
AdapterErrorCode์ ๋ํ ์์ธํ ์ ๋ณด๋ ์๋ ErrorCode ํญ๋ชฉ์ ์ฐธ๊ณ ํ์ญ์์ค.

#### API

```cs
static bool IsSuccess(AdapterError error)
```

#### Example

```cs
private void SampleIsSucces(AdapterError error)
{
    if (GpmAdapter.IsSuccess(error) == true)
    {
        Debug.Log("success");
    }
    else
    {
        Debug.Log(string.Format("failure. error:{0}", error));
    }
}
```

### Login

IdP์ ์ด๋ฆ๊ณผ ์ถ๊ฐ ์ ๋ณด๋ฅผ ์ฌ์ฉํ์ฌ IdP ๋ก๊ทธ์ธ์ ์๋ํฉ๋๋ค.
Adapter์์ ์ง์ํ๋ IdP์ ์ด๋ฆ์ GpmAdapterType.Idp ํด๋์ค๋ฅผ ํตํด ์ ๊ณตํฉ๋๋ค.

> [์ฐธ๊ณ ]
>
> Facebook SDK ๋ก๊ทธ์ธ ์์๋ Facebook ๊ถํ ์ ๋ณด๊ฐ ํ์ํ๋ฉฐ, ์ถ๊ฐ ์ ๋ณด์ `facebook_permissions` ํค๋ฅผ ์ฌ์ฉํ์ฌ ์ค์ ํด์ผ ํฉ๋๋ค. Facebook ๊ถํ ์ ๋ณด๋ฅผ ์ค์ ํ์ง ์์ ๊ฒฝ์ฐ์๋ ๊ธฐ๋ณธ๊ฐ์ผ๋ก `[public_profile, email]` ๊ฐ์ด ์ค์ ๋ฉ๋๋ค. ์์ธํ ์ฌ์ฉ๋ฒ์ ์๋ Example์ ์ฐธ๊ณ ํ์ญ์์ค.

#### API

```cs
static void Login(string idpName, Dictionary<string, object> additionalInfo, Action<AdapterError> callback)
```

#### Example

```cs
private void SampleLogin(string idpName)
{
    Dictionary<string, object> additionalInfo;
    
    switch (idpName)
    {
        case GpmAdapterType.Idp.FACEBOOK:
        {
            var facebookPermissionList = new List<string> { "public_profile", "email" };
            additionalInfo = new Dictionary<string, object>();
            additionalInfo.Add("facebook_permissions", facebookPermissionList);
            break;
        }
        case GpmAdapterType.Idp.GPGS:
        default:
        {
            additionalInfo = null;
            break;
        }
    }
    
    GpmAdapter.Idp.Login(GpmAdapterType.Idp.FACEBOOK, additionalInfo, (error) => 
    {
        if (GpmAdapter.IsSuccess(error) == true)
        {
            Debug.Log("success");
        }
        else
        {
            Debug.Log(string.Format("failure. error:{0}", error));
        }
    });
}
```

### Logout

IdP ๋ก๊ทธ์์์ ์๋ํฉ๋๋ค.

#### API

```cs
static void Logout(string idpName, Action<AdapterError> callback)
```

#### Example

```cs
private void SampleLogout()
{
    GpmAdapter.Idp.Logout(GpmAdapterType.Idp.FACEBOOK, (error) => 
    {
        if (GpmAdapter.IsSuccess(error) == true)
        {
            Debug.Log("success");
        }
        else
        {
            Debug.Log(string.Format("failure. error:{0}", error));
        }
    });
}
```

### LogoutAll

๋ชจ๋  IdP ๋ก๊ทธ์์์ ์๋ํฉ๋๋ค.
๋ชจ๋  IdP๊ฐ ๋ก๊ทธ์์๋๊ธฐ ์ ์ ์ค๋ฅ๊ฐ ๋ฐ์ํ๋ฉด, ๋ ์ด์ ๋ก๊ทธ์์์ ์ฒ๋ฆฌํ์ง ์๊ณ  ์ค๋ฅ๋ฅผ ๋ฐํํฉ๋๋ค.

#### API

```cs
static void LogoutAll(Action<AdapterError> callback)
```

#### Example

```cs
private void SampleLogoutAll()
{
    GpmAdapter.Idp.LogoutAll((error) =>
    {
        if (GpmAdapter.IsSuccess(error) == true)
        {
            Debug.Log("success");
        }
        else
        {
            Debug.Log(string.Format("failure. error:{0}", error));
        }
    });
}
```

### GetAuthInfo

IdP์ ์ธ์ฆ ์ ๋ณด๋ฅผ ์กฐํํฉ๋๋ค.
Facebook์ AccessToken์ ๋ฐํํ๋ฉฐ, Google์ ServerAuthCode๋ฅผ ๋ฐํํฉ๋๋ค.
์ธ์ฆ ์ ๋ณด๊ฐ Empty์ธ ๊ฒฝ์ฐ, DebugLogEnabled๋ฅผ ํ์ฑํํ๊ณ  ๋ก๊ทธ๋ฅผ ํ์ธํ์ญ์์ค.

#### API

```cs
static void GetAuthInfo(string idpName, Action<string> callback)
```

#### Example

```cs
private void SampleGetAuthInfo()
{
    GpmAdapter.Idp.GetAuthInfo(GpmAdapterType.Idp.FACEBOOK, (facebookAuthInfo) => 
    {
        Debug.Log(string.Format("authInfo:{0}", facebookAuthInfo));
    });
}
```

### GetProfile

IdP์ ํ๋กํ ์ ๋ณด๋ฅผ ์กฐํํฉ๋๋ค.
ํ๋กํ์ ๊ธฐ๋ณธ ์ ๋ณด๋ ์๋์ ๊ฐ์ต๋๋ค.

* id
* name
* email


#### API

```cs
static void GetProfile(string idpName, Action<Dictionary<string, object>> callback)
```

#### Example

```cs
private void SampleGetProfile()
{
    GpmAdapter.Idp.GetProfile(GpmAdapterType.Idp.FACEBOOK, (facebookProfile) =>
    {
        if (facebookProfile == null)
        {
            Debug.Log("Facebook profile is null.");
        }
        else
        {
            foreach (KeyValuePair<string, object>kvp in facebookProfile)
            {
                Debug.Log(string.Format("{0}:{1}\n", kvp.Key, kvp.Value));
            }
        }
    });
}
```

### GetLoggedInIdpList

๋ก๊ทธ์ธ๋ ๋ชจ๋  IdP์ ์ด๋ฆ์ ์กฐํํฉ๋๋ค.

#### API

```cs
static List<string> GetLoggedInIdpList()
```

#### Example

```cs
private void SampleGetLoggedInIdpList()
{
    var loggedInIdpList = GpmAdapter.Idp.GetLoggedInIdpList();
    foreach (var loggedInIdp in loggedInIdpList)
    {
        Debug.Log(string.Format("loggedInIdp:{0}", loggedInIdp));
    }
}
```

### GetUserId

IdP์ UserId ์ ๋ณด๋ฅผ ์กฐํํฉ๋๋ค.

#### API

```cs
static string GetUserId(string idpName)
```

#### Example

```cs
private void SampleGetUserId()
{
    var facebookUserId = GpmAdapter.Idp.GetUserId(GpmAdapterType.Idp.FACEBOOK);
    Debug.Log(string.Format("facebookUserId:{0}", facebookUserId));
}
```

### ErrorCode

| Error | Error Code | Description |
| --- | --- | --- |
| SUCCESS | 0 | ์ฑ๊ณต |
| ADAPTER_NOT_FOUND | 1 | ์ด๋ํฐ๋ฅผ ์ฐพ์ ์ ์์ต๋๋ค. ์ด๋ํฐ๋ฅผ ์ค์ ํ์ญ์์ค. |
| NOT_LOGGED_IN | 2 | ๋ก๊ทธ์ธ์ด ๋์ด ์์ง ์์ต๋๋ค. ๋ก๊ทธ์ธ ํ์ ํด๋น API๋ฅผ ํธ์ถํ์ญ์์ค. |
| USER_CANCELED | 3 | ์ ์ ๊ฐ ์ทจ์ํ์์ต๋๋ค. |
| EXTERNAL_LIBRARY_ERROR | 4 | ์ธ๋ถ ๋ผ์ด๋ธ๋ฌ๋ฆฌ ์ค๋ฅ์๋๋ค. |