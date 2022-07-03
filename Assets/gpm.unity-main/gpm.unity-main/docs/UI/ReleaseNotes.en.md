# Release notes

🌏 [한국어](ReleaseNotes.md)

## 2.5.0

### Date

* 2022.05.30

### Added
* Added WebCacheImage

### Updated
* Added Common v2.1.0 dependency
* Added CacheStorage v0.1.0 dependency

### Fixed
* InfiniteScroll
    * Fixed the problem that scroll items are not reused after clearing the list

## 2.4.0

### Date

* 2022.04.18

### Added
* InfiniteScroll
    * Added Scroll Event [(180)](https://github.com/nhn/gpm.unity/issues/180)
        * OnChangeValue
        * OnChangeActiveItem
        * OnStartLine
        * OnEndLine

* WrapLayoutGroup
    * Added Samples
    * Added a document

## 2.3.0

### Date

* 2022.03.21

### Added
* InfiniteScroll
    * Added a function to split into a Grid [(161)](https://github.com/nhn/gpm.unity/issues/161)

### Fixed
* InfiniteScroll
    * Fixed the problem that the list is not displayed according to the initialization order

## 2.2.0

### Date

* 2022.02.21

### Added
* Added WrapLayoutGroup

## 2.1.1

### Date

* 2022.01.17

### Fixed
* InfiniteScroll
    * Fixed a problem where ScrollItem Item size was incorrectly calculated as total size 0

## 2.1.0

### Date

* 2022.01.13

### Added
* InfiniteScroll
    * Added ScrollItem active function
    * Added ScrollItem Item size setting function

### Updated
* InfiniteScroll
    * Update to be able to respond to variable-length ScrollItems in dynamicItemSize environment [(165)](https://github.com/nhn/gpm.unity/issues/165)

### Fixed
* InfiniteScroll
    * Fixed an issue where invisible ScrollItem object was activated in dynamicItemSize environment

## 2.0.7

### Date

* 2020.06.21

### Added
* InfiniteScroll
    * Added scroll item spacing function

## 2.0.6

### Date

* 2020.05.26

### Fixed
* InfiniteScroll
    * Correction of error when calling Clear before initialization

## 2.0.5

### Date

* 2020.05.13

### Changed
* DragableRect renamed to DraggableRect

## 2.0.4

### Date

* 2020.05.03

### Updated
* ContentSizeSetter
    * ExecuteInEditMode changed to ExcuteAlways as a popup issue in prefab mode
* LayoutUpdate
    * ExecuteInEditMode changed to ExcuteAlways as a popup issue in prefab mode

### Fixed
* DragableRect 
    * Fixed a problem where events are accumulated when repeating on/off
* LayoutUpdate
    * Added exception handling when parent RectTransform does not exist.

## 2.0.3

### Date

* 2020.04.16

### Added
* Add DrawableRect feature
* Add ContentSizeFitter  feature

### Updated
* Improvement InfiniteScroll initialization logic 
* Change folder structure 

## 2.0.2

### Date

* 2020.03.11

### Fixed

* Fix comfile error when building after applying Asseambly Definition

## 2.0.1

### Date

* 2020.03.10

### Added

* Add Assembly Definition

## 2.0.0

### Date

* 2020.12.21

### Updated

* Brand name changed to Game Package Manager from TOAST Kit.

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