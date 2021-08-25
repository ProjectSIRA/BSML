using HMUI;
using IPA.Utilities;
using System;
using System.Threading.Tasks;

namespace BeatSaberMarkupLanguage
{
    /// <summary>
    /// Provides useful and common extensions when working with BSML and Beat Saber UI
    /// </summary>
    public static class BSMLExtensions
    {
        #region Flow Coordinator Extensions

        /// <summary>
        /// Presents a flow coordinator as a child of another flow coordinator.
        /// </summary>
        /// <param name="flowCoordinator">The parent flow coordinator. This should be the currently active flow coordinator</param>
        /// <param name="childFlowCoordinator">The child flow coordinator. Ususally, this is your own flow coordinator that you want to show.</param>
        /// <param name="finishedCallback">A callback for when the flow coordinator finishes activating. This is called after all the initial view controllers have transitioned.</param>
        /// <param name="animationDirection">The direction to animate it in.</param>
        /// <param name="immediately">Immmediately present the flow coordinator. This will skip the animation, but can be a bit jarring for users.</param>
        /// <param name="replaceTopViewController">Replaces the top view controller. The top view controller refers to the main one in this scenario (not the title bar).</param>
        public static void PresentFlowCoordinator(this FlowCoordinator flowCoordinator, FlowCoordinator childFlowCoordinator, Action? finishedCallback = null, ViewController.AnimationDirection animationDirection = ViewController.AnimationDirection.Horizontal, bool immediately = false, bool replaceTopViewController = false)
        {
            flowCoordinator.InvokeMethod<object, FlowCoordinator>(nameof(PresentFlowCoordinator), flowCoordinator, finishedCallback, animationDirection, immediately, replaceTopViewController);
        }

        /// <summary>
        /// Presents a flow coordinator as a child of another flow coordinator.
        /// </summary>
        /// <param name="flowCoordinator">The parent flow coordinator. This should be the currently active flow coordinator</param>
        /// <param name="childFlowCoordinator">The child flow coordinator. Ususally, this is your own flow coordinator that you want to show.</param>
        /// <param name="animationDirection">The direction to animate it in.</param>
        /// <param name="immediately">Immmediately present the flow coordinator. This will skip the animation, but can be a bit jarring for users.</param>
        /// <param name="replaceTopViewController">Replaces the top view controller. The top view controller refers to the main one in this scenario (not the title bar).</param>
        /// <returns></returns>
        public static async Task PresentFlowCoordinatorAsync(this FlowCoordinator flowCoordinator, FlowCoordinator childFlowCoordinator, ViewController.AnimationDirection animationDirection = ViewController.AnimationDirection.Horizontal, bool immediately = false, bool replaceTopViewController = false)
        {
            bool finished = false;
            PresentFlowCoordinator(flowCoordinator, childFlowCoordinator, () => finished = true, animationDirection, immediately, replaceTopViewController);
            while (!finished)
                await Task.Yield();
        }

        #endregion
    }
}