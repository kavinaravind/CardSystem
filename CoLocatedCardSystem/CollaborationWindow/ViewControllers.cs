using CoLocatedCardSystem.CollaborationWindow.InteractionModule;
using CoLocatedCardSystem.CollaborationWindow.Layers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace CoLocatedCardSystem.CollaborationWindow
{
    public class ViewControllers
    {
        InteractionControllers interactionControllers;
        BaseLayerController baseLayerController;
        CardLayerController cardLayerController;
        LinkingLayerController linkingLayerController;
        MenuLayerController menuLayerController;
        SortingBoxLayerController sortingBoxLayerController;

        public InteractionControllers InteractionControllers
        {
            get
            {
                return interactionControllers;
            }
        }

        internal BaseLayerController BaseLayerController
        {
            get
            {
                return baseLayerController;
            }
        }

        internal CardLayerController CardLayerController
        {
            get
            {
                return cardLayerController;
            }
        }

        internal LinkingLayerController LinkingLayerController
        {
            get
            {
                return linkingLayerController;
            }
        }

        internal MenuLayerController MenuLayerController
        {
            get
            {
                return menuLayerController;
            }
        }
        internal SortingBoxLayerController SortingBoxLayerController
        {
            get
            {
                return sortingBoxLayerController;
            }
        }
        /// <summary>
        /// Initialize the views, including different layers.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="interactionControllers"></param>
        public void Init(int width, int height, InteractionControllers interactionControllers)
        {
            this.interactionControllers = interactionControllers;

            baseLayerController = new BaseLayerController(this);
            baseLayerController.Init(width, height);
            Coordination.Baselayer = baseLayerController.BaseLayer;//Set the base layer to the coordination helper

            cardLayerController = new CardLayerController(this);
            cardLayerController.Init(width, height);

            sortingBoxLayerController = new SortingBoxLayerController(this);
            sortingBoxLayerController.Init(width, height);

            menuLayerController = new MenuLayerController(this);
            menuLayerController.Init(width, height);

        }


        public void Deinit()
        {
            baseLayerController.Deinit();
            baseLayerController = null;

            cardLayerController.Deinit();
            cardLayerController = null;

            sortingBoxLayerController.Deinit();
            sortingBoxLayerController = null;

            menuLayerController.Deinit();
            menuLayerController = null;
        }
        /// <summary>
        /// Create a sorting box
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="content"></param>
        internal void CreateSortingBox(User owner, string content)
        {
            interactionControllers.SortingBoxController.CreateSortingBox(content, owner);
        }
        /// <summary>
        /// Pass the touch point to the interaction controller
        /// </summary>
        /// <param name="localPoint"></param>
        /// <param name="globalPoint"></param>
        /// <param name="baseLayer"></param>
        /// <param name="type"></param>
        internal void OnTouchDown(PointerPoint localPoint, PointerPoint globalPoint, object baseLayer, Type type)
        {
            interactionControllers.TouchController.TouchDown(localPoint, globalPoint, baseLayer, type);
        }

        internal void OnTouchMove(PointerPoint localPoint, PointerPoint globalPoint)
        {
            interactionControllers.TouchController.TouchMove(localPoint, globalPoint);
        }

        internal void OnTouchUp(PointerPoint localPoint, PointerPoint globalPoint)
        {
            interactionControllers.TouchController.TouchUp(localPoint, globalPoint);
        }
    }
}
