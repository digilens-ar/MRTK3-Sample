// Copyright (c) Mixed Reality Toolkit Contributors
// Licensed under the BSD 3-Clause

using System;
using UnityEngine;

namespace MixedReality.Toolkit
{
    /// <summary>
    /// An interface indicating that this interactor belongs to an GameObject that is governed by the
    /// interaction mode manager. This GameObject represents the 'controller' that this interactor belongs to.
    /// </summary>
    public interface IModeManagedInteractor
    {
        /// <summary>
        /// Returns the GameObject that this interactor belongs to. This GameObject is governed by the
        /// interaction mode manager and is assigned an interaction mode. This GameObject represents the 'controller' that this interactor belongs to.
        /// </summary>
        [Obsolete("This function is obsolete and will be removed in the next major release. Use ModeManagedRoot instead.")]
        public GameObject GetModeManagedController();

        /// <summary>
        /// Returns the root management GameObject that interactor belongs to. This GameObject is governed by the
        /// interaction mode manager and is assigned an interaction mode. 
        /// </summary>
        public GameObject ModeManagedRoot { get; }
    }
}
