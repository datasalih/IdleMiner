// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("AlaVh8htnsFNgqK0JiXfhocbeQDudHuUsDjRn9azkdoUQ2DO/dqLiMlKREt7yUpBSclKSkuOEGQC3LIa2d+G8iMmMtVVZ6GURyZ9qj0gOM95Hk5ylCkpG1v77ZiYP9OwC3Px7HvJSml7Rk1CYc0DzbxGSkpKTktIyKjiTbxBEMvugR5+QYp1epVS7kPbUqaZcfVXrAdIJ49EHvbSTrVvBsNrG9kya5IBVUrmHmt9fgqIf0G0UPG6QDALyFM9GIUA3PkhqmK9xLH0/eBUXDkvtZzgmaM6mlJHplL8S/Nq9Zf8SSY4Pma/hj4YMH7G3XeJBMttn5X9PsODHYkePq6BAEXP3NHWR10rE2MgnR1aPW7mJrNGxZUjRUWA9eOBCjxUEklISktK");
        private static int[] order = new int[] { 6,5,5,4,7,6,6,13,9,12,11,13,12,13,14 };
        private static int key = 75;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
