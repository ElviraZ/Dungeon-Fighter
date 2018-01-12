using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Global;
using Kernal;
/// <summary>
/// 主角的攻击
/// </summary>
namespace Ctrl
{
    public class Ctrl_HeroAttack : BaseControl
    {


        private List<GameObject> enemyList = new List<GameObject>();//敌人list
        public Transform nearestEnemy = null;//最近的那个敌人

        float disMax = 10f;
        float disMin = 5f;//最小的关注范围
        public float attackDis = 2f;//实际有效攻击距离
        private float rotationSpeed = 1f;

        private void Awake()
        {
            //事件注册
            Ctrl_HeroAttackInputByKey.evePlayerControl += ResponseNormalAttack;
            Ctrl_HeroAttackInputByKey.evePlayerControl += ResponseMagicTrickA;
            Ctrl_HeroAttackInputByKey.evePlayerControl += ResponseMagicTrickB;
        }
        #region 响应输入控制


        public void ResponseNormalAttack(string contrlType)
        {
            if (contrlType == GloabalParameter.NormalAttackInput)
            {
                Ctrl_HeroAnimationCtrl._Instance.SetCurActionState(HeroActionState.NormalAttack);
                AttackEnemyNormal();
            }
        }
        public void ResponseMagicTrickA(string contrlType)
        {
            if (contrlType == GloabalParameter.MagicTrickAInput)
            {
                Ctrl_HeroAnimationCtrl._Instance.SetCurActionState(HeroActionState.MagicTrickA);

            }
        }
        public void ResponseMagicTrickB(string contrlType)
        {
            if (contrlType == GloabalParameter.MagicTrickBInput)
            {
                Ctrl_HeroAnimationCtrl._Instance.SetCurActionState(HeroActionState.MagicTrickB);

            }
        }
        #endregion

        /*    攻击的开发思路
        * 
        *    1、将附近的敌人放入“敌人数组” 
        *                RecordAllEnemy()
        *    2、注视范围内的最近的一个’
        *   
        *    3、响应攻击，并给与伤害
        * 
        * 
        * 
        * */
        private void Start()
        {
            StartCoroutine("RecordAllEnemy");
            StartCoroutine("HeroLookAtEnemy");
        }
        #region 将附近的敌人加入集合并找出最近的那个
        IEnumerator RecordAllEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(GloabalParameter.waitfortime_2);
                GetEnemiesToArray();
                GetNearestEnemy();
            }
        }

        private void GetEnemiesToArray()
        {
            enemyList.Clear();
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tag.Enemy);
            foreach (GameObject item in enemies)
            {
                //t判断敌人是否是活的，再处理
                Ctrl_Enemy enemy = item.GetComponent<Ctrl_Enemy>();
                if (enemy.IsAlive && enemy)
                {
                    enemyList.Add(item);
                }
            }
            //去重
            for (int i = 0; i < enemyList.Count; i++)
            {
                for (int j = 0; j < enemyList.Count - 1; j++)
                {
                    if (enemyList[i].name == enemyList[j].name)
                    {
                        enemyList.RemoveAt(j);
                    }
                }
            }
        //    Debug.Log(enemyList.Count);
        }

        public void GetNearestEnemy()
        {
            if (enemyList == null || enemyList.Count == 0)
                return;

            foreach (GameObject item in enemyList)
            {
                float dis = Vector3.Distance(this.gameObject.transform.position, item.transform.position);
                if (dis < disMax)
                {
                    disMax = dis;
                    nearestEnemy = item.transform;
                }
            }

        }

        #endregion

        #region 面向最近的那个敌人
        IEnumerator HeroLookAtEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(GloabalParameter.waitfortime_0D5);
                if (nearestEnemy != null && Ctrl_HeroAnimationCtrl._Instance.CurActionState == HeroActionState.Idle)
                {
                    float dis = Vector3.Distance(this.gameObject.transform.position, nearestEnemy.transform.position);
                    if (dis < disMin)
                    {
                        this.transform.rotation =
                            Quaternion.Slerp(
                                               this.transform.rotation,
                                               Quaternion.LookRotation(new Vector3(nearestEnemy.position.x, 0, nearestEnemy.position.z) - new Vector3(this.gameObject.transform.position.x, 0, this.transform.position.z)),
                                               rotationSpeed);
                    }
                }
            }
        }

        #endregion
        #region 攻击伤害处理
        public void AttackEnemyNormal()
        {
            if (enemyList == null || enemyList.Count == 0)
            {
                nearestEnemy = null;
                return;
            }
            foreach (GameObject item in enemyList)
            {
                if (item.GetComponent<Ctrl_Enemy>().isAlive)
                {
                    float dis = Vector3.Distance(this.gameObject.transform.position, item.transform.position);
                    Vector3 dir = (item.transform.position - this.transform.position).normalized;
                    float angle = Vector3.Dot(dir, this.transform.forward);
                    if (angle > 0 && dis <= attackDis)
                    {
                        //假设攻击值为10
                        item.SendMessage("OnHurt", 10f, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
        #endregion

    }
}
