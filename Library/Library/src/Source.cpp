#define _USE_MATH_DEFINES
#include <Source.h>
#include <stdlib.h>
#include <cmath>  

float Random(float min, float max) {
	return (float)(rand()) / RAND_MAX*(max - min) + min;
}

float RandomAngle() {
	return Random(0, M_PI);
}