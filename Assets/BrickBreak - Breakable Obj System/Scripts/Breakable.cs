using UnityEngine;
using System.Collections.Generic;

namespace lottehime.BrickBreak
{
    public class Breakable : MonoBehaviour
    {
        public bool VelocityBreaksObject = true;
        public float RequiredVelocity = 2.0f;
        public bool ClickBreaksObject = false;
        public bool BrokenPiecesExpire = false;
        public bool BreakSound = true;
        public GameObject BreakAudioOneShot;
        public float OneShotAudioLifetime = 2.0f;
        public List<GameObject> BrokenObjectVariants;
        public float ObjectSlowdownFactor = 0.65f;
        public float BrokenObjectPieceMass = 0.35f;

        private float _brokenPieceDecayTime;
        private GameObject _brokenObj;

        void Awake()
        {
            _brokenPieceDecayTime = BrokenPiecesExpire ? 4.0f : 0.0f;
        }

        public void Break()
        {
            if (BrokenObjectVariants != null)
            {
                _brokenObj =
                    Instantiate(BrokenObjectVariants[Random.Range(0, BrokenObjectVariants.Count)], transform.position,
                        transform.rotation) as GameObject;

                if (_brokenObj != null)
                {
                    _brokenObj.transform.localScale = transform.lossyScale;

                    foreach (Transform shardObj in _brokenObj.transform)
                    {
                        shardObj.GetComponent<Rigidbody>().mass = BrokenObjectPieceMass;
                    }

                    if (BreakSound)
                        Destroy(Instantiate(BreakAudioOneShot, transform.position, transform.rotation) as GameObject,
                            OneShotAudioLifetime);

                    if (_brokenPieceDecayTime > 0) Destroy(_brokenObj, _brokenPieceDecayTime);
                }

                Destroy(gameObject);
            }
            else
            {
                Debug.Log("You have not assigned a broken object variant to this object: " +
                            gameObject +
                            "\nPlease assign one under 'Broken Object Variants' in the inspector.");
            }
        }

        void OnMouseDown()
        {
            if (ClickBreaksObject)
            {
                Break();
            }
        }
    }
}