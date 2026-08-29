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
        ///  returns a boolean that tells whether the collector is running
        /// </summary>
        IsRunning = 6,
        /// <summary>
        ///  Changes the collector to generational mode with the given parameters (see §2.5.2). Returns the previous mode (LUA_GCGEN or LUA_GCINC). 
        /// </summary>
        Generational = 7,
        /// <summary>
        /// Changes the collector to incremental mode with the given parameters (see §2.5.1). Returns the previous mode (LUA_GCGEN or LUA_GCINC). 
        /// </summary>
        Incremental = 8,
        /// <summary>
        /// Changes and/or returns the value of a parameter of the collector.
        /// </summary>
        Parameter = 9,
    }

    /// <summary>
    /// Garbage Collector operations for use with <see cref="LuaGC.Parameter"/>
    /// </summary>
    public enum LuaGCParameter
    {
        /// <summary>
        /// The minor multiplier.
        /// </summary>
        MinorMultiplier = 0,
        /// <summary>
        /// The major-minor multiplier.
        /// </summary>
        MajorMinorMultiplier = 1,
        /// <summary>
        /// The minor-major multiplier.
        /// </summary>
        MinorMajorMultiplier = 2,
        /// <summary>
        /// The garbage-collector pause.
        /// </summary>
        Pause = 3,
        /// <summary>
        /// The step multiplier.
        /// </summary>
        StepMultiplier = 4,
        /// <summary>
        /// The step size.
        /// </summary>
        StepSize = 5,
    }
}
