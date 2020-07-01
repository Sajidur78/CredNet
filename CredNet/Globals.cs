using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CredNet.Interface;

namespace CredNet
{
    internal class Globals
    {
        public static BiDictionary<uint, IControl> ControlTable = new BiDictionary<uint, IControl>();

        public static uint GetControlID(IControl control)
        {
            if (ControlTable.Backward.TryGetValue(control, out uint key))
            {
                return key;
            }

            key = unchecked((uint) RuntimeHelpers.GetHashCode(control));

            ControlTable.Add(key, control);

            return key;
        }

        public static IControl GetControlFromID(uint id)
        {
            if (ControlTable.Forward.TryGetValue(id, out var value))
                return value;
            
            return default;
        }
    }
}
