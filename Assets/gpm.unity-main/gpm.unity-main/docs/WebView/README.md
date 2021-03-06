# WebView

π [English](README.en.md)

## π© λͺ©μ°¨

* [κ°μ](#κ°μ)
* [μ€ν](#μ€ν)
* [νλ«νΌλ³ μ€μ ](#-νλ«νΌλ³-μ€μ )
* [API](#-api)
* [Release notes](./ReleaseNotes.md)


## κ°μ

κ²μμμ λ€μνκ² μ¬μ©ν  μ μλ μΉλ·°λ₯Ό μ κ³΅ν©λλ€.

## μ€ν

### Unity μ§μ λ²μ 

* 2018.4.0 μ΄μ

### Android μ§μ λ²μ 

* 4.4 μ΄μ

### iOS μ§μλ²μ 

* 11 μ΄μ

### μ§μ νλ«νΌ

* Android
* iOS 

### μ§μνλ κΈ°λ₯

| Category | Spec |
| --- | --- |
| Style | Popup |
|   | Fullscreen |
| Navigation | Visibility |
|   | Color |
|   | Title |
|   | Back |
|   | Forward |
|   | Close |
| Show API | URL, HTML file, HTML string |
|   | Callback |
|   | Scheme List |
| Position, Size API | SetPosition, GetX, GetY |
|   | SetSize, GetWidth, GetHeight |
|   | SetMargins |
| Show SafeBrowsing | |
|   | Callback |
| Other | IsActive |
|   | Execute JavaScript |
|   | Clear Cookies |
|   | Clear Cache |
|   | Can Go Back |
|   | Can Go Forward |
|   | Go Back |
|   | Go Forward |
|   | Multiple Windows |
|   | File upload</br>(Android API 21 μ΄μ) |
|   | User agent string |
|   | Set auto rotation |

## π¨ νλ«νΌλ³ μ€μ 

###  Android

[Gradle](https://docs.unity3d.com/Manual/android-gradle-overview.html)μ μ¬μ©νμ¬ Androidμμ νμν μ’μμ±μ μ€μ ν©λλ€.
Unity 2019.3 μ΄μ  λ²μ μ νλ‘μ νΈμμλ **Internal** λΉλ μ€μ μ΄ μλ **Gradle**λ‘ μ νν΄μΌ ν©λλ€.

#### hardwareAccelerated μ€μ 

μνν WebView μ¬μ©μ μν΄ PostProcessBuild μ€ν¬λ¦½νΈμμ **hardwareAccelerated**λ₯Ό νμ±ννκ³  μμ΅λλ€.

#### Gradle μ€μ 

1.  **File > Build Settings > Player Settings > Android > Publishing Settings**μμ **Custom Gradle Template**μ νμ±ννλ©΄ `Assets/Plugins/Android/mainTemplate.gradle` νμΌμ΄ μμ±λ©λλ€.
    * ![unity_gradle.png](images/unity_gradle.png)
    * μ¬μ© μ€μΈ mainTemplate.gradle νμΌμ΄ μμ λλ μλ΅ν  μ μμ΅λλ€.
2.  mainTemplate.gradleμ μ£Όμ λΌμΈμ μ κ±°ν©λλ€.
    ```gradle
    // GENERATED BY UNITY. REMOVE THIS COMMENT TO PREVENT OVERWRITING WHEN EXPORTING AGAIN
    ```
3.  mainTemplate.gradleμμ dependenciesλ₯Ό μΆκ°ν©λλ€.
    ```gradle
    dependencies {
        implementation 'org.jetbrains.kotlin:kotlin-stdlib-jdk7:1.3.72'
        
        // ShowSafeBrowsing APIλ₯Ό μ¬μ©ν  κ²½μ° μΆκ°
        implementation "androidx.browser:browser:1.3.0"
    }
    ```
    * λ€λ₯Έ ν¨ν€μ§μμ μ΄λ―Έ μΆκ°ν κ²½μ° ν΄λΉ κ³Όμ μ μ μΈν  μ μμ΅λλ€.

### iOS

#### Other Linker Flags μ€μ 

Xcode Target(Unity-iPhone)μμ **Build Settings > Linking > Other Linker Flags**μ -ObjCλ₯Ό μΆκ°ν΄μΌ ν©λλ€.

#### GPMWebView.bundle

Unity νΉμ  λ²μ μμ iOS λΉλ μ, **λ΄λΉκ²μ΄μ λ°**μ λ²νΌμ΄ λ³΄μ΄μ§ μλ νμμ΄ λ°μν  μ μμ΅λλ€.
ν΄λΉ νμμ΄ λ°μνλ©΄, Xcode Target(Unity-iPhone)μ **Xcode Project > Build Phases > Copy Bundle Resource** μ€μ μμ + λ²νΌμ λλ¬ `GPMWebView.bundle` νμΌ κ²μνμ¬ μΆκ°νμ­μμ€.

![GPMWebViewBundle.png](images/GPMWebViewBundle.png)

## π¨ API

### ShowUrl

WebViewλ₯Ό νμν©λλ€.

**Required νλΌλ―Έν°**

* url : νλΌλ―Έν°λ‘ μ μ‘λλ urlμ μ ν¨ν κ°μ΄μ΄μΌ ν©λλ€.
* configuration : GpmWebViewRequest.ConfigurationμΌλ‘ WebViewμ μ΅μμ λ³κ²½ν  μ μμ΅λλ€.

**Optional νλΌλ―Έν°**

* callback : WebViewμμ λ°μνλ μ½λ°±μ μ λ¬λ°μ΅λλ€.
* schemeList : μ¬μ©μκ° λ°κ³  μΆμ μ»€μ€ν μ€ν΄(scheme) λͺ©λ‘μ μ§μ ν©λλ€.
    * 'https://'λ₯Ό μλ ₯νλ©΄ 'https://'λ‘ μμνλ λͺ¨λ  urlμ schemeEventλ‘ λ°μ μ μμ΅λλ€.
    * schemeEventλ‘ λ°μ schemeμ redirect λμ§ μμ΅λλ€.

#### Configuration

| Parameter | Values | Description |
| ------------------------- | ----------------------------------------- | -------------------------------- |
| style                     | GpmWebViewStyle.POPUP                     | νμ λͺ¨λ |
|                           | GpmWebViewStyle.FULLSCREEN                | μ μ²΄ νλ©΄ λͺ¨λ |
| isClearCookie             | bool                                      | μΏ ν€ μ κ±° |
| isClearCache              | bool                                      | μΊμ μ κ±° |
| isNavigationBarVisible    | bool                                      | λ€λΉκ²μ΄μ λ° νμ± λλ λΉνμ± |
|                           |                                           | Popup WebView Close λ²νΌ νμ± λλ λΉνμ± (iOS only) |
| navigationBarColor        | string                                    | λ€λΉκ²μ΄μ λ° μμ |
| title                     | string                                    | WebViewμ μ λͺ© |
| orientation               | UnityEngine.ScreenOrientation             | GPM WebView v1.1.0μμ μ κ±°λμμ΅λλ€. |
| isBackButtonVisible       | bool                                      | λ€λ‘ κ°κΈ° λ²νΌ νμ± λλ λΉνμ±  |
| isForwardButtonVisible    | bool                                      | μμΌλ‘ κ°κΈ° λ²νΌ νμ± λλ λΉνμ± |
| supportMultipleWindows    | bool                                      | GPM WebViewμ λ€μ€ μ°½ μ§μ μ¬λΆ |
| userAgentString           | string                                    | GPM WebViewμ userAgentString μ€μ  |
| position                  | GpmWebViewRequest.Position                | Popup WebView μμΉ μ§μ  |
| size                      | GpmWebViewRequest.Size                    | Popup WebView ν¬κΈ° μ§μ  |
| margins                   | GpmWebViewRequest.Margins                 | Popup WebView μ¬λ°± μ§μ  |
| isMaskViewVisible</br>(iOS only) | bool                               | Popup WebView λ°°κ²½ νμ± λλ λΉνμ± |
| contentMode</br>(iOS only)| GamebaseWebViewContentMode.RECOMMENDED    | νμ¬ νλ«νΌ μΆμ² λΈλΌμ°μ  |
|                           | GamebaseWebViewContentMode.MOBILE         | λͺ¨λ°μΌ λΈλΌμ°μ  |
|                           | GamebaseWebViewContentMode.DESKTOP        | λ°μ€ν¬ν λΈλΌμ°μ  |
| isAutoRotation</br>(iOS only) | bool                                  | WebView νμ  μ€μ </br>Screen.orientationμ μλ μ€μ νμ§ μμ λλ§ trueλ₯Ό μ§μ ν©λλ€. |

**API**

```cs
public static void ShowUrl(
    string url,
    GpmWebViewRequest.Configuration configuration,
    GpmWebViewCallback.GpmWebViewDelegate callback,
    List<string> schemeList)
```

**Example**

```cs
// FullScreen
public void ShowUrlFullScreen()
{
    GpmWebView.ShowUrl(
        "https://google.com/",
        new GpmWebViewRequest.Configuration()
        {
            style = GpmWebViewStyle.FULLSCREEN,
            isClearCookie = true,
            isClearCache = true,
            isNavigationBarVisible = true,
            navigationBarColor = "#4B96E6",
            title = "The page title.",
            isBackButtonVisible = true,
            isForwardButtonVisible = true,
            supportMultipleWindows = true,
#if UNITY_IOS
            contentMode = GpmWebViewContentMode.MOBILE
#endif
        },
        OnCallback,
        new List<string>()
        {
            "USER_ CUSTOM_SCHEME"
        });
}

// Popup default
public void ShowUrlPopupDefault()
{
    GpmWebView.ShowUrl(
        "https://google.com/",
        new GpmWebViewRequest.Configuration()
        {
            style = GpmWebViewStyle.POPUP,
            isClearCookie = true,
            isClearCache = true,
            isNavigationBarVisible = false,
            supportMultipleWindows = true,
#if UNITY_IOS
            contentMode = GpmWebViewContentMode.MOBILE
            isMaskViewVisible = true,
#endif
        },
        OnCallback,
        new List<string>()
        {
            "USER_ CUSTOM_SCHEME"
        });
}

// Popup custom position and size
public void ShowUrlPopupPositionSize()
{
    GpmWebView.ShowUrl(
        "https://google.com/",
        new GpmWebViewRequest.Configuration()
        {
            style = GpmWebViewStyle.POPUP,
            isClearCookie = true,
            isClearCache = true,
            isNavigationBarVisible = false,
            position = new GpmWebViewRequest.Position
            {
                hasValue = true,
                x = (int)(Screen.width * 0.1f),
                y = (int)(Screen.height * 0.1f)
            },
            size = new GpmWebViewRequest.Size
            {
                hasValue = true,
                width = (int)(Screen.width * 0.8f),
                height = (int)(Screen.height * 0.8f)
            },
            supportMultipleWindows = true,
#if UNITY_IOS
            contentMode = GpmWebViewContentMode.MOBILE
            isMaskViewVisible = true,
#endif
        }, null, null);
}

// Popup custom margins
public void ShowUrlPopupMargins()
{
    GpmWebView.ShowUrl(
        "https://google.com/",
        new GpmWebViewRequest.Configuration()
        {
            style = GpmWebViewStyle.POPUP,
            isClearCookie = true,
            isClearCache = true,
            isNavigationBarVisible = false,
            margins = new GpmWebViewRequest.Margins
            {
                hasValue = true,
                left = (int)(Screen.width * 0.1f),
                top = (int)(Screen.height * 0.1f),
                right = (int)(Screen.width * 0.1f),
                bottom = (int)(Screen.height * 0.1f)
            },
            supportMultipleWindows = true,
#if UNITY_IOS
            contentMode = GpmWebViewContentMode.MOBILE
            isMaskViewVisible = true,
#endif
        }, null, null);
}

private void OnCallback(
    GpmWebViewCallback.CallbackType callbackType,
    string data,
    GpmWebViewError error)
{
    Debug.Log("OnCallback: " + callbackType);
    switch (callbackType)
    {
        case GpmWebViewCallback.CallbackType.Open:
            if (error != null)
            {
                Debug.LogFormat("Fail to open WebView. Error:{0}", error);
            }
            break;
        case GpmWebViewCallback.CallbackType.Close:
            if (error != null)
            {
                Debug.LogFormat("Fail to close WebView. Error:{0}", error);
            }
            break;
        case GpmWebViewCallback.CallbackType.PageLoad:
            if (string.IsNullOrEmpty(data) == false)
            {
                Debug.LogFormat("Loaded Page:{0}", data);
            }
            break;
        case GpmWebViewCallback.CallbackType.MultiWindowOpen:
            break;
        case GpmWebViewCallback.CallbackType.MultiWindowClose:
            break;
        case GpmWebViewCallback.CallbackType.Scheme:
            if (error == null)
            {
                if (data.Equals("USER_ CUSTOM_SCHEME") == true || data.Contains("CUSTOM_SCHEME") == true)
                {
                    Debug.Log(string.Format("scheme:{0}", data));
                }
            }
            else
            {
                Debug.Log(string.Format("Fail to custom scheme. Error:{0}", error));
            }
            break;
    }
}
```

### ShowHtmlFile

**Assets > StreamingAssets** ν΄λμ μλ HTML νμΌμ μΉλ·°μ λΆλ¬μ΅λλ€.

![StreamingAssets.png](images/StreamingAssets.png)

ShowHtmlFile APIμ filePath κ°μ μλ μ½λλ₯Ό μ°Έκ³ νμ¬ μλ ₯νμ­μμ€.

```cs
#if UNITY_IOS
    // "file://" + Application.streamingAssetsPath + "/" + "YOUR_HTML_PATH.html"
    string.Format("file://{0}/{1}", Application.streamingAssetsPath, "YOUR_HTML_PATH.html");
#elif UNITY_ANDROID
    // "file:///android_asset/" + "YOUR_HTML_PATH.html"
    string.Format("file:///android_asset/{0}", "YOUR_HTML_PATH.html");
#endif
```

**API**

```cs
public static void ShowHtmlFile(
    string filePath,
    GpmWebViewRequest.Configuration configuration,
    GpmWebViewCallback.GpmWebViewDelegate callback,
    List<string> schemeList)
```

**Example**

```cs
public void ShowHtmlFile()
{
    var htmlFilePath = string.Empty;
#if UNITY_IOS
        htmlFilePath = string.Format("file://{0}/{1}", Application.streamingAssetsPath, "YOUR_HTML_PATH.html");
#elif UNITY_ANDROID
        htmlFilePath = string.Format("file:///android_asset/{0}", "YOUR_HTML_PATH.html");
#endif

    GpmWebView.ShowHtmlFile(
        htmlFilePath,
        new GpmWebViewRequest.Configuration()
        {
            style = GpmWebViewStyle.FULLSCREEN,
            isClearCookie = true,
            isClearCache = true,
            isNavigationBarVisible = true,
            navigationBarColor = "#4B96E6",
            title = "The page title.",
            isBackButtonVisible = true,
            isForwardButtonVisible = true,
            supportMultipleWindows = true,
#if UNITY_IOS
            contentMode = GpmWebViewContentMode.MOBILE
#endif
        },
        OnCallback,
        new List<string>()
        {
            "USER_ CUSTOM_SCHEME"
        });
}

```

### ShowHtmlString

μ§μ λ HTML λ¬Έμμ΄μ μΉλ·°μ λΆλ¬μ΅λλ€.

**API**

```cs
public static void ShowHtmlString(
    string htmlString,
    GpmWebViewRequest.Configuration configuration,
    GpmWebViewCallback.GpmWebViewDelegate callback,
    List<string> schemeList)
```

**Example**

```cs
public void ShowHtmlString()
{
    GpmWebView.ShowHtmlString(
        "${HTML_STRING}",
        new GpmWebViewRequest.Configuration()
        {
            style = GpmWebViewStyle.FULLSCREEN,
            isClearCookie = true,
            isClearCache = true,
            isNavigationBarVisible = true,
            navigationBarColor = "#4B96E6",
            title = "The page title.",
            isBackButtonVisible = true,
            isForwardButtonVisible = true,
            supportMultipleWindows = true,
#if UNITY_IOS
            contentMode = GpmWebViewContentMode.MOBILE
#endif
        },
        OnCallback,
        new List<string>()
        {
            "USER_ CUSTOM_SCHEME"
        });
}
```

### ShowSafeBrowsing

Appμμ Android Chrome λλ iOS Safari λΈλΌμ°μ λ₯Ό νμν©λλ€.</br>
π **GpmWebViewSafeBrowsing** classλ₯Ό μ¬μ©ν©λλ€.

**Required νλΌλ―Έν°**

* url : νλΌλ―Έν°λ‘ μ μ‘λλ urlμ μ ν¨ν κ°μ΄μ΄μΌ ν©λλ€.

**Optional νλΌλ―Έν°**

* configuration : GpmWebViewRequest.ConfigurationSafeBrowsingμΌλ‘ NavigationBarμ μμμ λ³κ²½ν  μ μμ΅λλ€.
* callback : λΈλΌμ°μ μ Open, Close μ½λ°±μ μ λ¬λ°μ΅λλ€.

#### Configuration

| Parameter | Values | Description |
| ------------------------- | ----------------------------------------- | -------------------------------- |
| navigationBarColor        | string                                    | λ€λΉκ²μ΄μ λ° μμ |
| navigationTextColor</br>(iOS only) | string                           | λ€λΉκ²μ΄μ νμ€νΈ μμ |

**API**

```cs
public static void ShowSafeBrowsing(
    string url,
    GpmWebViewRequest.ConfigurationSafeBrowsing configuration = null,
    GpmWebViewCallback.GpmWebViewDelegate callback = null)
```

**Example**

```cs
public void OpenSafeBrowsing()
{
    GpmWebViewSafeBrowsing.ShowSafeBrowsing(sampleUrl,
        new GpmWebViewRequest.ConfigurationSafeBrowsing()
        {
            navigationBarColor = "#4B96E6",
            navigationTextColor = "#FFFFFF"
        },
        OnCallback);
}
```

### ExecuteJavaScript

μ§μ λ JavaScript λ¬Έμμ΄μ μ€νν©λλ€.

**API**

```cs
public static void ExecuteJavaScript(string script)
```

**Example**

```cs
public void ExecuteJavaScriptSample()
{
    GpmWebView.ExecuteJavaScript("alert('ExecuteJavaScript');");
}
```

### Close

λ€μ APIλ₯Ό μ΄μ©ν΄ WebViewλ₯Ό λ«μ μ μμ΅λλ€.

**API**

```cs
public static void Close()
```

**Example**

```cs
public void Close()
{
    GpmWebView.Close();
}
```

### IsActive

WebView νμ±ν μ¬λΆλ₯Ό νμΈν©λλ€.

**API**

```cs
public static bool IsActive()
```

**Example**

```cs
public bool Something()
{
    if (GpmWebView.IsActive() == true)
    {
        ...
    }
}
```

### CanGoBack

WebViewμ μ΄μ  λ°©λ¬Έ κΈ°λ‘μ΄ μλμ§ νμΈν©λλ€.

**API**

```cs
public static bool CanGoBack()
```

### CangoForward

WebViewμ λ€μ λ°©λ¬Έ κΈ°λ‘μ΄ μλμ§ νμΈν©λλ€.

```cs
public static bool CanGoForward()
```

### GoBack

WebViewμ μ΄μ  λ°©λ¬Έ κΈ°λ‘μΌλ‘ μ΄λν©λλ€.

**API**

```cs
public static void GoBack()
```

**Example**

```cs
public void GoBack()
{
    GpmWebView.GoBack();
}
```

### GoForward

WebViewμ λ€μ λ°©λ¬Έ κΈ°λ‘μΌλ‘ μ΄λν©λλ€.

**API**

```cs
public static void GoForward()
```

**Example**

```cs
public void GoForward()
{
    GpmWebView.GoForward();
}
```

### SetPosition

Popup WebViewμ μμΉλ₯Ό μ‘°μ ν©λλ€.

**API**

```cs
public static void SetPosition(int x, int y)
```

**Example**

```cs
public IEnumerator SetPosition()
{
    while (true)
    {
        if (GpmWebView.IsActive() == true)
        {
            break;
        }
        yield return new WaitForEndOfFrame();
    }

    GpmWebView.SetPosition((int)(Screen.width * 0.1f), (int)(Screen.height * 0.1f));
}
```

### SetSize

Popup WebViewμ ν¬κΈ°λ₯Ό μ‘°μ ν©λλ€.

**API**

```cs
public static void SetSize(int width, int height)
```

**Example**

```cs
public IEnumerator SetSize()
{
    while (true)
    {
        if (GpmWebView.IsActive() == true)
        {
            break;
        }
        yield return new WaitForEndOfFrame();
    }

    GpmWebView.SetSize((int)(Screen.width * 0.8f), (int)(Screen.height * 0.8f));
}
```

### SetMargins

Popup WebViewμ μ¬λ°±μ μ‘°μ ν©λλ€.

**API**

```cs
public static void SetMargins(int left, int top, int right, int bottom)
```

**Example**

```cs
public IEnumerator SetMargins()
{
    while (true)
    {
        if (GpmWebView.IsActive() == true)
        {
            break;
        }
        yield return new WaitForEndOfFrame();
    }

    GpmWebView.SetMargins((int)(Screen.width * 0.1f), (int)(Screen.height * 0.1f), (int)(Screen.width * 0.1f), (int)(Screen.height * 0.1f));
}
```

### GetX, GetY

WebViewμ μμΉλ₯Ό λ°νν©λλ€.

**API**

```cs
public static int GetX()
public static int GetY()
```

**Example**

```cs
public void Something()
{
    if (GpmWebView.IsActive() == true)
    {
        int x = GpmWebView.GetX();
        int y = GpmWebView.GetY();
        ...
    }
}
```

### GetWidth, GetHeight

WebViewμ ν¬κΈ°λ₯Ό λ°νν©λλ€.

**API**

```cs
public static int GetWidth()
public static int GetHeight()
```

**Example**

```cs
public void Something()
{
    if (GpmWebView.IsActive() == true)
    {
        int width = GpmWebView.GetWidth();
        int height = GpmWebView.GetHeight();
        ...
    }
}
```
