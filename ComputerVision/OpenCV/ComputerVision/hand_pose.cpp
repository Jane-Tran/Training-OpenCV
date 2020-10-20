#include<opencv2/dnn.hpp>
#include<opencv2/imgproc.hpp>
#include<opencv2/highgui.hpp>
#include<iostream>

using namespace std;
using namespace cv;
using namespace cv::dnn;

const int POSE_PAIRS[20][2] =
{
	{0,1}, {1,2}, {2,3}, {3,4},			//        8   12  16  20
	{0,5}, {5,6}, {6,7}, {7,8},			//        |   |   |   |
	{0,9}, {9,10}, {10,11}, {11,12},	//        7   11  15  19
	{0,13}, {13,14}, {14,15}, {15,16},	//    4   |   |   |   |
	{0,17}, {17,18}, {18,19}, {19,20}	//    |   6   10  14  18
										//    3   |   |   |   |
										//    |   5---9---13--17
										//    2    \         /
										//     \    \       /
										//      1    \     /
										//       \    \   /
										//        ------0-
};

string protoFile = "hand/pose_deploy.prototxt";
string wieghtFile = "hand/pose_iter_102000.caffemodel";

int nPoint = 22;

int main(int argc, char **argv) 
{
	float thresh = 0.01;

	cv::VideoCapture cap(0);

	if (!cap.isOpened())
	{
		cerr << "Unable to connect to camera" << endl;
		return 1;
	}
}