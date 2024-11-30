// export dll function with name "add" and "sub"

#include <iostream>
#include <Windows.h>
#include <thread>
#include <chrono>

void(*callback_)(int);

extern "C" __declspec(dllexport) int add(int a, int b) {
	std::cout << "add function from dll" << std::endl;
	callback_(a + b);
	return a + b;
}

extern "C" __declspec(dllexport) int sub(int a, int b) {
	std::cout << "sub function from dll" << std::endl;
	callback_(a - b);
	return a - b;
}

extern "C" __declspec(dllexport) void init(void(*callback)(int)) {
	callback_ = callback;
	std::cout << "took callback success" << std::endl;
}