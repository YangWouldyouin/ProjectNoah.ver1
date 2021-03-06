# Infinite Scroll

๐ [English](README.en.md)

## ๐ฉ ๋ชฉ์ฐจ

* [๊ฐ์](#๊ฐ์)
* [์ฌ์ฉ ๋ฐฉ๋ฒ](#์ฌ์ฉ-๋ฐฉ๋ฒ)
* [API](#-api)
* [Sample](#-sample)

## ๊ฐ์

์คํฌ๋กค ์ฌ๊ฐ ์์ญ(Scroll Rect(Scroll View))์ ์ฌ์ฉํ  ๋ ๋ทฐํฌํธ(Viewport) ํฌ๊ธฐ์ ๋ง๊ฒ ์์ดํ์ ์์ฑํด ์ฌ์ฌ์ฉํ  ์ ์๋ ์ปดํฌ๋ํธ์๋๋ค.

* InfiniteScroll์ ์ฌ์ฉ์๊ฐ ์ฝ์ํ InfiniteScrollData(ํน์ ์์๋ฐ์) ํด๋์ค๋ก ์ฝํ์ธ (Content)์ ์์(Element)๋ฅผ ์์ฑํฉ๋๋ค.
    * InfiniteScroll.InsertData()
* ์ฝํ์ธ ์ ์์๋ก ์ฌ์ฉํ  ํ๋ฆฌํน(Prefab)์์๋ InfiniteScrollItem(ํน์ ์์๋ฐ์) ํด๋์ค๋ฅผ ์ฐ๊ฒฐํด์ ์ฌ์ฉํด์ผ ํฉ๋๋ค.
    * InfiniteScrollItem.UpdateData()์์ ํ๋ฆฌํน ๋ก์ง ๊ตฌํ

## ์ฌ์ฉ ๋ฐฉ๋ฒ

### ์์ฑ
![inspector](images/inspector.png)
* ์คํฌ๋กค ์ฌ๊ฐ ์์ญ(Scroll Rect(Scroll View))์ด ๋ถ์ด์๋ ์ค๋ธ์ ํธ์ Infinite Scroll ์ปดํฌ๋ํธ๋ฅผ ์ถ๊ฐํฉ๋๋ค.
* Item Prefab์ InfiniteScrollItem์ ์์๋ฐ์ ํด๋์ค๊ฐ ๋ถ์ด์๋ ํ๋ฆฌํน์ ์ถ๊ฐํฉ๋๋ค.

### ์คํฌ๋กค ๋ฐ์ดํ ์ ์ฉ
* InfiniteScrollItem ์์๋ฐ์ ํด๋์ค ๋ด์์ ์ฝํ์ธ (Content)์ ๋ฐ์ดํ(Data)๋ฅผ ์ ์ฉํ์ฌ ์ฌ์ฉํฉ๋๋ค.
    ```
    public override void UpdateData(InfiniteScrollData scrollData)
    {
        base.UpdateData(scrollData);

        // InfiniteScrollData ์ฝํ์ธ ๋ก ๋ฐ์ดํ ์ ์ฉ
    }
    ```

### ์์ดํ ๋์  ํฌ๊ธฐ ์กฐ์ 
* Dynamic Item Size ์ต์์ ํ์ฑํํฉ๋๋ค.
* InfiniteScrollItem ์์ ๋ฐ์ ํด๋์ค
    * SetSize๋ฅผ ์ฌ์ฉํ์ฌ ํฌ๊ธฐ๋ฅผ ๋ณ๊ฒฝํฉ๋๋ค.
    * SetSize๋ฅผ ์ฌ์ฉํ์ง ์๊ณ  ํฌ๊ธฐ ๋ณ๊ฒฝ ์ OnUpdateItemSize() ํจ์๋ฅผ ํธ์ถํด ์คํฌ๋กค์ ๋ฐ์ํฉ๋๋ค.

### ์คํฌ๋กค ๊ทธ๋ฆฌ๋ ์ ์ฉ
* Layout์ Values ๊ทธ๋ฆฌ๋๋ฅผ ๋ถํ ํ  ํฌ๊ธฐ๋ฅผ ์ค์ ํฉ๋๋ค.
* Values์ Element์ ๋น์จ๋ก ๊ทธ๋ฆฌ๋๋ฅผ ๋น์จ์ ์ค์ ํฉ๋๋ค.
    * ![grid_2](images/grid_2.png)
    * ์๋์ ๊ฐ์ด 2:1:1 ๋น์จ๋ก ๋๋ ๊ฒฐ๊ณผ์๋๋ค.
    * 200, 100, 100๋ฑ 1์ด ๋์ด๊ฐ ๊ฐ์ผ๋ก ํฌ๊ธฐ์ ๋ง์ถฐ์ ์ง์ ํ  ์๋ ์์ต๋๋ค.
    * ![grid_1](images/grid_1.png)

### ์คํฌ๋กค ์ด๋ฒคํธ
ScrollView์ ์ํ ๋ณํ์ ๋ฐ๋ผ ํธ์ถํ๋ ์ด๋ฒคํธ ์๋๋ค.

Inspector๋ AddListener๋ฅผ ํตํด ์ฝ๋ฐฑ ํจ์๋ฅผ ๋ฑ๋กํ์ฌ ํ์ฉํ  ์ ์์ต๋๋ค.

#### ์ธ์คํฉํฐ
![event](images/event.png)

#### onChangeValue
ScrollView์ ๊ฐ์ด ๋ณ๊ฒฝ๋์์ ๋ ํธ์ถํ๋ ์ด๋ฒคํธ ์๋๋ค.
* (int)firstDataIndex
    * ์คํฌ๋กค์์ ๋ณด์ด๋ ์ฒซ๋ฒ์งธ Data์ Index
* (int)lastDataIndex
    * ์คํฌ๋กค์์ ๋ณด์ด๋ ๋ง์ง๋ง Data์ Index
* (bool)isStartLine
    * ์คํฌ๋กค์ด ์์ ์ง์ ์ธ์ง ์ฌ๋ถ
* (bool)isEndLine
    * ์คํฌ๋กค์ด ๋ง์ง๋ง ์ง์ ์ธ์ง ์ฌ๋ถ
```cs
onChangeValue.AddListener(firstDataIndex, lastDataIndex, isStartLine, isEndLine =>
{
    // funtion
});
```

#### onChangeActiveItem
Scroll Item์ด ๋ณด์ด๊ฑฐ๋ ์ฌ๋ผ์ง๋ ํธ์ถํ๋ ์ด๋ฒคํธ ์๋๋ค.
* (int)dataIndex
    * ๋ณ๊ฒฝ๋ ์คํฌ๋กค Data์ Index
* (bool)active
    * ์คํฌ๋กค ์์ดํ์ ํ์ฑํ ์ฌ๋ถ
```cs
onChangeActiveItem.AddListener(dataIndex, active =>
{
    // funtion
});
```

#### onStartLine
ScrollView์ ์์ ์ง์ ์ธ์ง ์ฌ๋ถ๊ฐ ๋ฐ๋๋ ํธ์ถํ๋ ์ด๋ฒคํธ ์๋๋ค.
* (bool)isStartLine
    * ์คํฌ๋กค์ด ์์ ์ง์ ์ธ์ง ์ฌ๋ถ
```cs
onStartLine.AddListener((bool)isStartLine =>
{
    // funtion
});
```

#### onEndLine
ScrollView์ ๋ง์ง๋ง ์ง์ ์ธ์ง ์ฌ๋ถ๊ฐ ๋ฐ๋๋ ํธ์ถํ๋ ์ด๋ฒคํธ ์๋๋ค.
* (bool)isEndLine
    * ์คํฌ๋กค์ด ๋ง์ง๋ง ์ง์ ์ธ์ง ์ฌ๋ถ
```cs
onEndLine.AddListener((bool)isEndLine =>
{
    // funtion
});
```


## ๐จ API

API ์ฌ์ฉ ๋ฐฉ๋ฒ์ Assets/GPM/UI/Sample/InfiniteScroll/Scripts/InfiniteScrollSample.cs๋ฅผ ์ฐธ๊ณ ํ์๊ธฐ ๋ฐ๋๋๋ค.

### InsertData

์ฝํ์ธ ์ ์์๋ก ๋ณด์ฌ์ค ๋ฐ์ดํฐ๋ฅผ ์ถ๊ฐํฉ๋๋ค.

```cs
public void InsertData(InfiniteScrollData data)
```

### UpdateData

์ฝ์ํ ๋ฐ์ดํฐ๋ฅผ ์๋ฐ์ดํธํฉ๋๋ค.

```cs
public void UpdateData(InfiniteScrollData data)
```

### UpdateAllData

๋ชจ๋  ๋ฐ์ดํฐ๋ฅผ ์๋ฐ์ดํธํฉ๋๋ค.

```cs
public void UpdateAllData()
```

### RemoveData

์ฝ์ํ ๋ฐ์ดํฐ๋ฅผ ์ญ์ ํฉ๋๋ค.

```cs
public void RemoveData(InfiniteScrollData data)
```
```cs
public void RemoveData(int dataIndex)
```

### Clear

๋ชจ๋  ๋ฐ์ดํฐ๋ฅผ ์ญ์ ํฉ๋๋ค.

```cs
public void Clear()
```

### MoveToFirstData

์ฒซ ๋ฒ์งธ ๋ฐ์ดํฐ๋ก ์ฝํ์ธ ๋ฅผ ์ด๋ํฉ๋๋ค.

```cs
public void MoveToFirstData()
```

### MoveToLastData

๋ง์ง๋ง ๋ฐ์ดํฐ๋ก ์ฝํ์ธ ๋ฅผ ์ด๋ํฉ๋๋ค.

```cs
public void MoveToLastData()
```

### IsMoveToLastData

์ฝํ์ธ ๊ฐ ๋ง์ง๋ง ๋ฐ์ดํฐ๋ก ์ด๋ํ๋์ง ํ์ธํฉ๋๋ค.

```cs
public bool IsMoveToLastData()
```

### MoveTo

ํด๋น ๋ฐ์ดํฐ๋ก ์ฝํ์ธ ๋ฅผ ์ด๋ํฉ๋๋ค.

```cs
public void MoveTo(InfiniteScrollData data, MoveToType moveToType)
```

```cs
public void MoveTo(int dataIndex, MoveToType moveToType)
```

### ResizeScrollView

ScrollView ํฌ๊ธฐ๊ฐ ๋ณ๊ฒฝ๋์์ ๋ Infinite Scroll์์ ํฌ๊ธฐ ๋ณ๊ฒฝ์ ์ฒ๋ฆฌํ๋ ๋ฐ ํ์ํ API์๋๋ค.

```cs
public void ResizeScrollView()
```

## ๐พ Sample

Assets/GPM/UI/Sample/InfiniteScroll

![infinitescroll_sample](images/infinitescroll_sample.gif)

---

![dynamic_sample](images/dynamic_sample.gif)

