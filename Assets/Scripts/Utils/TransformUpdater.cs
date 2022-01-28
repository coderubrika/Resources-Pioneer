using System.Collections.Generic;
using UnityEngine;

public enum VectorType
{
    Position,
    Rotation,
    Scale
}

public enum UpdateType
{
    None,
    Update,
    LateUpdate,
    FixedUpdate,
    BeforeRender,
    AllUpdates
}

public class TransformUpdater : MonoBehaviour
{
    [Tooltip("If null, then use this transform")]
    public Transform Self;

    public List<Transform> Targets;
    public VectorUpdate[] VectorUpdates;

    public UpdateType UpdateType = UpdateType.Update;

    private void Awake()
    {
        if (!Self)
            Self = transform;
    }

    private void Update()
    {
        if (UpdateType == UpdateType.Update || UpdateType == UpdateType.AllUpdates)
            UpdateVectors();
    }

    private void FixedUpdate()
    {
        if (UpdateType == UpdateType.FixedUpdate || UpdateType == UpdateType.AllUpdates)
            UpdateVectors();
    }

    private void LateUpdate()
    {
        if (UpdateType == UpdateType.LateUpdate || UpdateType == UpdateType.AllUpdates)
            UpdateVectors();
    }

    private void BeforeRender()
    {
        if (UpdateType == UpdateType.BeforeRender || UpdateType == UpdateType.AllUpdates)
            UpdateVectors();
    }

    private void UpdateVectors()
    {
        foreach (var t in Targets)
            foreach (var i in VectorUpdates)
                i.UpdateTransform(Self, t);
    }

    private void OnEnable()
    {
        Application.onBeforeRender += BeforeRender;
    }

    private void OnDisable()
    {
        Application.onBeforeRender -= BeforeRender;
    }
}

[System.Serializable]
public struct VectorUpdate
{
    public bool UpdateX;
    public bool UpdateY;
    public bool UpdateZ;
    public VectorType Type;
    public bool InWorldSpace;
    private Vector3 prevRot;

    public void UpdateTransform(Transform self, Transform target)
    {
        switch (Type)
        {
            case VectorType.Position:
                UpdatePosition(self, target);
                break;
            case VectorType.Rotation:
                UpdateRotation(self, target);
                break;
            case VectorType.Scale:
                UpdateScale(self, target);
                break;
        }
    }

    private void UpdatePosition(Transform self, Transform target)
    {
        Vector3 newPos = InWorldSpace ? target.position : target.localPosition;
        if (UpdateX)
            newPos.x = InWorldSpace ? self.position.x : self.localPosition.x;
        if (UpdateY)
            newPos.y = InWorldSpace ? self.position.y : self.localPosition.y;
        if (UpdateZ)
            newPos.z = InWorldSpace ? self.position.z : self.localPosition.z;
        if (InWorldSpace)
            target.position = newPos;
        else
            target.localPosition = newPos;
    }

    private void UpdateRotation(Transform self, Transform target)
    {
        if (prevRot == null)
            if (InWorldSpace)
                prevRot = new Vector3(target.eulerAngles.x, target.eulerAngles.y, target.eulerAngles.z);
            else
                prevRot = new Vector3(target.localEulerAngles.x, target.localEulerAngles.y, target.localEulerAngles.z);
        if (UpdateX)
            prevRot.x = InWorldSpace ? self.eulerAngles.x : self.localEulerAngles.x;
        if (UpdateY)
            prevRot.y = InWorldSpace ? self.eulerAngles.y : self.localEulerAngles.y;
        if (UpdateZ)
            prevRot.z = InWorldSpace ? self.eulerAngles.z : self.localEulerAngles.z;
        if (InWorldSpace)
            target.rotation = Quaternion.Euler(prevRot);
        else
            target.localRotation = Quaternion.Euler(prevRot);
    }

    private void UpdateScale(Transform self, Transform target)
    {
        Vector3 newScale = target.localScale;
        if (UpdateX)
            newScale.x = self.localScale.x;
        if (UpdateY)
            newScale.y = self.localScale.y;
        if (UpdateZ)
            newScale.z = self.localScale.z;
        target.localScale = newScale;
    }
}