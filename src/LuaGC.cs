using System;
using System.Collections.Generic;
using System.Text;

namespace KeraLua
{
    /// <summary>
    /// Garbage Collector operations
    /// </summary>
    public enum LuaGC
    {
        /// <summary>
        ///  Stops the garbage collector. 
        /// </summary>
        Stop = 0,
        /// <summary>
        /// Restarts the garbage collector. 
        /// </summary>
        Restart = 1,
        /// <summary>
        /// Performs a full garbage-collection cycle. 
        /// </summary>
        Collect = 2,
        /// <summary>
        ///  Returns the current amount of memory (in Kbytes) in use by Lua. 
        /// </summary>
        Count = 3,
        /// <summary>
        ///  Returns the remainder of dividing the current amount of bytes of memory in use by Lua by 1024
        /// </summary>
        Countb = 4,
        /// <summary>
        ///  Performs an incremental step of garbage collection. 
        /// </summary>
        Step = 5,
        /// <summary>
        /// Sets data as the new value for the pause of the collector (see §2.5) and returns the previous value
        /// </summary>
        SetPause = 6,
        /// <summary>
        /// sets data as the new value for the step multiplier of the collector
        /// </summary>
        SetStepMultiplier = 7,
        /// <summary>
        ///  returns a boolean that tells whether the collector is running
        /// </summary>
        IsRunning = 9,
    }
}
