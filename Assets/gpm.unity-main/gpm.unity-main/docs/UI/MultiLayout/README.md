# Multi Layout

π [English](README.en.md)

## π© λͺ©μ°¨

* [κ°μ](#κ°μ)
* [API](#-api)
* [Sample](#-sample)

## κ°μ

MultiLayout μ»΄ν¬λνΈλ UI μ»΄ν¬λνΈμ RectTransform μ λ³΄λ₯Ό μ¬λ¬ κ°μ λ μ΄μμμΌλ‘ μ€μ ν΄ ν΄μλ, νλ©΄ λ°©ν₯ λ±μ λμν  μ μλλ‘ λμμ€λλ€.

## π¨ API

### SelectLayout

μ€μ λ λ μ΄μμ μ€ νλλ₯Ό μ νν©λλ€.

#### API

```cs
public void SelectLayout(int layoutIndex)
```

#### Example

```cs
public void SetOrientation(ScreenOrientation orientataion)
{
    if (orientataion == ScreenOrientation.Portrait)
    {
        multiLayout.SelectLayout(1);
    }
    else
    {
        multiLayout.SelectLayout(0);
    }
}
```

## πΎ Sample

Assets/GPM/UI/Sample/MultiLayout

### Editor

![multilayout_editor](images/multilayout_editor.gif)

### Runtime

![multilayout_runtime](images/multilayout_runtime.gif)