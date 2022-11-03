#[no_mangle]
pub extern fn add_numbers(a: i32, b: i32) -> i32 {
    println!("Hello from rust!");
    a + b
}