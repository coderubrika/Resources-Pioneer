namespace Assets.Scripts.Utils
{
    public enum ManipulationMode
    {
        Position, Rotation, Scale
    }

    public enum UpdateMode
    {
        FixedUpdate, Update, LateUpdate, BeforeRender
    }

    public enum MonoHooksNoParamEnum
    {
        FixedUpdate, Update, LateUpdate, BeforeRender, OnEnable, OnDisable,
        Awake, Start, OnDestroy
    }

    public enum MonoHooksWithParamEnum
    {
        OnTriggerEnter, OnTriggerExit, OnTriggerStay, OnCollisionEnter, OnCollisionExit, OnCollisionStay
    }

    [System.Serializable]
    public struct KeyValuePairStruct<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
    }

    public enum ResourceType { A, B, C};
}
