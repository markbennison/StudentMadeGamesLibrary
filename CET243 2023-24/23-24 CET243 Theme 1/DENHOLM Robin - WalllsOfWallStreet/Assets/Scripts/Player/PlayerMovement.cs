using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb;
    public InputActionAsset asset;
    public InputActionReference moveAction, jumpAction, grabRightAction, grabLeftAction;
    public float moveSpeed, jumpHeight, throwHeight, maxGroundVelocity, maxAirVelocity, launchForce;
    public GameObject leftHand, rightHand;
    bool isGrounded, hasGrabbed, hasGrabbedSinceLeavingGround, canGrabLeft, canGrabRight;
    CapsuleCollider2D mainCollider;
    SpriteRenderer leftHandSPR;
    SpriteRenderer rightHandSPR;
    SpriteRenderer playerSPR;

    public GameObject movementTip;
    public GameObject climbingTip;
    public GameObject attackTip;
    
    public GameObject winScreen;
    public GameObject deathScreen;
    public TMP_Text trowelTextUI;
    public TMP_Text trowelTextWin;
    public TMP_Text trowelTextDied;

    public int health = 3;
    public Sprite[] sprites = new Sprite[3];

    private Coroutine followCurveCoroutine;

    public int trowels;
    public float cooldown;
    private float timeStamp;

    public bool movementTipZone, climbingTipZone, attackTipZone;
    private void OnEnable()
    {
        asset.Enable();
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void Start() {
        leftHandSPR = leftHand.GetComponent<SpriteRenderer>();
        rightHandSPR = rightHand.GetComponent<SpriteRenderer>();
        playerSPR = this.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate() {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        isGrounded = IsCollidingWithTag(groundCheckPos, colliderRadius, "Ground");
        canGrabRight = IsCollidingWithTag(rightHand.transform.position, 0.25f, "Climbable");
        canGrabLeft = IsCollidingWithTag(leftHand.transform.position, 0.25f, "Climbable");

        bool isWinner = IsCollidingWithTag(transform.position, colliderRadius, "Win");
        if(isWinner) {
            trowelTextWin.text = $"Trowels: {this.trowels}/45";
            winScreen.SetActive(true);
            this.gameObject.SetActive(false);
        }

        GameObject launcher = GetCollidingWithTag(transform.position, colliderRadius, "Launcher");
        if (launcher != null && launcher.TryGetComponent<LauncherHandler>(out LauncherHandler launcherHandler)) {
            followCurveCoroutine = StartCoroutine(launcherHandler.FollowParabolicCurve(gameObject));
        }
        GameObject trowel = GetCollidingWithTag(transform.position, colliderRadius, "Trowel");
        if (trowel != null) {
            trowels++;
            trowelTextUI.text = $"x{this.trowels}";
            Destroy(trowel);
        }

        movementTipZone = IsCollidingWithTag(transform.position, colliderRadius, "MovementTip");
        if (movementTipZone) {
            movementTip.SetActive(true);
        } else {
            movementTip.SetActive(false);
        }

        climbingTipZone = IsCollidingWithTag(transform.position, colliderRadius, "ClimbingTip");
        if (climbingTipZone) {
            climbingTip.SetActive(true);
        } else {
            climbingTip.SetActive(false);
        }

        attackTipZone = IsCollidingWithTag(transform.position, colliderRadius, "AttackTip");
        if (attackTipZone) {
            attackTip.SetActive(true);
        } else {
            attackTip.SetActive(false);
        }


        if (grabRightAction.action.ReadValue<float>() > 0) {
            rightHandSPR.color = Color.green;
        } else {
            rightHandSPR.color = Color.blue;
        }

        if (grabLeftAction.action.ReadValue<float>() > 0) {
            leftHandSPR.color = Color.green;
        } else {
            leftHandSPR.color = Color.blue;
        }

        if (canGrabLeft && canGrabRight) {
            if (grabRightAction.action.ReadValue<float>() > 0 && grabLeftAction.action.ReadValue<float>() > 0) {
                rb.velocity = Vector3.zero;
                hasGrabbed = true;
                hasGrabbedSinceLeavingGround = true;
            }
        }
        if (canGrabRight) {
            if (grabRightAction.action.ReadValue<float>() > 0 && grabLeftAction.action.ReadValue<float>() == 0) {
                rb.velocity = Vector3.zero;
                transform.RotateAround(rightHand.transform.position, Vector3.back, 200 * Time.deltaTime);
                hasGrabbed = true;
                hasGrabbedSinceLeavingGround = true;
            }
        }
        if (canGrabLeft) {
            if (grabLeftAction.action.ReadValue<float>() > 0 && grabRightAction.action.ReadValue<float>() == 0) {
                rb.velocity = Vector3.zero;
                transform.RotateAround(leftHand.transform.position, Vector3.forward, 200 * Time.deltaTime);
                hasGrabbed = true;
                hasGrabbedSinceLeavingGround = true;
            }
        }

        if (moveAction.action.ReadValue<float>() == 0 && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x * Time.deltaTime, rb.velocity.y);
        }
        if (hasGrabbed && (grabRightAction.action.ReadValue<float>() == 0 && grabLeftAction.action.ReadValue<float>() == 0)) {
            Vector3 newForce = (transform.up * throwHeight);
            rb.velocity += new Vector2(newForce.x, newForce.y);
            hasGrabbed = false;
        }
        if (isGrounded) {
            hasGrabbedSinceLeavingGround = false;
            transform.rotation = Quaternion.Euler(Vector3.zero);
            rb.velocity += new Vector2(0, jumpAction.action.ReadValue<float>() * jumpHeight);
        }
        if ((isGrounded && Math.Abs(rb.velocity.x) < maxGroundVelocity) || (!isGrounded && Math.Abs(rb.velocity.x) < maxAirVelocity)) {
            rb.velocity += new Vector2(moveAction.action.ReadValue<float>() * moveSpeed, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            if (rb.velocity.magnitude >= 17 && !isGrounded && hasGrabbedSinceLeavingGround) {
                SpriteRenderer spr = collision.gameObject.GetComponent<SpriteRenderer>();
                Collider2D col = collision.gameObject.GetComponent<Collider2D>();
                col.enabled = false;
                spr.color = Color.red;
                Destroy(collision.gameObject, 0.25f);
                rb.velocity = Vector3.Reflect(rb.velocity, Vector3.up) / 2f;
            } else if(timeStamp <= Time.time) {
                health--;
                UpdateSprite();
                timeStamp = Time.time + cooldown;
                if (health <= 0) {
                    trowelTextDied.text = $"Trowels: {this.trowels}/45";
                    deathScreen.SetActive(true);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }



    private void UpdateSprite() {
        int index = Math.Clamp(health-1, 0, this.sprites.Length);
        playerSPR.sprite = this.sprites[index];
    }

    private Boolean IsCollidingWithTag(Vector3 position, float radius, string tag) {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius);
        if (colliders.Length > 0) {
            for (int i = 0; i < colliders.Length; i++) {
                if (colliders[i].CompareTag(tag)) {
                    return true;
                }
            }
        }
        return false;
    }

    private GameObject GetCollidingWithTag(Vector3 position, float radius, string tag) {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius);
        if (colliders.Length > 0) {
            for (int i = 0; i < colliders.Length; i++) {
                if (colliders[i].CompareTag(tag)) {
                    return colliders[i].gameObject;
                }
            }
        }
        return null;
    }
    
}
