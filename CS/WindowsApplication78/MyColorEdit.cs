using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Popup;
using System.Drawing;
using System.Collections;

namespace CustomEditors
{
    [UserRepositoryItem("Register")]
    public class RepositoryItemMyColorEdit : RepositoryItemColorEdit
    {
        static RepositoryItemMyColorEdit()
        {
            Register();
        }
        public RepositoryItemMyColorEdit() { }

        internal const string EditorName = "MyColorEdit";

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(MyColorEdit),
                typeof(RepositoryItemMyColorEdit), typeof(DevExpress.XtraEditors.ViewInfo.ColorEditViewInfo),
                new DevExpress.XtraEditors.Drawing.ColorEditPainter(), true, null));
        }
        public override string EditorTypeName
        {
            get { return EditorName; }
        }

        protected override string GetColorDisplayText(Color editValue)
        {
            object color = editValue;
            ColorHelper.TryConvertToKnownColor(ref color);
            return base.GetColorDisplayText((Color)color);
        }
    }

    class ColorHelper
    {
        static ColorHelper()
        {
            knownColorsHash = InitKnownColorsHash();
        }
        private ColorHelper() { }

        private static Hashtable knownColorsHash;

        private static Hashtable InitKnownColorsHash()
        {
            System.Array knownColors = System.Enum.GetValues(typeof(KnownColor));
            Hashtable hashtable = new Hashtable(knownColors.Length);
            foreach (KnownColor knownColorObject in knownColors)
            {
                Color color = Color.FromKnownColor(knownColorObject);
                int argbValue = color.ToArgb();
                if (color.IsSystemColor && hashtable.ContainsKey(argbValue))
                    continue;
                hashtable[argbValue] = knownColorObject;
            }
            return hashtable;
        }

        public static bool TryConvertToKnownColor(ref object color)
        {
            KnownColor knownColor = GetKnownColor(color);
            if (knownColor != 0)
            {
                color = Color.FromKnownColor(knownColor);
                return true;
            }
            return false;
        }

        public static KnownColor GetKnownColor(Color color)
        {
            KnownColor knownColor = color.ToKnownColor();
            if (knownColor == 0)
                knownColor = GetKnownColor(color.ToArgb());
            return knownColor;
        }
        public static KnownColor GetKnownColor(int argb)
        {
            object result = knownColorsHash[argb];
            if (result == null)
                return 0;
            return (KnownColor)result;
        }

        public static KnownColor GetKnownColor(object color)
        {
            if (color is KnownColor)
                return (KnownColor)color;
            if (color is Color)
                return GetKnownColor((Color)color);
            if (color is int)
                return GetKnownColor((int)color);
            return 0;
        }
    }

    public class MyColorEdit : ColorEdit
    {
        static MyColorEdit()
        {
            RepositoryItemMyColorEdit.Register();
        }
        public MyColorEdit() { }

        public override string EditorTypeName
        {
            get { return RepositoryItemMyColorEdit.EditorName; }
        }
    }
}

