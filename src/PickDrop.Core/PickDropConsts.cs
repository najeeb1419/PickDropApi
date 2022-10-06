using PickDrop.Debugging;

namespace PickDrop
{
    public class PickDropConsts
    {
        public const string LocalizationSourceName = "PickDrop";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "fa2f74e929734e64b7ca981d04b65128";
    }
}
