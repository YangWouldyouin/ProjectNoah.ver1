# ContentSizeSetter

๐ [English](README.en.md)

## ๐ฉ ๋ชฉ์ฐจ

* [๊ฐ์](#๊ฐ์)
* [์ฌ์ฉ ๋ฐฉ๋ฒ](#์ฌ์ฉ-๋ฐฉ๋ฒ)
* [Sample](#Sample)

## ๊ฐ์

๋ค๋ฅธ UI์ปจํ์ธ  ์ฌ์ด์ฆ๋ฅผ ์ค์ ํด์ฃผ๋ ์ปดํฌ๋ํธ์๋๋ค.

## ์ฌ์ฉ ๋ฐฉ๋ฒ
๊ธฐ์ค์ด๋  UI ์ค๋ธ์ ํธ์ **ContentSizeSetter** ์ปดํฌ๋ํธ๋ฅผ ์ถ๊ฐํฉ๋๋ค.
์ฌ์ด์ฆ๋ฅผ ๋ณ๊ฒฝํ  ๋์์ Target์ ์ถ๊ฐํฉ๋๋ค..

![ContentSizeSetter.png](https://github.com/nhn/gpm.unity/blob/main/docs/UI/ContentSizeSetter/images/ContentSizeSetter.png?raw=true)
1. ๋๋ ๊ทธ๊ฐ ์์๋ ๋์ ์ด๋ฒคํธ๋ฅผ ์ถ๊ฐํ ์ ์์ต๋๋ค.
2. ์ฌ์ด์ฆ๋ฅผ ๋ณ๊ฒฝํ  ๋์์ ์ค์ ํฉ๋๋ค.

## Sample

Assets/GPM/UI/Sample/CotentSizeSetter

![CotentSizeSetterSample.gif](https://github.com/nhn/gpm.unity/blob/main/docs/UI/ContentSizeSetter/images/CotentSizeSetterSample.gif?raw=true)

ํด๋น ์ํ์์๋ **ContentSizeSetter**๋ฅผ ์๋์ ๊ฐ์ ์ํฉ์ ์ฌ์ฉํ๊ณ  ์์ต๋๋ค.
1. ContentsSizeFrame๊ฐ EntryRoot ํฌ๊ธฐ ๋ณด๋ค (5, 5) ๋ ํฐ ํฌ๊ธฐ๋ก ์ค์ 
2. Entity ํ๋ฆฌํน์์ TextBox๊ฐ Text_Value ํฌ๊ธฐ ๋ณด๋ค (10, 8) ๋ ํฐ ํฌ๊ธฐ๋ก ์ค์ 
3. ChildContainer๊ฐ ChildRoot ํฌ๊ธฐ ๋ณด๋ค (10, 0) ๋ ํฐ ํฌ๊ธฐ๋ก ์ค์ 

ํด๋น ์ํ์์๋ LayoutGroup์ ContentSizeFitter๋ฅผ ์ค์ฒฉํ์ฌ ์ฌ์ฉํ๊ณ  ์์ต๋๋ค.
์ด๋ด๊ฒฝ์ฐ ๋์ ์์์ ์ํด ํฌ๊ธฐ๋ ๋ ์ด์์์ด ๊ฐฑ์ ์ด ์ ๋๋ก ๋์ง ์๊ธฐ ๋๋ฌธ์ 
**LayoutUpdater**์ ์ปดํฌ๋ํธ๋ฅผ ์ด์ฉํด ๋ถ๋ชจ ๋ ์ด์์์ ๊ฐฑ์ ํด์ค๋๋ค.
**LayoutUpdater**๋ ๋ถ๋ชจ ์ค๋ธ์ ํธ์ ๋ ์ด์์ ๊ฐฑ์ ์ ๋ณด๋ฅผ ์ ๋ฌํด์ค๋๋ค.