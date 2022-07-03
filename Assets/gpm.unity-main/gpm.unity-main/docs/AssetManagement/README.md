# AssetManagement

🌏 [English](README.en.md)

## 🚩 목차

* [개요](#개요)
* [스펙](#스펙)
* [기능 설명](#기능-설명)
    * [에셋 맵](#에셋-맵)
    * [에셋 이슈 찾기](#에셋-이슈-찾기)
    * [에셋 레퍼런스 찾기](#에셋-레퍼런스-찾기)
    * [불필요한 에셋 관리](#불필요한-에셋-관리)
* [사용 방법](#사용-방법)
    * [활성화하기](#활성화하기)
    * [에셋 구조 보기](#에셋-구조-보기)
    * [에셋 구조 사용하기](#에셋-구조-사용하기)
    * [문제 있는 에셋 찾고 수정하기](#문제-있는-에셋-찾고-수정하기)
    * [연결된 에셋 찾고 바꾸기](#연결된-에셋-찾고-바꾸기)
    * [불필요한 에셋 정리하기](#불필요한-에셋-정리하기)
* [따라 하기](#따라-하기)
* [Release notes](./ReleaseNotes.md)
    

## 개요
* AssetManagerment는 유니티 에셋들을 손쉽게 관리할 수 있는 툴입니다.

### 무엇을 할 수 있는가?

1. 에셋의 관계를 쉽게 이해할 수 있습니다.
    * 처음 보는 에셋이라도 쉽게 분석할 수 있습니다.
2. 에셋이 어디서 쓰이고 있는지 쉽게 알 수 있습니다.
    * 쉽고 안전하게 수정 및 교체할 수 있습니다.
3. 에셋에 문제가 있는지 파악하여 오류를 줄일 수 있습니다.
    * missing이 발생한 지점을 추적하여 쉽게 수정할 수 있습니다.
    * 작업 중 문제가 발생했다면 경고 로그로 알려줍니다.
4. 프로젝트를 관리하고 최적화할 수 있습니다.
    * 필요 없는 에셋을 쉽고 안전하게 제거하여 프로젝트 크기를 줄여줍니다.
    * 에셋의 복잡도를 최소화해 빌드 크기를 줄일 수 있습니다.

## 스펙

### 서비스 지원 버전

* Unity 2018.4.0 이상

## 기능 설명

### 에셋 맵

* 에셋의 관계와 상태를 한눈에 관리할 수 있습니다.
![1_gpm_assetmanagement_assetmap_kr.png](./images/1_gpm_assetmanagement_assetmap_kr.png)

1. 루트 에셋 설정
    * 에셋의 관계와 상태를 보여줄 대상입니다.
2. 레퍼런스 트리 뷰
    * 대상 에셋을 사용하는 부모 에셋을 알 수 있습니다.
    * 선택하면 해당 에셋의 그래프 노드가 선택됩니다.
3. 디팬던시 트리 뷰
    * 대상 에셋이 사용 중인 자식 에셋을 알 수 있습니다.
    * 선택하면 해당 에셋의 그래프 노드가 선택됩니다.
4. 에셋 그래프
    * 에셋의 관계를 보여주는 그래프 노드를 보여줍니다. 
    * 에셋의 상태를 볼 수 있고 쉽게 관리할 수 있습니다.
5. 언어 설정
    * 언어를 변경할 수 있습니다.

### 에셋 이슈 찾기

* 이슈가 있는 전체 에셋을 알 수 있습니다. 이슈는 missing과 같은 상태입니다.
![2_gpm_assetmanagement_issuecheck_kr.png](./images/2_gpm_assetmanagement_issuecheck_kr.png)

1. 이슈 리스트 전체 검색
    * 원하는 시점에 이슈가 있는 에셋 리스트를 갱신을 할 수 있습니다.
    * 첫 진입 시에는 자동으로 검색합니다.
2. 에셋 이슈 트리 뷰
    * 이슈가 있는 에셋과 해당 위치, 상태를 알 수 있습니다.
    * missing이 발생한 에셋을 바꾸기로 즉시 해결도 가능합니다.
3. 언어 설정
    * 언어를 변경할 수 있습니다.

### 에셋 레퍼런스 찾기
* 에셋이 사용되는 지점을 찾고 쉽게 수정할 수 있습니다.
![3_gpm_assetmanagement_referencefind_kr.png](./images/3_gpm_assetmanagement_referencefind_kr.png)

1. 검색 대상 및 옵션 설정 
    * 찾을 대상을 설정하고 검색 옵션을 제공합니다.
2. 계층(hierarchy) 뷰
    * 계층(hierarchy)에 있는 열려있는 신(scene)과, 열린 프리팹을 찾습니다.
3. 계층(hierarchy) 바꾸기 옵션 
    * 활성화하면 계층(hierarchy)에 있는 신(scene)과, 프리팹을 바꿀 수 있습니다.
4. 프로젝트 뷰
    * 프로젝트에 있는 신(scene)과 에셋을 찾습니다.
5. 프로젝트 바꾸기 옵션
    * 활성화하면 프로젝트에 있는 신(scene)과 에셋을 바꿀 수 있습니다.
6. 언어 설정
    * 언어를 변경할 수 있습니다.

### 불필요한 에셋 관리
* 불필요한 에셋을 찾고 제거할 수 있습니다.
* 불필요한 에셋을 찾을 때 필터링 설정을 통해 제외할 수 있습니다.
![4_gpm_assetmanagement_unusedasset_kr.png](./images/4_gpm_assetmanagement_unusedasset_kr.png)
![4_gpm_assetmanagement_unusedasset_2_kr.png](./images/4_gpm_assetmanagement_unusedasset_2_kr.png)

1. 기능 선택 탭
    * 불필요한 에셋 제거
        * 불필요한 에셋을 검색하고 제거할 수 있습니다.
    * 필터 옵션
        * 불필요한 에셋을 찾을 때 무엇을 필터링할지 설정할 수 있습니다.
2. 불필요한 에셋 리스트
    * 불필요한 에셋을 검색하고 필터링에 포함 또는 제거 여부를 설정할 수 있습니다.
3. 전체 크기
    * 불필요한 에셋 리스트에서 체크된 모든 에셋의 크기를 보여줍니다.
4. 삭제 및 복구
    * 불필요한 에셋 리스트에서 체크된 모든 에셋을 삭제하거나 복구합니다.
5. 언어 설정
    * 언어를 변경할 수 있습니다.
6. 필터 옵션
    * 불필요한 에셋을 찾을 때 무엇을 필터링할지 설정할 수 있습니다.
    * Filter Built-in
        * Resources 하위 폴더, 프로젝트 설정 또는 기본 포함 씬등 빌드할 때 포함되는 리소스를 제외합니다.
    * Filter Assetbundles
        * Assetbundle로 지정된 리소스들을 제외합니다.
    * Filter Path List
        * path에 아래 리스트의 문자열이 포함되면 제외합니다.

## 사용 방법

### 활성화하기

* AssetManagement는 지속해서 에셋의 의존성을 관리하고 이슈를 추적합니다.
처음 데이터를 캐싱하는 데 시간이 걸리기 때문에 따로 활성화해야 기능을 사용할 수 있습니다.

* 프로젝트의 에셋을 선택하면 인스팩터의 Show AssetMap 버튼을 클릭해 **에셋 관리** 창을 열 수 있습니다.
**에셋 관리** 창에서 AssetManagement가 활성화돼 있지 않다면 **활성화** 버튼이 나타납니다.
![0_enable.gif](./images/0_enable.gif)

* Tools/GPM/AssetManagement/Enable 메뉴로 활성화나 비활성화가 가능합니다.


### 에셋 구조 보기

* 원하는 에셋의 관계 상태를 보려면 AssetMap에서 루트 에셋으로 지정해야 합니다. 
루트 에셋으로 지정하는 방법은 두 가지입니다.
    1. 루트 에셋에 드래그하여 직접 넣기
![1_SelectRoot_Drag.gif](./images/1_SelectRoot_Drag.gif)
    2. 프로젝트의 선택된 에셋 **Show AssetMap** 버튼 클릭
![1_SelectRoot_Show.gif](./images/1_SelectRoot_Show.gif)

* 루트 에셋을 대상으로 레퍼런스(참조), 디팬던시(의존성) 트리 뷰와 에셋의 관계도가 나타납니다.
    * 레퍼런스(참조)는 머터리얼과 텍스처 중 머터리얼같이 에셋을 사용하고 있는 부모 에셋이며
    * 디팬던시(의존성)은 머터리얼과 텍스처 중 텍스처와 같이 사용되는 자식 에셋입니다.

### 에셋 구조 사용하기
* 에셋 관계도는 마우스 휠 버튼을 클릭해 드래그하거나, 휠을 조작해 확대나 축소할 수 있습니다.
* 트리 뷰의 에셋을 선택하면 그래프 노드가 선택됩니다.
* 각 관계도의 **루트 선택** 버튼을 클릭하면 루트 에셋을 바꿀 수 있습니다. 루트 에셋마다 관계가 다릅니다.
![1_SelectRoot_DragRootSelect.gif](./images/1_SelectRoot_DragRootSelect.gif)
* 해당 에셋이 문제가 되는 이슈가 있으면 '이슈가 있습니다' 버튼이 나타납니다. 클릭하면 에셋의 이슈를 확인할 수 있습니다.
* **레퍼런스 검색** 버튼을 클릭하면 에셋이 어느 지점에서 사용되는지 정확히 알 수 있습니다.


### 문제 있는 에셋 찾고 수정하기

프로젝트에서 문제가 있는 전체 에셋을 알 수 있습니다.

* 트리의 최상위 노드는 문제가 발생한 에셋이며 하위 노드는 발생 지점입니다.
* 하위 노드를 더블클릭하면 문제가 되는 지점을 선택합니다.
* 신(scene) 에셋은 신(scene)이 addtive 형식으로 추가되며 확인 가능합니다.
![2_issuecheck_all.gif](./images/2_issuecheck_all.gif)

이슈가 발생한 에셋을 선택해서 수정하는 방법 말고도 툴 내에서 바로 해결할 수도 있습니다.

* 참조 missing이 발생한 경우 **Function** 텝에 있는 공간에 바꿀 에셋을 넣고 **바꾸기**를 클릭합니다.
* 컴포넌트 missing일 때는 경고만 표시됩니다. 이 경우에는 선택하여 수정합니다.
* 문제가 해결돼도 다시 검색할 때까지 리스트에 유지됩니다. 제대로 해결되었나 다시 확인 가능합니다.
![2_issuecheck_replace.gif](./images/2_issuecheck_replace.gif)

### 연결된 에셋 찾고 바꾸기

#### 에셋이 어느 지점에서 사용되는지 정확히 알 수 있습니다.

에셋 찾기 툴을 여는 방법은 다음과 같습니다.
* 에셋 관리 툴의 레퍼런스 검색
* 에셋 맵의 그래프 노드의 **레퍼런스 찾기** 버튼
* 프로젝트 에셋의 GPM Findreference 메뉴
* 컨텍스트의 GPM Findreference 메뉴

![3_open_find_reference.gif](./images/3_open_find_reference.gif)

대상(target) 에셋을 지정합니다.

찾은 데이터는 아래와 같이 분류됩니다.

* 계층(hierarchy) 뷰와 프로젝트 뷰를 나눠서 지원합니다.
    * 계층(hierarchy) 뷰
        * 현재 활성화된 신(scene)과 프리팹을 찾습니다.
    * 프로젝트뷰
        * 프로젝트에 저장된 신(scene)과 에셋을 찾습니다.
* 신(scene)과 일반 에셋을 나눠 보여줍니다.
    * 신(scene) 에셋은 Additive로 포함하여 보여줍니다.

![3_find_list.gif](./images/3_find_list.gif)

리스트 내용은 다음과 같습니다.

* 트리의 최상위 아이템은 대상 에셋을 참조 중인 에셋이며 하위 아이템은 참조 지점입니다.
* 하위 노드 더블클릭하면 참조 지점을 확인할 수 있습니다.
* 참조된 에셋을 다른 에셋으로 교체할 수 있습니다. Function에 에셋을 드래그하고 **바꾸기** 버튼을 클릭합니다.

### 불필요한 에셋 정리하기
프로젝트에서 불필요한 에셋을 제거할 수 있습니다.

![4_unusedAsset_check.gif](./images/4_unusedAsset_check.gif)
* 하단에는 체크된 에셋의 전체 파일 크기입니다.
* 전체 체크 버튼을 통해 전체 에셋을 체크할 수 있습니다.
* 여러 에셋을 선택 후 한 번에 체크 여부를 결정할 수 있습니다.

![4_unusedAsset_button.gif](./images/4_unusedAsset_button.gif)
* 필터 버튼을 통해 경로를 검색에 제외하거나, 에셋을 제거, 복구할 수 있습니다.
* 하단의 전체 제거, 전체 복구를 통해 체크된 에셋을 제거, 복구할 수 있습니다.
* 에셋 제거한 에셋은 Trash 하위 폴더에 보관되어 실수로 지워도 복구할 수 있습니다.

![4_unusedAsset_menu.gif](./images/4_unusedAsset_menu.gif)
* 에셋을 선택 후 마우스 오른쪽 버튼을 통해 관리 메뉴를 열 수 있습니다.
* 에셋 체크, 에셋 체크 해제
    * 선택된 에셋들을 체크하거나 해제합니다.
* 필터, 필터 해제
    * 선택된 에셋들의 경로를 필터링하여 검색에서 제외하거나 포함합니다.
* 에셋 제거, 에셋 복구
    * 선택된 에셋들을 제거하거나, 복구합니다.

![4_unusedAsset_filter.gif](./images/4_unusedAsset_filter.gif)
* 필터링 설정을 통해 나오는 목록을 선별할 수 있습니다.
    * Filter Built-in
        * Resources 하위 폴더, 프로젝트 설정 또는 기본 포함 씬등 빌드할 때 포함되는 리소스를 제외합니다.
    * Filter Assetbundles
        * Assetbundle로 지정된 리소스들을 제외합니다.
    * Filter Path List
        * path에 아래 리스트의 문자열이 포함되면 제외합니다.

## 따라 하기
### 기존 에셋을 교체하고 안전하게 삭제해 보기
Sample에서 새로운 폰트 파일로 교체하고 기존 폰트를 삭제해 봅니다.
* [Sample 다운로드](./sample/assetmanagement_sample.unitypackage)
* Sample 폰트 연결 구성
    * 씬
        * SampleScene
            * Text - arial
            * Text2 - arial
            * Text3 - Langar-Regular
            * Text4 - Langar-Regular
            * Text5 - arial
            * Text6 - Langar-Regular
            * Text7 - arial
    * 프리팹
        * SampleUI
            * Text - Langar-Regular
        * SampleUI2
            * Text - arial
            * Text2 - Langar-Regular
            * Text2 - Langar-Regular
            * Text3 - arial
        * SampleUI3
            * Text - arial

* 목표
    * Langar-Regular 폰트 NanumGothic-ExtraBold폰트로 교체
    * Langar-Regular 폰트 제거.

#### 1. 에셋 맵으로 Langar-Regular가 사용되는지 확인해 봅니다.
에셋맵으로 에셋이 어느 에셋에서 사용하는지 관계를 알 수 있습니다.
* 프로젝트에서 Langar-Regular를 선택합니다.
* 인스팩터의 Show AssetMap 버튼을 통해 에셋맵 열어 확인할 수 있습니다.
    ![sample_1.gif](./sample/images/sample_1.gif)

#### 2. Langar-Regular를 제거하면 문제가 발생합니다. 
에셋이 연결되있는데 지우게 되면 연결돼있던 에셋에 문제가 발생합니다.
* 문제가 생긴 에셋은 에셋 맵에서 표시해줍니다.
* 문제 있는 전체 에셋은 이슈 체크를 통해 추적하고 해결할 수 있습니다.
![sample_2.gif](./sample/images/sample_2.gif)

#### 3. 본격적으로 폰트를 다른 폰트로 바꿔봅시다. 
에셋맵으로 Langar-Regular가 어느 에셋에서 사용 중인지는 파악했습니다.
그러나 에셋 어디에서 사용되는지는 아직 정확히 알 수 없습니다. 
에셋 찾기를 통해 어디에서 사용되는지 정확히 알 수 있습니다. 
* 에셋맵 그래프 노드의 레퍼런스 검색 버튼을 통해 에셋 찾기를 할 수 있습니다.
    ![sample_3.gif](./sample/images/sample_3.gif)

#### 4. SampleScene에 연결된 폰트를 바꿔봅시다.
에셋 찾기는 GPM Find Reference메뉴를 통해도 찾을 수 있습니다.
어디에서 사용되는지 알 수 있으며 교체도 가능합니다. Test3에 연결된 폰트를 바꿔봅니다.
* 에셋 찾기의 아이템을 더블클릭하면 사용하는 지점이 선택됩니다.
* Test3 아이템 하위를 열면 연결된 정보가 보입니다. 
* 바꾸기 사용 옵션 체크 후 연결 정보에 NanumGothic-ExtraBold 넣고 바꿀 수 있습니다.
![sample_4.gif](./sample/images/sample_4.gif)

#### 5. 나머지 폰트도 직접 바꿔봅시다.
에셋 찾기는 크게 계층(hierarchy) 뷰와 프로젝트 뷰로 분류됩니다.
계층(hierarchy)에 열려있는 신(scene)의 폰트를 전부 바꿔줍시다.
그리고 프로젝트의 SampleUI2 프리팹을 열어서 바꿔봅시다.
* 계층(hierarchy) 뷰는 현재 열려있는 신(scene)과 프리팹을 보여줍니다.
* 프로젝트 뷰는 프로젝트에 저장돼있는 에셋들을 보여줍니다.
![sample_5.gif](./sample/images/sample_5.gif)

#### 6. 저장 후 프로젝트에서도 확인해봅시다.
계층(hierarchy)에서 수정한 것은 즉시 파일로 저장되지 않습니다. 
프로젝트를 확인해보았을 때 바뀌지 않은 것을 확인할 수 있습니다. 
* 저장 시 파일이 변경되어 프로젝트에도 적용됩니다.
![sample_6.gif](./sample/images/sample_6.gif)

#### 7. 프로젝트에서도 직접 교체해봅시다.
프로젝트에 있는 에셋을 직접 교체할 수도 있습니다.
* 프로젝트에서 바꾸기 할 때는 즉시 저장됩니다.
![sample_7.gif](./sample/images/sample_7.gif)

#### 8. 마무리
다시 검색하여 연결된 것이 있는지 확인해 봅니다.
전부 교체했기 때문에 레퍼런스가 없는 것을 확인했습니다.
새로운 폰트를 확인해봤을 떄 전부 교체된 것을 확인할 수 있습니다.
* 전부 교체했다면 기존 폰트에는 연결된 에셋이 없어서 삭제해도 무방합니다.
![sample_8.gif](./sample/images/sample_8.gif)
