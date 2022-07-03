# Release notes

🌏 [English](ReleaseNotes.en.md)

## 1.7.0

### Date

* 2022.05.27

### Added

* SafeBrowsing 지원
  * Android Chrome CustomTabsIntent
  * iOS SFSafariViewController

* WebView Show API callback 수정
  * 개별 callback 지원 deprecated
  * CallbackType에 따라 WebView 이벤트 처리

* auto rotation 변수 추가
  * WebView configuration 변수 : isAutoRotation
  * iOS only
  * Screen.orientation을 수동 설정하지 않을 때만 true로 지정

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

* File upload 지원
  * Android API 21 이상

* Custom user agent string 추가
  * WebView configuration 변수 : userAgentString

* Multiple windows 지원 (WebView의 새창 지원)
  * WebView configuration 변수 : supportMultipleWindows

* WebView API 추가
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
    * iOS Popup WebView close button 활성화/비활성화

* Sample.scene, SampleWebView.cs
  * API와 configuration으로 Popup WebView를 사용하는 방법

### Added

* WebView API 추가
  * SetPosition
  * SetSize
  * SetMargins
  * IsActive

* WebView configuration 변수 추가
  * position
  * size
  * margins
  * isMaskViewVisible
    * Popup WebView 배경 mask view 활성화/비활성화 (iOS only)

## 1.4.1

### Date

* 2022.03.11

### Fixed

* SamepleWebView.cs 파일의 일관성 없는 line ending 수정

#### iOS

* 한글이 포함된 URL 인코딩 오류 수정 ([#186](https://github.com/nhn/gpm.unity/issues/186))

## 1.4.0

### Date

* 2022.03.04

### Added

* WebView API 추가
  * CanGoBack
  * CanGoForward
  * GoBack
  * GoForward
* WebView Sample scene 추가 ([#105](https://github.com/nhn/gpm.unity/issues/105))

### Updated

* WebView API 수정
  * ShowUrl, ShowHtmlFile, ShowHtmlString에 OnPageLoadCallback 매개변수 추가 ([#71](https://github.com/nhn/gpm.unity/issues/71))

---

## 1.3.2

### Date

* 2021.11.29

### Fixed
#### iOS
* 일부 웹페이지에서 링크된 페이지로 이동하려고 할 때 이전의 페이지가 다시 로드되는 문제 수정

### Updated

* Unity Editor에서 동작하지 않는 WebView API를 호출하면 warning log가 발생하도록 수정

---

## 1.3.1

### Date

* 2021.08.12

### Fixed

* Assembly definitions의 Exclude Platforms 속성에서 Lumin을 비활성화
* Configuration.navigationBarColor의 기본 값 추가

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
    * Orientation 제거

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
