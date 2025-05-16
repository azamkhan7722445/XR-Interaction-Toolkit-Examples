using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace UnityEngine.XR.Content.Interaction.Analytics
{
    /// <summary>
    /// Class that connects the Socket Interactors station scene objects with their respective analytics events.
    /// </summary>
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    class XrcSocketInteractorsStationAnalytics : MonoBehaviour
    {
        [Header("Socket Simple Object Substation")]
        [SerializeField]
        XRSocketInteractor m_SimpleSocket; // Reference to the simple socket interactor

        [Header("Perler Machine")]
        [SerializeField]
        XRSocketInteractor m_BatterySlotSocket; // Reference to the battery slot socket interactor

        [SerializeField]
        XRSocketInteractor[] m_InfinityPegSockets; // Array of infinity peg socket interactors

        [SerializeField]
        Transform m_GridCenter; // Reference to the grid center transform

        void Start()
        {
            // Register analytics events for the simple socket (connect/disconnect)
            XrcAnalyticsUtils.Register(m_SimpleSocket, new ConnectSocketSimpleObject(), new DisconnectSocketSimpleObject());

            // Register analytics event for connecting the battery slot socket
            XrcAnalyticsUtils.Register(m_BatterySlotSocket, new ConnectPerlerMachineBattery());

            // Create analytics parameter for grabbing a perler bead
            var grabPerlerBeadParameter = new GrabPerlerBead();

            // Register analytics for each infinity peg socket and its currently selected interactables
            foreach (var socket in m_InfinityPegSockets)
            {
                // Register analytics for interactables already selected in the socket
                foreach (var interactable in socket.interactablesSelected)
                {
                    XrcAnalyticsUtils.Register(interactable as XRBaseInteractable, grabPerlerBeadParameter);
                }

                // Register analytics when a new interactable is selected in the socket
                socket.selectEntered.AddListener(args => XrcAnalyticsUtils.Register(args.interactableObject as XRBaseInteractable, grabPerlerBeadParameter));
            }

            // Create analytics parameter for connecting a perler bead
            var connectPerlerBeadParameter = new ConnectPerlerBead();

            // Register analytics for all socket interactors that are children of the grid center
            foreach (var gridSocket in m_GridCenter.GetComponentsInChildren<XRSocketInteractor>())
                XrcAnalyticsUtils.Register(gridSocket, connectPerlerBeadParameter);
        }
    }
}
