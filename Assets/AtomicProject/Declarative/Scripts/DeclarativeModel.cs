using System;
using System.Collections.Generic;
using UnityEngine;

namespace Declarative
{
    public abstract class DeclarativeModel : MonoBehaviour
    {
        public Action onAwake;
        public Action onEnable;
        public Action onStart;
        public Action<float> onUpdate;
        public Action<float> onFixedUpdate;
        public Action<float> onLateUpdate;
        public Action onDisable;
        public Action onDestroy;

        private Dictionary<Type, object> sections;
        private MonoContext monoContext;
        private List<IDisposable> disposables;

        internal object GetSection(Type type)
        {
            return this.sections[type];
        }

        internal bool TryGetSection(Type type, out object section)
        {
            return this.sections.TryGetValue(type, out section);
        }

        private void Awake()
        {
            this.monoContext = new MonoContext(this);
            this.disposables = new List<IDisposable>();
            this.sections = SectionScanner.ScanSections(this);

            foreach (var section in this.sections.Values)
            {
                MonoContextInstaller.RegisterElements(section, this.monoContext, this.disposables);
                SectionConstructor.ConstructSection(section, this);
            }

            this.monoContext.Awake();
            this.onAwake?.Invoke();
        }

        private void OnEnable()
        {
            this.monoContext.OnEnable();
            this.onEnable?.Invoke();
        }

        private void Start()
        {
            this.monoContext.Start();
            this.onStart?.Invoke();
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            this.monoContext.FixedUpdate(deltaTime);
            this.onFixedUpdate?.Invoke(deltaTime);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            this.monoContext.Update(deltaTime);
            this.onUpdate?.Invoke(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            this.monoContext.LateUpdate(deltaTime);
            this.onLateUpdate?.Invoke(deltaTime);
        }

        private void OnDisable()
        {
            this.monoContext?.OnDisable();
            this.onDisable?.Invoke();
        }

        private void OnDestroy()
        {
            this.monoContext?.OnDestroy();
            this.onDestroy?.Invoke();
            
            if (this.disposables != null)
            {
                foreach (var disposable in this.disposables)
                {
                    disposable.Dispose();
                }
            }
            
            DelegateUtils.Dispose(ref this.onAwake);
            DelegateUtils.Dispose(ref this.onEnable);
            DelegateUtils.Dispose(ref this.onStart);
            DelegateUtils.Dispose(ref this.onUpdate);
            DelegateUtils.Dispose(ref this.onFixedUpdate);
            DelegateUtils.Dispose(ref this.onLateUpdate);
            DelegateUtils.Dispose(ref this.onDisable);
            DelegateUtils.Dispose(ref this.onDestroy);
        }

#if UNITY_EDITOR
        
        public Action onDrawGizmos;
        public Action onDrawGizmosSelected;
        
        [ContextMenu("Construct")]
        private void Construct()
        {
            this.Awake();
            this.OnEnable();
            Debug.Log($"<color=#FF6235>: {this.name} successfully constructed!</color>");
        }

        [ContextMenu("Destruct")]
        private void Destruct()
        {
            this.OnDisable();
            this.OnDestroy();
            Debug.Log($"<color=#FF6235>: {this.name} successfully destructed!</color>");
        }
        
        private void OnDrawGizmos()
        {
            this.onDrawGizmos?.Invoke();
        }

        private void OnDrawGizmosSelected()
        {
            this.onDrawGizmosSelected?.Invoke();
        }
#endif
    }
}