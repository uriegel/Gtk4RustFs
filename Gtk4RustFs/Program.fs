open System.Runtime.InteropServices

[<DllImport("../../../../target/debug/librust.so", SetLastError = true, CharSet=CharSet.Auto)>]
extern int add_numbers(int a, int b)

printfn "Hello from F#"
printfn "addNumbers: %d" <| add_numbers (12, 99)



