using UnityEngine;

[ExecuteAlways]
public class Follow : MonoBehaviour
{
    [System.Serializable]
    public struct Vector3Bool
    {
        public bool x;
        public bool y;
        public bool z;
    }

    [Header("Position")]
    public Vector3Bool _PositionBool;
    public Vector3Bool _RotationBool;
    public Transform Target;
    [SerializeField] Vector3 _Offset;
    public bool DeleteIfNull;

    void Update()
    {
        if (Target != null)
        {
            Vector3 Position = new Vector3(_PositionBool.x ? Target.position.x : 0, _PositionBool.y ? Target.position.y : 0, _PositionBool.z ? Target.position.z : 0);
            Vector3 Rotation = new Vector3(_RotationBool.x ? Target.eulerAngles.x : 0, _RotationBool.y ? Target.eulerAngles.y : 0, _RotationBool.z ? Target.eulerAngles.z : 0);
            transform.position = Position + _Offset;
            transform.rotation = Quaternion.Euler(Rotation);
        }
        else if (DeleteIfNull)
            Destroy(gameObject);
    }
}
