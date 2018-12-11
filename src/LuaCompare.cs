﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KeraLua
{
    /// <summary>
    /// Used by Compare
    /// </summary>
    public enum LuaCompare
    {
        /// <summary>
        ///  compares for equality (==)
        /// </summary>
        Equal = 0,
        /// <summary>
        ///  compares for less than 
        /// </summary>
        LessThen = 1,
        /// <summary>
        /// compares for less or equal 
        /// </summary>
        LessOrEqual = 2
    }
}
