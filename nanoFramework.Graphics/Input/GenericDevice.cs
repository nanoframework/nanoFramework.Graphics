//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Presentation;
using nanoFramework.Runtime.Events;

namespace nanoFramework.UI.Input
{
    /// <summary>
    /// Generic Event handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GenericEventHandler(object sender, GenericEventArgs e);

    /// <summary>
    ///  Event Args
    /// </summary>
    public class GenericEventArgs : InputEventArgs
    {
        /// <summary>
        ///  Generic Event Args
        /// </summary>
        /// <param name="inputDevice"></param>
        /// <param name="genericEvent"></param>
        public GenericEventArgs(InputDevice inputDevice, GenericEventEx genericEvent)
            : base(inputDevice, genericEvent.Time)
        {
            InternalEvent = genericEvent;
        }

        /// <summary>
        /// GenericEventEx
        /// </summary>
        public readonly GenericEventEx InternalEvent;
    }

    /// <summary>
    /// Generic Events
    /// </summary>
    public sealed class GenericEvents
    {
        /// <summary>
        /// Generic Standard Events
        /// </summary>
        public static readonly RoutedEvent GenericStandardEvent = new RoutedEvent("GenericStandardEvent", RoutingStrategy.Tunnel, typeof(GenericEventArgs));
    }

    /// <summary>
    ///     The GenericDevice class represents the Generic device to the
    ///     members of a context.
    /// </summary>
    public sealed class GenericDevice : InputDevice
    {
        internal GenericDevice(InputManager inputManager)
        {
            _inputManager = inputManager;

            _inputManager.InputDeviceEvents[(int)InputManager.InputDeviceType.Generic].PostProcessInput += new ProcessInputEventHandler(PostProcessInput);
        }

        private UIElement _focus = null;

        /// <summary>
        /// 
        /// </summary>
        public override UIElement Target
        {
            get
            {
                VerifyAccess();

                return _focus;
            }
        }

        /// <summary>
        /// SetTarget
        /// </summary>
        /// <param name="target"></param>
        public void SetTarget(UIElement target)
        {
            _focus = target;
        }

        /// <summary>
        ///  Input Manager
        /// </summary>
        public override InputManager.InputDeviceType DeviceType
        {
            get
            {
                return InputManager.InputDeviceType.Generic;
            }
        }

        private void PostProcessInput(object sender, ProcessInputEventArgs e)
        {
            InputReportEventArgs input = e.StagingItem.Input as InputReportEventArgs;
            if (input != null && input.RoutedEvent == InputManager.InputReportEvent)
            {
                RawGenericInputReport report = input.Report as RawGenericInputReport;

                if (report != null)
                {
                    if (!e.StagingItem.Input.Handled)
                    {
                        GenericEventEx ge = (GenericEventEx)report.InternalEvent;
                        GenericEventArgs args = new GenericEventArgs(
                            this,
                            report.InternalEvent);

                        args.RoutedEvent = GenericEvents.GenericStandardEvent;
                        if (report.Target != null)
                        {
                            args.Source = report.Target;
                        }

                        e.PushInput(args, e.StagingItem);
                    }
                }
            }
        }

        private InputManager _inputManager;
    }
}


