using System;
using System.Runtime.InteropServices;

class DLLInterface
{
    public const string DLL_IMPORT = "dll_callback";
    [DllImportAttribute(DLL_IMPORT, EntryPoint = "add", CallingConvention = CallingConvention.Cdecl)]
    public static extern int add(int a, int b);

    [DllImportAttribute(DLL_IMPORT, EntryPoint = "sub", CallingConvention = CallingConvention.Cdecl)]
    public static extern int sub(int a, int b);

    // Define the delegate that matches the callback signature
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CallbackDelegate(int value);
    [DllImportAttribute(DLL_IMPORT, EntryPoint = "init", CallingConvention = CallingConvention.Cdecl)]
    public static extern void init(CallbackDelegate callback);

}

class Program
{
    public static void MyCallback(int value)
    {
        Console.WriteLine("Callback received value: " + value);
    }

    public static void Main()
    {
        DLLInterface.init(MyCallback);
        Console.WriteLine("add(1, 2) = " + DLLInterface.add(1, 2));
        Console.WriteLine("sub(1, 2) = " + DLLInterface.sub(1, 2));
    }
}