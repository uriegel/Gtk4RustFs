open System
open System.Runtime.InteropServices

[<DllImport ("libc.so.6")>]
extern void free(nativeint ptr)
[<DllImport("../../../../target/debug/librust.so", SetLastError = true, EntryPoint="add_numbers")>]
extern int addNumbers(int a, int b)
[<DllImport("../../../../target/debug/librust.so", SetLastError = true, EntryPoint="get_name")>]
extern nativeint getName()

type CallbackDelegate = delegate of int -> unit

[<DllImport("../../../../target/debug/librust.so", SetLastError = true, EntryPoint="call_back")>]
extern void callBack(CallbackDelegate cb) 

let fromPtr (ptr: nativeint) = 
    let str = Marshal.PtrToStringUTF8 ptr
    free ptr
    str

printfn "Hello from F#"
printfn "addNumbers: %d" <| addNumbers (12, 99)
printfn "getString: %s" <| (fromPtr <| getName ())
let cb = fun i -> printfn "Callback from rust: %d" i
callBack(cb)
printfn "Finished"




