# Release notes

๐ [English](ReleaseNotes.en.md)

## 1.7.0

### Date

* 2022.05.27

### Added

* SafeBrowsing ์ง์
  * Android Chrome CustomTabsIntent
  * iOS SFSafariViewController

* WebView Show API callback ์์ 
  * ๊ฐ๋ณ callback ์ง์ deprecated
  * CallbackType์ ๋ฐ๋ผ WebView ์ด๋ฒคํธ ์ฒ๋ฆฌ

* auto rotation ๋ณ์ ์ถ๊ฐ
  * WebView configuration ๋ณ์ : isAutoRotation
  * iOS only
  * Screen.orientation์ ์๋ ์ค์ ํ์ง ์์ ๋๋ง true๋ก ์ง์ 

### Updated

* Deprecated API

```cs
[System.Obsolete("This method is deprecated.")]
public static void ShowUrl(
    string url,
    GpmWebViewRequest.Configuration configuration,
    GpmWebViewCallback.GpmWebViewErrorDelegate openCallback,
    GpmWebViewCallback.GpmWebViewErrorDelegate closeCallback,
    List<string> schemeList,
    GpmWebViewCallback.GpmWebViewDelegate<string> schemeEvent)

[System.Obsolete("This method is deprecated.")]
public static void ShowUrl(
    string url,
    GpmWebViewRequest.Configuration configuration,
    GpmWebViewCallback.GpmWebViewErrorDelegate openCallback = null,
    GpmWebViewCallback.GpmWebViewErrorDelegate closeCallback = null,
    GpmWebViewCallback.GpmWebViewPageLoadDelegate pageLoadCallback = null,
    List<string> schemeList = null,
    GpmWebViewCallback.GpmWebViewDelegate<string> schemeEvent = null)

[System.Obsolete("This method is deprecated.")]
public static void ShowHtmlFile(
    string filePath,
    GpmWebViewRequest.Configuration configuration,
    GpmWebViewCallback.GpmWebViewErrorDelegate openCallback,
    GpmWebViewCallback.GpmWebViewErrorDelegate closeCallback,
    List<string> schemeList,
    GpmWebViewCallback.GpmWebViewDelegate<string> schemeEvent)

[System.Obsolete("This method is deprecated.")]
public static void ShowHtmlFile(
    string filePath,
    GpmWebViewRequest.Configuration configuration,
    GpmWebViewCallback.GpmWebViewErrorDelegate openCallback = null,
    GpmWebViewCallback.GpmWebViewErrorDelegate closeCallback = null,
    GpmWebViewCallback.GpmWebViewPageLoadDelegate pageLoadCallback = null,
    List<string> schemeList = null,
    GpmWebViewCallback.GpmWebViewDelegate<string> schemeEvent = null)

[System.Obsolete("This method is deprecated.")]
public static void ShowHtmlString(
    string htmlString,
    GpmWebViewRequest.Configuration configuration,
    GpmWebViewCallback.GpmWebViewErrorDelegate openCallback = null,
    GpmWebViewCallback.GpmWebViewErrorDelegate closeCallback = null,
    List<string> schemeList = null,
    GpmWebViewCallback.GpmWebViewDelegate<string> schemeEvent = null,
    GpmWebViewCallback.GpmWebViewPageLoadDelegate pageLoadCallback = null)
```

## 1.6.0

### Date

* 2022.05.16

### Added

* File upload ์ง์
  * Android API 21 ์ด์

* Custom user agent string ์ถ๊ฐ
  * WebView configuration ๋ณ์ : userAgentString

* Multiple windows ์ง์ (WebView์ ์์ฐฝ ์ง์)
  * WebView configuration ๋ณ์ : supportMultipleWindows

* WebView API ์ถ๊ฐ
  * getX
  * getY
  * getWidth
  * getHeight

## 1.5.1

### Date

* 2022.05.11

### Fixed

* iOS WebView custom scheme callback

## 1.5.0

### Date

* 2022.04.20

### Updated

* WebView configuration
  * isNavigationBarVisible
    * iOS Popup WebView close button ํ์ฑํ/๋นํ์ฑํ

* Sample.scene, SampleWebView.cs
  * API์ configuration์ผ๋ก Popup WebView๋ฅผ ์ฌ์ฉํ๋ ๋ฐฉ๋ฒ

### Added

* WebView API ์ถ๊ฐ
  * SetPosition
  * SetSize
  * SetMargins
  * IsActive

* WebView configuration ๋ณ์ ์ถ๊ฐ
  * position
  * size
  * margins
  * isMaskViewVisible
    * Popup WebView ๋ฐฐ๊ฒฝ mask view ํ์ฑํ/๋นํ์ฑํ (iOS only)

## 1.4.1

### Date

* 2022.03.11

### Fixed

* SamepleWebView.cs ํ์ผ์ ์ผ๊ด์ฑ ์๋ line ending ์์ 

#### iOS

* ํ๊ธ์ด ํฌํจ๋ URL ์ธ์ฝ๋ฉ ์ค๋ฅ ์์  ([#186](https://github.com/nhn/gpm.unity/issues/186))

## 1.4.0

### Date

* 2022.03.04

### Added

* WebView API ์ถ๊ฐ
  * CanGoBack
  * CanGoForward
  * GoBack
  * GoForward
* WebView Sample scene ์ถ๊ฐ ([#105](https://github.com/nhn/gpm.unity/issues/105))

### Updated

* WebView API ์์ 
  * ShowUrl, ShowHtmlFile, ShowHtmlString์ OnPageLoadCallback ๋งค๊ฐ๋ณ์ ์ถ๊ฐ ([#71](https://github.com/nhn/gpm.unity/issues/71))

---

## 1.3.2

### Date

* 2021.11.29

### Fixed
#### iOS
* ์ผ๋ถ ์นํ์ด์ง์์ ๋งํฌ๋ ํ์ด์ง๋ก ์ด๋ํ๋ ค๊ณ  ํ  ๋ ์ด์ ์ ํ์ด์ง๊ฐ ๋ค์ ๋ก๋๋๋ ๋ฌธ์  ์์ 

### Updated

* Unity Editor์์ ๋์ํ์ง ์๋ WebView API๋ฅผ ํธ์ถํ๋ฉด warning log๊ฐ ๋ฐ์ํ๋๋ก ์์ 

---

## 1.3.1

### Date

* 2021.08.12

### Fixed

* Assembly definitions์ Exclude Platforms ์์ฑ์์ Lumin์ ๋นํ์ฑํ
* Configuration.navigationBarColor์ ๊ธฐ๋ณธ ๊ฐ ์ถ๊ฐ

---

## 1.3.0

### Date

* 2021.07.31

### Added

* Configuration
    * navigationBarColor
    * supportMultipleWindows (Android only)
* Assembly definition

---

## 1.2.0

### Date

* 2021.03.12

### Added

* Configuration
    * isNavigationBarVisible
    * isClearCookie
    * isClearCache

---

## 1.1.0

### Date

* 2021.02.23

### Added

* Configuration
    * Popup Style
    * Forward Button
* API
    * ShowHtmlFile
    * ShowHtmlString
    * ExecuteJavaScript

### Updated

* Configuration
    * Orientation ์ ๊ฑฐ

---

## 1.0.0

### Date

* 2020.12.24

### Features

* Platform 
    * Android
    * iOS

* API
    * ShowUrl
    * Close
