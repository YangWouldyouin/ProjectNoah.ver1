# Release notes

๐ [English](ReleaseNotes.en.md)

## 2.5.0

### Date

* 2022.05.30

### Added
* WebCacheImage ์ถ๊ฐ

### Updated
* Common v2.1.0 ์์กด์ฑ ์ถ๊ฐ
* CacheStorage v0.1.0 ์์กด์ฑ ์ถ๊ฐ

### Fixed
* InfiniteScroll
    * ๋ฆฌ์คํธ ํด๋ฆฌ์ด ์ ํ ์คํฌ๋กค ์์ดํ ์ฌ์ฌ์ฉ ํ์ง ์๋ ๋ฌธ์  ์์ 

## 2.4.0

### Date

* 2022.04.18

### Added
* InfiniteScroll
    * ์คํฌ๋กค ์ด๋ฒคํธ ์ถ๊ฐ [(180)](https://github.com/nhn/gpm.unity/issues/180)
        * OnChangeValue
        * OnChangeActiveItem
        * OnStartLine
        * OnEndLine

* WrapLayoutGroup
    * ์ํ ์ถ๊ฐ
    * ๋ฌธ์ ์ถ๊ฐ

## 2.3.0

### Date

* 2022.03.21

### Added
* InfiniteScroll
    * ์ ๋ ฌ Grid๋ก ๋ถํ ํ  ์ ์๋๋ก ๊ธฐ๋ฅ ์ถ๊ฐ [(161)](https://github.com/nhn/gpm.unity/issues/161)

### Fixed
* InfiniteScroll
    * ์ด๊ธฐํ ์์์ ๋ฐ๋ผ ๋ฆฌ์คํธ ๋ณด์ด์ง ์๋ ๋ฌธ์  ์์ 

## 2.2.0

### Date

* 2022.02.21

### Added
* WrapLayoutGroup ์ถ๊ฐ

## 2.1.1

### Date

* 2022.01.17

### Fixed
* InfiniteScroll
    * ScrollItem Item size ์ ์ฒด ์ฌ์ด์ฆ 0์ผ๋ก ์๋ชป ๊ณ์ฐํ๋ ๋ฌธ์  ์์ 

## 2.1.0

### Date

* 2022.01.13

### Added
* InfiniteScroll
    * ScrollItem active ํจ์ ์ถ๊ฐ
    * ScrollItem Item size ์ค์  ํจ์ ์ถ๊ฐ

### Updated
* InfiniteScroll
    * dynamicItemSize ํ๊ฒฝ์์ ๊ฐ๋ณ๊ธธ์ด ScrollItem ๋์ ๊ฐ๋ฅํ๋๋ก ์์  ๋ก์ง ์์ [(165)](https://github.com/nhn/gpm.unity/issues/165)

### Fixed
* InfiniteScroll
    * dynamicItemSize ํ๊ฒฝ์์ ๋ณด์ด์ง ์๋ ScrollItem ์ค๋ธ์ ํธ ํ์ฑํ ๋๋ ๋ฌธ์  ์์ 

## 2.0.7

### Date

* 2020.06.21

### Added
* InfiniteScroll
    * ์คํฌ๋กค ์์ดํ ๊ฐ๊ฒฉ ๊ธฐ๋ฅ ์ถ๊ฐ

## 2.0.6

### Date

* 2020.05.26

### Fixed
* InfiniteScroll
    * ์ด๊ธฐํ ์  Clear ํธ์ถํ  ๋ ์ค๋ฅ ์์ 

## 2.0.5

### Date

* 2020.05.13

### Changed
* DragableRect DraggableRect๋ก ์ด๋ฆ ๋ณ๊ฒฝ

## 2.0.4

### Date

* 2020.05.03

### Updated
* ContentSizeSetter
    * ExecuteInEditMode ํ๋ฆฌํน ๋ชจ๋ ํ์ ์ด์๋ก ExcuteAlways๋ก ๋ณ๊ฒฝ
* LayoutUpdate
    * ExecuteInEditMode ํ๋ฆฌํน ๋ชจ๋ ํ์ ์ด์๋ก ExcuteAlways๋ก ๋ณ๊ฒฝ

### Fixed
* DragableRect 
    * ์จ/์คํ ๋ฐ๋ณต ์ ์ด๋ฒคํธ ๋์ ๋๋ ๋ฌธ์  ์์ 
* LayoutUpdate
    * ๋ถ๋ชจ RectTransform๊ฐ ์์ ๊ฒฝ์ฐ์ ๋ํ ์์ธ ์ฒ๋ฆฌ๋ฅผ ์ถ๊ฐํฉ๋๋ค.

## 2.0.3

### Date

* 2020.04.16

### Added
* DragableRect ๊ธฐ๋ฅ ์ถ๊ฐ
* ContentSizeSetter ๊ธฐ๋ฅ ์ถ๊ฐ

### Updated
* InfiniteScroll ์ด๊ธฐํ ๋ก์ง ๊ฐ์ 
* ํด๋ ๊ตฌ์กฐ ๋ณ๊ฒฝ

## 2.0.2

### Date

* 2020.03.11

### Fixed

* Asseambly Definition ์ ์ฉ ํ ๋น๋์ ์ปดํ์ผ ์ค๋ฅ ์์ 

## 2.0.1

### Date

* 2020.03.10

### Added

* Assembly Definition ์ ์ฉ

### 2.0.0

### Date

* 2020.12.21

### Updated

* TOAST Kit์์ Game Package Manager๋ก ๋ธ๋๋ ์ด๋ฆ ๋ณ๊ฒฝ

---

## 1.1.0

### Added

#### Infinite Scroll

* Support dynamic item size

## 1.0.1

### Fixed

#### Infinite Scroll

* Fixed initialization problem related to Item in Clear().

## 1.0.0

### Features

* MultiLayout
* InfiniteScroll