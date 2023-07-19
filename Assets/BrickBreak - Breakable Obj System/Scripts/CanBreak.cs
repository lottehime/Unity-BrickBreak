using UnityEngine;

namespace lottehime.BrickBreak
{
	public class CanBreak : MonoBehaviour
	{
		Vector3 _breakerVelocity;
		Breakable _Obj;

		void FixedUpdate()
		{
			_breakerVelocity = GetComponent<Rigidbody>().velocity;
		}

		void OnCollisionEnter(Collision col)
		{
			if (col.gameObject != null && col.gameObject.GetComponent<Breakable>() == null) return;

			if (col.gameObject == null) return;
			_Obj = col.gameObject.GetComponent<Breakable>();
			GetComponent<Rigidbody>().velocity = _breakerVelocity * _Obj.ObjectSlowdownFactor;

			if (!_Obj.VelocityBreaksObject) return;

			if (!(col.relativeVelocity.magnitude >= _Obj.RequiredVelocity)) return;
			col.gameObject.GetComponent<Breakable>().Break();
		}
	}
}