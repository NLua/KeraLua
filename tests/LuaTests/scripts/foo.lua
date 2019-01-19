
local m = require "module1"

function method1()
    local x = 10;
    print("method 1")
    m.method3(x)
end

function method2()
    local x = 10;
    print("method 1")
    method1()
end

