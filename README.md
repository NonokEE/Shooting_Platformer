# Shooting Platformer
유니티 2D 기반 횡스크롤 액션을 구현하며 물리 상호작용 및 실시간 액션에 필요한 구현 기법을 습득하기 위한 프로젝트

## 프로젝트 개요
유니티 에디터 버전: 2022.3.22.f1</br>
플랫폼: PC</br>

## 진행중

> 적 캐릭터 이동 기능 및 인공지능 부여


## 작업 현황

- [x]  FSM 구현
- [x]  싱글톤    
- [x]  ESC 누르면 메뉴창 띄우기(무기 테스트용)
- [x]  무한체력 허수아비
- [x]  팔레트맵 기반 스테이지 구성
    - [x]  일방향 플랫폼
- [ ]  피격시 이펙트
    - [ ]  피격시 무적
    - [x]  인디케이터 
    - [ ]  체력바
- [ ]  캐릭터 컨트롤러
  - [ ] 플레이어 컨트롤러
    - [x]  MoveStrategy
    - [x]  AttackStrategy
        - [x]  공격: 조작 타입 구현
        - [ ]  공격: 공격체 타입 구현           
            - [x]  투사체
                - [x]  직사
                    - [x]  데미지, 관통 횟수
                - [x]  곡사
                    - [x]  thrower
                        - [x]  투척기 바닥 튕기는 횟수 or 시간                            
                - [ ]  유도
                - [ ]  부메랑
            - [ ]  히트스캔
            - [ ]  좌표생성
            - [ ]  오브젝트
                - [ ]  장판
                - [ ]  폭발
            - [ ]  버프
            - [ ]  디버프
        - [ ]  공격 이펙트
      - [ ]  스킬 구현
  - [ ]  적 인공지능
- [ ]  UI 구성
    - [ ]  패널 블러
- [ ]  무기, 스킬 이펙트
