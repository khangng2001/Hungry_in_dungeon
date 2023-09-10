#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Ink.Editor.Tools.Ink_Inspector {
	public abstract class DefaultAssetInspector {
		// Reference to the actual editor we draw to
		public UnityEditor.Editor editor;
		// Shortcut to the target object
		public Object target;
		// Shortcut to the serializedObject
		public SerializedObject serializedObject;

		public abstract bool IsValid(string assetPath);
		public virtual void OnEnable () {}
		public virtual void OnDisable () {}
		public virtual void OnHeaderGUI () {}
		public virtual void OnInspectorGUI() {}
	}
}