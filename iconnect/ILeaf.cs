﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace iconnect
{
    /// <summary>Link leaf</summary>
    public interface ILeaf
    {
        /// <summary>Leaf identification</summary>
        uint Ident { get; }
        /// <summary>Leaf name</summary>
        String Name { get; }
        /// <summary>Leaf ip address</summary>
        IPAddress ExternalIP { get; }
        /// <summary>Leaf port</summary>
        ushort Port { get; }
        /// <summary>Perform action on the user collection for this leaf</summary>
        void ForEachUser(Action<IUser> action);
        /// <summary>Print to all users in this leaf</summary>
        void Print(String text);
        /// <summary>Print to all users in this leaf if they are in a vroom</summary>
        void Print(ushort vroom, String text);
        /// <summary>Print to all users in this leaf if their admin level is high enough</summary>
        void Print(ILevel level, String text);
    }
}