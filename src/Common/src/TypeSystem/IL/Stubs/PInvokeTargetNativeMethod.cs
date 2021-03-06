// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

using Internal.TypeSystem;
using Internal.TypeSystem.Interop;
using Debug = System.Diagnostics.Debug;
using Internal.TypeSystem.Ecma;

namespace Internal.IL.Stubs
{
    /// <summary>
    /// Synthetic method that represents the actual PInvoke target method.
    /// All parameters are simple types. There will be no code
    /// generated for this method. Instead, a static reference to a symbol will be emitted.
    /// </summary>
    public sealed partial class PInvokeTargetNativeMethod : MethodDesc
    {
        private readonly MethodDesc _declMethod;
        private readonly MethodSignature _signature;
        
        public PInvokeTargetNativeMethod(MethodDesc declMethod, MethodSignature signature)
        {
            _declMethod = declMethod;
            _signature = signature;
        }

        public override TypeSystemContext Context
        {
            get
            {
                return _declMethod.Context;
            }
        }

        public override TypeDesc OwningType
        {
            get
            {
                return _declMethod.OwningType;
            }
        }

        public override MethodSignature Signature
        {
            get
            {
                return _signature;
            }
        }

        public override string Name
        {
            get
            {
                return _declMethod.Name;
            }
        }

        public override bool HasCustomAttribute(string attributeNamespace, string attributeName)
        {
            return false;
        }

        public override bool IsPInvoke
        {
            get
            {
                return true;
            }
        }

        public override PInvokeMetadata GetPInvokeMethodMetadata()
        {
            return _declMethod.GetPInvokeMethodMetadata();
        }

        public override string ToString()
        {
            return "[EXTERNAL]" + Name;
        }
    }
}
