# CacheStorage

๐ [English](README.en.md)

## ๐ฉ ๋ชฉ์ฐจ

* [๊ฐ์](#๊ฐ์)
* [์คํ](#์คํ)
* [API](#api)
* [Release notes](./ReleaseNotes.md)

## ๊ฐ์

* CacheStorage๋ Unity์์ ์น ํต์ ์ ํ  ๋ Cache๋ฅผ ์ง์ํด ์ฑ๋ฅ์ ๊ฐ์ ํ  ์ ์๋ ์๋น์ค์๋๋ค.

## ์คํ

### Unity ์ง์ ๋ฒ์ 

* 2018.4.0 ์ด์

## API

### RequestHttpCache

url๋ก ๋ฐ์ดํฐ๋ฅผ ์์ฒญํฉ๋๋ค.
์บ์ ๋ ๋ฐ์ดํฐ์ ์น ๋ฐ์ดํฐ๊ฐ ๋์ผํ ๋ฐ์ดํฐ์ธ ๊ฒฝ์ฐ ์บ์ ๋ ๋ฐ์ดํฐ๋ฅผ ์ฌ์ฉํฉ๋๋ค.

**API**
```cs
public static CacheInfo RequestHttpCache(string url, Action<Result> onResult)
```

**Example**
```cs
public void Something()
{
    string url;
    GpmCacheStorage.RequestHttpCache(url, (result) =>
    {
        if (result.success == true)
        {
            bytes[] data = result.data;
        }
    });
}
```

### RequestLocalCache

url๋ก ์ด๋ฏธ ์บ์ ๋ ๋ฐ์ดํฐ๋ฅผ ์์ฒญํฉ๋๋ค. 
์บ์ ๋์ด์์ง ์์ ๊ฒฝ์ฐ ์คํจํฉ๋๋ค.

**API**
```cs
public static CacheInfo RequestLocalCache(string url, Action<Result> onResult)
```

**Example**
```cs
public void Something()
{
    string url;
    GpmCacheStorage.RequestLocalCache(url, (result) =>
    {
        if (result.success == true)
        {
            bytes[] data = result.data;
        }
    });
}
```

### GetCachedTexture

url๋ก ์ด๋ฏธ ์บ์ ๋ ํ์ค์ฒ๋ฅผ ์์ฒญํฉ๋๋ค.
์ฑ ์คํ ํ ๋ก๋ํ ํ์ค์ฒ๋ผ๋ฉด ์ฌ์ฌ์ฉํฉ๋๋ค.

**API**
```cs
public static CacheInfo GetCachedTexture(string url, Action<CachedTexture> onResult)
```

**Example**
```cs

public void Something()
{
    string url;
    CacheInfo cacheInfo = GpmCacheStorage.GetCachedTexture(url, (cachedTexture) =>
    {
        if (cachedTexture != null)
        {
            Texture texture = cachedTexture.texture;
        }
    });
}
```

### RequestTexture

url๋ก ์บ์ ๋ ๋ฐ์ดํฐ๋ฅผ ์์ฒญํฉ๋๋ค. 
์ฑ ์คํ ํ ๋ก๋ํ ํ์ค์ฒ๋ผ๋ฉด ์ฌ์ฌ์ฉํฉ๋๋ค.
์บ์ ๋ ๋ฐ์ดํฐ์ ์น ๋ฐ์ดํฐ๊ฐ ๋์ผํ ๋ฐ์ดํฐ์ธ ๊ฒฝ์ฐ ์บ์ ๋ ํ์ค์ฒ๋ฅผ ๋ก๋ํ์ฌ ์ฌ์ฉํฉ๋๋ค.

**API**
```cs
public static CacheInfo RequestTexture(string url, Action<CachedTexture> onResult)
```

**Example**
```cs
public void Something()
{
    string url;
    CacheInfo cacheInfo = GpmCacheStorage.RequestTexture(url, (cachedTexture) =>
    {
        if (cachedTexture != null)
        {
            Texture texture = cachedTexture.texture;
        }
    });
}
```

### GetCacheSize

๊ด๋ฆฌ ์ค์ธ ์บ์ ์ฉ๋์ ์ ์ ์์ต๋๋ค.

**API**
```cs
public static long GetCacheSize()
```

**Example**
```cs
public long GetCacheCount()
{
    return GpmCacheStorage.GetCacheSize();
}
```

### GetMaxSize

๊ด๋ฆฌํ  ์ต๋ ์บ์ ์ฉ๋์ ์ ์ ์์ต๋๋ค.

**API**
```cs
public static long GetMaxSize()
```

**Example**
```cs
public long GetMaxSize()
{
    return GpmCacheStorage.GetMaxSize();
}
```

### SetMaxSize

๊ด๋ฆฌํ  ์ต๋ ์บ์ ์ฉ๋์ ์ค์ ํ  ์ ์์ต๋๋ค.
* size
    * ๊ธฐ๋ณธ๊ฐ์ 0์๋๋ค.
    * 0์ผ ๋ ๋ฌด์ ํ ์ ์ฅํฉ๋๋ค.
* applayStorage
    * true ์ผ ๋ ์ ์ฅ์์ ์ฉ๋ ํฌ๊ธฐ๋ฅผ ์กฐ์ ํฉ๋๋ค
    * false ์ผ ๋ ์ค์ ๊ฐ๋ง ์์ ๋๊ณ  ํ์ผ์ด ์ถ๊ฐ๋  ๋ ์ ์ฉ๋ฉ๋๋ค.

**API**
```cs
public static void SetMaxSize(long size = 0, bool applyStorage = true)
```

**Example**
```cs
public void Something()
{
    long maxSize = 10 * 1024 * 1024; // 10 MB
    bool applayStorage = true; // ์ ์ฅ์ ์ ์ฉ(์๋ ์ญ์ )
    GpmCacheStorage.SetMaxSize(maxSize, applayStorage);
}
```

### GetCacheCount

๊ด๋ฆฌ ์ค์ธ ์บ์ ์๋ฅผ ์ ์ ์์ต๋๋ค.

**API**
```cs
public static int GetCacheCount()
```

**Example**

```cs
public int GetCacheCount()
{
    return GpmCacheStorage.GetCacheCount();
}
```

### GetMaxCount

๊ด๋ฆฌํ  ์ต๋ ์บ์ ๊ฐ์๋ฅผ ์ ์ ์์ต๋๋ค.

**API**
```cs
public static int GetMaxCount()
```

**Example**
```cs
public int GetMaxCount()
{
    return GpmCacheStorage.GetMaxCount();
}
```

### SetMaxCount

๊ด๋ฆฌํ  ์ต๋ ์บ์ ๊ฐ์๋ฅผ ์ค์ ํ  ์ ์์ต๋๋ค.
* count
    * ๊ธฐ๋ณธ๊ฐ์ 0์๋๋ค.
    * 0์ผ ๋ ๋ฌด์ ํ ์ ์ฅํฉ๋๋ค.
* applayStorage
    * true ์ผ ๋ ์ ์ฅ์์ ์ฉ๋ ํฌ๊ธฐ๋ฅผ ์กฐ์ ํฉ๋๋ค
    * false ์ผ ๋ ์ค์ ๊ฐ๋ง ์์ ๋๊ณ  ํ์ผ์ด ์ถ๊ฐ๋  ๋ ์ ์ฉ๋ฉ๋๋ค.

**API**
```cs
public static void SetMaxCount(int count = 0, bool applyStorage = true)
```

**Example**
```cs
public void Something()
{
    int maxCount = 50000;
    bool applayStorage = true; // ์ ์ฅ์ ์ ์ฉ(์๋ ์ญ์ )
    GpmCacheStorage.SetMaxCount(maxCount, applayStorage);
}
```

### ClearCache

๊ด๋ฆฌ ์ค์ธ ์บ์๋ฅผ ์ ๊ฑฐํฉ๋๋ค.

**API**
```cs
public static void ClearCache()
```

**Example**
```cs
public void ClearCache()
{
    GpmCacheStorage.ClearCache();
}
```

### GetCachePath

๊ด๋ฆฌ๋๋ ์บ์์ ๊ฒฝ๋ก๋ฅผ ์ ์ ์์ต๋๋ค.

**API**
```cs
public static string GetCachePath()
```

**Example**
```cs
public string GetCachePath()
{
    return GpmCacheStorage.GetCachePath();
}
```

### SetCachePath

๊ด๋ฆฌ๋๋ ์บ์์ ๊ฒฝ๋ก๋ฅผ ์ค์ ํฉ๋๋ค.
๊ธฐ๋ณธ๊ฐ์ Application.temporaryCachePath์๋๋ค.

**API**
```cs
public static void SetCachePath(string path)
```

**Example**
```cs
public void SetCachePath()
{
    string path = Application.temporaryCachePath;
    GpmCacheStorage.SetCachePath(path);
}
```


### GetReRequestTime

์น์บ์ ์ฌ์์ฒญ ์๊ฐ์ ์ ์ ์์ต๋๋ค.

**API**
```cs
public static long GetReRequestTime()
```

**Example**
```cs
public long GetReRequestTime()
{
    return GpmCacheStorage.GetReRequestTime();
}
```

### SetReRequestTime

์น์บ์ ์ฌ์์ฒญ ์๊ฐ์ ์ ํ  ์ ์์ต๋๋ค.
๊ธฐ๋ณธ๊ฐ์ 0์๋๋ค. ๋จ์๋ Tick์๋๋ค.


**API**
```cs
public static void SetReRequestTime(long value)
```

**Example**
```cs
public void SetReRequestTime()
{
    long reRequestTime = TimeSpan.TicksPerHour * 4;
    GpmCacheStorage.SetReRequestTime(reRequestTime);
}
```
