# WrapLayoutGroup

π [English](README.en.md)

## π© λͺ©μ°¨

* [κ°μ](#κ°μ)
* [μμ](#μμ)
* [Sample](#sample)

## κ°μ
UI μ¬κ°μμ­(RectTansform) λ΄μμ μμ§, λλ μνμΌλ‘ μμ μμλ₯Ό μ λ ¬μν€λ μ»΄ν¬λνΈ μλλ€.
μμ­μ λ²μ΄λλ©΄ λ€μ λΌμΈμΌλ‘ μ λ ¬μν΅λλ€.

![wrap.gif](images/wrap.gif)

## μμ

* Child Alignment
    * μμ μμλ€μ μ λ ¬ μ‘°κ±΄μ μ€μ ν©λλ€.
* Is Vertical
    * μ λ ¬ κΈ°μ€μ μμ§, λλ μνμΈμ§λ₯Ό κ²°μ νλ μμμλλ€
    * main
        * μμ§, μνμ κΈ°μ€μ΄ λλ λΌμΈμλλ€.
        * IsVertival : false
            * μμ§
        * IsVertival : true
            * μν
    * croll
        * main λΌμΈμμ μμ­μ λ²μ΄λ¬μλ μ λ ¬νλ λΌμΈμλλ€.
        * IsVertival : false
            * μν
        * IsVertival : true
            * μμ§
* Main Inverse
    * mainμμλ₯Ό λ°λλ‘ μ λ ¬ν©λλ€.
* Cross Inverse
    * cross μμλ₯Ό λ°λλ‘ μ λ ¬ν©λλ€.

## Sample
* κ° μμ­μ Child Alignmentμ μνκ°μ λ°λΌ μ λ ¬λλ μνλ₯Ό λ³Ό μ μμ΅λλ€.

### IsVertical : false
### Main Inverse : false
### Cross Inverse: false
![h_1.png](images/h_1.png)

---

### IsVertical : false
### Main Inverse : true
### Cross Inverse: false
![h_2.png](images/h_2.png)

---

### IsVertical : false
### Main Inverse : false
### Cross Inverse: true
![h_3.png](images/h_3.png)

---

### IsVertical : false
### Main Inverse : true
### Cross Inverse: true
![h_4.png](images/h_4.png)

---

### IsVertical : true
### Main Inverse : false
### Cross Inverse: false
![v_1.png](images/v_1.png)

---

### IsVertical : true
### Main Inverse : true
### Cross Inverse: false
![v_2.png](images/v_2.png)

---

### IsVertical : true
### Main Inverse : false
### Cross Inverse: true
![v_3.png](images/v_3.png)

---

### IsVertical : true
### Main Inverse : true
### Cross Inverse: true
![v_4.png](images/v_4.png)