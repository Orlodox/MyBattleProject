#ifdef EXPORTS
#define API _declspec(dllexport)
#else
#define API _declspec(dllimport)
#endif

extern "C" {
	float Random(float min, float max);
	API float RandomAngle();
	// Install-Package rxcpp -Version 4.0.0
}
