using UnityEngine;

namespace Shells.Tank {
    public class TankLightShell : MonoBehaviour {
        [SerializeField] private ParticleSystem explosionPs, trailPs;

        private CapsuleCollider2D _capsuleCollider2D;
        private SpriteRenderer _sr;
        private Rigidbody2D _rb;

        private ParticleSystem.EmissionModule _explosionEmMod, _trailEmMod;

        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
            _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }

        private void Start() {
            _explosionEmMod = explosionPs.emission;
            _trailEmMod = trailPs.emission;
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("TowerObj") || col.gameObject.CompareTag("WorldBorder") || col.gameObject.CompareTag("Wall")) {
                DestroyShell();
            }
        }

        private void OnTriggerExit2D(Collider2D col) {
            if (col.gameObject.CompareTag("LightShellGhost")) {
                DestroyShell();
            }
        }

        private void DestroyShell() {
            _rb.velocity = new Vector2(0, 0);
            _explosionEmMod.enabled = true;
            _trailEmMod.enabled = false;
            
            _sr.enabled = false;
            _capsuleCollider2D.enabled = false;

            Invoke(nameof(DestroyObj), 0.5f);
        }

        private void DestroyObj() {
            Destroy(gameObject);
        }
    }
}