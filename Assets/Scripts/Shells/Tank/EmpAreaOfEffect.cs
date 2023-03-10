using Enemy.Tower;
using ScriptableObjects;
using UnityEngine;

namespace Shells.Tank {
    public class EmpAreaOfEffect : MonoBehaviour {
        [SerializeField] private TankStatsSo tankStatsSo;
        private CircleCollider2D _circleCollider2D;

        private void Awake() {
            _circleCollider2D = GetComponent<CircleCollider2D>();
            _circleCollider2D.radius = tankStatsSo.EmpShellStatsSo.AoeRadius * 0.81f; // 0.81f is the 1xunit in real world, in terms of scaling, for hollow circle
        }

        public void EnableCircleCollider() {
            _circleCollider2D.enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("TowerObj")) {
                if (!col.gameObject.transform.Find("Turret")) return;
                col.gameObject.transform.Find("Turret").GetComponent<TurretController>().IsPowerOff = true;
            }
        }
    }
}