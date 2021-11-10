namespace KeraLua
{
    /// <summary>
    /// Enum for pseudo-index used by registry table
    /// </summary>
#pragma warning disable CA1008 // Enums should have zero value
    public enum LuaRegistry
#pragma warning restore CA1008 // Enums should have zero value
    {
        /* LUAI_MAXSTACK		1000000 */
        /// <summary>
        /// pseudo-index used by registry table
        /// </summary>
        Index = -1000000 - 1000
    }

    /// <summary>
    /// Registry index 
    /// </summary>
#pragma warning disable CA1008 // Enums should have zero value
    public enum LuaRegistryIndex
#pragma warning restore CA1008 // Enums should have zero value
    {
        /// <summary>
        ///  At this index the registry has the main thread of the state.
        /// </summary>
        MainThread = 1,
        /// <summary>
        /// At this index the registry has the global environment. 
        /// </summary>
        Globals = 2,
    }
}
