# WebCacheImage

๐ [English](README.en.md)

## ๐ฉ ๋ชฉ์ฐจ

* [๊ฐ์](#๊ฐ์)
* [์ฌ์ฉ ๋ฐฉ๋ฒ](#์ฌ์ฉ-๋ฐฉ๋ฒ)
* [API](#api)

## ๊ฐ์

URL์ ์ด์ฉํ์ฌ ์น ์ด๋ฏธ์ง๋ฅผ ์บ์ ํ์ฌ ์ด๋ฏธ์ง๋ฅผ ๋ณด์ฌ์ฃผ๋ ์ปดํฌ๋ํธ์๋๋ค.

## ์ฌ์ฉ ๋ฐฉ๋ฒ
UI ์ค๋ธ์ ํธ์ **WebCacheImage** ์ปดํฌ๋ํธ๋ฅผ ์ถ๊ฐํฉ๋๋ค. 
* RawImage๊ฐ ์๋ค๋ฉด RawImage ์ปดํฌ๋ํธ๋ ๊ฐ์ด ์์ฑ๋ฉ๋๋ค.
* RawImage๊ฐ ์๋ค๋ฉด RawImage ์ปดํฌ๋ํธ์ ์ฐ๋๋ฉ๋๋ค.

![WebCacheImage.png](https://github.com/nhn/gpm.unity/blob/main/docs/UI/WebCacheImage/images/WebCacheImage.png?raw=true)

1. ์ด๋ฏธ์ง๋ฅผ ๋ถ๋ฌ์ฌ URL์๋๋ค.
2. ์น ์์ฒญ์ ํตํด ์ด๋ฏธ์ง๋ฅผ ์ป์ ๊ฒฝ์ฐ ๋๋ ์ด๊ฐ ์์ต๋๋ค. ์บ์๊ฐ ์์ ๊ฒฝ์ฐ ๋ฏธ๋ฆฌ ๋ถ๋ฌ์ต๋๋ค.
3. Texture๊ฐ ์์ฒญ์ ํตํด Load ๋์์ ๋์ ์ด๋ฒคํธ์๋๋ค.

## API

### SetUrl

์ด๋ฏธ์ง๋ฅผ ๋ถ๋ฌ์ฌ URL์ ์ค์ ํฉ๋๋ค.

**Example**
```cs
WebCacheImage cache;

cache.SetUrl(cacheData.url);
```

### SetLoadTextureEvent

์ด๋ฏธ์ง๋ฅผ ๋ก๋ํ  ๋ ์ด๋ฒคํธ๋ฅผ ์ค์ ํฉ๋๋ค.

**Example**
```cs
WebCacheImage cache;
cache.SetLoadTextureEvent(OnLoadTexture);

public void OnLoadTexture(Texture texture)
{
}
```