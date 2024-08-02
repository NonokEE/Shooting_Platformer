using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;
using TMPro;

namespace Stage
{
    public class HitFeedback
    {
        public  Character Sender{ get; private set; }
        //TODO 피격무적 관련 옵션
        //TODO 체력바 관련 옵션
        //~ Invicator ~//
        public IIndicator Indicator;
        public bool showLog = true;

        public HitFeedback(Character character)
        {
            Sender = character;
        }
        public void Invoke(Attack attack, int damage)
        {
            if(showLog) Debug.Log("("+ Sender.name + ") got ("+ damage + ")damage by (" + attack.AttackInfo.Attacker.name + ") with (" + attack.AttackInfo.Weapon.name + ")");
            Indicator.Invoke(damage);
        }
    }

    /******* Indicator *******/
    // 피격시 데미지 표시 //
    public interface IIndicator 
    { 
        public Character Sender{ get; } 
        public void Invoke(int damage); 
        public void Initiate(Character sender);
    }
    public class NoIndicator : IIndicator 
    { 
        public NoIndicator(Character sender){ this.sender = sender; }
        private Character sender;
        public Character Sender{ get{ return sender; } } 

        public void Invoke(int damage){} 
        public void Initiate(Character sender){}
    }
    public class BasicIndicator : MonoBehaviour, IIndicator
    {
        /******* FIELD *******/
        //~ Properties ~//
        [Header("Indicator Attributes")]
        public TMP_Text textPrefab;
            [Space]
        
        [SerializeField] private Character sender;
        public Character Sender{ get{ return sender; } } 

        [Header("Option")]
        //TODO 인티케이터 타입: 떠오르기, 흔들리기 등등
        //타입별 파라미터 지정
        public Vector2 StartOffset;
        public Vector2 EndValue;
        public float Duration;

        public void Invoke(int damage)
        {
            TMP_Text text = Instantiate(textPrefab, sender.transform);

            text.name = sender.name + " HitIndicator";
            text.text = damage.ToString();
            text.rectTransform.anchoredPosition = StartOffset;

            Tween moveTween = text.transform.DOMove(text.transform.position + new Vector3(EndValue.x, EndValue.y), Duration).SetEase(Ease.OutQuart);
            moveTween.Play();
            moveTween.OnComplete(()=>
            {
                moveTween.Kill();
                Destroy(text.gameObject);
            });
        }
        public void Initiate(Character sender)
        {
            this.sender = sender;

            DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10);
        }
    }
}