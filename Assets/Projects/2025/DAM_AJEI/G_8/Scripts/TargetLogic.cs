using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EntilandVR.DosCinco.DAM_AJEI.G_Ocho
{
    public class TargetLogic : MonoBehaviour
    {
        //Definimos un enum para los difarantes tipos de targets
        enum TargetType { NORMAL, OBSTACLE, SPECIAL }

        [SerializeField] private GameObject _brokenTarget;
        [SerializeField] private GameObject _targetChild;
        [SerializeField] private TargetType _targetType;

        //Lógica al impactar una bala
        void TargetHit()
        {
            switch (_targetType)
            {
                case TargetType.NORMAL:
                    NormalTargetHit(); // ScoreManagerSingleton.Instance.AddScore(100);
                    break;
                case TargetType.OBSTACLE:
                    ObstacleTargetHit(); // ScoreManagerSingleton.Instance.AddScore(500);
                    break;
                case TargetType.SPECIAL:
                    SpecialTargetHit(); // ScoreManagerSingleton.Instance.AddScore(-100);
                    break;
                default:
                    break;
            }
        }

        void NormalTargetHit()
        {
            ScoreManagerSingleton.Instance.AddScore(100);
        }

        void SpecialTargetHit()
        {
            ScoreManagerSingleton.Instance.AddScore(500);
        }

        void ObstacleTargetHit()
        {
            ScoreManagerSingleton.Instance.AddScore(-100);
        }

        //Tempotizador de respawn de targets
        IEnumerator WaitForSecondsAndActivateTarget(float _seconds, GameObject brokenTarget)
        {
            yield return new WaitForSeconds(_seconds);
            Destroy(brokenTarget);
            TargetEnabled(true);
        }

        //Activar/desactivar targets
        private void TargetEnabled(bool _enableTarget)
        {
            _targetChild.SetActive(_enableTarget);
        }

        //Lógica de colisión
        private void OnTriggerEnter(Collider other)
        {
            switch (_targetType)
            {
                case TargetType.NORMAL:

                    if (other.transform.tag == "Ball")
                    {
                        TargetEnabled(false);
                        TargetHit();
                        //Spawnear // ordenar en la jerarquia porqwue aparece en la raíz //Colocar su posicion
                        GameObject instantiatedBrokenTarget = Instantiate(_brokenTarget, transform);
                        instantiatedBrokenTarget.transform.position = this.transform.position;
                        instantiatedBrokenTarget.transform.localEulerAngles = new Vector3(0, -90, 90);
                        StartCoroutine(WaitForSecondsAndActivateTarget(3,instantiatedBrokenTarget));
                    }
                    break;
                case TargetType.OBSTACLE:
                    if (other.transform.tag == "Ball")
                    {
                        TargetHit();
                    }
                    break;
                case TargetType.SPECIAL:
                    if (other.transform.tag == "Ball")
                    {
                        TargetEnabled(false);
                        TargetHit();
                        //Spawnear // ordenar en la jerarquia porqwue aparece en la raíz //Colocar su posicion
                        GameObject instantiatedBrokenTarget = Instantiate(_brokenTarget, transform);
                        instantiatedBrokenTarget.transform.position = this.transform.position;
                        instantiatedBrokenTarget.transform.localEulerAngles = new Vector3(0, -90, 90);
                        StartCoroutine(WaitForSecondsAndActivateTarget(3, instantiatedBrokenTarget));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}