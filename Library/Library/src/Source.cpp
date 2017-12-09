#define _USE_MATH_DEFINES
#include "rx.hpp"
namespace Rx {
	using namespace rxcpp;
	using namespace rxcpp::sources;
	using namespace rxcpp::operators;
	using namespace rxcpp::util;
}
using namespace Rx;
#include <Source.h>
#include <stdlib.h>
#include <cmath>  

float Random(float min, float max) {
	return (float)(rand()) / RAND_MAX*(max - min) + min;
	combine_latest(); // RxCpp
}

float RandomAngle() {
	return Random(0, M_PI);
}