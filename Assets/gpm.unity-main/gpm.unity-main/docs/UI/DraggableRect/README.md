# DraggableRect

๐ [English](README.en.md)

## ๐ฉ ๋ชฉ์ฐจ

* [๊ฐ์](#๊ฐ์)
* [์ฌ์ฉ ๋ฐฉ๋ฒ](#์ฌ์ฉ-๋ฐฉ๋ฒ)
* [Sample](#Sample)

## ๊ฐ์

UI๋ฅผ ๋๋๊ทธ ํ ์ ์๊ฒ ๋ง๋๋ ์ปดํฌ๋ํธ์๋๋ค.

## ์ฌ์ฉ ๋ฐฉ๋ฒ
UI ์ค๋ธ์ ํธ์ **DraggableRect** ์ปดํฌ๋ํธ๋ฅผ ์ถ๊ฐํฉ๋๋ค.
* ์ถ๊ฐ๋ UI๋ด์ Raycast Target์ด ํ์ฑํ๋์ด์ผ ๋์ํฉ๋๋ค.
* ๋๋๊ทธ ์ด๋ฒคํธ๋ง ์ ์ดํ๊ณ  ์ถ๋ค๋ฉด **DragaEventHandler** ์ปดํฌ๋ํธ๋ฅผ ๋์  ์ถ๊ฐํ ์ ์์ต๋๋ค.

![DraggableRect.png](https://github.com/nhn/gpm.unity/blob/main/docs/UI/DraggableRect/images/DraggableRect.png?raw=true)

1. ๋๋ ๊ทธ๊ฐ ์์๋ ๋์ ์ด๋ฒคํธ๋ฅผ ์ถ๊ฐํ ์ ์์ต๋๋ค.
2. ๋๋ ๊ทธ๊ฐ ์ค์ผ๋์ ์ด๋ฒคํธ๋ฅผ ์ถ๊ฐํ ์ ์์ต๋๋ค.
3. ๋๋ ๊ทธ๊ฐ ์ข๋ฃ๋ ๋์ ์ด๋ฒคํธ๋ฅผ ์ถ๊ฐํ ์ ์์ต๋๋ค.
4. ๋๋๊ทธ๋ก ์์ง์ผ UI๋ฅผ ์ง์ ํ ์ ์์ต๋๋ค. None์ผ๊ฒฝ์ฐ ์ปดํฌ๋ํธ๋ฅผ ๋ฃ์ UI๋ก ์๋์ผ๋ก ์ค์ ๋ฉ๋๋ค.


## Sample

Assets/GPM/UI/Sample/DraggableRect

![draggableRectSample.gif](https://github.com/nhn/gpm.unity/blob/main/docs/UI/DraggableRect/images/draggableRectSample.gif?raw=true)
