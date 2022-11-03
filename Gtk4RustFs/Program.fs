open System.Runtime.InteropServices

[<DllImport("../../../../target/debug/librust.so", SetLastError = true, EntryPoint="add_numbers")>]
extern int addNumbers(int a, int b)
[<DllImport("../../../../target/debug/librust.so", SetLastError = true, EntryPoint="get_name")>]
extern nativeint getName()
[<DllImport ("libc.so.6")>]
 extern void free(nativeint ptr)

let fromPtr (ptr: nativeint) = 
    let str = Marshal.PtrToStringUTF8 ptr
    free ptr
    str

printfn "Hello from F#"
printfn "addNumbers: %d" <| addNumbers (12, 99)
printfn "getString: %s" <| (fromPtr <| getName ())




