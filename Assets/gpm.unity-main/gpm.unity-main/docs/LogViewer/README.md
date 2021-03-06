# LogViewer

๐ [English](README.en.md)

## ๐ฉ ๋ชฉ์ฐจ

* [๊ฐ์](#๊ฐ์)
* [์คํ](#์คํ)
* [๊ธฐ๋ฅ ์ค๋ช](#๊ธฐ๋ฅ-์ค๋ช)
* [์ฌ์ฉ๋ฐฉ๋ฒ](#-์ฌ์ฉ๋ฐฉ๋ฒ)
* [Release notes](./ReleaseNotes.md)

## ๊ฐ์

* LogViewer๋ Unity Log์ ๋๋ฐ์ด์ค ์์คํ ์ ๋ณด๋ฅผ ํ๋ฉด์์ ํ์ธํ  ์ ์๊ณ , ๊ฐ๋ฐ์๊ฐ ๋ฏธ๋ฆฌ ๋ฑ๋กํ API๋ฅผ ํธ์ถํด ๋ณผ ์ ์๋ ํด์๋๋ค.

## ์คํ

### Unity ์ง์ ๋ฒ์ 

* 2018.4.0 ์ด์

## ๊ธฐ๋ฅ ์ค๋ช

### Console

* Unity Log๋ฅผ ํ๋ฉด์ ๋ณด์ฌ์ค๋๋ค.
* ์นดํ๊ณ ๋ฆฌ์ ํํฐ ๊ธฐ๋ฅ์ ์ ๊ณตํ์ฌ ์ํ๋ ๋ก๊ทธ๋ง ์ ํํ์ฌ ๋ณผ ์ ์์ต๋๋ค.
* ์ํ๋ ๋ก๊ทธ ํ์์ ์ผ๊ฑฐ๋ ๋ ์ ์์ต๋๋ค.
* ๋ก๊ทธ๋ฅผ ์ด๋ฉ์ผ๋ก ์ ์กํ  ์ ์์ต๋๋ค.

![console](./images/console.png)

1. ๋ฉ๋ด
    * Category
    * Filter
        * Search
            *  ์๋ ฅํ ๋จ์ด๋ฅผ ํฌํจํ ๋ก๊ทธ๋ง ์ถ๋ ฅํฉ๋๋ค.
        * Ignore Case
            * ์ฒดํฌ : ๋์๋ฌธ์๋ฅผ ๊ตฌ๋ถํฉ๋๋ค.
            * ์ฒดํฌ ํด์  : ๋์๋ฌธ์๋ฅผ ๊ตฌ๋ถํ์ง ์์ต๋๋ค.
    * Play Time
        * ์ฑ ์์ ํ ๋ก๊ทธ๊ฐ ๋ฐ์ํ์ ๋๊น์ง ๊ฒฝ๊ณผํ ์๊ฐ์ ๋ณด์ฌ์ค์ง ์ค์ ํฉ๋๋ค.
        * ์ด ๋จ์๋ก ํ์ํฉ๋๋ค.
    * Scene
        * ๋ก๊ทธ๊ฐ ๋ฐ์ํ์ ๋ ์ฌ์ ์ค์ธ Scene ์ด๋ฆ์ ๋ณด์ฌ์ค์ง ์ค์ ํฉ๋๋ค.
    * Send Mail
        * ์ ์ฒด ๋ก๊ทธ๋ฅผ ์ค์ ํ ์ด๋ฉ์ผ๋ก ์ ์กํฉ๋๋ค.
    * Clear
        * ์ ์ฒด ๋ก๊ทธ๋ฅผ ์ญ์ ํฉ๋๋ค.

2. ๋ก๊ทธ ํ์
    * ![logtype_info](./images/logtype_info.png)
        * LogType.Log ํ์์ ๋ก๊ทธ ์๋ฅผ ํ์ธํ  ์ ์์ต๋๋ค.
    * ![logtype_warning](./images/logtype_warning.png)
        * LogType.Warning ํ์์ ๋ก๊ทธ ์๋ฅผ ํ์ธํ  ์ ์์ต๋๋ค.
    * ![logtype_error](./images/logtype_error.png)
        * LogType.Assert, LogType.Error, LogType.Exception ํ์์ ๋ก๊ทธ ์๋ฅผ ํ์ธํ  ์ ์์ต๋๋ค.
    * ๊ฐ ๋ก๊ทธ ํ์์ ํด๋ฆญํ๋ฉด ํด๋น ๋ก๊ทธ ํ์์ ์ผ๊ฑฐ๋ ๋ ์ ์์ต๋๋ค.

3. ๋ก๊ทธ ๋ทฐ
    * ๋ก๊ทธ ๋ชฉ๋ก์ ํ์ธํ  ์ ์์ต๋๋ค.

4. ๋ก๊ทธ ์์ธ
    *  ๋ก๊ทธ ๋ทฐ์์ ์ ํํ ๋ก๊ทธ์ ์์ธ์ ๋ณด๋ฅผ ํ์ธํ  ์ ์์ต๋๋ค.


### Function

* ๊ฐ๋ฐ์๊ฐ ์ถ๊ฐํ API๋ฅผ LogViewer์์ ํธ์ถํ  ์ ์์ต๋๋ค.

![function](./images/function.png)

1. Cheat Key          
    * AddCheatKeyCallback API๋ฅผ ํตํด ๋ฑ๋กํ ์ฝ๋ฐฑ์ผ๋ก ์๋ ฅํ ๋ฌธ์์ด์ ์ ๋ฌํฉ๋๋ค.
2. Command
    * AddCommand API๋ฅผ ํตํด ๋ฑ๋กํ API๋ฅผ ํธ์ถํฉ๋๋ค.

#### System

* ์์คํ ์ ๋ณด๋ฅผ ํ์ธํ  ์ ์์ต๋๋ค.

![system](./images/system.png)

* ๊ฐฑ์  ๋ฒํผ
    * ์์คํ ์ ๋ณด๋ฅผ ๊ฐฑ์ ํฉ๋๋ค.


## ๐จ ์ฌ์ฉ๋ฐฉ๋ฒ

### ์ฌ์ฉ ์ค๋นํ๊ธฐ

* GpmLogViewer GameObject ์ค์     
    * GPM/LogViewer/Prefabs/GpmLogViewer.prefab ํ์ผ์ Scene์ ์ถ๊ฐํฉ๋๋ค.
    *  Inspector ์ค์ </br>
    ![inspector](./images/inspector.png)
        * Gesture Enable ์ค์ 
            * LogView๋ฅผ  ํ์ฑํํ๋ ์ ์ค์ฒ๋ฅผ ์ผ๊ฑฐ๋ ๋ ์ ์์ต๋๋ค.
        * ์ด๋ฉ์ผ ์ค์ 
            * To: ๋ฐ๋ ์ฌ๋ ์ด๋ฉ์ผ ์ฃผ์
            * User Name: ๋ณด๋ด๋ ์ฌ๋ ์ด๋ฉ์ผ ์ฃผ์
            * User Password: ๋ณด๋ด๋ ์ฌ๋ ์ด๋ฉ์ผ ์ํธ
            * Smtp Host: SMTP ํธ์คํธ
            * Smtp Port: SMTP ํฌํธ
            * Cc: ์ฐธ์กฐ์ ์ถ๊ฐํ  ์ด๋ฉ์ผ ์ฃผ์            

#### ์ด๋ฉ์ผ ์ค์  ์ ์ ์ ์ฌํญ

* Platform ๊ณตํต
    * Api Compatibilty Level์ .NET 2.0 ์ด์ ๋๋ .NET Standard 2.0 ์ด์์ผ๋ก ๋ณ๊ฒฝํฉ๋๋ค.
* iOS
    * IL2CPP๋ก ๋น๋ ํ  ๊ฒฝ์ฐ Assets ํด๋์ `link.xml`ํ์ผ ์์ฑ ํ ์๋ ๋ด์ฉ์ ์ถ๊ฐํฉ๋๋ค.
        ```xml
        <linker>
            <assembly fullname="System">
                <type fullname="System.Net.Configuration.MailSettingsSectionGroup" preserve="all"/>
                <type fullname="System.Net.Configuration.SmtpSection" preserve="all"/>
                <type fullname="System.Net.Configuration.SmtpNetworkElement" preserve="all"/>
                <type fullname="System.Net.Configuration.SmtpSpecifiedPickupDirectoryElement" preserve="all"/>
            </assembly>
        </linker>
        ```

* gmail๋ก ์ค์ ํ๊ธฐ
    * gmail์ [์ฑ ๋น๋ฐ๋ฒํธ](https://support.google.com/accounts/answer/185833)๋ฅผ ์ฌ์ฉํ์ฌ ์ค์ ํ์ฌ์ผ ํฉ๋๋ค.
    * <b>๋ณด์ ์์ค์ด ๋ฎ์ ์ฑ ํ์ฉ</b>์ 2022.5.31์ผ ์ดํ๋ก ์ฌ์ฉํ  ์ ์์ต๋๋ค.
        * To : ๋ฐ๋ ์ด๋ฉ์ผ ์ฃผ์
        * User Name : ๋ณด๋ด๋ ์ด๋ฉ์ผ ์ฃผ์
        * User Password : ๋ณด๋ด๋ ์ด๋ฉ์ผ ์ฃผ์์ [์ฑ ๋น๋ฐ๋ฒํธ](https://support.google.com/accounts/answer/185833)
        * Smtp Host : smtp.gmail.com
        * Smtp Port : 587

#### gmail ์ฑ ๋น๋ฐ๋ฒํธ ์ค์ 
1. ๊ตฌ๊ธ ๊ณ์ ์์ ๋ณด์ ํญ์ ์ ํํฉ๋๋ค.

![google_app_password_1_kr](./images/google_app_password_1_kr.png)

2. ๋ณด์ ํญ ๋ด์ Google์ ๋ก๊ทธ์ธ์์ ์ฑ ๋น๋ฐ๋ฒํธ๋ฅผ ์ ํํฉ๋๋ค.
    * ์ฑ ๋น๋ฐ๋ฒํธ ์ค์ ์ ์ํด์  2๋จ๊ณ ์ธ์ฆ์ด ํ์ฑํ๋ผ์ผ ํฉ๋๋ค.

![google_app_password_2_kr](./images/google_app_password_2_kr.png)

3. ์ฑ ๋น๋ฐ๋ฒํธ์์ ์ฑ ์ ํ์ ๋๋ฆ๋๋ค.

![google_app_password_3_kr](./images/google_app_password_3_kr.png)

4. ์ฑ ์ ํ ์์ญ์์ ๊ธฐํ(๋ง์ถค ์ด๋ฆ)์ ๋๋ฆ๋๋ค.

![google_app_password_4_kr](./images/google_app_password_4_kr.png)

5. ์ด๋ฆ์ <b>Smtp Client</b>๋ฅผ ๋ฃ์ด ์์ฑํฉ๋๋ค.

![google_app_password_5_kr](./images/google_app_password_5_kr.png)

6. User Password์ ๊ธฐ๊ธฐ์ฉ ์ฑ ๋น๋ฐ๋ฒํธ๋ฅผ ์ฌ์ฉํฉ๋๋ค.

![google_app_password_6_kr](./images/google_app_password_6_kr.png)

### ๋ฐํ์์์  LogViewer ํ์ฑํํ๊ธฐ

* ํ๋ซํผ๋ณ ํ์ฑํ ๋ฐฉ๋ฒ
    * ํ๋ซํผ ๊ณตํต
        * BackQuote Key๋ก ํ์ฑํํฉ๋๋ค.</br>
            ![backquote](./images/backquote.png)
    * iOS/Android ํ๋ซํผ์ ์ ์ค์ฒ๋ก ํ์ฑํํฉ๋๋ค.
        * ์๊ฐ๋ฝ ๋ค์ฏ๊ฐ๋ก 1์ด๊ฐ ํ๋ฉด์ ํฐ์นํฉ๋๋ค.

*  ๋ค์ ํ์์ ๋ก๊ทธ๊ฐ ๋ฐ์ํ๋ฉด ์๋์ผ๋ก ํ์ฑํ๋ฉ๋๋ค.
    *  LogType.Error
    *  LogType.Exception 

### Code

#### Console
1. Category
    * ์นดํ๊ณ ๋ฆฌ ์๋ ฅ ๋ฐฉ๋ฒ
        ```cs
        Debug.Log(GpmLogViewer.Instance.MakeLogWithCategory("TestLog", "UserCategory"));
        ```

2.  Log ํ์
    * Log        
        ```cs
        Debug.Log("");
        ```
    * Warnning        
        ```cs
        Debug.LogWarning("");
        ```
    * Assert/Error/Exception        
        ```cs
        Debug.LogAssertion("");
        Debug.LogError("");
        Debug.LogException("");
        ```
#### Command

1. Cheat Key      
    * Cheat Key ์ถ๊ฐ ๋ฐฉ๋ฒ
        ```cs
        public void AddCheatKeySample()
        {
            Function.Instance.AddCheatKeyCallback((cheatKey) =>
            {
                Debug.Log("Call cheat key callback with : " + cheatKey);
            });
        }
        ```
2. Command
    * Command ์ถ๊ฐ ๋ฐฉ๋ฒ
        ```cs
        private void TestCommand(int index)
        {       
            Debug.Log("Index : " + index);         
        }

        public void AddCommandSample()
        {
            Function.Instance.AddCommand(this, "TestCommand", new object[] { 2 });
        }
        ```
