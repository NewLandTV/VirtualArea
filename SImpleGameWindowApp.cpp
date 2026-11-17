#include <stdio.h>
#include <Windows.h>
#include <gdiplus.h>

#pragma comment(lib, "gdiplus.lib")

// Global variables
const char* className = "SimpleGameWindowApp";

ULONG_PTR ptr;
HINSTANCE gInstance;

// Functions
LRESULT CALLBACK WindowProcedure(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);

void RenderImage(HWND hWnd, HDC hdc, const wchar_t* filepath, int x, int y, int width, int height);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR args, int nCmdShow)
{
	// Gdi+ setup
	Gdiplus::GdiplusStartupInput in;

	Gdiplus::GdiplusStartup(&ptr, &in, NULL);
	
	// Window setup
	HWND hWnd;
	MSG message;
	WNDCLASSEXA wndClassEx;
	
	gInstance = hInstance;
	
	wndClassEx.hInstance = hInstance;
	wndClassEx.lpszClassName = className;
	wndClassEx.lpfnWndProc = WindowProcedure;
	wndClassEx.style = CS_DBLCLKS;
	wndClassEx.cbSize = sizeof(WNDCLASSEX);
	wndClassEx.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wndClassEx.hIconSm = LoadIcon(NULL, IDI_APPLICATION);
	wndClassEx.hCursor = LoadCursor(NULL, IDC_ARROW);
	wndClassEx.lpszMenuName = NULL;
	wndClassEx.cbClsExtra = 0;
	wndClassEx.cbWndExtra = 0;
	wndClassEx.hbrBackground = (HBRUSH)GetStockObject(DKGRAY_BRUSH);
	
	if (!RegisterClassEx(&wndClassEx))
	{
		return 0;
	}
	
	hWnd = CreateWindowEx(0, className, "Simple Game", WS_CAPTION | WS_SYSMENU, CW_USEDEFAULT, CW_USEDEFAULT, 960, 540, HWND_DESKTOP, NULL, hInstance, NULL);
	
	ShowWindow(hWnd, nCmdShow);
	
	while (GetMessage(&message, NULL, 0, 0))
	{
		TranslateMessage(&message);
		
		DispatchMessage(&message);
	}
	
	return message.wParam;
}

LRESULT CALLBACK WindowProcedure(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	// Variables
	static unsigned int score = 0;
	static unsigned int width = 128;
	static unsigned int height = 128;
	
	HDC hdc;
	PAINTSTRUCT paintStruct;
	
	switch (message)
	{
	case WM_CREATE:
		CreateWindow(TEXT("button"), TEXT(""), WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON, 370, 480, 220, 60, hWnd, (HMENU)0, gInstance, NULL);
		
		break;
	case WM_COMMAND:
		if (LOWORD(wParam) == 0)
		{
			score++;
			
			InvalidateRect(hWnd, NULL, TRUE);
			
			if (score % 10 == 0)
			{
				width += 16;
				height += 16;
			}
			if (score % 250 == 0)
			{
				width = 128;
				height = 128;
			}
		}
		
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &paintStruct);
		
		char scoreText[11];
		
		sprintf(scoreText, "%u", score);
		TextOut(hdc, 470, 0, TEXT(scoreText), strlen(scoreText));
		RenderImage(hWnd, hdc, L"E:\\Programming\\Projects\\Unity\\Game\\GrowingTown\\Assets\\Images\\Food\\Potato.png", 160, 100, width, height);
		EndPaint(hWnd, &paintStruct);
		
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		Gdiplus::GdiplusShutdown(ptr);
		
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	
	return 0;
}

void RenderImage(HWND hWnd, HDC hdc, const wchar_t* filepath, int x, int y, int width, int height)
{
	Gdiplus::Image image(filepath);
	Gdiplus::Rect rect(x, y, width, height);
	
	if (image.GetLastStatus() != Gdiplus::Ok)
	{
		return;
	}
	
	Gdiplus::Graphics graphics(hdc);
	
	graphics.DrawImage(&image, rect);
}
