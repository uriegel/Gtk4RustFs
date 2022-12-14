use std::slice::from_raw_parts_mut;

use libc::malloc;

unsafe fn get_string_ptr(str: &str) -> *mut u8 {
    let bytes = str.as_bytes();
    let len = bytes.len();
    let ptr = malloc(len + 1) as *mut u8;
    let slice0 = from_raw_parts_mut(ptr, len + 1);        
    slice0[len] = 0;
    let slice = from_raw_parts_mut(ptr, len);        
    slice.copy_from_slice(bytes);
    ptr
}


#[no_mangle]
pub extern fn add_numbers(a: i32, b: i32) -> i32 {
    println!("Hello from rust!");
    a + b
}

#[no_mangle]
pub extern fn get_name() -> *mut u8 {
    let string = "Hello from Rustππππ";
    unsafe {
        get_string_ptr(string)
    }
}

#[no_mangle]
pub extern fn call_back(func: unsafe extern "C" fn(*const u8, i32)) {
    println!("Before calling F# back");
    unsafe {
        let text = "Callback from Rustππππ";
        let bytes = text.as_bytes();
        func(bytes.as_ptr(), bytes.len() as i32);
    }
    println!("After calling F# back");
}
