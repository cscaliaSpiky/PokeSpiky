    using UnityEngine;

    public class DebugLocalCamera : MonoBehaviour
    {
        public static DebugLocalCamera Instance;

        public Camera TargetCamera
        {
            get { return this.camera; }
        }

        [SerializeField]
        private Camera camera;

        private Vector3 originalPos;
        private Vector3 originalRotation;
        private float originalFov;

        private void Start()
        {
            Instance = this;
            this.UpdateCamera();
            DebugGeneric.Instance.OnMainPositionChanged += this.OnMainPositionChangedHandler;
            DebugGeneric.Instance.OnMainRotationChanged += this.OnMainRotationChangedHandler;
            DebugGeneric.Instance.OnMainFOVChanged += this.OnMainFovChangedHandler;

            this.TargetCamera.transform.localPosition = this.originalPos + DebugGeneric.Instance.MainCameraOffsetPosition;
            this.TargetCamera.transform.localRotation = Quaternion.Euler(this.originalRotation + DebugGeneric.Instance.MainCameraOffsetRotation);
            this.TargetCamera.fieldOfView = this.originalFov + DebugGeneric.Instance.MainCameraOffsetFOV;
        }

        private void UpdateCamera()
        {
            this.originalFov = this.TargetCamera.fieldOfView;
            this.originalRotation = this.TargetCamera.transform.eulerAngles;
            this.originalPos = this.TargetCamera.transform.localPosition;
        }

        private void OnMainPositionChangedHandler(Vector3 position)
        {
            this.TargetCamera.transform.localPosition = this.originalPos + position;
        }

        private void OnMainRotationChangedHandler(Vector3 euler)
        {
            this.TargetCamera.transform.rotation = Quaternion.Euler(this.originalRotation + euler);
        }

        private void OnMainFovChangedHandler(float offset)
        {
            this.TargetCamera.fieldOfView = this.originalFov + offset;
        }
    }
