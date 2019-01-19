

local module1 = { }

function module1.method3(param)
    print("method 3")
    local y = 10 + param;
    return y * 2
end

return module1