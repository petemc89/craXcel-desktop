using System;
using System.Collections.Generic;
using System.Text;

namespace CraxcelLibrary
{
    /// <summary>
    /// Contains the options set by the user, which should be changeable via whatever UI is implemented.
    /// </summary>
    public static class UserOptions
    {
        //TO-DO : If number of applications grow it may be a good idea to encapsulate options into groups (i.e. MicrosoftOfficeOptions)

        /// <summary>
        /// Bool that controls whether VBA Projects are unlocked for MicrosoftOffice applications.
        /// </summary>
        public static bool UnlockVBA { get; set; } = true;
    }
}
