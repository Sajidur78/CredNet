using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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

        public static ConditionalWeakTable<Bitmap, BitmapHandleStore> BitmapHandles =
            new ConditionalWeakTable<Bitmap, BitmapHandleStore>();

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

        public static IntPtr GetBitmapHandle(Bitmap map)
        {
            if (BitmapHandles.TryGetValue(map, out var store))
                return store.Handle;

            store = new BitmapHandleStore(map);
            BitmapHandles.Add(map, store);
            return store.Handle;
        }

        public static IntPtr GetBitmapHandle(Bitmap map, Color color)
        {
            if (BitmapHandles.TryGetValue(map, out var store))
                return store.Handle;

            store = new BitmapHandleStore(map, color);
            BitmapHandles.Add(map, store);
            return store.Handle;
        }
    }

    public class BitmapHandleStore
    {
        public IntPtr Handle { get; set; }

        public BitmapHandleStore(Bitmap map)
        {
            Handle = map.GetHbitmap();
        }

        public BitmapHandleStore(Bitmap map, Color color)
        {
            Handle = map.GetHbitmap(color);
        }

        ~BitmapHandleStore()
        {
            if (Handle != IntPtr.Zero)
                Native.DeleteObject(Handle);
        }
    }
}
