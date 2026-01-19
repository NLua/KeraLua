namespace KeraLua
{
    /// <summary>
    /// Enum for pseudo-index used by registry table
    /// </summary>
#pragma warning disable CA1008 // Enums should have zero value
    public enum LuaRegistry
#pragma warning restore CA1008 // Enums should have zero value
    {
        /// <summary>
        /// pseudo-index used by registry table: <c>-1073742823</c>
        /// </summary>
        Index = -(int.MaxValue / 2 + 1000)
    }

    /// <summary>
    /// Registry index 
    /// </summary>
#pragma warning disable CA1008 // Enums should have zero value
    public enum LuaRegistryIndex
#pragma warning restore CA1008 // Enums should have zero value
    {
        /* index 1 is reserved for the reference mechanism */

        /// <summary>
        /// At this index the registry has the global environment. 
        /// </summary>
        Globals = 2,
        /// <summary>
        ///  At this index the registry has the main thread of the state.
        /// </summary>
        MainThread = 3
    }
}
