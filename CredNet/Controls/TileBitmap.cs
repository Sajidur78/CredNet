using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredNet.Interface;
using CredNet.Interop;

namespace CredNet.Controls
{
    public class TileBitmap : FieldControl, ITileImageControl
    {
        private Color mBackground;
        private Bitmap mImage;

        public override FieldType GetFieldType() => FieldType.TileImage;

        public Bitmap Image
        {
            get => mImage;
            set
            {
                mImage = value;
                PerformCredentialOperation(events =>
                {
                    Credential.InternalCredential.GetBitmapValue(ID, out IntPtr bitmap);
                    events.SetFieldBitmap(Credential.InternalCredential, ID, bitmap);
                });

                OnPropertyChanged();
            }
        }

        public Color Background
        {
            get => mBackground;
            set
            {
                mBackground = value;
                Image = mImage;

                OnPropertyChanged();
            }
        }
    }
}
