#define _USE_MATH_DEFINES
#include "rx.hpp"
#include "rx-lite.hpp"
#include "operators/rx-take.hpp"
#include "rx-coroutine.hpp"
#include <Source.h>
#include <stdlib.h>
#include <cmath>  

namespace Rx {
	using namespace rxcpp;
	using namespace rxcpp::sources;
	using namespace rxcpp::operators;
	using namespace rxcpp::util;
}
using namespace Rx; 


float Random(float min, float max) {

	float res;

	auto period = std::chrono::milliseconds(50);
	auto values = timer(period);
	values.subscribe(
		[](int v) {},
		[]() {});

	res = (float)((rand()) / RAND_MAX*(max - min) + min);
	return res;
}

float RandomAngle() {
	return Random(0, 2*M_PI);
	}
