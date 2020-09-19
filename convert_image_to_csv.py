# -*- coding: utf-8 -*-
"""
Created on Fri Aug  7 13:30:36 2020

@author: tvq_huy
"""

from PIL import Image 
import numpy as np
import os
import csv
import sys

fileList = []
myPath = "D:/dataset/ASL/asl_alphabet_test/asl_alphabet_test"

""" Function load original image """
def createFilsList(myDir, format = ".jpg"):
    print(myDir)
    for root, dirs, files in os.walk(myDir, topdown = False):
        for name in files:
            if name.endswith(format):
                fullName = os.path.join (root, name)
                fileList.append(fullName)
    return fileList

myFileList = createFilsList(myPath)


for file in fileList:
    print(file)
    img_file = Image.open(file)
    """get the original image parameters"""
    width, height = img_file.size
    format = img_file.format
    mode =  img_file.mode
    
    """convert image to numpy array """
    value = np.asarray(img_file.getdata(), dtype = np.int)
    value = value.flatten()
    print(value)
    with open("csv/image_csv_dataset", 'a', newline='') as f:
        writer = csv.writer(f)
        writer.writerow(value)
