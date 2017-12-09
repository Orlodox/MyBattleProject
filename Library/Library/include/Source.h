#ifdef EXPORTS
#define API _declspec(dllexport)
#else
#define API _declspec(dllimport)
#endif

extern "C" {
	API float RandomAngle(); 
}
