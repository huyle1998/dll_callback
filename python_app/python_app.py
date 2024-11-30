
import ctypes
import os

# Load the DLL
dll_path = os.path.abspath("dll_callback.dll")
dll = ctypes.CDLL(dll_path)

# Define the callback function type
CALLBACK = ctypes.CFUNCTYPE(None, ctypes.c_int)

# Define the callback function
def my_callback(value):
    print(f"Callback received value: {value}")

# Convert the Python callback function to a C callback
c_callback = CALLBACK(my_callback)

# Initialize the DLL with the callback
dll.init(c_callback)

# Call the add function
result_add = dll.add(5, 3)
print(f"Result of add: {result_add}")

# Call the sub function
result_sub = dll.sub(5, 3)
print(f"Result of sub: {result_sub}")
