
#-*- encoding:utf-8 -*-
__date__ = '17/04/21'
'''
CV_INTER_NN - nearest neighbor interpolation,  
CV_INTER_LINEAR - Bilinear interpolation (default)  
CV_INTER_AREA - Resample using pixel relations. This method prevents ripples from appearing when the image is zoomed out. When the image is zoomed in, it is similar to the CV_INTER_NN method:  
CV_INTER_CUBIC - Cubic interpolation
'''
 
import os, codecs
import cv2
import numpy as np
from sklearn.cluster import KMeans
 
def get_file_name(path):
	'''
	Args: path to list;  Returns: path with filenames
	'''
	filenames = os.listdir(path)
	path_filenames = []
	filename_list = []
	for file in filenames:
		if not file.startswith('.'):
			path_filenames.append(os.path.join(path, file))
			filename_list.append(file)
 
	return path_filenames
 
def knn_detect(file_list, cluster_nums, randomState = None):
	features = []
	files = file_list
	sift = cv2.SIFT()
	for file in files:
		print(file)
		img = cv2.imread(file)
		img = cv2.resize(img, (32, 32), interpolation=cv2.INTER_CUBIC)
		
		gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
		print(gray.dtype)
		_, des = sift.detectAndCompute(gray, None)
		
		if des is None:
			file_list.remove(file)
			continue
 
		reshape_feature = des.reshape(-1, 1)
		features.append(reshape_feature[0].tolist())
 
	input_x = np.array(features)
 
	kmeans = KMeans(n_clusters = cluster_nums, random_state = randomState).fit(input_x)
	
	return kmeans.labels_, kmeans.cluster_centers_
 
def res_fit(filenames, labels):
	
	files = [file.split('/')[-1] for file in filenames]
 
	return dict(zip(files, labels))
 
def save(path, filename, data):
	file = os.path.join(path, filename)
	with codecs.open(file, 'w', encoding = 'utf-8') as fw:
		for f, l in data.items():
			fw.write("{}\t{}\n".format(f, l))
 
def main():
	path_filenames = get_file_name("./picture/")
 
	labels, cluster_centers = knn_detect(path_filenames, 2)
 
	res_dict = res_fit(path_filenames, labels)
	save('./', 'knn_res.txt', res_dict)
 
if __name__ == "__main__":
	main()