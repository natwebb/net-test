using System.Globalization;

namespace NetTest.Shared.Constants
{
    public enum AssetType
    {
        Avatar = 0,
        Other
    }

    public static class AssetTypesHelper
    {
        public static string ToTypeString(this AssetType type)
        {
            switch (type)
            {
                case AssetType.Avatar:
                    return "Avatar";
                default:
                    return "Other";
            }
        }

        public static AssetType FromTypeString(string name)
        {
            switch (name.ToUpper(CultureInfo.InvariantCulture).Replace(" ", ""))
            {
                case "AVATAR":
                case "AVATARIMAGE":
                    return AssetType.Avatar;
                default:
                    return AssetType.Other;
            }
        }
    }
}