using UnityEngine;

public class PointInTime
{
    public Vector3 position;
    public Quaternion rotation;
    public Rigidbody2D rigidbody;
    public bool animIsFalling, animUp, animIsHolding, animPlayerAttack, animIsCrouching;
    public float animHorizontal;

    public PointInTime(Vector3 _position, bool _animIsFalling, bool _animUp, bool _animIsHolding, bool _animPlayerAttack, bool _animIsCrouching, float _animHorizontal)
    {
        this.position = _position;
        this.animIsFalling = _animIsFalling;
        this.animUp = _animUp;
        this.animIsHolding = _animIsHolding;
        this.animPlayerAttack = _animPlayerAttack;
        this.animIsCrouching = _animIsCrouching;
        this.animHorizontal = _animHorizontal;
    }
}