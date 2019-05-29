#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/ml/ml.hpp>
#include<iostream>
#include<fstream>
#include <sstream>
#include <string>

using namespace cv;
using namespace std;

int main()
{

	ifstream reader;
	string fromFile;
	float arm_train[410][40];
	float arm_label[410];
	float kick_train[410][40];
	float kick_label[410];
	float mosh_train[410][40];
	float mosh_label[410];
	float play_train[410][40];
	float play_label[410];
	float stand_train[410][40];
	float stand_label[410];
	int i = 0;
	int a = 0;
	int b = 0;
	while (i<750)
	{
		string y = "C:/Users/elliot/Documents/Visual Studio 2015/Projects/opencv8/opencv8/training/arm/skeleton";
		y += std::to_string(i);
		y += ".csv";
		//couts the first element of each file (with comma on the end)
		reader.open(y);
		if (reader.good())
		{
			while (!reader.eof())
			{
				reader >> fromFile;
				if (reader.eof())break;
				//cout<<fromFile; 
				arm_train[a][b] = stof(fromFile);
				kick_train[a][b] = stof(fromFile);
				mosh_train[a][b] = stof(fromFile);
				play_train[a][b] = stof(fromFile);
				stand_train[a][b] = stof(fromFile);
				//cout<<train[a][b]<<endl;
				b++;
			}
			reader.close();
			arm_label[a] = 1.0;
			kick_label[a] = -1.0;
			mosh_label[a] = -1.0;
			play_label[a] = -1.0;
			stand_label[a] = -1.0;
			i++;
			a++;
			b = 0;
		}
		else i++;
	}
	i = 0;

	while (i<750)
	{
		string y = "C:/Users/elliot/Documents/Visual Studio 2015/Projects/opencv8/opencv8/training/kick/skeleton";
		y += std::to_string(i);
		y += ".csv";
		//couts the first element of each file (with comma on the end)
		reader.open(y);
		if (reader.good())
		{
			while (!reader.eof())
			{
				reader >> fromFile;
				if (reader.eof())break;
				//cout<<fromFile; 
				arm_train[a][b] = stof(fromFile);
				kick_train[a][b] = stof(fromFile);
				mosh_train[a][b] = stof(fromFile);
				play_train[a][b] = stof(fromFile);
				stand_train[a][b] = stof(fromFile);
				//cout<<train[a][b]<<endl;
				b++;
			}
			reader.close();
			arm_label[a] = -1.0;
			kick_label[a] = 1.0;
			mosh_label[a] = -1.0;
			play_label[a] = -1.0;
			stand_label[a] = -1.0;
			i++;
			a++;
			b = 0;
		}
		else i++;
	}
	i = 0;

	while (i<750)
	{
		string y = "C:/Users/elliot/Documents/Visual Studio 2015/Projects/opencv8/opencv8/training/mosh/skeleton";
		y += std::to_string(i);
		y += ".csv";
		//couts the first element of each file (with comma on the end)
		reader.open(y);
		if (reader.good())
		{
			while (!reader.eof())
			{
				reader >> fromFile;
				if (reader.eof())break;
				//cout<<fromFile; 
				arm_train[a][b] = stof(fromFile);
				kick_train[a][b] = stof(fromFile);
				mosh_train[a][b] = stof(fromFile);
				play_train[a][b] = stof(fromFile);
				stand_train[a][b] = stof(fromFile);
				//cout<<train[a][b]<<endl;
				b++;
			}
			reader.close();
			arm_label[a] = -1.0;
			kick_label[a] = -1.0;
			mosh_label[a] = 1.0;
			play_label[a] = -1.0;
			stand_label[a] = -1.0;
			i++;
			a++;
			b = 0;
		}
		else i++;
	}
	i = 0;

	while (i<750)
	{
		string y = "C:/Users/elliot/Documents/Visual Studio 2015/Projects/opencv8/opencv8/training/play/skeleton";
		y += std::to_string(i);
		y += ".csv";
		//couts the first element of each file (with comma on the end)
		reader.open(y);
		if (reader.good())
		{
			while (!reader.eof())
			{
				reader >> fromFile;
				if (reader.eof())break;
				//cout<<fromFile; 
				arm_train[a][b] = stof(fromFile);
				kick_train[a][b] = stof(fromFile);
				mosh_train[a][b] = stof(fromFile);
				play_train[a][b] = stof(fromFile);
				stand_train[a][b] = stof(fromFile);
				//cout<<train[a][b]<<endl;
				b++;
			}
			reader.close();
			arm_label[a] = -1.0;
			kick_label[a] = -1.0;
			mosh_label[a] = -1.0;
			play_label[a] = 1.0;
			stand_label[a] = -1.0;
			i++;
			a++;
			b = 0;
		}
		else i++;
	}
	i = 0;

	while (i<750)
	{
		string y = "C:/Users/elliot/Documents/Visual Studio 2015/Projects/opencv8/opencv8/training/stand/skeleton";
		y += std::to_string(i);
		y += ".csv";
		//couts the first element of each file (with comma on the end)
		reader.open(y);
		if (reader.good())
		{
			while (!reader.eof())
			{
				reader >> fromFile;
				if (reader.eof())break;
				//cout<<fromFile; 
				arm_train[a][b] = stof(fromFile);
				kick_train[a][b] = stof(fromFile);
				mosh_train[a][b] = stof(fromFile);
				play_train[a][b] = stof(fromFile);
				stand_train[a][b] = stof(fromFile);
				//cout<<train[a][b]<<endl;
				b++;
			}
			reader.close();
			arm_label[a] = -1.0;
			kick_label[a] = -1.0;
			mosh_label[a] = -1.0;
			play_label[a] = -1.0;
			stand_label[a] = 1.0;
			i++;
			a++;
			b = 0;
		}
		else i++;
	}
	i = 0;

	// Set up training data
	Mat arm_labelsMat(409, 1, CV_32FC1, arm_label);
	Mat arm_trainingDataMat(409, 40, CV_32FC1, arm_train);
	Mat kick_labelsMat(409, 1, CV_32FC1, kick_label);
	Mat kick_trainingDataMat(409, 40, CV_32FC1, kick_train);
	Mat mosh_labelsMat(409, 1, CV_32FC1, mosh_label);
	Mat mosh_trainingDataMat(409, 40, CV_32FC1, mosh_train);
	Mat play_labelsMat(409, 1, CV_32FC1, play_label);
	Mat play_trainingDataMat(409, 40, CV_32FC1, play_train);
	Mat stand_labelsMat(409, 1, CV_32FC1, stand_label);
	Mat stand_trainingDataMat(409, 40, CV_32FC1, stand_train);

	// Set up SVM's parameters
	CvSVMParams params;
	params.svm_type = CvSVM::C_SVC;
	params.kernel_type = CvSVM::LINEAR;
	params.term_crit = cvTermCriteria(CV_TERMCRIT_ITER, 100, 1e-6);

	// Train the SVM
	CvSVM arm_SVM;
	arm_SVM.train_auto(arm_trainingDataMat, arm_labelsMat, Mat(), Mat(), params);
	CvSVM kick_SVM;
	kick_SVM.train_auto(kick_trainingDataMat, kick_labelsMat, Mat(), Mat(), params);
	CvSVM mosh_SVM;
	mosh_SVM.train_auto(mosh_trainingDataMat, mosh_labelsMat, Mat(), Mat(), params);
	CvSVM play_SVM;
	play_SVM.train_auto(play_trainingDataMat, play_labelsMat, Mat(), Mat(), params);
	CvSVM stand_SVM;
	stand_SVM.train_auto(stand_trainingDataMat, stand_labelsMat, Mat(), Mat(), params);

	float testdata[40];
	int e = 0;
	reader.open("C:/Users/elliot/Documents/Visual Studio 2015/Projects/opencv8/opencv8/currentframe.csv");
	while (!reader.eof())
	{
		reader >> fromFile;
		if (reader.eof())break;
		testdata[e] = stof(fromFile);
		e++;
	}
	reader.close();

	cv::Mat testDataMat(40, 1, CV_32FC1, testdata);
	//circle(image, cv::Point(500, 50), 5, cv::Scalar(0, 0, 255), thickness, lineType);
	float arm_prediction = arm_SVM.predict(testDataMat);
	float kick_prediction = kick_SVM.predict(testDataMat);
	float mosh_prediction = mosh_SVM.predict(testDataMat);
	float play_prediction = play_SVM.predict(testDataMat);
	float stand_prediction = stand_SVM.predict(testDataMat);

	if (arm_prediction == 1)cout << "arm" << endl;
	if (kick_prediction == 1)cout << "kick" << endl;
	if (mosh_prediction == 1)cout << "mosh" << endl;
	if (play_prediction == 1)cout << "play" << endl;
	if (stand_prediction == 1)cout << "stand" << endl;

	std::cin.ignore();

	waitKey(0);
}
